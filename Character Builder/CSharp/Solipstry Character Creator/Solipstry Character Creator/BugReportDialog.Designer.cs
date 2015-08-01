namespace Solipstry_Character_Creator
{
	partial class BugReportDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugReportDialog));
			this.btnSend = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblBugDesc = new System.Windows.Forms.Label();
			this.txtBugDesc = new System.Windows.Forms.TextBox();
			this.lblFromEmail = new System.Windows.Forms.Label();
			this.txtFromEmail = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(387, 255);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(87, 25);
			this.btnSend.TabIndex = 3;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(293, 255);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblBugDesc
			// 
			this.lblBugDesc.AutoSize = true;
			this.lblBugDesc.Location = new System.Drawing.Point(14, 31);
			this.lblBugDesc.Name = "lblBugDesc";
			this.lblBugDesc.Size = new System.Drawing.Size(168, 14);
			this.lblBugDesc.TabIndex = 5;
			this.lblBugDesc.Text = "Description of the bug:";
			// 
			// txtBugDesc
			// 
			this.txtBugDesc.Location = new System.Drawing.Point(17, 48);
			this.txtBugDesc.Multiline = true;
			this.txtBugDesc.Name = "txtBugDesc";
			this.txtBugDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBugDesc.Size = new System.Drawing.Size(457, 200);
			this.txtBugDesc.TabIndex = 1;
			// 
			// lblFromEmail
			// 
			this.lblFromEmail.AutoSize = true;
			this.lblFromEmail.Location = new System.Drawing.Point(14, 10);
			this.lblFromEmail.Name = "lblFromEmail";
			this.lblFromEmail.Size = new System.Drawing.Size(161, 14);
			this.lblFromEmail.TabIndex = 5;
			this.lblFromEmail.Text = "Your email (optional):";
			// 
			// txtFromEmail
			// 
			this.txtFromEmail.Location = new System.Drawing.Point(181, 6);
			this.txtFromEmail.Name = "txtFromEmail";
			this.txtFromEmail.Size = new System.Drawing.Size(293, 20);
			this.txtFromEmail.TabIndex = 4;
			// 
			// BugReportDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 293);
			this.Controls.Add(this.txtFromEmail);
			this.Controls.Add(this.lblFromEmail);
			this.Controls.Add(this.txtBugDesc);
			this.Controls.Add(this.lblBugDesc);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSend);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BugReportDialog";
			this.Text = "BugReportDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblBugDesc;
		public System.Windows.Forms.TextBox txtBugDesc;
		private System.Windows.Forms.Label lblFromEmail;
		public System.Windows.Forms.TextBox txtFromEmail;
	}
}