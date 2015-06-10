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
	public partial class SpellInfoForm : Form
	{
		public SpellInfoForm(string name, string school, string cost, string prereq, string effect)
		{
			InitializeComponent();
			this.Text = name;

			lblName.Text = name;
			lblSchool.Text = school;
			lblCost.Text = cost;
			lblPrereq.Text = prereq.Equals("") ? "None" : prereq; //If there are no prereqs, display "None"
			txtEffects.Text = effect;
			txtEffects.SelectionStart = 0;
			txtEffects.SelectionLength = 0;
		}
	}
}
