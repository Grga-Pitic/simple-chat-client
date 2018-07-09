using System.Threading;

namespace irc_client.connection.handlers {
	public abstract class AbstractHandler : IQueueHandler {

		#region constants

		public const int PROCESSING_PAUSE = 1;

		#endregion

		#region delegates

		protected delegate void ProcessingMethod();

		#endregion

		#region properties

		private ProcessingMethod method;
		private Thread           thread;

		private RequestQueue queue;

		#endregion

		#region constructors

		public AbstractHandler() {
			isRun = true;
		}

		#endregion

		#region operations

		public void AbortHandling() {

			isRun = false;

		}

		public void StartHandling() {
			this.thread = new Thread(new ThreadStart(method));
			this.thread.Start();
		}

		#endregion

		#region properties

		protected RequestQueue Queue {
			get {
				return this.queue;
			}
			set {
				this.queue = value;
			}
		}

		protected bool isRun { get; set; }

		protected void SetMethod(ProcessingMethod method) {
			this.method = method;
		}

		#endregion

	}
}
