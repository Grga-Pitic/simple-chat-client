using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using irc_client.session;
using irc_client.connection.requests;

namespace irc_client.connection.requests.hadnlers {
	public class StatusRequestHandler : IRequestHandler {

		private OperationStatus _globalStatus;

		/// <summary>
		/// Creates a handler witch handles a StatusRequest object. 
		/// </summary>
		/// <param name="data">OperationStatus object.</param>
		public StatusRequestHandler(OperationStatus globalStatus) {
			this._globalStatus = globalStatus;
		}

		public void Handle(IRequest request) {
			switch (request.Type) {
				case RequestType.AuthSuccess:
					this._globalStatus.AuthSuccess  = true;
					this._globalStatus.AuthFeedback = true;
					break;
				case RequestType.AuthFailed:
					this._globalStatus.AuthSuccess  = false;
					this._globalStatus.AuthFeedback = true;
					break;
				case RequestType.RegistationSuccess:
					MessageBox.Show(request.RequestString);
					this._globalStatus.RegistrationFeedback = true;
					break;
				case RequestType.RegistationFailed:
					MessageBox.Show(request.RequestString);
					this._globalStatus.RegistrationFeedback = true;
					break;
				case RequestType.InvalidMessage:
					MessageBox.Show("Message wasn't sent");
					break;

			}
		}
	}
}
