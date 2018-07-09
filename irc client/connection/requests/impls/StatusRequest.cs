using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class StatusRequest : IRequest {

		public StatusRequest(string requestString, RequestType type) {

			this.RequestString = requestString;
			this.Type = type;

		}

		public RequestType Type {
			get;
			private set;
		}

		public string RequestString {
			get;
			private set;
		}

	}
}
