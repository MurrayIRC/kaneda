using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boing {
    public enum LoopType {
        None,
        RestartFromBeginning,
        PingPong
    }

    public abstract class Tween<T> : ITweenable, ITween<T> where T : struct {
        protected enum TweenState {
            Running,
            Paused,
            Complete
        }

        protected ITweenTarget<T> target;
        protected T fromValue;
        protected T toValue;
        protected bool isFromValueOverridden;
        protected EaseType easeType;
        protected AnimationCurve animationCurve;
        protected bool shouldRecycleTween = true;
        protected bool isRelative;
        protected Action<T> updateHandler;
        protected Action<T> completionHandler;
        protected Action<T> loopCompletionHandler;
        protected Action<T> updateHandlerWithParams;
        protected Action<T> completionHandlerWithParams;
        protected Action<T> loopCompletionHandlerWithParams;
        protected System.Object[] updateParams;
        protected System.Object[] completionParams;
        protected System.Object[] loopCompletionParams;
        protected ITweenable nextTween;

        protected TweenState tweenState = TweenState.Complete;
        protected float delay;
        protected float duration;
        protected float elapsedTime;
        protected float timeScale = 1f;
        private bool isTimeScaleIndependent;

        protected LoopType loopType;
        protected int numLoops;
        protected float delayBetweenLoops;
        private bool isRunningInReverse;

        #region ITween Implementation

        public ITween<T> SetEaseType (EaseType type) {
            this.easeType = type;
            return this;
        }

        public ITween<T> SetAnimationCurve (AnimationCurve curve) {
            this.animationCurve = curve;
            return this;
        }

        public ITween<T> SetDelay (float seconds) {
            this.delay = seconds;
            this.elapsedTime = -delay;
            return this;
        }

        public ITween<T> SetDuration (float seconds) {
            this.duration = seconds;
            return this;
        }

        public ITween<T> SetTimeScale (float scale) {
            this.timeScale = scale;
            return this;
        }

        public ITween<T> SetIsTimeScaleDependent () {
            this.isTimeScaleIndependent = true;
            return this;
        }

        public ITween<T> SetUpdateHandler (Action<T> handler) {
            this.updateHandler = handler;
            return this;
        }

        public ITween<T> SetCompletionHandler (Action<T> handler) {
            this.completionHandler = handler;
            return this;
        }
        
        public ITween<T> SetLoopCompletionHandler (Action<T> handler) {
            this.loopCompletionHandler = handler;
            return this;
        }

        public ITween<T> SetLoops (LoopType type, int numLoops = 1, float delayBetweenLoops = 0) {
            this.loopType = type;
            this.delayBetweenLoops = delayBetweenLoops;
            if (loopType == LoopType.PingPong) {
                numLoops *= 2;
            }
            this.numLoops = numLoops;
            return this;
        }

        public ITween<T> SetFrom (T from) {
            this.isFromValueOverridden = true;
            this.fromValue = from;
            return this;
        }

        public ITween<T> PrepareForReuse (T from, T to, float duration) {
            Initialize(target, to, duration);
            return this;
        }

        public ITween<T> SetRecycleTween (bool shouldRecycleTween) {
            this.shouldRecycleTween = shouldRecycleTween;
            return this;
        }

        abstract public ITween<T> SetIsRelative ();

        public ITween<T> SetContext (object context) {
            this.Context = context;
            return this;
        }

        public ITween<T> SetNextTween (ITweenable nextTween) {
            this.nextTween = nextTween;
            return this;
        }

        #endregion

        #region ITweenControl Implementation

        public object Context { get; protected set; }

        public void JumpToElapsedTime (float elapsedTime) {
            elapsedTime = Mathf.Clamp(elapsedTime, 0f, duration);
            UpdateValue();
        }

        public void ReverseTween() {
            isRunningInReverse = !isRunningInReverse;
        }

        public IEnumerator WaitForCompletion () {
            while(tweenState != TweenState.Complete) {
                yield return null;
            }
        }

        public object GetTargetObject () {
            return target.GetTargetObject();
        }

        #endregion

        #region ITweenable Implementation

        public void Start () {
            if (!isFromValueOverridden) {
                fromValue = target.GetTweenedValue();
            }

            if (tweenState == TweenState.Complete) {
                tweenState = TweenState.Running;
                Boing.Instance.AddTween(this);
            }
        }

        public void Pause () {
            tweenState = TweenState.Paused;
        }

        public void Resume () {
            tweenState = TweenState.Running;
        }

        public void Stop (bool shouldComplete = false, bool shouldCompleteImmediately = false) {
            tweenState = TweenState.Complete;

            if (shouldComplete) {
                elapsedTime = isRunningInReverse ? 0f : duration;
                loopType = LoopType.None;
                numLoops = 0;

                if (shouldCompleteImmediately) {
                    Update();
                    Boing.Instance.RemoveTween(this);
                }
            }
            else {
                Boing.Instance.RemoveTween(this);
            }
        }

        public bool Update () {
            if (tweenState == TweenState.Paused) {
                return false;
            }

            float elapsedTimeExcess = 0f;
            if (!isRunningInReverse && elapsedTime >= duration) {
                elapsedTimeExcess = elapsedTime - duration;
                elapsedTime = duration;
                tweenState = TweenState.Complete;
            }
            else if (isRunningInReverse && elapsedTime <= 0f) {
                elapsedTimeExcess = 0f - elapsedTime;
                elapsedTime = 0f;
                tweenState = TweenState.Complete;
            }

            if (elapsedTime >= 0f && elapsedTime <= duration) {
                UpdateValue();
            }

            if (loopType != LoopType.None && tweenState == TweenState.Complete && numLoops > 0) {
                HandleLooping(elapsedTimeExcess);
            }

            float deltaTime = isTimeScaleIndependent ? Time.unscaledDeltaTime : Time.deltaTime;
            deltaTime *= timeScale;

            if (isRunningInReverse) {
                elapsedTime -= deltaTime;
            }
            else {
                elapsedTime += deltaTime;
            }

            if (tweenState == TweenState.Complete) {
                if (completionHandler != null) {
                    completionHandler(this.target.GetTweenedValue());
                }

                if (nextTween != null) {
                    nextTween.Start();
                    nextTween = null;
                }

                if (updateHandler != null) {
                    updateHandler(this.target.GetTweenedValue());
                }
                return true;
            }

            if (updateHandler != null) {
                updateHandler(this.target.GetTweenedValue());
            }
            return false;
        }

        public bool IsRunning () {
            return tweenState == TweenState.Running;
        }

        public virtual void RecycleSelf () {
            if (shouldRecycleTween) {
                target = null;
                nextTween = null;
            }
        }

        #endregion

        public void Initialize(ITweenTarget<T> target, T to, float duration) {
            Reset();
            this.target = target;
            this.toValue = to;
            this.duration = duration;
        }

        private void HandleLooping(float elapsedTimeExcess) {
            numLoops--;
            if (loopType == LoopType.PingPong) {
                ReverseTween();
            }

            if (loopType == LoopType.RestartFromBeginning || numLoops % 2 == 0) {
                if (loopCompletionHandler != null) {
                    loopCompletionHandler(this.target.GetTweenedValue());
                }
            }

            if (numLoops > 0) {
                tweenState = TweenState.Running;

                if (loopType == LoopType.RestartFromBeginning) {
                    elapsedTime = elapsedTimeExcess - delayBetweenLoops;
                }
                else {
                    if (isRunningInReverse) {
                        elapsedTime += delayBetweenLoops - elapsedTimeExcess;
                    }
                    else {
                        elapsedTime = elapsedTimeExcess - delayBetweenLoops;
                    }
                }

                if (delayBetweenLoops == 0f && elapsedTimeExcess > 0f) {
                    UpdateValue();
                }
            }
        }

        abstract protected void UpdateValue ();

        private void Reset() {
            Context = null;
            updateHandler = null;
            completionHandler = null;
            loopCompletionHandler = null;
            updateParams = null;
            completionParams = null;
            loopCompletionParams = null;
            isFromValueOverridden = false;
            isTimeScaleIndependent = false;
            tweenState = TweenState.Complete;
            isRelative = false;
            easeType = Boing.DefaultEaseType;
            animationCurve = null;

            if (nextTween != null) {
                nextTween.RecycleSelf();
                nextTween = null;
            }

            delay = 0f;
            duration = 0f;
            timeScale = 1f;
            elapsedTime = 0f;
            loopType = LoopType.None;
            delayBetweenLoops = 0f;
            numLoops = 0;
            isRunningInReverse = false;
        }
    }
}