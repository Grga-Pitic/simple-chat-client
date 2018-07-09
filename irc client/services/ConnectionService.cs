using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using irc_client.connection;
using irc_client.connection.handlers;
using irc_client.forms;

namespace irc_client.services {
	public class ConnectionService {

		private static ConnectionService instance;

		/// <summary>
		/// Creates a input and output data handlers and starts handling data from server.
		/// </summary>
		/// <param name="connection">Opened server connection.</param>
		public void StartHandling(ServerConnection connection) {

			if (connection.IsClosed) {
				Console.WriteLine("Debug message: Handling data was started with a closed server connection");
			}

			RequestQueue outputQueue = RequestRepository.Instance.OutputRequests;
			RequestQueue inputQueue = RequestRepository.Instance.InputRequests;

			IQueueHandler outputHandler = new OutputHandler(outputQueue, connection);
			IQueueHandler inputHandler = new InputHandler(inputQueue);

			outputQueue.Clear();
			inputQueue.Clear();

			RequestRepository.Instance.OutputHandler = outputHandler;
			RequestRepository.Instance.InputHandler = inputHandler;
			outputHandler.StartHandling();
			inputHandler.StartHandling();

		}

		/// <summary>
		/// Aborts handling the input and output data stream and closes a server connection. 
		/// </summary>
		/// <param name="connection">Server connection witch must be closed.</param>
		public void Close(ServerConnection connection) {
			connection.Close();

			RequestRepository.Instance.InputHandler.AbortHandling();
			RequestRepository.Instance.OutputHandler.AbortHandling();
		}

		public static ConnectionService Instance {
			get {
				if (instance == null) {
					instance = new ConnectionService();
				}
				return instance;
			}
		}

	}
}
