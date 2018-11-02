using System.Collections.Generic;
using UnityEngine;

namespace Boing {
    public enum TransformTargetType {
        Position,
        LocalPosition,
        LocalScale,
        EulerAngles,
        LocalEulerAngles
    }

    public class TransformVector3Tween : Vector3Tween, ITweenTarget<Vector3> {
        private Transform transform;
        private TransformTargetType targetType;

        public Vector3 GetTweenedValue () {
            switch (targetType) {
                case TransformTargetType.Position:
                    return transform.position;
                case TransformTargetType.LocalPosition:
                    return transform.localPosition;
                case TransformTargetType.LocalScale:
                    return transform.localScale;
                case TransformTargetType.EulerAngles:
                    return transform.eulerAngles;
                case TransformTargetType.LocalEulerAngles:
                    return transform.localEulerAngles;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public void SetTweenedValue (Vector3 value) {
            if (Boing.EnableNullChecking && !transform) {
                return;
            }

            switch(targetType) {
                case TransformTargetType.Position:
                    transform.position = value;
                    break;
                case TransformTargetType.LocalPosition:
                    transform.localPosition = value;
                    break;
                case TransformTargetType.LocalScale:
                    transform.localScale = value;
                    break;
                case TransformTargetType.EulerAngles:
                    transform.eulerAngles = value;
                    break;
                case TransformTargetType.LocalEulerAngles:
                    transform.localEulerAngles = value;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public new object GetTargetObject() {
            return transform;
        }

        public void SetTargetAndType(Transform t, TransformTargetType type) {
            transform = t;
            targetType = type;
        }

        protected override void UpdateValue () {
            // non-relative angle lerps should take the shortest possible rotation
            if ((targetType == TransformTargetType.EulerAngles || targetType == TransformTargetType.LocalEulerAngles) && !isRelative) {
                if (animationCurve != null) {
                    SetTweenedValue(Tweener.EaseAngle(animationCurve, fromValue, toValue, elapsedTime, duration));
                }
                else {
                    SetTweenedValue(Tweener.EaseAngle(easeType, fromValue, toValue, elapsedTime, duration));
                }
            }
            else {
                if (animationCurve != null) {
                    SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
                }
                else {
                    SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
                }
            }
        }

        public override void RecycleSelf () {
            if (shouldRecycleTween) {
                target = null;
                nextTween = null;
                transform = null;
                TweenCache<TransformVector3Tween>.Push(this);
            }
        }
    }
}