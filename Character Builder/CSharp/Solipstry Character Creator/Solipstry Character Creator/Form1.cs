﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml.Serialization;

namespace Solipstry_Character_Creator
{
    public partial class Window : Form
    {
		private const string SPELLS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Spells.accdb";

		private OleDbConnection spellsConnection;

        private Character character;
		private List<Button> attrValuesList;
		private List<TextBox> attributeTextBoxes;

		private Button btnDropFrom; //Button that the drag and drop originated from

        public Window()
        {
            InitializeComponent();

			//Create a context menu strip for the spell list box
			ContextMenuStrip spellMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem spellInfoItem = new ToolStripMenuItem("Info");
			spellInfoItem.Click += new EventHandler(spellInfoMenuItem_Click);
			spellInfoItem.Name = "Info";
			spellInfoItem.Enabled = false;
			spellMenuStrip.Items.Add(spellInfoItem);
			clbSpells.ContextMenuStrip = spellMenuStrip;

            character = new Character();

			//Store the labels for attributes in a list for easier processing
			attrValuesList = new List<Button>();
			attrValuesList.Add(btnAttr1);
			attrValuesList.Add(btnAttr2);
			attrValuesList.Add(btnAttr3);
			attrValuesList.Add(btnAttr4);
			attrValuesList.Add(btnAttr5);
			attrValuesList.Add(btnAttr6);
			attrValuesList.Add(btnAttr7);
			attrValuesList.Add(btnAttr8);

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

			//Initialize database connections
			spellsConnection = new OleDbConnection(SPELLS_ACCESS_STRING);
			try
			{
				spellsConnection.Open();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error opening connection to spell database: {0}", e.Message);
			}

			FillSpellsList();

			//DataRowCollection dra = PerformQuery(...).Tables[table].Rows;
			//foreach (DataRow dr in dra)
			//{
			//	Console.WriteLine("{0} is in school {1}", dr[0], dr[1]);
			//}
        }

		private void FillSpellsList()
		{
			DataSet ds = PerformQuery(spellsConnection, "SELECT spell_name FROM Spells", "Spells");
			DataRowCollection dra = ds.Tables["Spells"].Rows;
			List<string> spellList = new List<string>();

			foreach(DataRow dr in dra)
			{
				spellList.Add(dr[0].ToString());
			}
			spellList.Sort();

			foreach(string spell in spellList)
			{
				clbSpells.Items.Add(spell);
			}
		}

		/// <summary>
		/// Performs a SQL query on an OLE connection
		/// </summary>
		/// <param name="conn">OleDbConnection to use</param>
		/// <param name="query">SQL query to perform</param>
		/// <param name="table">Table to fill the dataset with</param>
		/// <returns>DataSet containing results of the query</returns>
		private DataSet PerformQuery(OleDbConnection conn, string query, string table)
		{
			DataSet ds = new DataSet();
		
			try
			{
				OleDbCommand cmd = new OleDbCommand(query, conn);
				OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
				adapter.Fill(ds, table);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return ds;
		}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
			UpdateBasicInformation();
			UpdateAttributes();
			CalculateDerivedTraits();


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
					foreach (Button btn in attrValuesList)
					{
						btn.Enabled = true;
						btn.Visible = true;
					}

					ClearTextBoxes(attributeTextBoxes);

					btnAttr1.Text = "20";
					btnAttr2.Text = "20";
					btnAttr3.Text = "20";
					btnAttr4.Text = "20";
					btnAttr5.Text = "20";
					btnAttr6.Text = "20";
					btnAttr7.Text = "20";
					btnAttr8.Text = "20";

					MakeReadOnly(attributeTextBoxes);
                    break;
                case 1: //2 30s, 4 20s, 2 10s
					foreach (Button btn in attrValuesList)
					{
						btn.Enabled = true;
						btn.Visible = true;
					}

					ClearTextBoxes(attributeTextBoxes);

					btnAttr1.Text = "30";
					btnAttr2.Text = "30";
					btnAttr3.Text = "20";
					btnAttr4.Text = "20";
					btnAttr5.Text = "20";
					btnAttr6.Text = "20";
					btnAttr7.Text = "10";
					btnAttr8.Text = "10";

					MakeReadOnly(attributeTextBoxes);
					break;
                case 2: //3 30s, 2 20s, 3 10s
					foreach (Button btn in attrValuesList)
					{
						btn.Enabled = true;
						btn.Visible = true;
					}

					ClearTextBoxes(attributeTextBoxes);

					btnAttr1.Text = "30";
					btnAttr2.Text = "30";
					btnAttr3.Text = "30";
					btnAttr4.Text = "20";
					btnAttr5.Text = "20";
					btnAttr6.Text = "10";
					btnAttr7.Text = "10";
					btnAttr8.Text = "10";

					MakeReadOnly(attributeTextBoxes);
					break;
                case 3: //Rolled own attributes
                    foreach(Button btn in attrValuesList)
					{
						btn.Enabled = false;
						btn.Visible = false;
					}

					ClearTextBoxes(attributeTextBoxes);
					
					MakeReadWrite(attributeTextBoxes);
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

		private void MakeReadOnly(List<TextBox> list)
		{
			foreach(TextBox txt in list)
			{
				txt.ReadOnly = true;
			}
		}

		private void MakeReadWrite(List<TextBox> list)
		{
			foreach(TextBox txt in list)
			{
				txt.ReadOnly = false;
			}
		}

		private void txtAttributes_DragDrop(object sender, DragEventArgs e)
		{
			TextBox txt = (TextBox) sender;
			string oldText = txt.Text;

			txt.Text = e.Data.GetData(DataFormats.Text).ToString();

			if(oldText.Equals("")) //If nothing was there, disable the button
			{
				btnDropFrom.Text = "";
				btnDropFrom.Enabled = false;
				btnDropFrom.Visible = false;
			}
			else //Transfer the old contents of the text box to the button
			{
				btnDropFrom.Text = oldText;
			}

		}

		private void ClearTextBoxes(List<TextBox> list)
		{
			foreach (TextBox txt in list)
			{
				txt.Text = "";
			}
		}

		private void txtAttributes_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void btnAttr_MouseDown(object sender, MouseEventArgs e)
		{
			btnDropFrom = (Button) sender; //Keep track of where the drag data came from
			btnDropFrom.DoDragDrop(btnDropFrom.Text, DragDropEffects.Copy | DragDropEffects.Move);
		}

		private void Window_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Close all database connections
			spellsConnection.Close();
		}

