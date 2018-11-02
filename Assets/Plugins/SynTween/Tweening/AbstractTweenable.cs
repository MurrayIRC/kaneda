using System.Collections;
using System;
using UnityEngine;

namespace SynCore.Tweening {
    public abstract class AbstractTweenable : ITweenable {
        protected bool isPaused;
        protected bool isCurrentlyManagedBySynTween;

        #region ITweenable

        public abstract bool Update ();

        public virtual void RecycleSelf () { }

        public bool IsRunning() {
            return isCurrentlyManagedBySynTween && !isPaused;
        }

        public virtual void Start() {
            if (isCurrentlyManagedBySynTween) {
                isPaused = false;
                return;
            }

            SynTween.Instance.AddTween(this);
            isCurrentlyManagedBySynTween = true;
            isPaused = false;
        }

        public void Pause() {
            isPaused = true;
        }

        public void Resume() {
            isPaused = false;
        }

        public virtual void Stop(bool shouldComplete = false, bool shouldCompleteImmediately = false) {
            SynTween.Instance.RemoveTween(this);
            isCurrentlyManagedBySynTween = false;
            isPaused = true;
        }

        #endregion
    }
}