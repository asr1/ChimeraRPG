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
	}
}
