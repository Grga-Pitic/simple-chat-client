using System.Collections.Generic;

using irc_client.connection.requests;

namespace irc_client.connection {

	/// <summary>
	/// Class queue wrapper. 
	/// </summary>
	public class RequestQueue { // TODO thread-safe

		#region fields

		private Queue<IRequest> queue;

		#endregion

		#region constructors

		/// <summary>
		/// New RequestQueue with empty queue.
		/// </summary>
		public RequestQueue() {

			queue = new Queue<IRequest>();

		}

		#endregion

		#region operations

		/// <summary>
		/// Adds new element to the end of queue.
		/// </summary>
		/// <param name="request">New element.</param>
		public void Enqueue(IRequest request) {

			queue.Enqueue(request);

		}

		/// <summary>
		/// Returns element from begin of queue.
		/// </summary>
		/// <returns>First element of queue</returns>
		public IRequest Dequeue() {

			return queue.Dequeue();

		}

		/// <summary>
		/// Removes all elements from queue.
		/// </summary>
		public void Clear() {

			queue.Clear();

		}

		public bool IsEmpty() {

			if (this.queue.Count == 0) {
				return true;
			}

			return false;

		}

		#endregion

	}
}
