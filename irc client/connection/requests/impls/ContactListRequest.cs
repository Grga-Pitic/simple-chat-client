using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class ContactListRequest : IRequest {
		public string RequestString {
			get {
				return "contacts";
			}
		}

		public RequestType Type {
			get {
				return RequestType.ContactList;
			}
		}
	}
}
