using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boing {
    public static class Tweener {
        #region Lerps

        public static float UnclampedLerp(float from, float to, float t) {
            return from + (to - from) * t;
        }

        public static float LerpTowards(float from, float to, float remainingFactorPerSecond, float deltaTime) {
            return UnclampedLerp(from, to, 1f - Mathf.Pow(remainingFactorPerSecond, deltaTime));
        }

        public static Vector2 UnclampedLerp (Vector2 from, Vector2 to, float t) {
            return new Vector2(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t);
        }

        public static Vector2 LerpTowards (Vector2 from, Vector2 to, float remainingFactorPerSecond, float deltaTime) {
            return UnclampedLerp(from, to, 1f - Mathf.Pow(remainingFactorPerSecond, deltaTime));
        }

        public static Vector3 UnclampedLerp (Vector3 from, Vector3 to, float t) {
            return new Vector3(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t, from.z + (to.z - from.z) * t);
        }

        public static Vector3 LerpTowards (Vector3 from, Vector3 to, float remainingFactorPerSecond, float deltaTime) {
            return UnclampedLerp(from, to, 1f - Mathf.Pow(remainingFactorPerSecond, deltaTime));
        }

        public static Vector3 LerpTowards (Vector3 followerCurrentPos, Vector3 targetPreviousPos, Vector3 targetCurrentPos, float smooth, float deltaTime) {
            Vector3 targetDiff = targetCurrentPos - targetPreviousPos;
            Vector3 temp = followerCurrentPos - targetPreviousPos + targetDiff / (smooth * deltaTime);
            return targetCurrentPos - targetDiff / (smooth * deltaTime) + temp * Mathf.Exp(-smooth * deltaTime);
        }

        public static Vector3 UnclampedAngledLerp (Vector3 from, Vector3 to, float t) {
            Vector3 toMinusFrom = new Vector3(Mathf.DeltaAngle(from.x, to.x), Mathf.DeltaAngle(from.y, to.y), Mathf.DeltaAngle(from.z, to.z));
            return new Vector3(from.x + toMinusFrom.x * t, from.y + toMinusFrom.y * t, from.z + toMinusFrom.z * t);
        }

        public static Vector4 UnclampedLerp (Vector4 from, Vector4 to, float t) {
            return new Vector4(from.x + (to.x - from.x) * t, from.y + (to.y - from.y) * t, from.z + (to.z - from.z) * t, from.w + (to.w - from.w) * t);
        }

        public static Color UnclampedLerp (Color from, Color to, float t) {
            return new Color(from.r + (to.r - from.r) * t, from.g + (to.g - from.g) * t, from.b + (to.b - from.b) * t, from.a + (to.a - from.a) * t);
        }

        public static Color32 UnclampedLerp (Color32 from, Color32 to, float t) {
            return new Color32((byte)((float)from.r + (float)(to.r - from.r) * t), (byte)((float)from.g + (float)(to.g - from.g) * t), (byte)((float)from.b + (float)(to.b - from.b) * t), (byte)((float)from.a + (float)(to.a - from.a) * t));
        }

        public static Rect UnclampedLerp (Rect from, Rect to, float t) {
            return new Rect(
                from.x + (to.x - from.x) * t,
                from.y + (to.y - from.y) * t,
                from.width + (to.width - from.width) * t,
                from.height + (to.height - from.height) * t
            );
        }

        #endregion

        #region Eases

        public static float Ease(EaseType ease, float from, float to, float t, float duration) {
            return UnclampedLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static float Ease (AnimationCurve curve, float from, float to, float t, float duration) {
            return UnclampedLerp(from, to, curve.Evaluate(t / duration));
        }

        public static Vector2 Ease (EaseType ease, Vector2 from, Vector2 to, float t, float duration) {
            return UnclampedLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Vector2 Ease (AnimationCurve curve, Vector2 from, Vector2 to, float t, float duration) {
            return UnclampedLerp(from, to, curve.Evaluate(t / duration));
        }

        public static Vector3 Ease (EaseType ease, Vector3 from, Vector3 to, float t, float duration) {
            return UnclampedLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Vector3 Ease (AnimationCurve curve, Vector3 from, Vector3 to, float t, float duration) {
            return UnclampedLerp(from, to, curve.Evaluate(t / duration));
        }

        public static Vector3 EaseAngle (EaseType ease, Vector3 from, Vector3 to, float t, float duration) {
            return UnclampedAngledLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Vector3 EaseAngle (AnimationCurve curve, Vector3 from, Vector3 to, float t, float duration) {
            return UnclampedAngledLerp(from, to, curve.Evaluate(t / duration));
        }

        public static Vector4 Ease (EaseType ease, Vector4 from, Vector4 to, float t, float duration) {
            return UnclampedLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Vector4 Ease (AnimationCurve curve, Vector4 from, Vector4 to, float t, float duration) {
            return UnclampedLerp(from, to, curve.Evaluate(t / duration));
        }

        public static Quaternion Ease (EaseType ease, Quaternion from, Quaternion to, float t, float duration) {
            return Quaternion.Lerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Quaternion Ease (AnimationCurve curve, Quaternion from, Quaternion to, float t, float duration) {
            return Quaternion.Lerp(from, to, curve.Evaluate(t / duration));
        }

        public static Color Ease (EaseType ease, Color from, Color to, float t, float duration) {
            return UnclampedLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Color Ease (AnimationCurve curve, Color from, Color to, float t, float duration) {
            return UnclampedLerp(from, to, curve.Evaluate(t / duration));
        }

        public static Color32 Ease (EaseType ease, Color32 from, Color32 to, float t, float duration) {
            return UnclampedLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Color32 Ease (AnimationCurve curve, Color32 from, Color32 to, float t, float duration) {
            return UnclampedLerp(from, to, curve.Evaluate(t / duration));
        }

        public static Rect Ease (EaseType ease, Rect from, Rect to, float t, float duration) {
            return UnclampedLerp(from, to, EaseHelper.Ease(ease, t, duration));
        }

        public static Rect Ease (AnimationCurve curve, Rect from, Rect to, float t, float duration) {
            return UnclampedLerp(from, to, curve.Evaluate(t / duration));
        }

        #endregion

        #region Springs

        public static float FastSpring(float currentValue, float targetValue, ref float velocity, float dampingRatio, float angularFrequency) {
            velocity += -2.0f * Time.deltaTime * dampingRatio * angularFrequency * velocity + Time.deltaTime * angularFrequency * angularFrequency * (targetValue - currentValue);
            currentValue += Time.deltaTime * velocity;
            return currentValue;
        }

        public static float StableSpring(float currentValue, float targetValue, ref float velocity, float dampingRatio, float angularFrequency) {
            float f = 1f + 2f * Time.deltaTime * dampingRatio * angularFrequency;
            float oo = angularFrequency * angularFrequency;
            float hoo = Time.deltaTime * oo;
            float hhoo = Time.deltaTime * hoo;
            float detInv = 1.0f / (f + hhoo);
            float detX = f * currentValue + Time.deltaTime * velocity + hhoo * targetValue;
            float detV = velocity + hoo * (targetValue - currentValue);

            currentValue = detX * detInv;
            velocity = detV * detInv;
            return currentValue;
        }

        public static Vector3 FastSpring (Vector3 currentValue, Vector3 targetValue, ref Vector3 velocity, float dampingRatio, float angularFrequency) {
            velocity += -2.0f * Time.deltaTime * dampingRatio * angularFrequency * velocity + Time.deltaTime * angularFrequency * angularFrequency * (targetValue - currentValue);
            currentValue += Time.deltaTime * velocity;
            return currentValue;
        }

        public static Vector3 StableSpring (Vector3 currentValue, Vector3 targetValue, ref Vector3 velocity, float dampingRatio, float angularFrequency) {
            float f = 1f + 2f * Time.deltaTime * dampingRatio * angularFrequency;
            float oo = angularFrequency * angularFrequency;
            float hoo = Time.deltaTime * oo;
            float hhoo = Time.deltaTime * hoo;
            float detInv = 1.0f / (f + hhoo);
            Vector3 detX = f * currentValue + Time.deltaTime * velocity + hhoo * targetValue;
            Vector3 detV = velocity + hoo * (targetValue - currentValue);

            currentValue = detX * detInv;
            velocity = detV * detInv;
            return currentValue;
        }

        #endregion
    }
}