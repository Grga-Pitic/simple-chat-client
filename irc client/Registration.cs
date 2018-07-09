using System;
using System.Windows.Forms;
using System.Threading;

using irc_client.forms;
using irc_client.services;
using irc_client.connection;
using irc_client.connection.requests;
using irc_client.session;

namespace irc_client {
	public partial class Registration : Form {
		public Registration() {
			InitializeComponent();
		}

		private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {

		}

		private void button2_Click(object sender, EventArgs e) {
			this.Hide();
			FormManager.Instance.GetForm(FormType.Auth).Show();
		}

		protected override void OnFormClosing(FormClosingEventArgs e) {

			if (e.CloseReason == CloseReason.UserClosing) {

				e.Cancel = true;
				FormManager.Instance.GetForm(FormType.Auth).Show();
				this.Visible = false;

			}

			base.OnFormClosing(e);

		}

		private void button1_Click(object sender, EventArgs e) {
			// reading the textboxs with a registration data.
			string login           = loginBox.Text;
			string password        = passwordBox.Text;
			string confirmPassword = confirmPasswordBox.Text;
			string nickname        = nicknameBox.Text;
			string addressString   = addressBox.Text;

			OperationStatus.Instance.RegistrationFeedback = false;

			// if password aren't equials then return from the method and writes the message.
			if (!password.Equals(confirmPassword)) {
				MessageBox.Show("Passwords are not equials!");
				return;
			}

			// Повтор кода. надо бы пофиксить
			ServerConnection connection = new ServerConnection(); 
			if (!connection.Open(ServerConnection.STANDART_ADDRESS, ServerConnection.STANDART_PORT)) {
				MessageBox.Show("Connection failed. Host " + ServerConnection.STANDART_ADDRESS + ":" + ServerConnection.STANDART_PORT.ToString() + " not found.");
				return;
			}
			connection.StartListen(); 

			ConnectionService.Instance.StartHandling(connection);

			IRequest request = new RegisterRequest(login, password, nickname);

			RequestRepository.Instance.OutputRequests.Enqueue(request);

			Console.WriteLine(!OperationStatus.Instance.RegistrationFeedback);
			while (!OperationStatus.Instance.RegistrationFeedback) {
				// waiting for the message from the server
				Thread.Sleep(100);
			}

			ConnectionService.Instance.Close(connection);

		}

		private void Registration_Load(object sender, EventArgs e) {
			addressBox.Text = ServerConnection.STANDART_ADDRESS + ":" + ServerConnection.STANDART_PORT;
		}
	}
}
