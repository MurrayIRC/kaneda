using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Boing {
    public static class BoingExtensions {
        #region Transform Extensions

        public static Vector3Tween TweenPosition(this Transform self, Vector3 to, float duration = 0.5f) {
            TransformVector3Tween tween = TweenCache<TransformVector3Tween>.Pop();
            tween.SetTargetAndType(self, TransformTargetType.Position);
            tween.Initialize(tween, to, duration);
            return tween;
        }

        public static Vector3Tween TweenLocalPosition (this Transform self, Vector3 to, float duration = 0.5f) {
            TransformVector3Tween tween = TweenCache<TransformVector3Tween>.Pop();
            tween.SetTargetAndType(self, TransformTargetType.LocalPosition);
            tween.Initialize(tween, to, duration);
            return tween;
        }

        public static Vector3Tween TweenLocalScale (this Transform self, Vector3 to, float duration = 0.5f) {
            TransformVector3Tween tween = TweenCache<TransformVector3Tween>.Pop();
            tween.SetTargetAndType(self, TransformTargetType.LocalScale);
            tween.Initialize(tween, to, duration);
            return tween;
        }

        public static Vector3Tween TweenEulerAngles (this Transform self, Vector3 to, float duration = 0.5f) {
            TransformVector3Tween tween = TweenCache<TransformVector3Tween>.Pop();
            tween.SetTargetAndType(self, TransformTargetType.EulerAngles);
            tween.Initialize(tween, to, duration);
            return tween;
        }

        public static Vector3Tween TweenLocalEulerAngles (this Transform self, Vector3 to, float duration = 0.5f) {
            TransformVector3Tween tween = TweenCache<TransformVector3Tween>.Pop();
            tween.SetTargetAndType(self, TransformTargetType.LocalEulerAngles);
            tween.Initialize(tween, to, duration);
            return tween;
        }

        public static QuaternionTween TweenRotation (this Transform self, Quaternion to, float duration = 0.5f) {
            TransformRotationTarget target = new TransformRotationTarget(self, TransformRotationTarget.TransformRotationType.Rotation);
            QuaternionTween tween = new QuaternionTween(target, self.rotation, to, duration);
            return tween;
        }

        public static QuaternionTween TweenLocalRotation (this Transform self, Quaternion to, float duration = 0.5f) {
            TransformRotationTarget target = new TransformRotationTarget(self, TransformRotationTarget.TransformRotationType.LocalRotation);
            QuaternionTween tween = new QuaternionTween(target, self.localRotation, to, duration);
            return tween;
        }

        #endregion

        #region SpriteRenderer Extensions

        public static ColorTween TweenColor (this SpriteRenderer self, Color to, float duration = 0.5f) {
            SpriteRendererColorTarget target = new SpriteRendererColorTarget(self);
            ColorTween tween = ColorTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenAlpha (this SpriteRenderer self, float to, float duration = 0.5f) {
            SpriteRendererAlphaTarget target = new SpriteRendererAlphaTarget(self);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region Material Extensions

        public static ColorTween TweenColor (this Material self, Color to, float duration = 0.5f, string propertyName = "_Color") {
            MaterialColorTarget target = new MaterialColorTarget(self, propertyName);
            ColorTween tween = ColorTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenAlpha (this Material self, float to, float duration = 0.5f, string propertyName = "_Color") {
            MaterialAlphaTarget target = new MaterialAlphaTarget(self, propertyName);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenFloat (this Material self, float to, float duration = 0.5f, string propertyName = "_Color") {
            MaterialFloatTarget target = new MaterialFloatTarget(self, propertyName);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static Vector4Tween TweenVector4 (this Material self, Vector4 to, float duration = 0.5f, string propertyName = "_Color") {
            MaterialVector4Target target = new MaterialVector4Target(self, propertyName);
            Vector4Tween tween = Vector4Tween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static Vector2Tween TweenTextureOffset (this Material self, Vector2 to, float duration = 0.5f, string propertyName = "_MainTex") {
            MaterialTextureOffsetTarget target = new MaterialTextureOffsetTarget(self, propertyName);
            Vector2Tween tween = Vector2Tween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static Vector2Tween TweenTextureScale (this Material self, Vector2 to, float duration = 0.5f, string propertyName = "_MainTex") {
            MaterialTextureScaleTarget target = new MaterialTextureScaleTarget(self, propertyName);
            Vector2Tween tween = Vector2Tween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region AudioSource Extensions

        public static FloatTween TweenVolume (this AudioSource self, float to, float duration = 0.5f) {
            AudioSourceFloatTarget target = new AudioSourceFloatTarget(self, AudioSourceFloatTarget.AudioSourceFloatType.Volume);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenPitch (this AudioSource self, float to, float duration = 0.5f) {
            AudioSourceFloatTarget target = new AudioSourceFloatTarget(self, AudioSourceFloatTarget.AudioSourceFloatType.Pitch);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenPanStereo (this AudioSource self, float to, float duration = 0.5f) {
            AudioSourceFloatTarget target = new AudioSourceFloatTarget(self, AudioSourceFloatTarget.AudioSourceFloatType.PanStereo);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region Camera Extensions

        public static FloatTween TweenFieldOfView (this Camera self, float to, float duration = 0.5f) {
            CameraFloatTarget target = new CameraFloatTarget(self, CameraFloatTarget.CameraTargetType.FieldOfView);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenOrthographicSize (this Camera self, float to, float duration = 0.5f) {
            CameraFloatTarget target = new CameraFloatTarget(self, CameraFloatTarget.CameraTargetType.OrthographicSize);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static ColorTween TweenBackgroundColor (this Camera self, Color to, float duration = 0.5f) {
            CameraBackgroundColorTarget target = new CameraBackgroundColorTarget(self);
            ColorTween tween = ColorTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static RectTween TweenRect (this Camera self, Rect to, float duration = 0.5f) {
            CameraRectTarget target = new CameraRectTarget(self, CameraRectTarget.CameraTargetType.Rect);
            RectTween tween = RectTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static RectTween TweenPixelRect (this Camera self, Rect to, float duration = 0.5f) {
            CameraRectTarget target = new CameraRectTarget(self, CameraRectTarget.CameraTargetType.PixelRect);
            RectTween tween = RectTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region CanvasGroup Extensions

        public static FloatTween TweenAlpha (this CanvasGroup self, float to, float duration = 0.5f) {
            CanvasGroupAlphaTarget target = new CanvasGroupAlphaTarget(self);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region Image Extensions

        public static FloatTween TweenAlpha (this Image self, float to, float duration = 0.5f) {
            ImageFloatTarget target = new ImageFloatTarget(self, ImageFloatTarget.ImageTargetType.Alpha);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenFillAmount (this Image self, float to, float duration = 0.5f) {
            ImageFloatTarget target = new ImageFloatTarget(self, ImageFloatTarget.ImageTargetType.FillAmount);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static ColorTween TweenColor (this Image self, Color to, float duration = 0.5f) {
            ImageColorTarget target = new ImageColorTarget(self);
            ColorTween tween = ColorTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region RectTransform Extensions

        public static Vector2Tween TweenAnchoredPosition (this RectTransform self, Vector2 to, float duration = 0.5f) {
            RectTransformAnchoredPositionTarget target = new RectTransformAnchoredPositionTarget(self);
            Vector2Tween tween = Vector2Tween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static Vector3Tween TweenAnchoredPosition3D (this RectTransform self, Vector3 to, float duration = 0.5f) {
            RectTransformAnchoredPosition3DTarget target = new RectTransformAnchoredPosition3DTarget(self);
            Vector3Tween tween = Vector3Tween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static Vector2Tween TweenSizeDelta (this RectTransform self, Vector2 to, float duration = 0.5f) {
            RectTransformSizeDeltaTarget target = new RectTransformSizeDeltaTarget(self);
            Vector2Tween tween = Vector2Tween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region ScrollRect Extensions

        public static Vector2Tween TweenNormalizedPosition (this ScrollRect self, Vector2 to, float duration = 0.5f) {
            ScrollRectNormalizedPositionTarget target = new ScrollRectNormalizedPositionTarget(self);
            Vector2Tween tween = Vector2Tween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region Light Extensions

        public static FloatTween TweenIntensity (this Light self, float to, float duration = 0.5f) {
            LightFloatTarget target = new LightFloatTarget(self, LightFloatTarget.LightTargetType.Intensity);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenRange (this Light self, float to, float duration = 0.5f) {
            LightFloatTarget target = new LightFloatTarget(self, LightFloatTarget.LightTargetType.Range);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenSpotAngle (this Light self, float to, float duration = 0.5f) {
            LightFloatTarget target = new LightFloatTarget(self, LightFloatTarget.LightTargetType.SpotAngle);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static ColorTween TweenColor (this Light self, Color to, float duration = 0.5f) {
            LightColorTarget target = new LightColorTarget(self);
            ColorTween tween = ColorTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region Text Extensions

        public static ColorTween TweenColor (this Text self, Color to, float duration = 0.5f) {
            TextColorTarget target = new TextColorTarget(self);
            ColorTween tween = ColorTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static FloatTween TweenAlpha (this Text self, float to, float duration = 0.5f) {
            TextAlphaTarget target = new TextAlphaTarget(self);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion
    }
}