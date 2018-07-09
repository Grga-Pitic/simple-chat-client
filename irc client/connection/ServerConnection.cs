using System;
using System.Text;
using System.Threading;

using System.Net.Sockets;
using System.Windows.Forms;

using irc_client.connection.requests;

namespace irc_client.connection {

	/// <summary>
	/// Class is used to get and send data.
	/// Also, it is necessary to work with a socket.
	/// </summary>
	public class ServerConnection {

		#region constants

		public const string STANDART_ADDRESS = "localhost";
		public const int    STANDART_PORT    = 6666;

		#endregion

		#region fields 
		private Socket socket;

		private Thread listenThread;

		private bool _isClosed;
		#endregion

		#region constructors

		public ServerConnection() {
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}

		#endregion

		#region operations

		/// <summary>
		/// Opens the socket connection. If connection failed then returns false. Else returns true.
		/// </summary>
		/// <param name="address">Domain or IP address of server.</param>
		/// <param name="port">Connection port.</param>
		/// <returns></returns>
		public bool Open(string address, int port) {

			try {
				socket.Connect(address, port);
				_isClosed = false;
				return true;
			} catch (SocketException ex) {
				return false;
			}

		}

		/// <summary>
		/// Creates new thread which listen input data from socket.
		/// </summary>
		public void StartListen() {

			listenThread = new Thread(new ThreadStart(StartLisnening));
			listenThread.Start(); // start listening

		}

		/// <summary>
		/// Closes the socket.
		/// </summary>
		public void Close() {
			socket.Close();
			_isClosed = true;
		}

		/// <summary>
		/// Prepares a data and sends it.
		/// </summary>
		/// <param name="query">Query string</param>
		public void SendQuery(string query) {

			int length = Encoding.ASCII.GetByteCount(query);

			byte[] toSendLength = BitConverter.GetBytes (length);
			byte[] toSend       = Encoding.UTF8.GetBytes(query);

			try {
				socket.Send(toSendLength);
				socket.Send(toSend);
			} catch(ObjectDisposedException ex) {
				MessageBox.Show(ex.Message);
			}
			
			
		}
		#endregion

		#region properties

		public bool IsClosed => _isClosed;

		#endregion

		/// <summary>
		/// Listens server.
		/// Processes input data stream. Enqueues Requests to input queue.
		/// </summary>
		private void StartLisnening() {

			Console.WriteLine("thread started");

			for (; ; ) {

				byte[] receivedLength;
				byte[] receivedMessage;

				string answer;
				
				try {
					receivedLength = new byte[4];
				
					socket.Receive(receivedLength);
					receivedMessage = new byte[System.BitConverter.ToInt32(receivedLength, 0)];
					socket.Receive(receivedMessage);
				
					answer = System.Text.Encoding.ASCII.GetString(receivedMessage);
					answer = answer.Substring(0, answer.Length);

					IRequest newRequest = RequestFactory.Instance.CreateRequestByString(answer);

					RequestRepository.Instance.InputRequests.Enqueue(newRequest);
				
					Console.WriteLine("ответ сервера: " + answer);
				}
				catch (SocketException ex) {
					MessageBox.Show(ex.Message);
					Close();
				}
				catch (ObjectDisposedException ex) {
					Console.WriteLine(ex.Message);
				}

				if (_isClosed) {
					break;
				}

				Thread.Sleep(100);
			}
		}
	}
}
