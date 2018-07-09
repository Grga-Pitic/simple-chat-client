using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class AddRequest:AbstractRequest, IRequest {

		public const int LOGIN = 0;

		public AddRequest(string login) : base("add", 1) {
			base._requestParams[LOGIN] = login;
		}

		public RequestType Type {
			get {
				return RequestType.Add;
			}
		}

	}
}
