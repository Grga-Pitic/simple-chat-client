using System;
using System.Threading;

using irc_client.forms;
using irc_client.session;
using irc_client.connection.requests;
using irc_client.connection.requests.hadnlers;

namespace irc_client.connection.handlers {
	public class InputHandler : AbstractHandler, IQueueHandler {

		#region constructors

		public InputHandler(RequestQueue queue) {

			base.Queue = queue;
			base.SetMethod(_ProcessingMethod);

		}

		#endregion

		#region handling methods

		/// <summary>
		/// The method handles a input queue. 
		/// </summary>
		private void _ProcessingMethod() {

			while (base.isRun) {
				if (base.Queue.IsEmpty()) {
					Thread.Sleep(AbstractHandler.PROCESSING_PAUSE);
					continue;
				}

				IRequest request = base.Queue.Dequeue(); // Dequeue request from queue
				IRequestHandler requestHandler = RequestHandlerFactory.Instance.CreateByType(request.Type); // Get necessery handler.

				requestHandler.Handle(request);

			}
		}

		#endregion

	}
}
