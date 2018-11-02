using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Boing {
    #region Transform Rotation

    public class TransformRotationTarget : AbstractTweenTarget<Transform, Quaternion> {
        public enum TransformRotationType {
            Rotation,
            LocalRotation
        }
        TransformRotationType targetType;

        public TransformRotationTarget (Transform transform, TransformRotationType type) {
            target = transform;
            targetType = type;
        }

        public override Quaternion GetTweenedValue () {
            switch (targetType) {
                case TransformRotationType.Rotation:
                    return target.rotation;
                case TransformRotationType.LocalRotation:
                    return target.localRotation;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public override void SetTweenedValue (Quaternion value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            switch(targetType) {
                case TransformRotationType.Rotation:
                    target.rotation = value;
                    break;
                case TransformRotationType.LocalRotation:
                    target.localRotation = value;
                    break;
            }
        }
    }

    #endregion

    #region SpriteRenderer

    public abstract class AbstractSpriteRendererTarget {
        protected SpriteRenderer spriteRenderer;

        public void PrepareForUse(SpriteRenderer renderer) {
            spriteRenderer = renderer;
        }

        public object GetTargetObject() {
            return spriteRenderer;
        }
    }

    public class SpriteRendererColorTarget : AbstractSpriteRendererTarget, ITweenTarget<Color> {
        public SpriteRendererColorTarget(SpriteRenderer renderer) {
            PrepareForUse(renderer);
        }

        public void SetTweenedValue(Color value) {
            if (Boing.EnableNullChecking && spriteRenderer == null) {
                return;
            }

            spriteRenderer.color = value;
        }

        public Color GetTweenedValue () {
            return spriteRenderer.color;
        }
    }

    public class SpriteRendererAlphaTarget : AbstractSpriteRendererTarget, ITweenTarget<float> {
        public SpriteRendererAlphaTarget (SpriteRenderer renderer) {
            PrepareForUse(renderer);
        }

        public void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && spriteRenderer == null) {
                return;
            }

            Color color = spriteRenderer.color;
            color.a = value;
            spriteRenderer.color = color;
        }

        public float GetTweenedValue () {
            return spriteRenderer.color.a;
        }
    }

    #endregion

    #region Text

    public abstract class AbstractTextTarget {
        protected Text text;

        public void PrepareForUse(Text t) {
            text = t;
        }

        public object GetTargetObject() {
            return text;
        }
    }

    public class TextColorTarget : AbstractTextTarget, ITweenTarget<Color> {
        public TextColorTarget(Text t) {
            PrepareForUse(t);
        }

        public Color GetTweenedValue () {
            return text.color;
        }

        public void SetTweenedValue(Color value) {
            if (Boing.EnableNullChecking && text == null) {
                return;
            }

            text.color = value;
        }
    }

    public class TextAlphaTarget : AbstractTextTarget, ITweenTarget<float> {
        public TextAlphaTarget (Text t) {
            PrepareForUse(t);
        }

        public float GetTweenedValue () {
            return text.color.a;
        }

        public void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && text == null) {
                return;
            }

            Color color = text.color;
            color.a = value;
            text.color = color;
        }
    }

    #endregion

    #region Material

    public abstract class AbstractMaterialTarget {
        protected Material material;
        protected int materialNameID;

        public void PrepareForUse (Material mat, string propertyName) {
            material = mat;
            materialNameID = Shader.PropertyToID(propertyName);
        }

        public object GetTargetObject () {
            return material;
        }
    }

    public class MaterialColorTarget : AbstractMaterialTarget, ITweenTarget<Color> {
        public MaterialColorTarget (Material mat, string propertyName) {
            PrepareForUse(mat, propertyName);
        }

        public void SetTweenedValue (Color value) {
            if (Boing.EnableNullChecking && material == null) {
                return;
            }

            material.SetColor(materialNameID, value);
        }

        public Color GetTweenedValue () {
            return material.GetColor(materialNameID);
        }
    }

    public class MaterialAlphaTarget : AbstractMaterialTarget, ITweenTarget<float> {
        public MaterialAlphaTarget (Material mat, string propertyName) {
            PrepareForUse(mat, propertyName);
        }

        public void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && material == null) {
                return;
            }

            Color color = material.GetColor(materialNameID);
            color.a = value;
            material.SetColor(materialNameID, color);
        }

        public float GetTweenedValue () {
            return material.GetColor(materialNameID).a;
        }
    }

    public class MaterialFloatTarget : AbstractMaterialTarget, ITweenTarget<float> {
        public MaterialFloatTarget (Material mat, string propertyName) {
            PrepareForUse(mat, propertyName);
        }

        public void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && material == null) {
                return;
            }

            material.SetFloat(materialNameID, value);
        }

        public float GetTweenedValue () {
            return material.GetFloat(materialNameID);
        }
    }

    public class MaterialVector4Target : AbstractMaterialTarget, ITweenTarget<Vector4> {
        public MaterialVector4Target (Material mat, string propertyName) {
            PrepareForUse(mat, propertyName);
        }

        public void SetTweenedValue (Vector4 value) {
            if (Boing.EnableNullChecking && material == null) {
                return;
            }

            material.SetVector(materialNameID, value);
        }

        public Vector4 GetTweenedValue () {
            return material.GetVector(materialNameID);
        }
    }

    public class MaterialTextureOffsetTarget : AbstractMaterialTarget, ITweenTarget<Vector2> {
        string propertyName;

        public MaterialTextureOffsetTarget (Material mat, string property) {
            PrepareForUse(mat, property);
            propertyName = property;
        }

        public void SetTweenedValue (Vector2 value) {
            if (Boing.EnableNullChecking && material == null) {
                return;
            }

            material.SetTextureOffset(propertyName, value);
        }

        public Vector2 GetTweenedValue () {
            return material.GetTextureOffset(propertyName);
        }
    }

    public class MaterialTextureScaleTarget : AbstractMaterialTarget, ITweenTarget<Vector2> {
        string propertyName;

        public MaterialTextureScaleTarget (Material mat, string property) {
            PrepareForUse(mat, property);
            propertyName = property;
        }

        public void SetTweenedValue (Vector2 value) {
            if (Boing.EnableNullChecking && material == null) {
                return;
            }

            material.SetTextureScale(propertyName, value);
        }

        public Vector2 GetTweenedValue () {
            return material.GetTextureScale(propertyName);
        }
    }

    #endregion

    #region AudioSource

    public class AudioSourceFloatTarget : AbstractTweenTarget<AudioSource, float> {
        public enum AudioSourceFloatType {
            Volume,
            Pitch,
            PanStereo
        }
        AudioSourceFloatType targetType;

        public AudioSourceFloatTarget (AudioSource source, AudioSourceFloatType type) {
            target = source;
            targetType = type;
        }

        public override float GetTweenedValue () {
            switch (targetType) {
                case AudioSourceFloatType.Volume:
                    return target.volume;
                case AudioSourceFloatType.Pitch:
                    return target.pitch;
                case AudioSourceFloatType.PanStereo:
                    return target.panStereo;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public override void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            switch (targetType) {
                case AudioSourceFloatType.Volume:
                    target.volume = value;
                    break;
                case AudioSourceFloatType.Pitch:
                    target.pitch = value;
                    break;
                case AudioSourceFloatType.PanStereo:
                    target.panStereo = value;
                    break;
            }
        }
    }

    #endregion

    #region Camera

    public class CameraFloatTarget : AbstractTweenTarget<Camera, float> {
        public enum CameraTargetType {
            OrthographicSize,
            FieldOfView
        }
        CameraTargetType targetType;

        public CameraFloatTarget (Camera source, CameraTargetType type) {
            target = source;
            targetType = type;
        }

        public override float GetTweenedValue () {
            switch (targetType) {
                case CameraTargetType.OrthographicSize:
                    return target.orthographicSize;
                case CameraTargetType.FieldOfView:
                    return target.fieldOfView;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public override void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            switch (targetType) {
                case CameraTargetType.OrthographicSize:
                    target.orthographicSize = value;
                    break;
                case CameraTargetType.FieldOfView:
                    target.fieldOfView = value;
                    break;
            }
        }
    }

    public class CameraBackgroundColorTarget : AbstractTweenTarget<Camera, Color> {
        public CameraBackgroundColorTarget(Camera cam) {
            target = cam;
        }

        public override Color GetTweenedValue () {
            return target.backgroundColor;
        }

        public override void SetTweenedValue (Color value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.backgroundColor = value;
        }
    }

    public class CameraRectTarget : AbstractTweenTarget<Camera, Rect> {
        public enum CameraTargetType {
            Rect,
            PixelRect
        }
        CameraTargetType targetType;

        public CameraRectTarget (Camera source, CameraTargetType type) {
            target = source;
            targetType = type;
        }

        public override Rect GetTweenedValue () {
            switch (targetType) {
                case CameraTargetType.Rect:
                    return target.rect;
                case CameraTargetType.PixelRect:
                    return target.pixelRect;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public override void SetTweenedValue (Rect value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            switch (targetType) {
                case CameraTargetType.Rect:
                    target.rect = value;
                    break;
                case CameraTargetType.PixelRect:
                    target.pixelRect = value;
                    break;
            }
        }
    }

    #endregion

    #region CanvasGroup

    public class CanvasGroupAlphaTarget : AbstractTweenTarget<CanvasGroup, float> {
        public CanvasGroupAlphaTarget(CanvasGroup group) {
            target = group;
        }

        public override float GetTweenedValue () {
            return target.alpha;
        }

        public override void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.alpha = value;
        }
    }

    #endregion

    #region Image

    public class ImageFloatTarget : AbstractTweenTarget<Image, float> {
        public enum ImageTargetType {
            Alpha,
            FillAmount
        }
        ImageTargetType targetType;

        public ImageFloatTarget (Image source, ImageTargetType type) {
            target = source;
            targetType = type;
        }

        public override float GetTweenedValue () {
            switch (targetType) {
                case ImageTargetType.Alpha:
                    return target.color.a;
                case ImageTargetType.FillAmount:
                    return target.fillAmount;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public override void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            switch (targetType) {
                case ImageTargetType.Alpha:
                    Color color = target.color;
                    color.a = value;
                    target.color = color;
                    break;
                case ImageTargetType.FillAmount:
                    target.fillAmount = value;
                    break;
            }
        }
    }

    public class ImageColorTarget : AbstractTweenTarget<Image, Color> {
        public ImageColorTarget (Image source) {
            target = source;
        }

        public override Color GetTweenedValue () {
            return target.color;
        }

        public override void SetTweenedValue (Color value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.color = value;
        }
    }

    #endregion

    #region RectTransform

    public class RectTransformAnchoredPositionTarget : AbstractTweenTarget<RectTransform, Vector2> {
        public RectTransformAnchoredPositionTarget (RectTransform rectTransform) {
            target = rectTransform;
        }

        public override void SetTweenedValue (Vector2 value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.anchoredPosition = value;
        }

        public override Vector2 GetTweenedValue () {
            return target.anchoredPosition;
        }
    }

    public class RectTransformAnchoredPosition3DTarget : AbstractTweenTarget<RectTransform, Vector3> {
        public RectTransformAnchoredPosition3DTarget (RectTransform rectTransform) {
            target = rectTransform;
        }

        public override void SetTweenedValue (Vector3 value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.anchoredPosition3D = value;
        }

        public override Vector3 GetTweenedValue () {
            return target.anchoredPosition3D;
        }
    }

    public class RectTransformSizeDeltaTarget : AbstractTweenTarget<RectTransform, Vector2> {
        public RectTransformSizeDeltaTarget (RectTransform rectTransform) {
            target = rectTransform;
        }

        public override void SetTweenedValue (Vector2 value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.sizeDelta = value;
        }

        public override Vector2 GetTweenedValue () {
            return target.sizeDelta;
        }
    }

    #endregion

    #region ScrollRect

    public class ScrollRectNormalizedPositionTarget : AbstractTweenTarget<ScrollRect, Vector2> {
        public ScrollRectNormalizedPositionTarget (ScrollRect scrollRect) {
            target = scrollRect;
        }

        public override void SetTweenedValue (Vector2 value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.normalizedPosition = value;
        }

        public override Vector2 GetTweenedValue () {
            return target.normalizedPosition;
        }
    }

    #endregion

    #region Light

    public class LightColorTarget : AbstractTweenTarget<Light, Color> {
        public LightColorTarget (Light light) {
            target = light;
        }

        public override void SetTweenedValue (Color value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            target.color = value;
        }

        public override Color GetTweenedValue () {
            return target.color;
        }
    }

    public class LightFloatTarget : AbstractTweenTarget<Light, float> {
        public enum LightTargetType {
            Intensity,
            Range,
            SpotAngle
        }
        private LightTargetType targetType;

        public LightFloatTarget (Light light, LightTargetType type = LightTargetType.Intensity) {
            target = light;
            targetType = type;
        }

        public override void SetTweenedValue (float value) {
            if (Boing.EnableNullChecking && !ValidateTarget()) {
                return;
            }

            switch (targetType) {
                case LightTargetType.Intensity:
                    target.intensity = value;
                    break;
                case LightTargetType.Range:
                    target.range = value;
                    break;
                case LightTargetType.SpotAngle:
                    target.spotAngle = value;
                    break;
            }
        }

        public override float GetTweenedValue () {
            switch (targetType) {
                case LightTargetType.Intensity:
                    return target.intensity;
                case LightTargetType.Range:
                    return target.range;
                case LightTargetType.SpotAngle:
                    return target.spotAngle;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
    }

    #endregion
}