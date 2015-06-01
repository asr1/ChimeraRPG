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

			lblInfo_Name.Text = name;
			lblInfo_School.Text = school;
			lblInfo_Cost.Text = cost;
			lblInfo_Prereq.Text = prereq.Equals("") ? "None" : prereq;
			txtInfo_Effects.Text = effect;
			txtInfo_Effects.SelectionStart = 0;
			txtInfo_Effects.SelectionLength = 0;
		}
	}
}
