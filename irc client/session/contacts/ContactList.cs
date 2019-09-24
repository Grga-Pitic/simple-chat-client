using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {

	/// <summary>
	/// A class-wrapper.
	/// </summary>
	public class ContactList {

		private List<Contact> _contactList;

		public ContactList() {
			this._contactList = new List<Contact>();
			this.Updated = false;
		}

		public bool Updated { get; set; }

		public ContactList(List<Contact> contactList) {
			this._contactList = contactList;
		}

		public void AddContact(Contact newContact) {
			this.Updated = true;
			this._contactList.Add(newContact);
		}

		public void DeleteContactByIndex(int index) {
			this.Updated = true;
			this._contactList.RemoveAt(index);
		}

		// does is need for me?
		public void DeleteContactByLogin(string login) {

		}

		public void DeleteAll() {
			this.Updated = true;
			this._contactList.Clear();
		}

		public Contact GetByIndex(int index) {
			return this._contactList[index];
		}

		public Contact GetOrCreateByLogin(string login) {

			foreach (var contact in _contactList) {
				if (contact.Login.Equals(login)) {
					return contact;
				}
			}

			Contact newContact = new Contact(login, login);
			_contactList.Add(newContact);
			return newContact;

		}

		public bool IsLoginInList(string login) {
			foreach (var contact in _contactList) {
				if (contact.Login.Equals(login)) {
					return true;
				}
			}
			return false;
		}

		public int Size {
			get {
				return this._contactList.Count;
			}
		}

	}
}
