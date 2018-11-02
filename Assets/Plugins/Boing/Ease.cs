using UnityEngine;

namespace Boing {
    
    public enum EaseType {
        Linear,

        SineIn,
        SineOut,
        SineInOut,

        QuadIn,
        QuadOut,
        QuadInOut,

        CubicIn,
        CubicOut,
        CubicInOut,

        QuartIn,
        QuartOut,
        QuartInOut,

        QuintIn,
        QuintOut,
        QuintInOut,

        ExpoIn,
        ExpoOut,
        ExpoInOut,

        CircIn,
        CircOut,
        CircInOut,

        BackIn,
        BackOut,
        BackInOut,

        ElasticIn,
        ElasticOut,
        ElasticInOut,

        BounceIn,
        BounceOut,
        BounceInOut
    }

    /// <summary>
    /// Helper function that hooks up the Ease types to their corresponding easing functions.
    /// </summary>
    public static class EaseHelper {
        public static float Ease(EaseType ease, float t, float duration) {
            switch(ease) {
                case EaseType.Linear:
                    return EasingFunctions.Linear.Ease(t, duration);

                case EaseType.SineIn:
                    return EasingFunctions.Sine.EaseIn(t, duration);
                case EaseType.SineOut:
                    return EasingFunctions.Sine.EaseOut(t, duration);
                case EaseType.SineInOut:
                    return EasingFunctions.Sine.EaseInOut(t, duration);

                case EaseType.QuadIn:
                    return EasingFunctions.Quad.EaseIn(t, duration);
                case EaseType.QuadOut:
                    return EasingFunctions.Quad.EaseOut(t, duration);
                case EaseType.QuadInOut:
                    return EasingFunctions.Quad.EaseInOut(t, duration);

                case EaseType.CubicIn:
                    return EasingFunctions.Cubic.EaseIn(t, duration);
                case EaseType.CubicOut:
                    return EasingFunctions.Cubic.EaseOut(t, duration);
                case EaseType.CubicInOut:
                    return EasingFunctions.Cubic.EaseInOut(t, duration);

                case EaseType.QuintIn:
                    return EasingFunctions.Quint.EaseIn(t, duration);
                case EaseType.QuintOut:
                    return EasingFunctions.Quint.EaseOut(t, duration);
                case EaseType.QuintInOut:
                    return EasingFunctions.Quint.EaseInOut(t, duration);

                case EaseType.ExpoIn:
                    return EasingFunctions.Expo.EaseIn(t, duration);
                case EaseType.ExpoOut:
                    return EasingFunctions.Expo.EaseOut(t, duration);
                case EaseType.ExpoInOut:
                    return EasingFunctions.Expo.EaseInOut(t, duration);

                case EaseType.CircIn:
                    return EasingFunctions.Circ.EaseIn(t, duration);
                case EaseType.CircOut:
                    return EasingFunctions.Circ.EaseOut(t, duration);
                case EaseType.CircInOut:
                    return EasingFunctions.Circ.EaseInOut(t, duration);

                case EaseType.BackIn:
                    return EasingFunctions.Back.EaseIn(t, duration);
                case EaseType.BackOut:
                    return EasingFunctions.Back.EaseOut(t, duration);
                case EaseType.BackInOut:
                    return EasingFunctions.Back.EaseInOut(t, duration);

                case EaseType.ElasticIn:
                    return EasingFunctions.Elastic.EaseIn(t, duration);
                case EaseType.ElasticOut:
                    return EasingFunctions.Elastic.EaseOut(t, duration);
                case EaseType.ElasticInOut:
                    return EasingFunctions.Elastic.EaseInOut(t, duration);

                case EaseType.BounceIn:
                    return EasingFunctions.Bounce.EaseIn(t, duration);
                case EaseType.BounceOut:
                    return EasingFunctions.Bounce.EaseOut(t, duration);
                case EaseType.BounceInOut:
                    return EasingFunctions.Bounce.EaseInOut(t, duration);

                default:
                    return EasingFunctions.Linear.Ease(t, duration);
            }
        }
    }

    /// <summary>
    ///     A collection of all the standard easing functions.
    /// </summary>
    public static class EasingFunctions {
        public static class Linear {
            public static float Ease(float t, float d) {
                return t / d;
            }
        }

        public static class Sine {
            public static float EaseIn(float t, float d) {
                return -1f * Mathf.Cos(t / d * (Mathf.PI / 2f)) + 1f;
            }

            public static float EaseOut (float t, float d) {
                return Mathf.Sin(t / d * (Mathf.PI / 2f));
            }

            public static float EaseInOut (float t, float d) {
                return -0.5f * (Mathf.Cos(Mathf.PI * t / d) - 1f);
            }
        }

        public static class Quad {
            public static float EaseIn (float t, float d) {
                return (t /= d) * t;
            }

            public static float EaseOut (float t, float d) {
                return -1f * (t /= d) * (t - 2f);
            }

            public static float EaseInOut (float t, float d) {
                if ((t /= d / 2f) < 1f) {
                    return 0.5f * t * t;
                }

                return -0.5f * ((--t) * (t - 2f) - 1f);
            }
        }

        public static class Cubic {
            public static float EaseIn (float t, float d) {
                return (t /= d) * t * t;
            }

            public static float EaseOut (float t, float d) {
                return ((t = t / d - 1f) * t * t + 1);
            }

            public static float EaseInOut (float t, float d) {
                if ((t /= d / 2f) < 1f) {
                    return 0.5f * t * t * t;
                }

                return 0.5f * ((t -= 2f) * t * t + 2f);
            }
        }

