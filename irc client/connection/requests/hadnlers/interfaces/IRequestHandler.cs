using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using irc_client.connection.requests;

namespace irc_client.connection.requests.hadnlers {
	public interface IRequestHandler {
		void Handle(IRequest request);
	}
}
