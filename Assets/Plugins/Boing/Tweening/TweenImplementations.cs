using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boing {
    public class IntTween : Tween<int> {
        public static IntTween Create () {
            return Boing.CacheIntTweens ? TweenCache<IntTween>.Pop() : new IntTween();
        }

        public IntTween () { }
        public IntTween (ITweenTarget<int> target, int to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<int> SetIsRelative () {
            isRelative = true;
            toValue += fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue((int)Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue((int)Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf() {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheIntTweens) {
                TweenCache<IntTween>.Push(this);
            }
        }
    }

    public class FloatTween : Tween<float> {
        public static FloatTween Create () {
            return Boing.CacheFloatTweens ? TweenCache<FloatTween>.Pop() : new FloatTween();
        }

        public FloatTween () { }
        public FloatTween (ITweenTarget<float> target, float to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<float> SetIsRelative () {
            isRelative = true;
            toValue += fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheFloatTweens) {
                TweenCache<FloatTween>.Push(this);
            }
        }
    }

    public class Vector2Tween : Tween<Vector2> {
        public static Vector2Tween Create () {
            return Boing.CacheVector2Tweens ? TweenCache<Vector2Tween>.Pop() : new Vector2Tween();
        }

        public Vector2Tween () { }
        public Vector2Tween (ITweenTarget<Vector2> target, Vector2 to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<Vector2> SetIsRelative () {
            isRelative = true;
            toValue += fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheVector2Tweens) {
                TweenCache<Vector2Tween>.Push(this);
            }
        }
    }

    public class Vector3Tween : Tween<Vector3> {
        public static Vector3Tween Create () {
            return Boing.CacheVector3Tweens ? TweenCache<Vector3Tween>.Pop() : new Vector3Tween();
        }

        public Vector3Tween () { }
        public Vector3Tween (ITweenTarget<Vector3> target, Vector3 to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<Vector3> SetIsRelative () {
            isRelative = true;
            toValue += fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheVector3Tweens) {
                TweenCache<Vector3Tween>.Push(this);
            }
        }
    }

    public class Vector4Tween : Tween<Vector4> {
        public static Vector4Tween Create () {
            return Boing.CacheVector4Tweens ? TweenCache<Vector4Tween>.Pop() : new Vector4Tween();
        }

        public Vector4Tween () { }
        public Vector4Tween (ITweenTarget<Vector4> target, Vector4 to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<Vector4> SetIsRelative () {
            isRelative = true;
            toValue += fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheVector4Tweens) {
                TweenCache<Vector4Tween>.Push(this);
            }
        }
    }

    public class QuaternionTween : Tween<Quaternion> {
        public static QuaternionTween Create () {
            return Boing.CacheQuaternionTweens ? TweenCache<QuaternionTween>.Pop() : new QuaternionTween();
        }

        public QuaternionTween () { }
        public QuaternionTween (ITweenTarget<Quaternion> target, Quaternion from, Quaternion to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<Quaternion> SetIsRelative () {
            isRelative = true;
            toValue *= fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheQuaternionTweens) {
                TweenCache<QuaternionTween>.Push(this);
            }
        }
    }

    public class ColorTween : Tween<Color> {
        public static ColorTween Create () {
            return Boing.CacheColorTweens ? TweenCache<ColorTween>.Pop() : new ColorTween();
        }

        public ColorTween () { }
        public ColorTween (ITweenTarget<Color> target, Color to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<Color> SetIsRelative () {
            isRelative = true;
            toValue += fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheColorTweens) {
                TweenCache<ColorTween>.Push(this);
            }
        }
    }

    public class Color32Tween : Tween<Color32> {
        public static Color32Tween Create () {
            return Boing.CacheColor32Tweens ? TweenCache<Color32Tween>.Pop() : new Color32Tween();
        }

        public Color32Tween () { }
        public Color32Tween (ITweenTarget<Color32> target, Color32 to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<Color32> SetIsRelative () {
            isRelative = true;
            toValue = (Color)toValue + (Color)fromValue;
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheColor32Tweens) {
                TweenCache<Color32Tween>.Push(this);
            }
        }
    }

    public class RectTween : Tween<Rect> {
        public static RectTween Create () {
            return Boing.CacheRectTweens ? TweenCache<RectTween>.Pop() : new RectTween();
        }

        public RectTween () { }
        public RectTween (ITweenTarget<Rect> target, Rect to, float duration) {
            Initialize(target, to, duration);
        }

        public override ITween<Rect> SetIsRelative () {
            isRelative = true;
            toValue = new Rect(
                toValue.x + fromValue.x,
                toValue.y + fromValue.y,
                toValue.width + fromValue.width,
                toValue.height + fromValue.height
            );
            return this;
        }

        protected override void UpdateValue () {
            if (animationCurve != null) {
                target.SetTweenedValue(Tweener.Ease(animationCurve, fromValue, toValue, elapsedTime, duration));
            }
            else {
                target.SetTweenedValue(Tweener.Ease(easeType, fromValue, toValue, elapsedTime, duration));
            }
        }

        public override void RecycleSelf () {
            base.RecycleSelf();
            if (shouldRecycleTween && Boing.CacheRectTweens) {
                TweenCache<RectTween>.Push(this);
            }
        }
    }
}
