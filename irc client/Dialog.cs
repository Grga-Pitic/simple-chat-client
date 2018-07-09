using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using irc_client.session;
using irc_client.connection;
using irc_client.connection.requests;
using irc_client.forms;

namespace irc_client {
	public partial class Dialog : Form {

		private Contact _companion;

		public Contact Companion {
			get {
				return this._companion;
			}
			set {
				if (!value.Login.Equals(Companion)) {
					this.messageTextBox.Text = "";
				}
				this._companion = value;
			}
		}

		public DialogData Data { get; set; }

		public Dialog() {
			InitializeComponent();
		}

		private void sendButton_Click(object sender, EventArgs e) {
			sendMessage();
		}

		public void UpdateMessageList() {

			messageBox.Items.Clear();

			for (int i = 0; i < Data.MessageList.GetSize(); i++) {
				IRCMessage messageForOutput = Data.MessageList.GetMessageByIndex(i);
				string line;

				if (messageForOutput.IsItMe) {
					line = "me: " + messageForOutput.Text;
				} else {
					line = Companion.Nickname + ": " + messageForOutput.Text;
				}

				
				messageBox.Items.Add(line);
				messageBox.TopIndex = messageBox.Items.Count - 1;
			}
			
		}

		private void Dialog_FormClosing(object sender, FormClosingEventArgs e) {
			Hide();
			e.Cancel = true;
		}

		public void UpdateTitle() {

			this.Text = Companion.Nickname;
			if (Data.IsHaveANewMassege) {
				this.Text += " – New message!";
			}
		}

		private void messageTextBox_Enter(object sender, EventArgs e) {
			Data.IsHaveANewMassege = false;
			UpdateTitle();
			Contacts contactsForm = (Contacts)FormManager.Instance.GetForm(FormType.Contacts);
			contactsForm.UpdateContactList();
		}

		private void messageTextBox_KeyPress(object sender, KeyPressEventArgs e) {
			if (Convert.ToInt32(e.KeyChar) == 13) {
				sendMessage();
			}
		}

		private void sendMessage() {

			if (messageTextBox.Text.Equals("")) {
				return;
			}

			IRCMessage message = new IRCMessage(messageTextBox.Text, true);
			Data.MessageList.AddMessage(message);

			RequestQueue outputQueue = RequestRepository.Instance.OutputRequests;

			outputQueue.Enqueue(new MessageRequest(message.Text, Companion.Login));

			UpdateMessageList();
			messageTextBox.Text = "";
		}
	}
}
