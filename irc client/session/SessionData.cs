using System;
using System.Collections.Generic;
using System.Text;

using irc_client.connection;

namespace irc_client.session {

	/// <summary>
	/// Class-container. Contains a session data.
	/// </summary>
	public class SessionData {

		private ContactList _contactList;

		private DialogDictionary _dialogDictionary;

		#region properties

		/// <summary>
		/// Gets and sets server address.
		/// </summary>
		public string Address      { get; set; }

		/// <summary>
		/// Gets and sets server port.
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// Gets and sets user login.
		/// </summary>
		public string Login        { get; set; }

		/// <summary>
		/// Gets and sets user password.
		/// </summary>
		public string Password     { get; set; }

		/// <summary>
		/// Gets and sets authentication flag.
		/// </summary>
		public bool   AuthComplete { get; set; }

		/// <summary>
		/// Returns a contact list.
		/// </summary>
		public ContactList ContactList {
			get {
				return this._contactList;
			}
		}

		/// <summary>
		/// Returns a dialog dictionary.
		/// </summary>
		public DialogDictionary DialogDictionary {
			get {
				return _dialogDictionary;
			}
		}

		#endregion

		#region constructors

		/// <summary>
		/// Creates new default session.
		/// </summary>
		public SessionData() {

			// Default connection parameters.
			this.Address = ServerConnection.STANDART_ADDRESS;
			this.Port    = ServerConnection.STANDART_PORT;

			// Default user data values.
			this.Login        = "";
			this.Password     = "";
			this.AuthComplete = false;

			// Empty dialogs and contact list. 
			this._dialogDictionary = new DialogDictionary();
			this._contactList      = new ContactList();

		}

		/// <summary>
		/// Creates new session end sets parameters.
		/// </summary>
		/// <param name="address">Address of server</param>
		/// <param name="login">User login</param>
		/// <param name="password">User password</param>
		public SessionData(string address, int port, string login, string password) {

			Address      = address;
			Port         = port;
			Login        = login;
			Password     = password;
			AuthComplete = false;

			this._contactList      = new ContactList();
			this._dialogDictionary = new DialogDictionary();

		}

		#endregion

	}

}
