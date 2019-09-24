using System;
using System.Windows.Forms;
using System.Threading;

using irc_client.session;
using irc_client.connection;
using irc_client.connection.requests;
using irc_client.services;
using irc_client.services.parcers;
using irc_client.forms;

namespace irc_client {
	public partial class Auth : Form {

		private ConnectionData conData;
		private ServerConnection  connection;

		public Auth() {
			InitializeComponent();
		}

		private void buttonEnter_Click(object sender, EventArgs e) {
			
			if (loginBox.Text.Length == 0) {
				MessageBox.Show("Login field is empty");
				return;
			}

			if (passwordBox.Text.Length == 0) {
				MessageBox.Show("Password field is empty");
				return;
			}

			FormManager.Instance.GetForm(FormType.Contacts).AddOwnedForm(this); // просто костыль. я щас слишком спать хочу чтоб разбираться, что оно делает и почему без него не работает.

			OperationStatus.Instance.AuthFeedback = false;
			OperationStatus.Instance.AuthSuccess  = false;

			ParcedAddress address = new ParcedAddress();
			if (!Parcer.ParceAddress(addressBox.Text, address)) {
				// if parced failed
				MessageBox.Show("Address format error! Example: 127.0.0.1:6666");
				return;
			}

			conData       = new ConnectionData(address.IP, address.Port, loginBox.Text, passwordBox.Text);
			connection = new ServerConnection();

			Session.Instance.Data = conData;
			if (!connection.Open(conData.Address, conData.Port)) {
				MessageBox.Show("Connection failed. Host " + conData.Address + ":" + conData.Port.ToString() + " not found.");
				return;
			}
			connection.StartListen();

			ConnectionService.Instance.StartHandling(connection);

			RequestQueue outputQueue = RequestRepository.Instance.OutputRequests;
			outputQueue.Enqueue(new AuthRequest(conData.Login, conData.Password));
			while (!OperationStatus.Instance.AuthFeedback) {
				// do nothing
				Thread.Sleep(100);
			}

			if (!OperationStatus.Instance.AuthSuccess) {
				MessageBox.Show("Incorrect login/password");
				ConnectionService.Instance.Close(connection);
				return;
			} else {
				FormManager.Instance.GetForm(FormType.Contacts).Show();
			}

			outputQueue.Enqueue(new ContactListRequest());

			outputQueue.Enqueue(new MessageRequest("test", "mainadmin")); // debugging

			this.Hide(); 
			

		}

		private void buttonRegister_Click(object sender, EventArgs e) {

			this.Hide();
			Form reg = FormManager.Instance.GetForm(FormType.Registration);
			reg.Show();

		}

		public ServerConnection Connection {
			get {
				return this.connection;
			}
		}

		private void Auth_Load(object sender, EventArgs e) {

			addressBox.Text = ServerConnection.STANDART_ADDRESS + ":" + ServerConnection.STANDART_PORT;

		}

		private void Auth_VisibleChanged(object sender, EventArgs e) {

			if (Visible == true) {
				loginBox.Text    = "";
				passwordBox.Text = "";
			}

		}
	}
}
