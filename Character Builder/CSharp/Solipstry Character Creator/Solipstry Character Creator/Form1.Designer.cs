namespace Solipstry_Character_Creator
{
    partial class Window
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtRace = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.txtAspiration = new System.Windows.Forms.TextBox();
            this.txtBackground = new System.Windows.Forms.TextBox();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblAspiration = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblRace = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tabAttributes = new System.Windows.Forms.TabPage();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.tabTalents = new System.Windows.Forms.TabPage();
            this.tabSpells = new System.Windows.Forms.TabPage();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(684, 361);
            this.splitContainer1.SplitterDistance = 499;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Controls.Add(this.tabAttributes);
            this.tabControl1.Controls.Add(this.tabSkills);
            this.tabControl1.Controls.Add(this.tabTalents);
            this.tabControl1.Controls.Add(this.tabSpells);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 358);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.lblSize);
            this.tabInfo.Controls.Add(this.cmbSize);
            this.tabInfo.Controls.Add(this.txtName);
            this.tabInfo.Controls.Add(this.txtClass);
            this.tabInfo.Controls.Add(this.txtRace);
            this.tabInfo.Controls.Add(this.txtHeight);
            this.tabInfo.Controls.Add(this.txtWeight);
            this.tabInfo.Controls.Add(this.txtAge);
            this.tabInfo.Controls.Add(this.txtOccupation);
            this.tabInfo.Controls.Add(this.txtAspiration);
            this.tabInfo.Controls.Add(this.txtBackground);
            this.tabInfo.Controls.Add(this.lblBackground);
            this.tabInfo.Controls.Add(this.lblAspiration);
            this.tabInfo.Controls.Add(this.lblOccupation);
            this.tabInfo.Controls.Add(this.lblAge);
            this.tabInfo.Controls.Add(this.lblWeight);
            this.tabInfo.Controls.Add(this.lblHeight);
            this.tabInfo.Controls.Add(this.lblRace);
            this.tabInfo.Controls.Add(this.lblClass);
            this.tabInfo.Controls.Add(this.lblName);
            this.tabInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(486, 332);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Info";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(200, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 17;
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(200, 66);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(155, 20);
            this.txtClass.TabIndex = 16;
            // 
            // txtRace
            // 
            this.txtRace.Location = new System.Drawing.Point(201, 92);
            this.txtRace.Name = "txtRace";
            this.txtRace.Size = new System.Drawing.Size(154, 20);
            this.txtRace.TabIndex = 15;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(201, 118);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(154, 20);
            this.txtHeight.TabIndex = 14;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(201, 144);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(154, 20);
            this.txtWeight.TabIndex = 13;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(201, 170);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(154, 20);
            this.txtAge.TabIndex = 12;
            // 
            // txtOccupation
            // 
            this.txtOccupation.Location = new System.Drawing.Point(201, 196);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(154, 20);
            this.txtOccupation.TabIndex = 11;
            // 
            // txtAspiration
            // 
            this.txtAspiration.Location = new System.Drawing.Point(201, 222);
            this.txtAspiration.Name = "txtAspiration";
            this.txtAspiration.Size = new System.Drawing.Size(154, 20);
            this.txtAspiration.TabIndex = 10;
            // 
            // txtBackground
            // 
            this.txtBackground.Location = new System.Drawing.Point(201, 248);
            this.txtBackground.Name = "txtBackground";
            this.txtBackground.Size = new System.Drawing.Size(154, 20);
            this.txtBackground.TabIndex = 9;
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Location = new System.Drawing.Point(116, 251);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(65, 13);
            this.lblBackground.TabIndex = 8;
            this.lblBackground.Text = "Background";
            // 
            // lblAspiration
            // 
            this.lblAspiration.AutoSize = true;
            this.lblAspiration.Location = new System.Drawing.Point(116, 225);
            this.lblAspiration.Name = "lblAspiration";
            this.lblAspiration.Size = new System.Drawing.Size(53, 13);
            this.lblAspiration.TabIndex = 7;
            this.lblAspiration.Text = "Aspiration";
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(116, 199);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(62, 13);
            this.lblOccupation.TabIndex = 6;
            this.lblOccupation.Text = "Occupation";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(116, 173);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 5;
            this.lblAge.Text = "Age";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(116, 147);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 4;
            this.lblWeight.Text = "Weight";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(116, 121);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Height";
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Location = new System.Drawing.Point(116, 95);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(33, 13);
            this.lblRace.TabIndex = 2;
            this.lblRace.Text = "Race";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(116, 69);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 13);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "Class";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(116, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tabAttributes
            // 
            this.tabAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributes.Size = new System.Drawing.Size(486, 332);
            this.tabAttributes.TabIndex = 1;
            this.tabAttributes.Text = "Attributes";
            this.tabAttributes.UseVisualStyleBackColor = true;
            // 
            // tabSkills
            // 
            this.tabSkills.Location = new System.Drawing.Point(4, 22);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Size = new System.Drawing.Size(486, 332);
            this.tabSkills.TabIndex = 2;
            this.tabSkills.Text = "Skills";
            this.tabSkills.UseVisualStyleBackColor = true;
            // 
            // tabTalents
            // 
            this.tabTalents.Location = new System.Drawing.Point(4, 22);
            this.tabTalents.Name = "tabTalents";
            this.tabTalents.Size = new System.Drawing.Size(486, 332);
            this.tabTalents.TabIndex = 3;
            this.tabTalents.Text = "Talents";
            this.tabTalents.UseVisualStyleBackColor = true;
            // 
            // tabSpells
            // 
            this.tabSpells.Location = new System.Drawing.Point(4, 22);
            this.tabSpells.Name = "tabSpells";
            this.tabSpells.Size = new System.Drawing.Size(486, 332);
            this.tabSpells.TabIndex = 4;
            this.tabSpells.Text = "Spells";
            this.tabSpells.UseVisualStyleBackColor = true;
            // 
            // cmbSize
            // 
            this.cmbSize.DisplayMember = "Medium";
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.cmbSize.Location = new System.Drawing.Point(200, 275);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(155, 21);
            this.cmbSize.TabIndex = 18;
            this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(116, 278);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 19;
            this.lblSize.Text = "Size";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Window";
            this.Text = "Solipstry Character Creator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabAttributes;
        private System.Windows.Forms.TabPage tabSkills;
        private System.Windows.Forms.TabPage tabTalents;
        private System.Windows.Forms.TabPage tabSpells;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblAspiration;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.TextBox txtAspiration;
        private System.Windows.Forms.TextBox txtBackground;
        private System.Windows.Forms.TextBox txtOccupation;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtRace;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.ComboBox cmbSize;
    }
}

