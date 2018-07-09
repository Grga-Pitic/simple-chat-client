using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using irc_client.session;
using irc_client.connection.requests;

namespace irc_client.connection {
	public class RequestFactory {

		private const string AUTH_SUCCESS = "auth success!";
		private const string AUTH_FAILED = "Invalid login/password";
		private const string REGISTRATION_FAILED = "Invalid registration data";
		private const string REGISTRATION_SUCCESS = "You're registered!";
		private const string INVALID_MESSAGE = "Invalid message";

		private static RequestFactory instance;

		private RequestFactory() { }

		public IRequest CreateRequestByString(string requestString) {

			IRequest request = new EmptyRequest();

			// checking status requests
			switch (requestString) {
				case AUTH_SUCCESS:
					request = new StatusRequest(requestString, RequestType.AuthSuccess);
					break;

				case AUTH_FAILED:
					request = new StatusRequest(requestString, RequestType.AuthFailed);
					break;

				case REGISTRATION_SUCCESS:
					request = new StatusRequest(requestString, RequestType.RegistationSuccess);
					break;

				case REGISTRATION_FAILED:
					request = new StatusRequest(requestString, RequestType.RegistationFailed);
					break;
				case INVALID_MESSAGE:
					request = new StatusRequest(requestString, RequestType.InvalidMessage);
					break;
				case "contacts":
					request = new ContactListRequest();
					break;
			}

			if (request.Type != RequestType.Empty) {
				return request;
			}

			int splitterIndex = requestString.IndexOf(':');

			string requetsType = requestString.Substring(0, splitterIndex);
			string requestBody = requestString.Substring(splitterIndex + 1);

			string[] requestParams = splitRequestBody(requestBody);

			switch (requetsType) {
				case "msg":
					request = new MessageRequest(
						requestParams[MessageRequest.TEXT], 
						requestParams[MessageRequest.TO_LOGIN]);
					break;
				case "auth":
					request = new AuthRequest(
						requestParams[AuthRequest.LOGIN], 
						requestParams[AuthRequest.PASSWORD]);
					break;
				case "add":
					request = new AddRequest(
						requestParams[AddRequest.LOGIN]);
					break;
				case "contact":
					request = new ContactRequest(
						requestParams[ContactRequest.NICKNAME], 
						requestParams[ContactRequest.LOGIN]);
					break;
				case "reg":
					request = new RegisterRequest(
						requestParams[RegisterRequest.LOGIN], 
						requestParams[RegisterRequest.PASSWORD], 
						requestParams[RegisterRequest.NICKNAME]);
					break;
			}
			
			return request;

		}

		private string[] splitRequestBody(string requestBody) {
			string[] requestParams = requestBody.Split('&');
			return requestParams;
		}

		public static RequestFactory Instance {
			get {
				if (instance == null) {
					instance = new RequestFactory();
				}

				return instance;
			}
		}

	}
}
