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
	public partial class CustomSkillForm : Form
	{
		public CustomSkillForm()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			//Skill name is required
			if(string.IsNullOrWhiteSpace(txtSkillName.Text))
			{
				MessageBox.Show("Please enter a skill name");
				txtSkillName.Focus();
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

		private void CustomSkill_Load(object sender, EventArgs e)
		{
			cmbSkillAttr.SelectedIndex = 0;
		}

		/// <summary>
		/// Gets the name of the created skill
		/// </summary>
		/// <returns>Name of the skill</returns>
		public string GetSkillName()
		{
			return txtSkillName.Text;
		}

		/// <summary>
		/// Gets the abbreviation of the skills governing attribute
		/// </summary>
		/// <returns>Abbreviation of the governing attribute</returns>
		public string GetGoverningAttribute()
		{
			string attr = "";

			switch(cmbSkillAttr.SelectedItem.ToString())
			{
				case "Charisma":
					attr = "CHA";
					break;
				case "Constitution":
					attr = "CON";
					break;
				case "Dexterity":
					attr = "DEX";
					break;
				case "Intelligence":
					attr = "INT";
					break;
				case "Luck":
					attr = "LCK";
					break;
				case "Speed":
					attr = "SPD";
					break;
				case "Strength":
					attr = "STR";
					break;
				case "Wisdom":
					attr = "WIS";
					break;
			}

			return attr;
		}

		/// <summary>
		/// Returns whether the user wants to use this skill as a primary skill
		/// </summary>
		/// <returns>True if the user wants the skill to be primary, false otherwise</returns>
		public bool IsPrimarySkill()
		{
			return chkPrimary.Checked;
		}
	}
}
