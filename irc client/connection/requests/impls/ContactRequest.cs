using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class ContactRequest:AbstractRequest, IRequest {
		public const int LOGIN    = 0;
		public const int NICKNAME = 1;

		public string Nickname => base._requestParams[NICKNAME];
		public string Login    => base._requestParams[LOGIN]; 

		public ContactRequest(string nickname, string login):base("contact", 2) {

			base._requestParams[NICKNAME] = nickname;
			base._requestParams[LOGIN]    = login;

		}

		public RequestType Type {
			get {
				return RequestType.Contact;
			}
		}
	}
}
