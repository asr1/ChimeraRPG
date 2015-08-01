namespace Solipstry_Character_Creator
{
	partial class CreditsDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsDialog));
			this.lblGiveMeCredit = new System.Windows.Forms.Label();
			this.lblGiveThemCredit = new System.Windows.Forms.Label();
			this.lblAlexAndRachel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblGiveMeCredit
			// 
			this.lblGiveMeCredit.AutoSize = true;
			this.lblGiveMeCredit.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGiveMeCredit.Location = new System.Drawing.Point(9, 9);
			this.lblGiveMeCredit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblGiveMeCredit.Name = "lblGiveMeCredit";
			this.lblGiveMeCredit.Size = new System.Drawing.Size(506, 25);
			this.lblGiveMeCredit.TabIndex = 0;
			this.lblGiveMeCredit.Text = "Character builder created by Jake Long";
			// 
			// lblGiveThemCredit
			// 
			this.lblGiveThemCredit.AutoSize = true;
			this.lblGiveThemCredit.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGiveThemCredit.ForeColor = System.Drawing.Color.Black;
			this.lblGiveThemCredit.Location = new System.Drawing.Point(138, 52);
			this.lblGiveThemCredit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblGiveThemCredit.Name = "lblGiveThemCredit";
			this.lblGiveThemCredit.Size = new System.Drawing.Size(230, 21);
			this.lblGiveThemCredit.TabIndex = 1;
			this.lblGiveThemCredit.Text = "Solipstry created by";
			// 
			// lblAlexAndRachel
			// 
			this.lblAlexAndRachel.AutoSize = true;
			this.lblAlexAndRachel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlexAndRachel.ForeColor = System.Drawing.Color.Black;
			this.lblAlexAndRachel.Location = new System.Drawing.Point(87, 73);
			this.lblAlexAndRachel.Name = "lblAlexAndRachel";
			this.lblAlexAndRachel.Size = new System.Drawing.Size(328, 18);
			this.lblAlexAndRachel.TabIndex = 2;
			this.lblAlexAndRachel.Text = "Alex Rinehart and Rachel Bennett";
			// 
			// CreditsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 115);
			this.Controls.Add(this.lblAlexAndRachel);
			this.Controls.Add(this.lblGiveThemCredit);
			this.Controls.Add(this.lblGiveMeCredit);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "CreditsDialog";
			this.Text = "Credits";
			this.Load += new System.EventHandler(this.CreditsDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblGiveMeCredit;
		private System.Windows.Forms.Label lblGiveThemCredit;
		private System.Windows.Forms.Label lblAlexAndRachel;

	}
}