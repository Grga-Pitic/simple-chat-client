using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.forms {
	public enum FormType : int {

		Auth         = 0x0,
		Contacts     = 0x1,
		Registration = 0x2,
		Dialog       = 0x3,
		Add          = 0x4

	}
}
