using System.Windows.Forms;
using System.Resources;
using System;

namespace Solipstry_Character_Creator
{
	class TextBoxWithHint : TextBox
	{
		private PictureBox pbx; //Picture box to show the hint on

		public TextBoxWithHint() : base()
		{
			pbx = new PictureBox();
			pbx.Anchor = AnchorStyles.Top | AnchorStyles.Left;
			pbx.Location = new System.Drawing.Point(0, 0);
			pbx.SizeMode = PictureBoxSizeMode.StretchImage;
			pbx.Image = Solipstry_Character_Creator.Properties.Resources.search_hint;
			this.Controls.Add(pbx);
			pbx.Cursor = Cursors.IBeam;
			pbx.Left = 10;
			pbx.Top = -2;
			pbx.Size = pbx.Image.Size;
			pbx.Click += new EventHandler(this.PictureBoxOnClick);

			this.TextChanged += new EventHandler(this.TextChangedHandler);
		}

		private void TextChangedHandler(object sender, EventArgs e)
		{
			if(this.Text.Equals(""))
			{
				pbx.Visible = true;
			}
			else
			{
				pbx.Visible = false;
			}
		}

		private void PictureBoxOnClick(object sender, EventArgs e)
		{
			this.Focus();
		}
	}
}
