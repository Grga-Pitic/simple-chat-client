using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class RegisterRequest : AbstractRequest, IRequest {

		public const int LOGIN    = 0;
		public const int PASSWORD = 1;
		public const int NICKNAME = 2;

		public RegisterRequest(string login, string password, string nickname) : base("reg", 3) {

			base._requestParams[LOGIN]    = login;
			base._requestParams[PASSWORD] = password;
			base._requestParams[NICKNAME] = nickname;

		}

		public RequestType Type {
			get {
				return RequestType.Register;
			}
		}

	}
}
