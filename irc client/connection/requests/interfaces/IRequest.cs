using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.connection.requests {
	public interface IRequest {

		string RequestString { get; }
		RequestType Type { get; }

	}
}
