using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {
	public class IRCMessage {

		public string Text   { get; }
		public bool   IsItMe { get; }

		public IRCMessage(string text, bool isItMe) {
			this.IsItMe = isItMe;
			this.Text   = text;
		}

	}
}
