using System.Collections;
using UnityEngine;

namespace Boing {
    public abstract class AbstractTweenTarget<U, T> : ITweenTarget<T> where T : struct {
        protected U target;

        abstract public void SetTweenedValue (T value);
        abstract public T GetTweenedValue ();

        public AbstractTweenTarget<U, T> SetTarget(U t) {
            target = t;
            return this;
        }

        public bool ValidateTarget() {
            return !target.Equals(null);
        }

        public object GetTargetObject() {
            return target;
        }
    }
}