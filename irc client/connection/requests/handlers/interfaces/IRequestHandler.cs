using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using irc_client.connection.requests;

namespace irc_client.connection.requests.hadnlers {

	/// <summary>
	/// A handler of a request.
	/// </summary>
	public interface IRequestHandler {

		/// <summary>
		/// Handles a request.
		/// </summary>
		/// <param name="request">A request which nesessary to handle.</param>
		void Handle(IRequest request);
	}
}
