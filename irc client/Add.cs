using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using irc_client.connection;
using irc_client.connection.requests;

namespace irc_client {
	public partial class Add : Form {
		public Add() {
			InitializeComponent();
			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;
		}

		private void addButton_Click(object sender, EventArgs e) {
			addFriendAndHideForm();
		}

		private void addButton_KeyPress(object sender, KeyPressEventArgs e) {
			if (Convert.ToInt32(e.KeyChar) == 13) {
				addFriendAndHideForm();
			}
		}

		private void addFriendAndHideForm() {
			string friendLogin = friendLoginBox.Text;
			RequestRepository.Instance.OutputRequests.Enqueue(new AddRequest(friendLogin));

			friendLoginBox.Text = "";
			this.Hide();
		}
	}
}
