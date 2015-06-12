namespace Solipstry_Character_Creator
{
	partial class SpellInfoForm
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
			this.lblSchoolLabel = new System.Windows.Forms.Label();
			this.lblCostLabel = new System.Windows.Forms.Label();
			this.lblPrereqLabel = new System.Windows.Forms.Label();
			this.lblEffectsLabel = new System.Windows.Forms.Label();
			this.lblPrereq = new System.Windows.Forms.Label();
			this.lblCost = new System.Windows.Forms.Label();
			this.lblSchool = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.txtEffects = new System.Windows.Forms.TextBox();
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
			// lblSchoolLabel
			// 
			this.lblSchoolLabel.AutoSize = true;
			this.lblSchoolLabel.Location = new System.Drawing.Point(12, 32);
			this.lblSchoolLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.lblSchoolLabel.Name = "lblSchoolLabel";
			this.lblSchoolLabel.Size = new System.Drawing.Size(43, 13);
			this.lblSchoolLabel.TabIndex = 1;
			this.lblSchoolLabel.Text = "School:";
			// 
			// lblCostLabel
			// 
			this.lblCostLabel.AutoSize = true;
			this.lblCostLabel.Location = new System.Drawing.Point(12, 55);
			this.lblCostLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.lblCostLabel.Name = "lblCostLabel";
			this.lblCostLabel.Size = new System.Drawing.Size(31, 13);
			this.lblCostLabel.TabIndex = 2;
			this.lblCostLabel.Text = "Cost:";
			// 
			// lblPrereqLabel
			// 
			this.lblPrereqLabel.AutoSize = true;
			this.lblPrereqLabel.Location = new System.Drawing.Point(12, 78);
			this.lblPrereqLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.lblPrereqLabel.Name = "lblPrereqLabel";
			this.lblPrereqLabel.Size = new System.Drawing.Size(70, 13);
			this.lblPrereqLabel.TabIndex = 3;
			this.lblPrereqLabel.Text = "Prerequisites:";
			// 
			// lblEffectsLabel
			// 
			this.lblEffectsLabel.AutoSize = true;
			this.lblEffectsLabel.Location = new System.Drawing.Point(12, 101);
			this.lblEffectsLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.lblEffectsLabel.Name = "lblEffectsLabel";
			this.lblEffectsLabel.Size = new System.Drawing.Size(43, 13);
			this.lblEffectsLabel.TabIndex = 4;
			this.lblEffectsLabel.Text = "Effects:";
			// 
			// lblPrereq
			// 
			this.lblPrereq.AutoSize = true;
			this.lblPrereq.Location = new System.Drawing.Point(88, 78);
			this.lblPrereq.Name = "lblPrereq";
			this.lblPrereq.Size = new System.Drawing.Size(68, 13);
			this.lblPrereq.TabIndex = 5;
			this.lblPrereq.Text = "Spell prereqs";
			// 
			// lblCost
			// 
			this.lblCost.AutoSize = true;
			this.lblCost.Location = new System.Drawing.Point(88, 55);
			this.lblCost.Name = "lblCost";
			this.lblCost.Size = new System.Drawing.Size(53, 13);
			this.lblCost.TabIndex = 6;
			this.lblCost.Text = "Spell cost";
			// 
			// lblSchool
			// 
			this.lblSchool.AutoSize = true;
			this.lblSchool.Location = new System.Drawing.Point(88, 32);
			this.lblSchool.Name = "lblSchool";
			this.lblSchool.Size = new System.Drawing.Size(64, 13);
			this.lblSchool.TabIndex = 7;
			this.lblSchool.Text = "Spell school";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(88, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(59, 13);
			this.lblName.TabIndex = 8;
			this.lblName.Text = "Spell name";
			// 
			// txtEffects
			// 
			this.txtEffects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEffects.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtEffects.Location = new System.Drawing.Point(91, 98);
			this.txtEffects.Multiline = true;
			this.txtEffects.Name = "txtEffects";
			this.txtEffects.ReadOnly = true;
			this.txtEffects.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEffects.Size = new System.Drawing.Size(190, 92);
			this.txtEffects.TabIndex = 9;
			// 
			// SpellInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 196);
			this.Controls.Add(this.txtEffects);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.lblSchool);
			this.Controls.Add(this.lblCost);
			this.Controls.Add(this.lblPrereq);
			this.Controls.Add(this.lblEffectsLabel);
			this.Controls.Add(this.lblPrereqLabel);
			this.Controls.Add(this.lblCostLabel);
			this.Controls.Add(this.lblSchoolLabel);
			this.Controls.Add(this.lblNameLabel);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(303, 235);
			this.Name = "SpellInfoForm";
			this.Text = "Spell Information";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNameLabel;
		private System.Windows.Forms.Label lblSchoolLabel;
		private System.Windows.Forms.Label lblCostLabel;
		private System.Windows.Forms.Label lblPrereqLabel;
		private System.Windows.Forms.Label lblEffectsLabel;
		private System.Windows.Forms.Label lblPrereq;
		private System.Windows.Forms.Label lblCost;
		private System.Windows.Forms.Label lblSchool;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtEffects;
	}
}