        public static class Quart {
            public static float EaseIn (float t, float d) {
                return (t /= d) * t * t * t;
            }

            public static float EaseOut (float t, float d) {
                return -1f * ((t = t / d - 1f) * t * t * t - 1f);
            }

            public static float EaseInOut (float t, float d) {
                t /= d / 2f;
                if (t < 1f) {
                    return 0.5f * t * t * t * t;
                }

                t -= 2f;
                return -0.5f * (t * t * t * t - 2f);
            }
        }

        public static class Quint {
            public static float EaseIn (float t, float d) {
                return (t /= d) * t * t * t * t;
            }

            public static float EaseOut (float t, float d) {
                return ((t = t / d - 1f) * t * t * t * t + 1f);
            }

            public static float EaseInOut (float t, float d) {
                if ((t /= d / 2f) < 1f) {
                    return 0.5f * t * t * t * t * t;
                }

                return 0.5f * ((t -= 2f) * t * t * t * t + 2f);
            }
        }

        public static class Expo {
            public static float EaseIn (float t, float d) {
                return (t == 0f) ? 0f : Mathf.Pow(2f, 10f * (t / d - 1f));
            }

            public static float EaseOut (float t, float d) {
                return t == d ? 1f : (-Mathf.Pow(2f, -10f * t / d) + 1f);
            }

            public static float EaseInOut (float t, float d) {
                if (t == 0) {
                    return 0f;
                }

                if (t == d) {
                    return 1f;
                }

                if ((t /= d / 2f) < 1f) {
                    return 0.5f * Mathf.Pow(2f, 10f * (t - 1f));
                }
                return 0.5f * (-Mathf.Pow(2f, -10f * --t) + 2f);
            }
        }

        public static class Circ {
            public static float EaseIn (float t, float d) {
                return -(Mathf.Sqrt(1f - (t /= d) * t) - 1f);
            }

            public static float EaseOut (float t, float d) {
                return Mathf.Sqrt(1f - (t = t / d - 1f) * t);
            }

            public static float EaseInOut (float t, float d) {
                if ((t /= d / 2f) < 1f) {
                    return -0.5f * (Mathf.Sqrt(1f - t * t) - 1f);
                }

                return 0.5f * (Mathf.Sqrt(1f - (t -= 2f) * t) + 1f);
            }
        }

        public static class Back {
            public static float EaseIn (float t, float d) {
                return (t /= d) * t * ((1.70158f + 1f) * t - 1.70158f);
            }

            public static float EaseOut (float t, float d) {
                return ((t = t / d - 1f) * t * ((1.70158f + 1f) * t + 1.70158f) + 1f);
            }

            public static float EaseInOut (float t, float d) {
                float s = 1.70158f;
                if ((t /= d / 2f) < 1f) {
                    return 0.5f * (t * t * (((s *= (1.525f)) + 1f) * t - s));
                }
                return 0.5f * ((t -= 2f) * t * (((s *= (1.525f)) + 1f) * t + s) + 2f);
            }
        }

        public static class Elastic {
            public static float EaseIn (float t, float d) {
                if (t == 0f) {
                    return 0f;
                }

                if ((t /= d) == 1f) {
                    return 1f;
                }

                float p = d * 0.3f;
                float s = p / 4f;
                return -(1f * Mathf.Pow(2f, 10f * (t -= 1f)) * Mathf.Sin((t * d - s) * (2f * Mathf.PI) / p));
            }

            public static float EaseOut (float t, float d) {
                if (t == 0f) {
                    return 0f;
                }

                if ((t /= d) == 1f) {
                    return 1f;
                }

                float p = d * 0.3f;
                float s = p / 4f;
                return (1f * Mathf.Pow(2f, -10f * t) * Mathf.Sin((t * d - s) * (2f * Mathf.PI) / p) + 1f);
            }

            public static float EaseInOut (float t, float d) {
                if (t == 0f) {
                    return 0f;
                }

                if ((t /= d / 2f) == 2f) {
                    return 1f;
                }

                float p = d * (0.3f * 1.5f);
                float s = p / 4f;

                if (t < 1f) {
                    return -0.5f * (Mathf.Pow(2f, 10f * (t -= 1f)) * Mathf.Sin((t * d - s) * (2f * Mathf.PI) / p));
                }

                return (Mathf.Pow(2f, -10f * (t -= 1f)) * Mathf.Sin((t * d - s) * (2f * Mathf.PI) / p) * 0.5f + 1f);
            }

            public static float Punch (float t, float d) {
                if (t == 0f) {
                    return 0f;
                }

                if ((t /= d) == 1f) {
                    return 0f;
                }

                const float p = 0.3f;
                return (Mathf.Pow(2f, -10f * t) * Mathf.Sin(t * (2f * Mathf.PI) / p));
            }
        }

        public static class Bounce {
            public static float EaseIn (float t, float d) {
                return 1f - EaseOut(d - t, d);
            }

            public static float EaseOut (float t, float d) {
                if ((t /= d) < (1f / 2.75f)) {
                    return (7.5625f * t * t);
                }
                else if (t < (2f / 2.75f)) {
                    return (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f);
                }
                else if (t < (2.5f / 2.75f)) {
                    return (7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f);
                }
                else {
                    return (7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f);
                }
            }

            public static float EaseInOut (float t, float d) {
                if (t < d / 2f) {
                    return EaseIn(t * 2f, d) * 0.5f;
                }
                else {
                    return EaseOut(t * 2f - d, d) * 0.5f + 1f * 0.5f;
                }
            }
        }
    }
}


