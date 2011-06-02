using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace InVision.Extensions
{
	public static class QueueExtensions
	{
		/// <summary>
		/// Enqueues all.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="queue">The queue.</param>
		/// <param name="sequence">The sequence.</param>
		public static void EnqueueAll<T>(this ConcurrentQueue<T> queue, IEnumerable<T> sequence)
		{
			foreach (T data in sequence) {
				queue.Enqueue(data);
			}
		}

		/// <summary>
		/// Enqueues all.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="queue">The queue.</param>
		/// <param name="sequence">The sequence.</param>
		public static void EnqueueAll<T>(this Queue<T> queue, IEnumerable<T> sequence)
		{
			foreach (T data in sequence) {
				queue.Enqueue(data);
			}
		}
	}
}