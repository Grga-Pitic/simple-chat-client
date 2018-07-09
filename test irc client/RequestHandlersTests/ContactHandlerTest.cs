using Microsoft.VisualStudio.TestTools.UnitTesting;

using irc_client.session;
using irc_client.connection.requests;
using irc_client.connection.requests.hadnlers;

namespace test_irc_client.RequestHandlersTests {
	[TestClass]
	public class ContactHandlerTest {
		[TestMethod]
		public void Handle_createsWith1and2_updateContactListIsTrue() {
			SessionData data = new SessionData();

			IRequestHandler handler = new ContactRequestHandler(data);
			IRequest request = new ContactRequest("1", "2");

			handler.Handle(request);

			bool expected = true;
			bool actual = data.ContactList.Updated;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Handle_createsWith1and2_contactListSizeIs1() {
			SessionData data = new SessionData();

			IRequestHandler handler = new ContactRequestHandler(data);
			IRequest request = new ContactRequest("1", "2");

			handler.Handle(request);

			int expected = 1;
			int actual = data.ContactList.Size;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Handle_createsWith1and2_1stContactLoginIs2() {
			SessionData data = new SessionData();

			IRequestHandler handler = new ContactRequestHandler(data);
			IRequest request = new ContactRequest("1", "2");

			handler.Handle(request);

			string expected = "2";
			string actual = data.ContactList.GetByIndex(0).Login;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Handle_createsWith1and2_1stContactNickIs1() {
			SessionData data = new SessionData();

			IRequestHandler handler = new ContactRequestHandler(data);
			IRequest request = new ContactRequest("1", "2");

			handler.Handle(request);

			string expected = "1";
			string actual = data.ContactList.GetByIndex(0).Nickname;
			Assert.AreEqual(expected, actual);
		}

	}
}
