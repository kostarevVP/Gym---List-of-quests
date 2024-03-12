using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEditor;
using UnityEngine;

namespace WKosArch.Common.Utils.Async
{
    public class UnityAwaiters
    {
        private static readonly WaitForEndOfFrame endOfFrameWaiter = new WaitForEndOfFrame();

        public static async UniTask WaitForSeconds(float seconds, CancellationToken cancellationToken = default)
        {
#if UNITY_EDITOR
            if (!UnityEngine.Application.isPlaying)
            {
                // When the editor is not playing
                // scaled time is the same as realtime
                await WaitForSecondsRealtime(seconds, cancellationToken);
                return;
            }
#endif
            float endTime = Time.time + seconds;
            while (Time.time < endTime)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Yield();
            }
        }

        public static async UniTask WaitForSecondsRealtime(float seconds, CancellationToken cancellationToken = default)
        {
#if UNITY_EDITOR
            if (!UnityEngine.Application.isPlaying)
            {
                float editorEndTime = (float)EditorApplication.timeSinceStartup + seconds;
                while ((float)EditorApplication.timeSinceStartup < editorEndTime)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await UniTask.Yield();
                }

                return;
            }
#endif

            float endTime = Time.realtimeSinceStartup + seconds;
            while (Time.realtimeSinceStartup < endTime)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Yield();
            }
        }

        public static async UniTask WaitUntil(Func<bool> predicate, CancellationToken cancellationToken = default)
        {
            while (!predicate.Invoke())
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Yield();
            }
        }

        public static async UniTask WaitWhile(Func<bool> predicate, CancellationToken cancellationToken = default)
        {
            while (predicate.Invoke())
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Yield();
            }
        }

        public static UniTask WaitForTime(TimeSpan timeSpan, CancellationToken cancellationToken = default)
        {
            return WaitForSeconds((float)timeSpan.TotalSeconds, cancellationToken);
        }

        public static UniTask WaitForRealtime(TimeSpan timeSpan, CancellationToken cancellationToken = default)
        {
            return WaitForSecondsRealtime((float)timeSpan.TotalSeconds, cancellationToken);
        }

        public static async UniTask WaitForFrames(int frameCount, CancellationToken cancellationToken = default)
        {
            int current = 0;
            while (current < frameCount)
            {
                await WaitNextFrame(cancellationToken);
                current++;
            }
        }

        public static YieldAwaitable WaitNextFrame()
        {
            return UniTask.Yield();
        }

        public static async UniTask WaitNextFrame(CancellationToken cancellationToken)
        {
            await UniTask.Yield();
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}