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
	public partial class CustomAbilityForm : Form
	{
		public CustomAbilityForm()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtAbilityName.Text))
			{
				MessageBox.Show("Please enter an ability name");
				txtAbilityName.Focus();
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void CustomAbilityForm_Load(object sender, EventArgs e)
		{
			cmbSchool.SelectedIndex = 0;
		}

		/// <summary>
		/// Gets the name of the ability
		/// </summary>
		/// <returns>Name of the ability</returns>
		public string GetAbilityName()
		{
			return txtAbilityName.Text;
		}

		/// <summary>
		/// Gets the cost of the ability
		/// </summary>
		/// <returns>Gets the cost of the ability, or 0 if one was not entered</returns>
		public string GetCost()
		{
			return String.IsNullOrWhiteSpace(txtCost.Text) ? "0" : txtCost.Text;
		}

		/// <summary>
		/// Gets the school the ability belongs to
		/// </summary>
		/// <returns>The school of the ability</returns>
		public string GetSchool()
		{
			return cmbSchool.SelectedItem.ToString();
		}

		/// <summary>
		/// Gets the effect of the ability
		/// </summary>
		/// <returns>The ability's effect</returns>
		public string GetEffect()
		{
			return txtEffect.Text;
		}
	}
}
