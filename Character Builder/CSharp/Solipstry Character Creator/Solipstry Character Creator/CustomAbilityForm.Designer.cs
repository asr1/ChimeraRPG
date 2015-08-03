namespace Solipstry_Character_Creator
{
	partial class CustomAbilityForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomAbilityForm));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblAbilityName = new System.Windows.Forms.Label();
			this.txtAbilityName = new System.Windows.Forms.TextBox();
			this.lblCost = new System.Windows.Forms.Label();
			this.cmbSchool = new System.Windows.Forms.ComboBox();
			this.lblSchool = new System.Windows.Forms.Label();
			this.txtCost = new System.Windows.Forms.TextBox();
			this.lblEffect = new System.Windows.Forms.Label();
			this.txtEffect = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(142, 192);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 25);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(237, 192);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(87, 25);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblAbilityName
			// 
			this.lblAbilityName.AutoSize = true;
			this.lblAbilityName.Location = new System.Drawing.Point(11, 10);
			this.lblAbilityName.Name = "lblAbilityName";
			this.lblAbilityName.Size = new System.Drawing.Size(42, 14);
			this.lblAbilityName.TabIndex = 2;
			this.lblAbilityName.Text = "Name:";
			// 
			// txtAbilityName
			// 
			this.txtAbilityName.Location = new System.Drawing.Point(14, 27);
			this.txtAbilityName.Name = "txtAbilityName";
			this.txtAbilityName.Size = new System.Drawing.Size(310, 20);
			this.txtAbilityName.TabIndex = 0;
			// 
			// lblCost
			// 
			this.lblCost.AutoSize = true;
			this.lblCost.Location = new System.Drawing.Point(11, 52);
			this.lblCost.Name = "lblCost";
			this.lblCost.Size = new System.Drawing.Size(35, 14);
			this.lblCost.TabIndex = 4;
			this.lblCost.Text = "Cost";
			// 
			// cmbSchool
			// 
			this.cmbSchool.FormattingEnabled = true;
			this.cmbSchool.Items.AddRange(new object[] {
            "Alteration",
            "Creation",
            "Destruction",
            "Restoration"});
			this.cmbSchool.Location = new System.Drawing.Point(128, 69);
			this.cmbSchool.Name = "cmbSchool";
			this.cmbSchool.Size = new System.Drawing.Size(195, 22);
			this.cmbSchool.TabIndex = 2;
			// 
			// lblSchool
			// 
			this.lblSchool.AutoSize = true;
			this.lblSchool.Location = new System.Drawing.Point(125, 52);
			this.lblSchool.Name = "lblSchool";
			this.lblSchool.Size = new System.Drawing.Size(56, 14);
			this.lblSchool.TabIndex = 6;
			this.lblSchool.Text = "School:";
			// 
			// txtCost
			// 
			this.txtCost.Location = new System.Drawing.Point(14, 69);
			this.txtCost.Name = "txtCost";
			this.txtCost.Size = new System.Drawing.Size(107, 20);
			this.txtCost.TabIndex = 1;
			// 
			// lblEffect
			// 
			this.lblEffect.AutoSize = true;
			this.lblEffect.Location = new System.Drawing.Point(14, 94);
			this.lblEffect.Name = "lblEffect";
			this.lblEffect.Size = new System.Drawing.Size(56, 14);
			this.lblEffect.TabIndex = 7;
			this.lblEffect.Text = "Effect:";
			// 
			// txtEffect
			// 
			this.txtEffect.Location = new System.Drawing.Point(14, 111);
			this.txtEffect.Multiline = true;
			this.txtEffect.Name = "txtEffect";
			this.txtEffect.Size = new System.Drawing.Size(310, 74);
			this.txtEffect.TabIndex = 3;
			// 
			// CustomAbilityForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 229);
			this.Controls.Add(this.txtEffect);
			this.Controls.Add(this.lblEffect);
			this.Controls.Add(this.txtCost);
			this.Controls.Add(this.lblSchool);
			this.Controls.Add(this.cmbSchool);
			this.Controls.Add(this.lblCost);
			this.Controls.Add(this.txtAbilityName);
			this.Controls.Add(this.lblAbilityName);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "CustomAbilityForm";
			this.Text = "Create Custom Ability";
			this.Load += new System.EventHandler(this.CustomAbilityForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblAbilityName;
		private System.Windows.Forms.TextBox txtAbilityName;
		private System.Windows.Forms.Label lblCost;
		private System.Windows.Forms.ComboBox cmbSchool;
		private System.Windows.Forms.Label lblSchool;
		private System.Windows.Forms.TextBox txtCost;
		private System.Windows.Forms.Label lblEffect;
		private System.Windows.Forms.TextBox txtEffect;
	}
}