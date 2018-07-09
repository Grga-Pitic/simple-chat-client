using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using irc_client.session;

namespace irc_client.connection.requests.hadnlers {
	public class RequestHandlerFactory {

		private static RequestHandlerFactory _instanse;
		
		public IRequestHandler CreateByType(RequestType type) {

			// if a type is the AuthSuccess, the AuthFailed, the RegistationSuccess and 
			// the RegistrationFailed
			if ((int)type >= (int)RequestType.AuthSuccess) {
				return new StatusRequestHandler(OperationStatus.Instance);
			}

			switch (type) {
				case RequestType.Message:
					return new MessageRequestHandler(Session.Instance.Data);
				case RequestType.Contact:
					return new ContactRequestHandler(Session.Instance.Data);
			}

			return new EmptyRequestHandler();
		}

		public static RequestHandlerFactory Instance {
			get {
				if (_instanse == null) {
					_instanse = new RequestHandlerFactory();
				}
				return _instanse;
			}
		}

	}
}
