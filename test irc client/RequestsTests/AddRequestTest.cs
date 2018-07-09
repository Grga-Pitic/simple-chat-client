using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using irc_client.connection.requests;

namespace test_irc_client.requests {
	[TestClass]
	public class AddRequestTest {
		[TestMethod]
		public void RequestString_createsWith1_add1returned() {
			IRequest request = new AddRequest("1");

			string actual = request.RequestString;

			string expected = "add:1";

			Assert.AreEqual(expected, actual);
		}
	}
}
