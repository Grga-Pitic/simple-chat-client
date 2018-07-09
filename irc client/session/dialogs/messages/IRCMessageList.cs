using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {
	public class IRCMessageList {

		private List<IRCMessage> _messageList;

		public IRCMessageList() {
			this._messageList = new List<IRCMessage>();
		}

		public IRCMessage GetMessageByIndex(int index) {
			return _messageList[index];
		}

		public int GetSize() {
			return _messageList.Count;
		}

		public void AddMessage(IRCMessage newMessage) {
			this._messageList.Add(newMessage);
		}

	}
}
