using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public abstract class AbstractRequest:IRequest {
		private string _type;
		protected IList<string> _requestParams;

		public AbstractRequest(string type, int size) {
			
			this._type = type;
			this._requestParams = new List<string>(size);

			for (int i = 0; i < size; i++) {
				this._requestParams.Add("");
			}
			
		}

		public string RequestString {
			get {

				var requestString = _type + ":";
				foreach (var param in _requestParams) {
					requestString += param + "&";
				}

				requestString = requestString.Substring(0, requestString.Length - 1);
				return requestString;

			}
		}

		public RequestType Type { get; }

	}
}
