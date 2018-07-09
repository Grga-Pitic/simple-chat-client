using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using irc_client.connection.requests;

namespace test_irc_client.requests {
	[TestClass]
	public class RegisterRequestTest {

		[TestMethod]
		public void RequestString_creates1and2and3_reg123returned() {
			IRequest request = new RegisterRequest("1", "2", "3");

			string actual = request.RequestString;

			string expected = "reg:1&2&3";

			Assert.AreEqual(expected, actual);
		}

	}
}