		//Handler for spell 'info' menu item click
		private void spellInfoMenuItem_Click(object sender, EventArgs e)
		{
			DataSet ds = PerformQuery(spellsConnection,
				"SELECT * FROM Spells WHERE spell_name = '" + clbSpells.SelectedItem.ToString().Trim() + "'",
				"Spells");
			DataRow infoRow = ds.Tables["Spells"].Rows[0];

			SpellInfoForm frm = new SpellInfoForm(infoRow[0].ToString(),
												  infoRow[2].ToString(),
												  infoRow[1].ToString(),
												  infoRow[3].ToString(),
												  infoRow[4].ToString());
			frm.ShowDialog();
		}

		private void clbSpells_SelectedIndexChanged(object sender, EventArgs e)
		{
			clbSpells.ContextMenuStrip.Items[0].Enabled = true;
		}

		private void clbSpells_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(e.CurrentValue == CheckState.Checked)
			{
				character.spells.Remove(clbSpells.SelectedItem.ToString());
			}
			else
			{
				character.spells.Add(clbSpells.SelectedItem.ToString());
			}

			CheckHomebrew();
		}

		private void CheckHomebrew()
		{
			bool hb = false; //Whether or not the character is homebrewed

			foreach(string spell in character.spells)
			{
				if(CheckSpellHomebrew(spell))
				{
					hb = true;
					break;
				}
			}

			//TODO: Check other homebrew things

			chkHomebrew.Checked = hb;
		}

		/// <summary>
		/// Check's if the character is homebrewed based off of the spells
		/// </summary>
		/// <param name="spell">Spell to check</param>
		/// <returns>True if the character is homebrewed, false otherwise</returns>
		private bool CheckSpellHomebrew(string spell)
		{
			//Get the prerequisites for the spell from the database
			DataRow dr = PerformQuery(spellsConnection, "SELECT prereq FROM Spells WHERE spell_name = '" + spell + "'", "Spells").Tables["Spells"].Rows[0];
			
			//Don't need to check prereqs if there are none
			if(dr[0].ToString().Equals(""))
			{
				return false;
			}

			string[] prereqs = dr[0].ToString().Split(','); //Split the prerequisites into an array for easier parsing

			foreach(string pr in prereqs)
			{
				//Check which kind of prereq it is (skill level or other spell)
				if(pr.StartsWith("Destruction") ||
				   pr.StartsWith("Conjuration") ||
				   pr.StartsWith("Alteration") ||
				   pr.StartsWith("Restoration"))
				{
					string[] split = pr.Split(' ');
				
					//If the character's skill level is too low for the required, its homebrewed
					if(character.GetSkillValue(split[0]) < TryParseInteger(split[1]))
					{
						return true;
					}
				}
				else if(pr.StartsWith("[Meta]"))
				{
					//TODO: Deal with meta magic
				}
				else
				{
					//If the character doesn't have the prerequisite spells, its homebrewed
					if(!character.spells.Contains(pr))
					{
						return true;
					}
				}
			}

			return false;
		}
    }
}
