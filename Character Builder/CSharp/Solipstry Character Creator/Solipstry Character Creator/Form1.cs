using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solipstry_Character_Creator
{
    public partial class Window : Form
    {
        private Character character;
		private List<Label> attributeLabels;
		private List<TextBox> attributeTextBoxes;

        public Window()
        {
            InitializeComponent();

            character = new Character();

			//Store the labels for attributes in a list for easier processing
			attributeLabels = new List<Label>();
			attributeLabels.Add(lblAttr1);
			attributeLabels.Add(lblAttr2);
			attributeLabels.Add(lblAttr3);
			attributeLabels.Add(lblAttr4);
			attributeLabels.Add(lblAttr5);
			attributeLabels.Add(lblAttr6);
			attributeLabels.Add(lblAttr7);
			attributeLabels.Add(lblAttr8);

			//Store the text boxes for attributes in a list for easier processing
			attributeTextBoxes = new List<TextBox>();
			attributeTextBoxes.Add(txtCharisma);
			attributeTextBoxes.Add(txtConstitution);
			attributeTextBoxes.Add(txtDexterity);
			attributeTextBoxes.Add(txtIntelligence);
			attributeTextBoxes.Add(txtLuck);
			attributeTextBoxes.Add(txtSpeed);
			attributeTextBoxes.Add(txtStrength);
			attributeTextBoxes.Add(txtWisdom);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
			UpdateBasicInformation();
			UpdateAttributes();

			//Update derived traits


            //TODO: Update character information
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.size = (string) cmbSize.SelectedItem;
            //TODO: Update character information
        }

        private void Window_Load(object sender, EventArgs e)
        {
			//Default to "All 20s"
            cmbAttributeMethod.SelectedIndex = 0;
			
			//Default to medium
			cmbSize.SelectedIndex = 1;
        }

        private void cmbAttributeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbAttributeMethod.SelectedIndex)
            {
                case 0: //All 20s
					lblAttr1.Text = "20";
					lblAttr2.Text = "20";
					lblAttr3.Text = "20";
					lblAttr4.Text = "20";
					lblAttr5.Text = "20";
					lblAttr6.Text = "20";
					lblAttr7.Text = "20";
					lblAttr8.Text = "20";

					DisableTextBoxes(attributeTextBoxes);
                    break;
                case 1: //2 30s, 4 20s, 2 10s
					lblAttr1.Text = "30";
					lblAttr2.Text = "30";
					lblAttr3.Text = "20";
					lblAttr4.Text = "20";
					lblAttr5.Text = "20";
					lblAttr6.Text = "20";
					lblAttr7.Text = "10";
					lblAttr8.Text = "10";

					DisableTextBoxes(attributeTextBoxes);
					break;
                case 2: //3 30s, 2 20s, 3 10s
					lblAttr1.Text = "30";
					lblAttr2.Text = "30";
					lblAttr3.Text = "30";
					lblAttr4.Text = "20";
					lblAttr5.Text = "20";
					lblAttr6.Text = "10";
					lblAttr7.Text = "10";
					lblAttr8.Text = "10";

					DisableTextBoxes(attributeTextBoxes);
					break;
                case 3: //Rolled own attributes
                    foreach(Label lbl in attributeLabels)
					{
						lbl.Text = "";
					}

					EnableTextBoxes(attributeTextBoxes);
					break;
            }
        }

		private void UpdateAttributes()
		{
			character.charisma = TryParseInteger(txtCharisma.Text);
			character.constitution = TryParseInteger(txtConstitution.Text);
			character.dexterity = TryParseInteger(txtDexterity.Text);
			character.intelligence = TryParseInteger(txtIntelligence.Text);
			character.luck = TryParseInteger(txtLuck.Text);
			character.speed = TryParseInteger(txtSpeed.Text);
			character.strength = TryParseInteger(txtStrength.Text);
			character.wisdom = TryParseInteger(txtWisdom.Text);
		}

		private void UpdateBasicInformation()
		{
			character.name = txtName.Text;
			character._class = txtClass.Text;
			character.race = txtRace.Text;
			character.height = txtHeight.Text;
			character.weight = txtWeight.Text;
			character.occupation = txtOccupation.Text;
			character.aspiration = txtAspiration.Text;
			character.background = txtBackground.Text;
		}

		private void CalculateDerivedTraits()
		{
			character.movement = character.CalculateModifier(character.speed) + 3;
			character.hitPoints = (int)Math.Truncate(1.5 * (double)character.CalculateModifier(character.constitution));
			character.magicTotal = 5 * character.CalculateModifier(character.wisdom);
			character.magicRegen = character.CalculateModifier(character.intelligence);
			character.fortunePoints = character.CalculateModifier(character.luck);
		}

		/// <summary>
		/// Attempts to parse a string as an integer
		/// </summary>
		/// <param name="str">String to be parsed</param>
		/// <returns>If the string is an integer, returns the integer. Else returns 0</returns>
		private int TryParseInteger(string str)
		{
			int useless = 0; //Because TryParse parameters
			bool isInteger = int.TryParse(str, out useless);
			return isInteger ? int.Parse(str) : 0;
		}

		private void EnableTextBoxes(List<TextBox> list)
		{
			foreach(TextBox box in list)
			{
				box.Enabled = true;
			}
		}

		private void DisableTextBoxes(List<TextBox> list)
		{
			foreach(TextBox box in list)
			{
				box.Enabled = false;
			}
		}

		private void txtAttributes_DragDrop(object sender, DragEventArgs e)
		{
			
		}
    }
}
