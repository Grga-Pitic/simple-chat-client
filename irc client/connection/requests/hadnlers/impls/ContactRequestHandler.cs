using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using irc_client.session;

namespace irc_client.connection.requests.hadnlers {

	public class ContactRequestHandler : IRequestHandler {

		private SessionData _data;

		/// <summary>
		/// Creates a handler witch handles a ContactRequest object. 
		/// </summary>
		/// <param name="data">SessionData object.</param>
		public ContactRequestHandler(SessionData data) {
			this._data = data;
		}

		public void Handle(IRequest request) {

			ContactRequest castedRequest = (ContactRequest)request;
			Contact newContact = new Contact(castedRequest.Login, castedRequest.Nickname);
			this._data.ContactList.AddContact(newContact);

			this._data.ContactList.Updated = true;
		}

	}

}
