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
	public partial class TalentInfoForm : Form
	{
		public TalentInfoForm(string name, string prereqs, string desc)
		{
			InitializeComponent();

			this.Text = name;

			lblName.Text = name;
			lblPrereqs.Text = prereqs.Equals("") ? "None" : prereqs; //If there are no prereqs, display "None"
			txtDesc.Text = desc;
			//Remove the selection from the description text
			txtDesc.SelectionStart = 0;
			txtDesc.SelectionLength = 0;
		}
	}
}
