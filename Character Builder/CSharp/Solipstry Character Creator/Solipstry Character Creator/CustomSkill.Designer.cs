namespace Solipstry_Character_Creator
{
	partial class CustomSkill
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.txtSkillName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.lblAttribute = new System.Windows.Forms.Label();
			this.cmbSkillAttr = new System.Windows.Forms.ComboBox();
			this.chkPrimary = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(122, 114);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(203, 114);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// txtSkillName
			// 
			this.txtSkillName.Location = new System.Drawing.Point(15, 25);
			this.txtSkillName.Name = "txtSkillName";
			this.txtSkillName.Size = new System.Drawing.Size(263, 20);
			this.txtSkillName.TabIndex = 0;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(12, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Name:";
			// 
			// lblAttribute
			// 
			this.lblAttribute.AutoSize = true;
			this.lblAttribute.Location = new System.Drawing.Point(12, 60);
			this.lblAttribute.Name = "lblAttribute";
			this.lblAttribute.Size = new System.Drawing.Size(100, 13);
			this.lblAttribute.TabIndex = 4;
			this.lblAttribute.Text = "Governing attribute:";
			// 
			// cmbSkillAttr
			// 
			this.cmbSkillAttr.FormattingEnabled = true;
			this.cmbSkillAttr.Items.AddRange(new object[] {
            "Charisma",
            "Constitution",
            "Dexterity",
            "Intelligence",
            "Luck",
            "Speed",
            "Strength",
            "Wisdom"});
			this.cmbSkillAttr.Location = new System.Drawing.Point(15, 76);
			this.cmbSkillAttr.Name = "cmbSkillAttr";
			this.cmbSkillAttr.Size = new System.Drawing.Size(121, 21);
			this.cmbSkillAttr.TabIndex = 1;
			// 
			// chkPrimary
			// 
			this.chkPrimary.AutoSize = true;
			this.chkPrimary.Location = new System.Drawing.Point(151, 78);
			this.chkPrimary.Name = "chkPrimary";
			this.chkPrimary.Size = new System.Drawing.Size(127, 17);
			this.chkPrimary.TabIndex = 5;
			this.chkPrimary.Text = "Take as primary skill?";
			this.chkPrimary.UseVisualStyleBackColor = true;
			// 
			// CustomSkill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 149);
			this.Controls.Add(this.chkPrimary);
			this.Controls.Add(this.cmbSkillAttr);
			this.Controls.Add(this.lblAttribute);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.txtSkillName);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "CustomSkill";
			this.Text = "Create Custom Skill";
			this.Load += new System.EventHandler(this.CustomSkill_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox txtSkillName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblAttribute;
		private System.Windows.Forms.ComboBox cmbSkillAttr;
		private System.Windows.Forms.CheckBox chkPrimary;
	}
}