using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using irc_client.services.parcers;

namespace test_irc_client {
	[TestClass]
	public class AddressParsingTest {
		[TestMethod]
		public void ParceAddress_validDomaineAndPort_truereturned() {
			// input data
			ParcedAddress parcedAddress = new ParcedAddress();
			var testInputString = "domain:1234";

			bool actual = Parcer.ParceAddress(testInputString, parcedAddress);

			Assert.IsTrue(actual);
		}

		[TestMethod]
		public void ParceAddress_validIPandPort_truereturned() {
			// input data
			ParcedAddress parcedAddress = new ParcedAddress();
			var testInputString = "192.168.0.1:1234";

			bool actual = Parcer.ParceAddress(testInputString, parcedAddress);

			Assert.IsTrue(actual);
		}

		[TestMethod]
		public void ParceAddress_withoutSplitter_falsereturned() {
			// input data
			ParcedAddress parcedAddress = new ParcedAddress();
			var testInputString = "domain1234";

			bool actual = Parcer.ParceAddress(testInputString, parcedAddress);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void ParceAddress_portIsNotNumerics_falsereturned() {
			// input data
			ParcedAddress parcedAddress = new ParcedAddress();
			var testInputString = "domaine:port";

			bool actual = Parcer.ParceAddress(testInputString, parcedAddress);

			Assert.IsFalse(actual);
		}
	}
}
