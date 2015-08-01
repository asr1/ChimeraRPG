namespace Solipstry_Character_Creator
{
	partial class CustomSkillForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSkillForm));
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
			this.btnCancel.Location = new System.Drawing.Point(165, 99);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 25);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(261, 99);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(88, 25);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// txtSkillName
			// 
			this.txtSkillName.Location = new System.Drawing.Point(18, 27);
			this.txtSkillName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtSkillName.Name = "txtSkillName";
			this.txtSkillName.Size = new System.Drawing.Size(307, 20);
			this.txtSkillName.TabIndex = 0;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(15, 9);
			this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(42, 14);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Name:";
			// 
			// lblAttribute
			// 
			this.lblAttribute.AutoSize = true;
			this.lblAttribute.Location = new System.Drawing.Point(15, 52);
			this.lblAttribute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAttribute.Name = "lblAttribute";
			this.lblAttribute.Size = new System.Drawing.Size(147, 14);
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
			this.cmbSkillAttr.Location = new System.Drawing.Point(18, 69);
			this.cmbSkillAttr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.cmbSkillAttr.Name = "cmbSkillAttr";
			this.cmbSkillAttr.Size = new System.Drawing.Size(140, 22);
			this.cmbSkillAttr.TabIndex = 1;
			// 
			// chkPrimary
			// 
			this.chkPrimary.AutoSize = true;
			this.chkPrimary.Location = new System.Drawing.Point(177, 71);
			this.chkPrimary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.chkPrimary.Name = "chkPrimary";
			this.chkPrimary.Size = new System.Drawing.Size(180, 18);
			this.chkPrimary.TabIndex = 2;
			this.chkPrimary.Text = "Take as primary skill?";
			this.chkPrimary.UseVisualStyleBackColor = true;
			// 
			// CustomSkillForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 136);
			this.Controls.Add(this.chkPrimary);
			this.Controls.Add(this.cmbSkillAttr);
			this.Controls.Add(this.lblAttribute);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.txtSkillName);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.Name = "CustomSkillForm";
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