using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class AuthRequest : AbstractRequest, IRequest {

		public const int LOGIN = 0;
		public const int PASSWORD = 1;

		public AuthRequest(string login, string password) : base("auth", 2) {

			base._requestParams[LOGIN]    = login;
			base._requestParams[PASSWORD] = password;

		}

		public RequestType Type {
			get {
				return RequestType.Auth;
			}
		}

	}
}
