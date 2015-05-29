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
			this.lblSize = new System.Windows.Forms.Label();
			this.cmbSize = new System.Windows.Forms.ComboBox();
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
			this.btnAttr8 = new System.Windows.Forms.Button();
			this.btnAttr7 = new System.Windows.Forms.Button();
			this.btnAttr6 = new System.Windows.Forms.Button();
			this.btnAttr5 = new System.Windows.Forms.Button();
			this.btnAttr4 = new System.Windows.Forms.Button();
			this.btnAttr3 = new System.Windows.Forms.Button();
			this.btnAttr2 = new System.Windows.Forms.Button();
			this.btnAttr1 = new System.Windows.Forms.Button();
			this.lblAttributeSelectionMethod = new System.Windows.Forms.Label();
			this.cmbAttributeMethod = new System.Windows.Forms.ComboBox();
			this.lblCharisma = new System.Windows.Forms.Label();
			this.lblConstitution = new System.Windows.Forms.Label();
			this.lblDexterity = new System.Windows.Forms.Label();
			this.lblIntelligence = new System.Windows.Forms.Label();
			this.lblLuck = new System.Windows.Forms.Label();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.lblStrength = new System.Windows.Forms.Label();
			this.lblWisdom = new System.Windows.Forms.Label();
			this.txtWisdom = new System.Windows.Forms.TextBox();
			this.txtStrength = new System.Windows.Forms.TextBox();
			this.txtSpeed = new System.Windows.Forms.TextBox();
			this.txtLuck = new System.Windows.Forms.TextBox();
			this.txtIntelligence = new System.Windows.Forms.TextBox();
			this.txtCharisma = new System.Windows.Forms.TextBox();
			this.txtConstitution = new System.Windows.Forms.TextBox();
			this.txtDexterity = new System.Windows.Forms.TextBox();
			this.tabSkills = new System.Windows.Forms.TabPage();
			this.tabTalents = new System.Windows.Forms.TabPage();
			this.tabSpells = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabInfo.SuspendLayout();
			this.tabAttributes.SuspendLayout();
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
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(116, 68);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(27, 13);
			this.lblSize.TabIndex = 19;
			this.lblSize.Text = "Size";
			// 
			// cmbSize
			// 
			this.cmbSize.DisplayMember = "Medium";
			this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSize.FormattingEnabled = true;
			this.cmbSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
			this.cmbSize.Location = new System.Drawing.Point(200, 65);
			this.cmbSize.Name = "cmbSize";
			this.cmbSize.Size = new System.Drawing.Size(155, 21);
			this.cmbSize.TabIndex = 18;
			this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged);
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
			this.txtClass.Location = new System.Drawing.Point(201, 274);
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
			this.lblClass.Location = new System.Drawing.Point(116, 277);
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
			this.tabAttributes.Controls.Add(this.btnAttr8);
			this.tabAttributes.Controls.Add(this.btnAttr7);
			this.tabAttributes.Controls.Add(this.btnAttr6);
			this.tabAttributes.Controls.Add(this.btnAttr5);
			this.tabAttributes.Controls.Add(this.btnAttr4);
			this.tabAttributes.Controls.Add(this.btnAttr3);
			this.tabAttributes.Controls.Add(this.btnAttr2);
			this.tabAttributes.Controls.Add(this.btnAttr1);
			this.tabAttributes.Controls.Add(this.lblAttributeSelectionMethod);
			this.tabAttributes.Controls.Add(this.cmbAttributeMethod);
			this.tabAttributes.Controls.Add(this.lblCharisma);
			this.tabAttributes.Controls.Add(this.lblConstitution);
			this.tabAttributes.Controls.Add(this.lblDexterity);
			this.tabAttributes.Controls.Add(this.lblIntelligence);
			this.tabAttributes.Controls.Add(this.lblLuck);
			this.tabAttributes.Controls.Add(this.lblSpeed);
			this.tabAttributes.Controls.Add(this.lblStrength);
			this.tabAttributes.Controls.Add(this.lblWisdom);
			this.tabAttributes.Controls.Add(this.txtWisdom);
			this.tabAttributes.Controls.Add(this.txtStrength);
			this.tabAttributes.Controls.Add(this.txtSpeed);
			this.tabAttributes.Controls.Add(this.txtLuck);
			this.tabAttributes.Controls.Add(this.txtIntelligence);
			this.tabAttributes.Controls.Add(this.txtCharisma);
			this.tabAttributes.Controls.Add(this.txtConstitution);
			this.tabAttributes.Controls.Add(this.txtDexterity);
			this.tabAttributes.Location = new System.Drawing.Point(4, 22);
			this.tabAttributes.Name = "tabAttributes";
			this.tabAttributes.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributes.Size = new System.Drawing.Size(486, 332);
			this.tabAttributes.TabIndex = 1;
			this.tabAttributes.Text = "Attributes";
			this.tabAttributes.UseVisualStyleBackColor = true;
			this.tabAttributes.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			// 
			// btnAttr8
			// 
			this.btnAttr8.FlatAppearance.BorderSize = 0;
			this.btnAttr8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr8.Location = new System.Drawing.Point(293, 278);
			this.btnAttr8.Name = "btnAttr8";
			this.btnAttr8.Size = new System.Drawing.Size(100, 20);
			this.btnAttr8.TabIndex = 25;
			this.btnAttr8.Text = "20";
			this.btnAttr8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr8.UseVisualStyleBackColor = true;
			this.btnAttr8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// btnAttr7
			// 
			this.btnAttr7.FlatAppearance.BorderSize = 0;
			this.btnAttr7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr7.Location = new System.Drawing.Point(293, 252);
			this.btnAttr7.Name = "btnAttr7";
			this.btnAttr7.Size = new System.Drawing.Size(100, 20);
			this.btnAttr7.TabIndex = 24;
			this.btnAttr7.Text = "20";
			this.btnAttr7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr7.UseVisualStyleBackColor = true;
			this.btnAttr7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// btnAttr6
			// 
			this.btnAttr6.FlatAppearance.BorderSize = 0;
			this.btnAttr6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr6.Location = new System.Drawing.Point(293, 226);
			this.btnAttr6.Name = "btnAttr6";
			this.btnAttr6.Size = new System.Drawing.Size(100, 20);
			this.btnAttr6.TabIndex = 23;
			this.btnAttr6.Text = "20";
			this.btnAttr6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr6.UseVisualStyleBackColor = true;
			this.btnAttr6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// btnAttr5
			// 
			this.btnAttr5.FlatAppearance.BorderSize = 0;
			this.btnAttr5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr5.Location = new System.Drawing.Point(293, 200);
			this.btnAttr5.Name = "btnAttr5";
			this.btnAttr5.Size = new System.Drawing.Size(100, 20);
			this.btnAttr5.TabIndex = 22;
			this.btnAttr5.Text = "20";
			this.btnAttr5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr5.UseVisualStyleBackColor = true;
			this.btnAttr5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// btnAttr4
			// 
			this.btnAttr4.FlatAppearance.BorderSize = 0;
			this.btnAttr4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr4.Location = new System.Drawing.Point(293, 174);
			this.btnAttr4.Name = "btnAttr4";
			this.btnAttr4.Size = new System.Drawing.Size(100, 20);
			this.btnAttr4.TabIndex = 21;
			this.btnAttr4.Text = "20";
			this.btnAttr4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr4.UseVisualStyleBackColor = true;
			this.btnAttr4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// btnAttr3
			// 
			this.btnAttr3.FlatAppearance.BorderSize = 0;
			this.btnAttr3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr3.Location = new System.Drawing.Point(293, 148);
			this.btnAttr3.Name = "btnAttr3";
			this.btnAttr3.Size = new System.Drawing.Size(100, 20);
			this.btnAttr3.TabIndex = 20;
			this.btnAttr3.Text = "20";
			this.btnAttr3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr3.UseVisualStyleBackColor = true;
			this.btnAttr3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// btnAttr2
			// 
			this.btnAttr2.FlatAppearance.BorderSize = 0;
			this.btnAttr2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr2.Location = new System.Drawing.Point(293, 122);
			this.btnAttr2.Name = "btnAttr2";
			this.btnAttr2.Size = new System.Drawing.Size(100, 20);
			this.btnAttr2.TabIndex = 19;
			this.btnAttr2.Text = "20";
			this.btnAttr2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr2.UseVisualStyleBackColor = true;
			this.btnAttr2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// btnAttr1
			// 
			this.btnAttr1.FlatAppearance.BorderSize = 0;
			this.btnAttr1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttr1.Location = new System.Drawing.Point(293, 96);
			this.btnAttr1.Name = "btnAttr1";
			this.btnAttr1.Size = new System.Drawing.Size(100, 20);
			this.btnAttr1.TabIndex = 18;
			this.btnAttr1.Text = "20";
			this.btnAttr1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAttr1.UseVisualStyleBackColor = true;
			this.btnAttr1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAttr_MouseDown);
			// 
			// lblAttributeSelectionMethod
			// 
			this.lblAttributeSelectionMethod.AutoSize = true;
			this.lblAttributeSelectionMethod.Location = new System.Drawing.Point(290, 54);
			this.lblAttributeSelectionMethod.Name = "lblAttributeSelectionMethod";
			this.lblAttributeSelectionMethod.Size = new System.Drawing.Size(129, 13);
			this.lblAttributeSelectionMethod.TabIndex = 17;
			this.lblAttributeSelectionMethod.Text = "Attribute selection method";
			// 
			// cmbAttributeMethod
			// 
			this.cmbAttributeMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAttributeMethod.FormattingEnabled = true;
			this.cmbAttributeMethod.Items.AddRange(new object[] {
            "All 20s",
            "Two 30s, four 20s, and two 10s",
            "Three 30s, two 20s, and three 10s",
            "I rolled my own"});
			this.cmbAttributeMethod.Location = new System.Drawing.Point(293, 70);
			this.cmbAttributeMethod.Name = "cmbAttributeMethod";
			this.cmbAttributeMethod.Size = new System.Drawing.Size(187, 21);
			this.cmbAttributeMethod.TabIndex = 16;
			this.cmbAttributeMethod.SelectedIndexChanged += new System.EventHandler(this.cmbAttributeMethod_SelectedIndexChanged);
			// 
			// lblCharisma
			// 
			this.lblCharisma.AutoSize = true;
			this.lblCharisma.Location = new System.Drawing.Point(6, 100);
			this.lblCharisma.Name = "lblCharisma";
			this.lblCharisma.Size = new System.Drawing.Size(50, 13);
			this.lblCharisma.TabIndex = 15;
			this.lblCharisma.Text = "Charisma";
			// 
			// lblConstitution
			// 
			this.lblConstitution.AutoSize = true;
			this.lblConstitution.Location = new System.Drawing.Point(6, 126);
			this.lblConstitution.Name = "lblConstitution";
			this.lblConstitution.Size = new System.Drawing.Size(62, 13);
			this.lblConstitution.TabIndex = 14;
			this.lblConstitution.Text = "Constitution";
			// 
			// lblDexterity
			// 
			this.lblDexterity.AutoSize = true;
			this.lblDexterity.Location = new System.Drawing.Point(6, 152);
			this.lblDexterity.Name = "lblDexterity";
			this.lblDexterity.Size = new System.Drawing.Size(48, 13);
			this.lblDexterity.TabIndex = 13;
			this.lblDexterity.Text = "Dexterity";
			// 
			// lblIntelligence
			// 
			this.lblIntelligence.AutoSize = true;
			this.lblIntelligence.Location = new System.Drawing.Point(6, 178);
			this.lblIntelligence.Name = "lblIntelligence";
			this.lblIntelligence.Size = new System.Drawing.Size(61, 13);
			this.lblIntelligence.TabIndex = 12;
			this.lblIntelligence.Text = "Intelligence";
			// 
			// lblLuck
			// 
			this.lblLuck.AutoSize = true;
			this.lblLuck.Location = new System.Drawing.Point(6, 204);
			this.lblLuck.Name = "lblLuck";
			this.lblLuck.Size = new System.Drawing.Size(31, 13);
			this.lblLuck.TabIndex = 11;
			this.lblLuck.Text = "Luck";
			// 
			// lblSpeed
			// 
			this.lblSpeed.AutoSize = true;
			this.lblSpeed.Location = new System.Drawing.Point(6, 230);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(38, 13);
			this.lblSpeed.TabIndex = 10;
			this.lblSpeed.Text = "Speed";
			// 
			// lblStrength
			// 
			this.lblStrength.AutoSize = true;
			this.lblStrength.Location = new System.Drawing.Point(6, 256);
			this.lblStrength.Name = "lblStrength";
			this.lblStrength.Size = new System.Drawing.Size(47, 13);
			this.lblStrength.TabIndex = 9;
			this.lblStrength.Text = "Strength";
			// 
			// lblWisdom
			// 
			this.lblWisdom.AutoSize = true;
			this.lblWisdom.Location = new System.Drawing.Point(6, 282);
			this.lblWisdom.Name = "lblWisdom";
			this.lblWisdom.Size = new System.Drawing.Size(45, 13);
			this.lblWisdom.TabIndex = 8;
			this.lblWisdom.Text = "Wisdom";
			// 
			// txtWisdom
			// 
			this.txtWisdom.AllowDrop = true;
			this.txtWisdom.Location = new System.Drawing.Point(114, 279);
			this.txtWisdom.Name = "txtWisdom";
			this.txtWisdom.Size = new System.Drawing.Size(100, 20);
			this.txtWisdom.TabIndex = 7;
			this.txtWisdom.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtWisdom.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
			// 
			// txtStrength
			// 
			this.txtStrength.AllowDrop = true;
			this.txtStrength.Location = new System.Drawing.Point(114, 253);
			this.txtStrength.Name = "txtStrength";
			this.txtStrength.Size = new System.Drawing.Size(100, 20);
			this.txtStrength.TabIndex = 6;
			this.txtStrength.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtStrength.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
			// 
			// txtSpeed
			// 
			this.txtSpeed.AllowDrop = true;
			this.txtSpeed.Location = new System.Drawing.Point(114, 227);
			this.txtSpeed.Name = "txtSpeed";
			this.txtSpeed.Size = new System.Drawing.Size(100, 20);
			this.txtSpeed.TabIndex = 5;
			this.txtSpeed.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtSpeed.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
			// 
			// txtLuck
			// 
			this.txtLuck.AllowDrop = true;
			this.txtLuck.Location = new System.Drawing.Point(114, 201);
			this.txtLuck.Name = "txtLuck";
			this.txtLuck.Size = new System.Drawing.Size(100, 20);
			this.txtLuck.TabIndex = 4;
			this.txtLuck.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtLuck.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
			// 
			// txtIntelligence
			// 
			this.txtIntelligence.AllowDrop = true;
			this.txtIntelligence.Location = new System.Drawing.Point(114, 175);
			this.txtIntelligence.Name = "txtIntelligence";
			this.txtIntelligence.Size = new System.Drawing.Size(100, 20);
			this.txtIntelligence.TabIndex = 3;
			this.txtIntelligence.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtIntelligence.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
			// 
			// txtCharisma
			// 
			this.txtCharisma.AllowDrop = true;
			this.txtCharisma.Location = new System.Drawing.Point(114, 97);
			this.txtCharisma.Name = "txtCharisma";
			this.txtCharisma.Size = new System.Drawing.Size(100, 20);
			this.txtCharisma.TabIndex = 2;
			this.txtCharisma.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtCharisma.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
			// 
			// txtConstitution
			// 
			this.txtConstitution.AllowDrop = true;
			this.txtConstitution.Location = new System.Drawing.Point(114, 123);
			this.txtConstitution.Name = "txtConstitution";
			this.txtConstitution.Size = new System.Drawing.Size(100, 20);
			this.txtConstitution.TabIndex = 1;
			this.txtConstitution.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtConstitution.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
			// 
			// txtDexterity
			// 
			this.txtDexterity.AllowDrop = true;
			this.txtDexterity.Location = new System.Drawing.Point(114, 149);
			this.txtDexterity.Name = "txtDexterity";
			this.txtDexterity.Size = new System.Drawing.Size(100, 20);
			this.txtDexterity.TabIndex = 0;
			this.txtDexterity.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragDrop);
			this.txtDexterity.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAttributes_DragEnter);
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
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 361);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Window";
			this.Text = "Solipstry Character Creator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
			this.Load += new System.EventHandler(this.Window_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabInfo.ResumeLayout(false);
			this.tabInfo.PerformLayout();
			this.tabAttributes.ResumeLayout(false);
			this.tabAttributes.PerformLayout();
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
        private System.Windows.Forms.Label lblLuck;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblWisdom;
        private System.Windows.Forms.TextBox txtWisdom;
        private System.Windows.Forms.TextBox txtStrength;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.TextBox txtLuck;
        private System.Windows.Forms.TextBox txtIntelligence;
        private System.Windows.Forms.TextBox txtCharisma;
        private System.Windows.Forms.TextBox txtConstitution;
        private System.Windows.Forms.TextBox txtDexterity;
        private System.Windows.Forms.Label lblCharisma;
        private System.Windows.Forms.Label lblConstitution;
        private System.Windows.Forms.Label lblDexterity;
        private System.Windows.Forms.Label lblIntelligence;
        private System.Windows.Forms.ComboBox cmbAttributeMethod;
		private System.Windows.Forms.Label lblAttributeSelectionMethod;
		private System.Windows.Forms.Button btnAttr8;
		private System.Windows.Forms.Button btnAttr7;
		private System.Windows.Forms.Button btnAttr6;
		private System.Windows.Forms.Button btnAttr5;
		private System.Windows.Forms.Button btnAttr4;
		private System.Windows.Forms.Button btnAttr3;
		private System.Windows.Forms.Button btnAttr2;
		private System.Windows.Forms.Button btnAttr1;
    }
}

