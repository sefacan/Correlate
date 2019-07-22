﻿using System;
using System.Threading.Tasks;

namespace Correlate
{
	/// <summary>
	/// Extensions for <see cref="IAsyncCorrelationManager"/>.
	/// </summary>
	public static class IAsyncCorrelationManagerExtensions
	{
		/// <summary>
		/// Executes the <paramref name="correlatedTask"/> with its own <see cref="CorrelationContext"/>.
		/// </summary>
		/// <param name="asyncCorrelationManager">The async correlation manager.</param>
		/// <param name="correlatedTask">The task to execute.</param>
		/// <returns>An awaitable that completes once the <paramref name="correlatedTask"/> has executed and the correlation context has disposed.</returns>
		/// <remarks>
		/// When logging and tracing are both disabled, no correlation context is created and the task simply executed as it normally would.
		/// </remarks>
		public static Task CorrelateAsync(this IAsyncCorrelationManager asyncCorrelationManager, Func<Task> correlatedTask)
		{
			return asyncCorrelationManager.CorrelateAsync(null, correlatedTask);
		}

		/// <summary>
		/// Executes the <paramref name="correlatedTask"/> with its own <see cref="CorrelationContext"/>.
		/// </summary>
		/// <param name="asyncCorrelationManager">The async correlation manager.</param>
		/// <param name="correlatedTask">The task to execute.</param>
		/// <param name="onException">A delegate to handle the exception inside the correlation scope, before it is disposed. Returns <see langword="true" /> to consider the exception handled, or <see langword="false" /> to throw.</param>
		/// <returns>An awaitable that completes once the <paramref name="correlatedTask"/> has executed and the correlation context has disposed.</returns>
		/// <remarks>
		/// When logging and tracing are both disabled, no correlation context is created and the task simply executed as it normally would.
		/// </remarks>
		public static Task CorrelateAsync(this IAsyncCorrelationManager asyncCorrelationManager, Func<Task> correlatedTask, OnException onException)
		{
			return asyncCorrelationManager.CorrelateAsync(null, correlatedTask, onException);
		}

		/// <summary>
		/// Executes the <paramref name="correlatedTask"/> with its own <see cref="CorrelationContext"/>.
		/// </summary>
		/// <param name="asyncCorrelationManager">The async correlation manager.</param>
		/// <param name="correlationId">The correlation id to use, or null to generate a new one.</param>
		/// <param name="correlatedTask">The task to execute.</param>
		/// <returns>An awaitable that completes once the <paramref name="correlatedTask"/> has executed and the correlation context has disposed.</returns>
		/// <remarks>
		/// When logging and tracing are both disabled, no correlation context is created and the task simply executed as it normally would.
		/// </remarks>
		public static Task CorrelateAsync(this IAsyncCorrelationManager asyncCorrelationManager, string correlationId, Func<Task> correlatedTask)
		{
			return asyncCorrelationManager.CorrelateAsync(correlationId, correlatedTask, null);
		}
	}
}