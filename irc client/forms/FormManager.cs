using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace irc_client.forms {

	/// <summary>
	/// Singleton.
	/// Contains forms.
	/// </summary>
	public class FormManager {

		#region fields

		private static FormManager instance;
		private Dictionary<FormType, Form> repository;

		#endregion

		#region constructors

		private FormManager() {
			repository = new Dictionary<FormType, Form>();
		}

		#endregion

		#region properties
		/// <summary>
		/// Returns a form-singleton got by a FormType. Creates form if it is't created.
		/// </summary>
		/// <param name="type">Type of a form</param>
		/// <returns>Form-singleton</returns>
		public Form GetForm(FormType type) {
			Form form;
			repository.TryGetValue(type, out form);

			if (form == null) {
				switch (type) {
					case FormType.Auth:
						repository.Add(type, new Auth());
						centerForm(repository[type]);
						break;
					case FormType.Contacts:
						repository.Add(type, new Contacts());
						centerForm(repository[type]);
						break;
					case FormType.Registration:
						repository.Add(type, new Registration());
						centerForm(repository[type]);
						break;
					case FormType.Dialog:
						repository.Add(type, new Dialog());
						centerForm(repository[type]);
						break;
					case FormType.Add:
						repository.Add(type, new Add());
						centerForm(repository[type]);
						break;
					default:
						Console.WriteLine("form unknown");
						return new Form();
				}
			}
			//repository[type].StartPosition = FormStartPosition.CenterScreen;
			return repository[type];

		}

		private void centerForm(Form form) {
			form.StartPosition = FormStartPosition.CenterScreen;
		}

		/// <summary>
		/// Returns FormManager instance. Create it if it is't created.
		/// </summary>
		public static FormManager Instance {
			get {
				if (instance == null) {
					instance = new FormManager();
				}

				return instance;
			}
		}

		#endregion
	}
}
