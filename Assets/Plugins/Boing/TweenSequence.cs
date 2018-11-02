using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boing {
    public class TweenSequence : AbstractTweenable {
        List<ITweenable> tweenList = new List<ITweenable>();
        int currentTweenIndex = 0;
        Action<TweenSequence> completionHandler;

        public int TweenCount { get { return tweenList.Count; } }

        #region ITweenable

        public override void Start () {
            if (tweenList.Count > 0) {
                tweenList[0].Start();
            }

            base.Start();
        }

        public override bool Update () {
            if (isPaused) {
                return false;
            }

            if (currentTweenIndex >= tweenList.Count) {
                return true;
            }

            ITweenable tween = tweenList[currentTweenIndex];
            if (tween.Update()) {
                currentTweenIndex++;
                if (currentTweenIndex == tweenList.Count) {
                    if (completionHandler != null) {
                        completionHandler(this);
                    }
                    isCurrentlyManagedBySynTween = false;
                    return true;
                }
                else {
                    tweenList[currentTweenIndex].Start();
                }
            }

            return false;
        }

        public override void RecycleSelf () {
            for (int i = 0; i < tweenList.Count; i++) {
                tweenList[i].RecycleSelf();
            }
            tweenList.Clear();
        }

        public override void Stop (bool shouldComplete = false, bool shouldCompleteImmediately = false) {
            currentTweenIndex = tweenList.Count;
        }

        #endregion

        #region ITweenControl

        public IEnumerator WaitForCompletion() {
            while(currentTweenIndex < tweenList.Count) {
                yield return null;
            }
        }

        #endregion

        #region Tween Sequence Management

        public TweenSequence AppendTween(ITweenable tween) {
            if (tween is ITweenable) {
                tween.Resume();
                tweenList.Add(tween as ITweenable);
            }
            else {
                Debug.LogError("Cannot add a tween to a sequence that does not implement ITweenable.");
            }

            return this;
        }

        public TweenSequence SetCompletionHandler(Action<TweenSequence> handler) {
            completionHandler = handler;
            return this;
        }

        #endregion
    }
}
