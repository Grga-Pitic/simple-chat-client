using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using irc_client.connection;
using irc_client.connection.requests;

namespace test_irc_client {
	[TestClass]
	public class RequestFactoryTest {

		private const string AUTH_SUCCESS = "auth success!";
		private const string AUTH_FAILED = "Invalid login/password";
		private const string REGISTRATION_FAILED = "Invalid registration data";
		private const string REGISTRATION_SUCCESS = "You're registered!";

		[TestMethod]
		public void CreateRequestByString_contactList_contactListObjectreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("contacts");

			RequestType expected = RequestType.ContactList;
			RequestType actual = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_authSuccess_statusAuthSuccessreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString(AUTH_SUCCESS);

			RequestType expected = RequestType.AuthSuccess;
			RequestType actual = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_authFailed_statusAuthFaileredturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString(AUTH_FAILED);

			RequestType expected = RequestType.AuthFailed;
			RequestType actual = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_regFailed_statusRegFaileredturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString(REGISTRATION_FAILED);

			RequestType expected = RequestType.RegistationFailed;
			RequestType actual = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_regSuccess_statusRegSuccessreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString(REGISTRATION_SUCCESS);

			RequestType expected = RequestType.RegistationSuccess;
			RequestType actual = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_messageRequest_messageRequesObjecttreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("msg:1&2");

			RequestType expected = RequestType.Message;
			RequestType actual   = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_messageRequest_textIs1treturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("msg:1&2");

			string expected = "1";
			string actual = ((MessageRequest)request).Text;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_messageRequest_toMsgIs2treturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("msg:1&2");

			string expected = "2";
			string actual = ((MessageRequest)request).ToLogin;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_addRequest_addRequestObjectreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("add:1&2");

			RequestType expected = RequestType.Add;
			RequestType actual   = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_authRequest_authRequestObjectreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("auth:1&2");

			RequestType expected = RequestType.Auth;
			RequestType actual   = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_contactRequest_contactRequestObjectreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("contact:1&2");

			RequestType expected = RequestType.Contact;
			RequestType actual   = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_contactRequest_loginIs1returned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("contact:1&2");

			string expected = "1";
			string actual = ((ContactRequest)request).Login;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_contactRequest_nicknameIs2returned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("contact:1&2");

			string expected = "2";
			string actual = ((ContactRequest)request).Nickname;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_registerRequest_registerRequestObjectreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("reg:1&2&3");

			RequestType expected = RequestType.Register;
			RequestType actual   = request.Type;

			Assert.AreEqual(expected, actual);

		}

		[TestMethod]
		public void CreateRequestByString_unknownRequest_emptyRequestObjectreturned() {

			IRequest request = RequestFactory.Instance.CreateRequestByString("asdas:1&2&3");

			RequestType expected = RequestType.Empty;
			RequestType actual   = request.Type;

			Assert.AreEqual(expected, actual);

		}
	}
}
