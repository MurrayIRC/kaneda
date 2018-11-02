using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boing {
    public partial class Boing : MonoBehaviour {
        public static EaseType DefaultEaseType = EaseType.SineIn;
        public static bool EnableNullChecking = false;
        public static bool FlushTweensOnLevelLoad = false;

        #region Caching Flags
        public static bool CacheIntTweens = false;
        public static bool CacheFloatTweens = false;
        public static bool CacheVector2Tweens = false;
        public static bool CacheVector3Tweens = false;
        public static bool CacheVector4Tweens = false;
        public static bool CacheQuaternionTweens = false;
        public static bool CacheColorTweens = false;
        public static bool CacheColor32Tweens = false;
        public static bool CacheRectTweens = false;
        #endregion

        List<ITweenable> activeTweens = new List<ITweenable>();
        List<ITweenable> tempTweens = new List<ITweenable>();

        List<ITweenable> removedTweens = new List<ITweenable>();

        static bool applicationIsQuitting;

        private bool isUpdating;

        private static Boing instance;
        public static Boing Instance {
            get {
                if (!instance && !applicationIsQuitting) {
                    instance = FindObjectOfType(typeof(Boing)) as Boing;

                    if (!instance) {
                        GameObject obj = new GameObject("SynTween");
                        instance = obj.AddComponent<Boing>();
                        DontDestroyOnLoad(obj);
                    }
                }
                return instance;
            }
        }

        #region Value Tweens

        public static FloatTween TweenValue(float from, float to, float duration = 0.5f) {
            TweenValueTarget<float> target = new TweenValueTarget<float>(from);
            FloatTween tween = FloatTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        public static IntTween TweenValue (int from, int to, float duration = 0.5f) {
            TweenValueTarget<int> target = new TweenValueTarget<int>(from);
            IntTween tween = IntTween.Create();
            tween.Initialize(target, to, duration);
            return tween;
        }

        #endregion

        #region MonoBehaviour Implementation

        private void Awake () {
            if (instance == null) {
                instance = this;
            }

            SceneManager.sceneLoaded -= OnSceneWasLoaded;
            SceneManager.sceneLoaded += OnSceneWasLoaded;
        }

        private void OnApplicationQuit () {
            instance = null;
            Destroy(this.gameObject);
            applicationIsQuitting = true;
        }

        private void OnSceneWasLoaded(Scene scene, LoadSceneMode loadSceneMode) {
            if (loadSceneMode == LoadSceneMode.Single && FlushTweensOnLevelLoad) {
                activeTweens.Clear();
            }
        }

        private void Update () {
            isUpdating = true;

            tempTweens.Clear();
            tempTweens.AddRange(activeTweens);
            for (int i = 0; i < tempTweens.Count; i++) {
                ITweenable tween = tempTweens[i];

                if (removedTweens.Contains(tween)) {
                    continue;
                }

                if (tween.Update()) {
                    // If true, the tween has completed.
                    tween.RecycleSelf();
                    activeTweens.Remove(tween);
                }
            }

            removedTweens.Clear();

            isUpdating = false;
        }

        #endregion

        #region Tween Management

        public void AddTween(ITweenable tween) {
            activeTweens.Add(tween);
        }

        public void RemoveTween(ITweenable tween) {
            tween.RecycleSelf();
            activeTweens.Remove(tween);

            if (isUpdating) {
                removedTweens.Add(tween);
            }
        }

        public void StopAllTweens(bool shouldCompleteTweens = false) {
            for (int i = activeTweens.Count - 1; i >= 0; i--) {
                activeTweens[i].Stop(shouldCompleteTweens);
            }
        }

        public List<ITweenable> GetAllTweensWithContext(object context) {
            List<ITweenable> foundTweens = new List<ITweenable>();

            for (int i = 0; i < activeTweens.Count; i++) {
                if (activeTweens[i] is ITweenable && (activeTweens[i] as ITweenControl).Context == context) {
                    foundTweens.Add(activeTweens[i]);
                }
            }

            return foundTweens;
        }

        public void StopAllTweensWithContext(object context, bool shouldCompleteTweens = false) {
            for (int i = activeTweens.Count - 1; i >= 0; i--) {
                if (activeTweens[i] is ITweenable && (activeTweens[i] as ITweenControl).Context == context) {
                    activeTweens[i].Stop(shouldCompleteTweens);
                }
            }
        }

        public List<ITweenable> GetAllTweensWithTarget(object target) {
            List<ITweenable> foundTweens = new List<ITweenable>();

            for (int i = 0; i < activeTweens.Count; i++) {
                if (activeTweens[i] is ITweenControl) {
                    ITweenControl control = activeTweens[i] as ITweenControl;
                    if (control.GetTargetObject() == target) {
                        foundTweens.Add(activeTweens[i] as ITweenable);
                    }
                }
            }

            return foundTweens;
        }

        public void StopAllTweensWithTarget (object target, bool shouldCompleteTweens = false) {
            for (int i = activeTweens.Count - 1; i >= 0; i--) {
                if (activeTweens[i] is ITweenControl) {
                    ITweenControl control = activeTweens[i] as ITweenControl;
                    if (control.GetTargetObject() == target) {
                        control.Stop(shouldCompleteTweens);
                    }
                }
            }
        }

        #endregion
    }
}