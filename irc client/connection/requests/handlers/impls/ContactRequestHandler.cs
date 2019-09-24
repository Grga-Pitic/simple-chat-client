using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irc_client.forms;
using irc_client.session;

namespace irc_client.connection.requests.hadnlers {

	public class ContactRequestHandler : IRequestHandler {

		private ConnectionData _data;

		/// <summary>
		/// Creates a handler witch handles a ContactRequest object. 
		/// </summary>
		/// <param name="data">SessionData object.</param>
		public ContactRequestHandler(ConnectionData data) {
			this._data = data;
		}

		public void Handle(IRequest request) {

			ContactRequest castedRequest = (ContactRequest)request;
			Contact newContact = new Contact(castedRequest.Login, castedRequest.Nickname);
			this._data.ContactList.AddContact(newContact);
			updateContactList();
		}

		#region operations

		/// <summary>
		/// Updates contact list on the contacts form.
		/// </summary>
		private void updateContactList() {

			Contacts contactForm = (Contacts)FormManager.Instance.GetForm(FormType.Contacts);
			contactForm.Invoke(new Action(() => {

				contactForm.UpdateContactList();

			}));

		}

		#endregion

	}

}
