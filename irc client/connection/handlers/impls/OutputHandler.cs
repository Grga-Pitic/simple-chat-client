using System;
using System.Threading;

namespace irc_client.connection.handlers {
	public class OutputHandler : AbstractHandler, IQueueHandler {

		#region constructors

		public OutputHandler(RequestQueue queue, ServerConnection connection) {
			
			base.Queue = queue;
			base.SetMethod(_ProcessingMethod);

			this.Connection = connection;

		}

		public OutputHandler(RequestQueue queue) {

			base.Queue = queue;
			base.SetMethod(_ProcessingMethod);

		}

		#endregion

		#region handling methods

		/// <summary>
		/// The method handles a input queue. 
		/// </summary>
		private void _ProcessingMethod() {
			while (isRun) {

				if (base.Queue.IsEmpty()) {
					Thread.Sleep(AbstractHandler.PROCESSING_PAUSE);
					continue;
				}

				string query = Queue.Dequeue().RequestString;
				Connection.SendQuery(query);

			}
		}

		#endregion

		#region properties

		public ServerConnection Connection { get; set; }
		
		#endregion
	}
}
