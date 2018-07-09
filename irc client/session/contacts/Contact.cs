using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {


	/// <summary>
	/// Stores user contact data. A nickname can change. A login is static.
	/// </summary>
	public class Contact {

		public Contact(string login) {

			this.Login    = login;
			this.Nickname = "";

		}

		public Contact(string login, string nickname) {

			this.Login    = login; 
			this.Nickname = nickname; 

		}
		
		public string Login { get; }
		public string Nickname { get; set; }

	}
}
