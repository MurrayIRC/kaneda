using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boing {
    public class TweenValueTarget<T> : ITweenTarget<T> where T : struct {
        protected T target;

        public object GetTargetObject () {
            return target;
        }

        public T GetTweenedValue () {
            return target;
        }

        public void SetTweenedValue (T value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target = value;
        }

        private bool ValidateTarget () {
            return !target.Equals(null);
        }

        public TweenValueTarget(T value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }
            target = value;
        }
    }
}

