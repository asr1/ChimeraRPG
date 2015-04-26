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

        public Window()
        {
            InitializeComponent();

            character = new Character();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update basic information
            character.name = txtName.Text;
            character._class = txtClass.Text;
            character.race = txtRace.Text;
            character.height = txtHeight.Text;
            character.weight = txtWeight.Text;
            character.occupation = txtOccupation.Text;
            character.aspiration = txtAspiration.Text;
            character.background = txtBackground.Text;

			//Update attributes
			character.charisma = TryParse(txtCharisma.Text);
			character.constitution = TryParse(txtConstitution.Text);
			character.dexterity = TryParse(txtDexterity.Text);
			character.intelligence = TryParse(txtIntelligence.Text);
			character.luck = TryParse(txtLuck.Text);
			character.speed = TryParse(txtSpeed.Text);
			character.strength = TryParse(txtStrength.Text);
			character.wisdom = TryParse(txtWisdom.Text);

			MessageBox.Show(character.luck.ToString());

			//Update derived traits
			character.movement = character.CalculateModifier(character.speed) + 3;
			character.hitPoints = (int) Math.Truncate(1.5 * (double) character.CalculateModifier(character.constitution));
			character.magicTotal = 5 * character.CalculateModifier(character.wisdom);
			character.magicRegen = character.CalculateModifier(character.intelligence);
			character.fortunePoints = character.CalculateModifier(character.luck);

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
        }

        private void cmbAttributeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbAttributeMethod.SelectedIndex)
            {
                case 0: //All 20s

                    break;
                case 1: //2 30s, 4 20s, 2 10s
                    
					break;
                case 2: //3 30s, 2 20s, 3 10s
                    
					break;
                case 3: //Rolled own attributes
                    
					break;
            }
        }

		/// <summary>
		/// Attempts to parse a string as an integer
		/// </summary>
		/// <param name="str">String to be parsed</param>
		/// <returns>If the string is an integer, returns the integer. Else returns 0</returns>
		private int TryParse(string str)
		{
			int useless = 0; //Because TryParse parameters
			bool isInteger = int.TryParse(str, out useless);
			return isInteger ? int.Parse(str) : 0;
		}
    }
}
