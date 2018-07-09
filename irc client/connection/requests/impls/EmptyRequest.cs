using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class EmptyRequest : IRequest {
		public string RequestString {
			get {
				return "empty";
			}
		}

		public RequestType Type {
			get {
				return RequestType.Empty;
			}
		}
	}
}
