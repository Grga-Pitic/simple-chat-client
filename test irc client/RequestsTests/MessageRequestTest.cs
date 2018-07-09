using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using irc_client.connection.requests;

namespace test_irc_client.requests {
	[TestClass]
	public class MessageRequestTest {
		[TestMethod]
		public void RequestString_creates1and2_msg12returned() {
			IRequest request = new MessageRequest("1", "2");

			string actual = request.RequestString;

			string expected = "msg:1&2";

			Assert.AreEqual(expected, actual);
		}
	}
}
