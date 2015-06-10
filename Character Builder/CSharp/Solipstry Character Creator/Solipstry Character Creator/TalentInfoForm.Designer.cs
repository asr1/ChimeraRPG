namespace Solipstry_Character_Creator
{
	partial class TalentInfoForm
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
			this.lblNameLabel = new System.Windows.Forms.Label();
			this.lblPrereqsLabel = new System.Windows.Forms.Label();
			this.lblDescLabel = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblPrereqs = new System.Windows.Forms.Label();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblNameLabel
			// 
			this.lblNameLabel.AutoSize = true;
			this.lblNameLabel.Location = new System.Drawing.Point(12, 9);
			this.lblNameLabel.Name = "lblNameLabel";
			this.lblNameLabel.Size = new System.Drawing.Size(38, 13);
			this.lblNameLabel.TabIndex = 0;
			this.lblNameLabel.Text = "Name:";
			// 
			// lblPrereqsLabel
			// 
			this.lblPrereqsLabel.AutoSize = true;
			this.lblPrereqsLabel.Location = new System.Drawing.Point(12, 32);
			this.lblPrereqsLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.lblPrereqsLabel.Name = "lblPrereqsLabel";
			this.lblPrereqsLabel.Size = new System.Drawing.Size(70, 13);
			this.lblPrereqsLabel.TabIndex = 1;
			this.lblPrereqsLabel.Text = "Prerequisites:";
			// 
			// lblDescLabel
			// 
			this.lblDescLabel.AutoSize = true;
			this.lblDescLabel.Location = new System.Drawing.Point(12, 55);
			this.lblDescLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.lblDescLabel.Name = "lblDescLabel";
			this.lblDescLabel.Size = new System.Drawing.Size(63, 13);
			this.lblDescLabel.TabIndex = 2;
			this.lblDescLabel.Text = "Description:";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(88, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(66, 13);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Talent name";
			// 
			// lblPrereqs
			// 
			this.lblPrereqs.AutoSize = true;
			this.lblPrereqs.Location = new System.Drawing.Point(88, 32);
			this.lblPrereqs.Name = "lblPrereqs";
			this.lblPrereqs.Size = new System.Drawing.Size(75, 13);
			this.lblPrereqs.TabIndex = 4;
			this.lblPrereqs.Text = "Talent prereqs";
			// 
			// txtDesc
			// 
			this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDesc.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtDesc.Location = new System.Drawing.Point(91, 52);
			this.txtDesc.Multiline = true;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ReadOnly = true;
			this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDesc.Size = new System.Drawing.Size(190, 92);
			this.txtDesc.TabIndex = 5;
			// 
			// TalentInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 150);
			this.Controls.Add(this.lblNameLabel);
			this.Controls.Add(this.lblPrereqsLabel);
			this.Controls.Add(this.lblDescLabel);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.lblPrereqs);
			this.Controls.Add(this.txtDesc);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(303, 189);
			this.Name = "TalentInfoForm";
			this.Text = "Talent Information";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNameLabel;
		private System.Windows.Forms.Label lblPrereqsLabel;
		private System.Windows.Forms.Label lblDescLabel;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblPrereqs;
		private System.Windows.Forms.TextBox txtDesc;
	}
}