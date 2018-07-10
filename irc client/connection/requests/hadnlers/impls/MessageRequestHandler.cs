using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using irc_client.session;
using irc_client.forms;

namespace irc_client.connection.requests.hadnlers {
	public class MessageRequestHandler : IRequestHandler {

		private SessionData _data;

		/// <summary>
		/// Creates a handler witch handles a MessageRequest object. 
		/// </summary>
		/// <param name="data">Data about a user session.</param>
		public MessageRequestHandler(SessionData data) {

			this._data = data;

		}

		public void Handle(IRequest request) {
			MessageRequest castedRequest = (MessageRequest)request;

			IRCMessage newMessage = new IRCMessage(castedRequest.Text, false);
			Contact contact = _data.ContactList.GetOrCreateByLogin(castedRequest.ToLogin);
			DialogData dialog = _data.DialogDictionary.GetDialogByContact(contact);

			dialog.MessageList.AddMessage(newMessage);
			dialog.IsHaveANewMassege = true;

			this._data.ContactList.Updated = true;
			updateDialogForm(contact);

		}

		/// <summary>
		/// Updates info on the dialog form.
		/// </summary>
		/// <param name="contact">User which sent a message.</param>
		private void updateDialogForm(Contact contact) {
			Dialog dialogForm = (Dialog)FormManager.Instance.GetForm(FormType.Dialog);

			if (dialogForm.Companion == contact) {

				dialogForm.Invoke(new Action(() => {

					dialogForm.UpdateMessageList();
					dialogForm.UpdateTitle();

				}));
			}
		}

	}
}
