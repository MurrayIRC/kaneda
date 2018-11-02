using System;
using System.Collections;
using UnityEngine;

namespace Boing {
    public interface ITweenable {
        void Start ();
        void Pause ();
        void Resume ();

        /// <summary>
        /// Stops the tween.
        /// </summary>
        /// <param name="complete">Complete the tween on the next SynTween Tick cycle?</param>
        /// <param name="completeImmediately">Override the SynTween Tick cycle and force-complete the tween right now?</param>
        void Stop (bool complete = false, bool completeImmediately = false);

        bool Update ();
        bool IsRunning ();

        void RecycleSelf ();
    }

    public interface ITweenControl : ITweenable {
        object Context { get; }
        void JumpToElapsedTime (float elapsedTime);
        IEnumerator WaitForCompletion ();
        object GetTargetObject ();
    }

    public interface ITween<T> : ITweenControl where T : struct {
        ITween<T> SetEaseType (EaseType type);
        ITween<T> SetAnimationCurve (AnimationCurve curve);
        ITween<T> SetDelay (float seconds);
        ITween<T> SetDuration (float seconds);
        ITween<T> SetTimeScale (float scale);
        ITween<T> SetIsTimeScaleDependent ();
        ITween<T> SetUpdateHandler (Action<T> handler);
        ITween<T> SetCompletionHandler (Action<T> handler);
        ITween<T> SetLoopCompletionHandler (Action<T> handler);
        ITween<T> SetLoops (LoopType type, int numLoops = 1, float delayBetweenLoops = 0f);
        ITween<T> SetFrom (T from);
        ITween<T> PrepareForReuse (T from, T to, float duration);
        ITween<T> SetRecycleTween (bool shouldRecycleTween);
        ITween<T> SetIsRelative ();
        ITween<T> SetContext (object context);
        ITween<T> SetNextTween (ITweenable nextTween);
    }

    public interface ITweenTarget<T> where T : struct {
        void SetTweenedValue (T value);
        T GetTweenedValue ();
        object GetTargetObject ();
    }
}
