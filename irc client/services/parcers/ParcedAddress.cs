using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.services.parcers {
	public class ParcedAddress {

		public string IP { get; set; }
		public int	  Port { get; set; }

		public override string ToString() {
			return IP + ":" + Port.ToString();
		}
	}
}
