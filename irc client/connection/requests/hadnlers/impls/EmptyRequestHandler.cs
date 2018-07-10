using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace irc_client.connection.requests.hadnlers {
	public class EmptyRequestHandler : IRequestHandler {

		/// <summary>
		/// Creates a handler witch handles a EmptyHandler object. 
		/// </summary>
		public EmptyRequestHandler() {

		}

		public void Handle(IRequest request) {
			MessageBox.Show("Empty request was handled");
		}
	}
}
