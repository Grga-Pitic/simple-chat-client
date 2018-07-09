using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {
	public class DialogData {

		private IRCMessageList _messageList;
		private Contact        _companion;

		public Contact        Companion {
			get {
				return this._companion;
			}
		}
		public IRCMessageList MessageList {
			get {
				return _messageList;
			}
		}

		public DialogData(Contact companion) {

			this._messageList = new IRCMessageList();
			this._companion   = companion;

		}

		public bool IsHaveANewMassege { get; set; }

	}
}
