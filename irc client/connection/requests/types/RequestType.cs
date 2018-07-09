using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public enum RequestType {
		Add, 
		Auth,
		Contact,
		Message, 
		Register, 
		ContactList,
		Empty,
		AuthSuccess,
		AuthFailed,
		RegistationSuccess,
		RegistationFailed,
		InvalidMessage
	}
}
