using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irc_client.session {
	public class DialogDictionary {
		Dictionary<Contact, DialogData> _dialogDictionary; 

		public DialogDictionary() {
			this._dialogDictionary = new Dictionary<Contact, DialogData>();
		}

		public DialogData GetDialogByContact(Contact key) {

			DialogData returnedData;
			this._dialogDictionary.TryGetValue(key, out returnedData);

			if (returnedData == null) {
				this._dialogDictionary.Add(key, new DialogData(key));
			}

			return this._dialogDictionary[key];
		}

		public void AddDialog(Contact key, DialogData newValue) {
			this._dialogDictionary.Add(key, newValue);
		}

	}
}
