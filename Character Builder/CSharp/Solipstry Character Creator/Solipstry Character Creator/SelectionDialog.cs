using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solipstry_Character_Creator
{
	public partial class SelectionDialog : Form
	{
		public SelectionDialog(CheckedListBox.ObjectCollection items, string title)
		{
			InitializeComponent();

			foreach(object item in items)
			{
				cmbItems.Items.Add(item);
			}

			cmbItems.SelectedIndex = 0;

			this.Text = title;
		}

		public SelectionDialog(List<string> items, string title)
		{
			InitializeComponent();

			foreach(string item in items)
			{
				cmbItems.Items.Add(item);	
			}

			cmbItems.SelectedIndex = 0;

			this.Text = title;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrWhiteSpace(cmbItems.SelectedText))
			{
				MessageBox.Show("Please select a skill");
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		/// <summary>
		/// Gets the skill the user selected
		/// </summary>
		/// <returns>Skill the user selected</returns>
		public string GetSelectedItem()
		{
			return cmbItems.SelectedText;
		}
	}
}
