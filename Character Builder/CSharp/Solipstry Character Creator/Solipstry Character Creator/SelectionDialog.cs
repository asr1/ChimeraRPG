/*
 * Copyright (C) 2015 Jacob Long
 * 
 * This file is part of Solipstry Character Creator
 * 
 * Solipstry Character Creator is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * any later version.
 * 
 * Solipstry Character Creator is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Affero General Public License for more details.
 * 
 * You should have received a copy of the GNU Affero General Public License
 * along with Solipstry Character Creator. If not, see <http://www.gnu.org/licenses/>.
 */

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
			Console.WriteLine(cmbItems.SelectedItem.ToString());
			return cmbItems.SelectedItem.ToString();
		}
	}
}
