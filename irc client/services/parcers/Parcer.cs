using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.services.parcers {
	public class Parcer {

		private const char ADDRESS_SPLIT_SIMBOL = ':';
		private const int MAX_PORT_VALUE = 9999;

		public static bool ParceAddress(string text, ParcedAddress addressObject) {

			string[] splittedText = text.Split(ADDRESS_SPLIT_SIMBOL);
			// add checking for exception after this comment

			try {
				addressObject.IP = splittedText[0];
				addressObject.Port = Convert.ToInt32(splittedText[1]);
			}
			catch (Exception ex) {
				return false;
			}

			if (addressObject.Port > MAX_PORT_VALUE) {
				return false;
			}

			return true;

		}

	}
}
