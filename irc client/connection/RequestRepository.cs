using irc_client.connection.handlers;

namespace irc_client.connection {

	/// <summary>
	/// Singleton.
	/// Contains input and output queue of requests.
	/// </summary>
	public class RequestRepository {

		#region fields

		private static RequestRepository instance;

		private RequestQueue inputRequests;
		private RequestQueue outputRequests;

		#endregion

		#region constructors

		/// <summary>
		/// Creates new repository with empty queues.
		/// </summary>
		private RequestRepository() {
			inputRequests  = new RequestQueue();
			outputRequests = new RequestQueue();
		}

		#endregion

		#region properies

		public RequestQueue InputRequests  => inputRequests;
		public RequestQueue OutputRequests => outputRequests;

		public IQueueHandler InputHandler  { get; set; }
		public IQueueHandler OutputHandler { get; set; }

		public static RequestRepository Instance {
			get {
				if (instance == null) {
					instance = new RequestRepository();
				}

				return instance;
			}
		}

		#endregion

	}
}
