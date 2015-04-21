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

            //TODO: Update character information
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.size = (string) cmbSize.SelectedItem;
            //TODO: Update character information
        }
    }
}
