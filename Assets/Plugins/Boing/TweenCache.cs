using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boing {
    public static class TweenCache<T> where T : new() {
        private static Stack<T> objectStack = new Stack<T>(10);

        public static void WarmCache(int numObjects) {
            numObjects -= objectStack.Count;
            if (numObjects > 0) {
                for (int i = 0; i < numObjects; i++) {
                    objectStack.Push(new T());
                }
            }
        }

        public static T Pop() {
            if (objectStack.Count > 0) {
                return objectStack.Pop();
            }

            return new T();
        }

        public static void Push(T obj) {
            objectStack.Push(obj);
        }
    }
}