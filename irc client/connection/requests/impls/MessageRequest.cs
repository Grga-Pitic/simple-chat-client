using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public class MessageRequest : AbstractRequest, IRequest {

		public const int TEXT = 0;
		public const int TO_LOGIN = 1;

		public MessageRequest(string text, string toLogin) : base("msg", 2) {

			base._requestParams[TEXT]     = text;
			base._requestParams[TO_LOGIN] = toLogin;

		}

		public string Text {
			get {
				return base._requestParams[TEXT];
			}
		}

		public string ToLogin {
			get {
				return base._requestParams[TO_LOGIN];
			}
		}

		public RequestType Type {
			get {
				return RequestType.Message;
			}
		}

	}
}
