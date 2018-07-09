using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {
	public class OperationStatus {

		private static OperationStatus instance;

		public bool RegistrationFeedback { get; set; }

		public bool AuthFeedback { get; set; }
		public bool AuthSuccess  { get; set; }

		public static OperationStatus Instance {
			get {
				if (instance == null) {
					instance = new OperationStatus();
				}

				return instance;
			}
		}

	}
}
