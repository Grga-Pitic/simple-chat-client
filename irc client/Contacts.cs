using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using irc_client.session;
using irc_client.connection;
using irc_client.services;
using irc_client.forms;


namespace irc_client {
	public partial class Contacts : Form {

		private const string NOTHIFICATION_SYMBOL = "*";
		private ContextMenu _menu;
		public Contacts() {
			InitializeComponent();
			_menu = new ContextMenu();
			_menu.MenuItems.Add("Delete selected");
			_menu.MenuItems.Add("Delete from local list");
			_menu.MenuItems.Add("Copy login");
			_menu.MenuItems.Add("Copy nickname");
			_menu.MenuItems[0].Click += new System.EventHandler(contextMenuDeleteClick);
			_menu.MenuItems[1].Click += new System.EventHandler(contextMenuDeleteLocalClick);
			_menu.MenuItems[2].Click += new System.EventHandler(contextMenuCopyLoginClick);
			_menu.MenuItems[3].Click += new System.EventHandler(contextMenuCopyNickClick);
			contactsList.ContextMenu = _menu;
		}

		private void contextMenuDeleteClick(object sender, EventArgs e) {
			deleteContactByIndex(contactsList.SelectedIndex);
		}

		private void contextMenuDeleteLocalClick(object sender, EventArgs e) {

		}

		private void contextMenuCopyLoginClick(object sender, EventArgs e) {

		}

		private void contextMenuCopyNickClick(object sender, EventArgs e) {

		}

		private void deleteContactByIndex(int index) {
			SessionData data = Session.Instance.Data;
			// checking for out of range
			if (index >= data.ContactList.Size) {
				return;
			}

			if (index < 0) {
				return;
			}
			string msg = "Deleted " + data.ContactList.GetByIndex(index).Login + " from contact list. Feature isn't implemented. Will be implemented when I come back from army.";
			MessageBox.Show(msg);
		}

		public void UpdateContactByIndex(int index) {

			SessionData data = Session.Instance.Data;
			Contact outputtedContact = data.ContactList.GetByIndex(index); // A contact which will be outputted
			String outputtedLine = outputtedContact.Login;
			bool isNewMessage = data.DialogDictionary.GetDialogByContact(outputtedContact).IsHaveANewMassege;

			if (isNewMessage) {
				outputtedLine += NOTHIFICATION_SYMBOL;
			}

			contactsList.Items[index] = outputtedLine;

		}

		public void UpdateContactList() {
			contactsList.Items.Clear(); // TODO I'll fix it later.
										// there's no more constant thing than temporary

			SessionData data = Session.Instance.Data;

			for (int i = 0; i < data.ContactList.Size; i++) {
				Contact outputtedContact = data.ContactList.GetByIndex(i); // A contact which will be outputted
				String outputtedLine = outputtedContact.Login;

				bool isNewMessage = data.DialogDictionary.GetDialogByContact(outputtedContact).IsHaveANewMassege;

				if (isNewMessage) {
					outputtedLine += NOTHIFICATION_SYMBOL;
				}

				contactsList.Items.Add(outputtedLine);
			}

		}

		public ListBox GetList() {
			return this.contactsList;
		}

		private void openDialog(int contactIndex) {


			SessionData data = Session.Instance.Data;
			// checking for out of range
			if (contactIndex >= data.ContactList.Size) {
				return;
			}

			if (contactIndex < 0) {
				return;
			}

			Dialog dialogForm = (Dialog)FormManager.Instance.GetForm(FormType.Dialog);

			Contact companion = data.ContactList.GetByIndex(contactIndex);

			dialogForm.Companion = companion;
			dialogForm.Data = data.DialogDictionary.GetDialogByContact(companion);
			dialogForm.UpdateTitle();
			dialogForm.Show();
			dialogForm.UpdateMessageList();

		}

		private void contactsList_MouseDoubleClick(object sender, MouseEventArgs e) {

			int index = this.contactsList.IndexFromPoint(e.Location);
			contactsList.SelectedIndex = index;
			openDialog(index);
	
		}

		private void contactsList_MouseClick(object sender, MouseEventArgs e) {
			int index = this.contactsList.IndexFromPoint(e.Location);
			contactsList.SelectedIndex = index;
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

		}

		private void toolLogout_Click(object sender, EventArgs e) {
			
			Auth formAuth = (Auth)FormManager.Instance.GetForm(FormType.Auth);

			ConnectionService.Instance.Close(formAuth.Connection);

			this.Hide();
			formAuth.Show();

			this.contactsList.Items.Clear();
		}

		private void Contacts_FormClosing(object sender, FormClosingEventArgs e) {

			closeTheProgram();

		}

		private void toolExit_Click(object sender, EventArgs e) {

			closeTheProgram();

		}

		private void closeTheProgram() {
			Auth formAuth = (Auth)FormManager.Instance.GetForm(FormType.Auth);
			ConnectionService.Instance.Close(formAuth.Connection);

			formAuth.Close();
		}

		private void toolAddContact_Click(object sender, EventArgs e) {
			FormManager.Instance.GetForm(FormType.Add).ShowDialog();
		}
	}
}
