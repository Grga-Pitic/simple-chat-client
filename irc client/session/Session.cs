using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {
	public class Session {

		private static Session instance;

		public SessionData Data { get; set; }

		public static Session Instance {
			get {
				if (instance == null) {
					instance = new Session(); 
				}

				return instance;
			}
		}

	}
}
