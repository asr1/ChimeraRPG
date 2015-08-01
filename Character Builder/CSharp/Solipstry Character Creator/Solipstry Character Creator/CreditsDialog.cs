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
	public partial class CreditsDialog : Form
	{
		public CreditsDialog()
		{
			InitializeComponent();
		}

		private void CreditsDialog_Load(object sender, EventArgs e)
		{
			int halfway = Size.Width / 2; //Halfway across the window

			//Center all the labels horizontally
			Size creditMeSize = TextRenderer.MeasureText(lblGiveMeCredit.Text, lblGiveMeCredit.Font);
			lblGiveMeCredit.Location = 
				new Point(halfway - (creditMeSize.Width / 2), lblGiveMeCredit.Location.Y);

			Size creditThemSize = TextRenderer.MeasureText(lblGiveThemCredit.Text, lblGiveThemCredit.Font);
			lblGiveThemCredit.Location =
				new Point(halfway - (creditThemSize.Width / 2), lblGiveThemCredit.Location.Y);

			Size theirNamesSize = TextRenderer.MeasureText(lblAlexAndRachel.Text, lblAlexAndRachel.Font);
			lblAlexAndRachel.Location =
				new Point(halfway - (theirNamesSize.Width / 2), lblAlexAndRachel.Location.Y);
		}
	}
}
