using System.Windows.Forms;

namespace irc_client {
	partial class Contacts {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void OnFormClosing(FormClosingEventArgs e) {

			e.Cancel = true;

			this.Hide();

			base.OnFormClosing(e);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.contactsList = new System.Windows.Forms.ListBox();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.ChatMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolAddContact = new System.Windows.Forms.ToolStripMenuItem();
			this.toolLogout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.contactsList, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 30);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 220);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// contactsList
			// 
			this.contactsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contactsList.FormattingEnabled = true;
			this.contactsList.Location = new System.Drawing.Point(3, 3);
			this.contactsList.Name = "contactsList";
			this.contactsList.Size = new System.Drawing.Size(254, 212);
			this.contactsList.TabIndex = 0;
			this.contactsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contactsList_MouseClick);
			this.contactsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.contactsList_MouseDoubleClick);
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChatMenu});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(284, 24);
			this.mainMenu.TabIndex = 2;
			this.mainMenu.Text = "menuStrip1";
			this.mainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
			// ChatMenu
			// 
			this.ChatMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddContact,
            this.toolLogout,
            this.toolExit});
			this.ChatMenu.Name = "ChatMenu";
			this.ChatMenu.Size = new System.Drawing.Size(44, 20);
			this.ChatMenu.Text = "Chat";
			// 
			// toolAddContact
			// 
			this.toolAddContact.Name = "toolAddContact";
			this.toolAddContact.Size = new System.Drawing.Size(139, 22);
			this.toolAddContact.Text = "Add contact";
			this.toolAddContact.Click += new System.EventHandler(this.toolAddContact_Click);
			// 
			// toolLogout
			// 
			this.toolLogout.Name = "toolLogout";
			this.toolLogout.Size = new System.Drawing.Size(139, 22);
			this.toolLogout.Text = "Logout";
			this.toolLogout.Click += new System.EventHandler(this.toolLogout_Click);
			// 
			// toolExit
			// 
			this.toolExit.Name = "toolExit";
			this.toolExit.Size = new System.Drawing.Size(139, 22);
			this.toolExit.Text = "Exit";
			this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
			// 
			// Contacts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.Name = "Contacts";
			this.Text = "Contacts";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Contacts_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListBox contactsList;
		private MenuStrip mainMenu;
		private ToolStripMenuItem ChatMenu;
		private ToolStripMenuItem toolAddContact;
		private ToolStripMenuItem toolLogout;
		private ToolStripMenuItem toolExit;
	}
}