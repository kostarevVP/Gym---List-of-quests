using Cysharp.Threading.Tasks;
using System;
using System.Diagnostics;

namespace WKosArch.Common.Utils.Async {
	public static class TaskExtensions {
		/// <summary>
        /// Executes a task in a async void context. Uncaught exceptions are logged to the console
        /// </summary>
        [DebuggerHidden]
        public static async void RunAsync(this UniTask task)
        {
            /*
             * In a regular C# application, this would be dangerous. Uncaptured exceptions
             * inside an async void method cause the application to crash because they
             * can't be caught by the caller.
             *
             * However, this is Unity. Uncaught exceptions, are captured and Logged to the
             * console by Unity's SyncronizationContext.
             */
            await task;
        }

        /// <summary>
        /// Executes a task in a async void context. Uncaught exceptions are logged to the console
        /// </summary>
        [DebuggerHidden]
        public static async void RunAsync(this UniTask task, Action continuation)
        {
            /*
             * In a regular C# application, this would be dangerous. Uncaptured exceptions
             * inside an async void method cause the application to crash because they
             * can't be caught by the caller.
             *
             * However, this is Unity. Uncaught exceptions, are captured and Logged to the
             * console by Unity's SyncronizationContext.
             */
            await task;
            continuation?.Invoke();
        }
	}
}