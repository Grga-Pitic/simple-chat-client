using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using irc_client.connection.requests;

namespace test_irc_client.requests {
	[TestClass]
	public class ContactRequestTest {

		[TestMethod]
		public void RequestString_createsWith1and2_contact12returned() {
			IRequest request = new ContactRequest("1", "2");

			var expected = "contact:2&1";

			var actual = request.RequestString;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void Nickname_createsWith1and2_1returned() {
			ContactRequest request = new ContactRequest("1", "2");

			var expected = "1";

			var actual = request.Nickname;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void Login_createsWith1and2_2returned() {
			ContactRequest request = new ContactRequest("1", "2");

			var expected = "2";

			var actual = request.Login;

			Assert.AreEqual(expected, actual);

		}
	}
}
