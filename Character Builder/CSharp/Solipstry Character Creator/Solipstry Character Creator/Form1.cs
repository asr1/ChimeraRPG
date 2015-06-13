using System;
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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Solipstry_Character_Creator
{
    public partial class Window : Form
    {
		private const string SPELLS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Spells.accdb";
		private const string TALENTS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Talents.accdb";
		private const string SKILLS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Skills.accdb";

		private OleDbConnection spellsConnection;
		private OleDbConnection talentsConnection;
		private OleDbConnection skillsConnection;

        private Character character;
		private List<Button> attrValuesList;
		private List<TextBox> attributeTextBoxes;

		private Button btnDropFrom; //Button that the drag and drop originated from

		private int primarySkillCount; //Number of skills set as primary skills

		#region Program setup
		public Window()
        {
            InitializeComponent();

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
			talentsConnection = new OleDbConnection(TALENTS_ACCESS_STRING);
			skillsConnection = new OleDbConnection(SKILLS_ACCESS_STRING);
			try
			{
				spellsConnection.Open();
				talentsConnection.Open();
				skillsConnection.Open();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error opening connection to database: {0}", e.Message);
			}

			FillSpellsList();
			FillTalentsList();
			FillSkillsList();
		}

		/// <summary>
		/// Queries the spell table and adds all spells to the CheckListBox for spells
		/// </summary>
		private void FillSpellsList()
		{
			DataSet ds = PerformQuery(spellsConnection, "SELECT spell_name FROM Spells", "Spells");
			DataRowCollection rows = ds.Tables["Spells"].Rows;
			List<string> spellList = new List<string>();

			foreach(DataRow dr in rows)
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
		/// Queries the talents table and adds the name of all talents to the CheckListBox
		/// for talents
		/// </summary>
		private void FillTalentsList()
		{
			DataSet ds = PerformQuery(talentsConnection, "SELECT talent_name FROM Talents", "Talents");
			DataRowCollection rows = ds.Tables["Talents"].Rows;
			List<string> talentList = new List<string>();

			foreach(DataRow dr in rows)
			{
				talentList.Add(dr[0].ToString());
			}
			talentList.Sort();

			foreach(string talent in talentList)
			{
				clbTalents.Items.Add(talent);
			}
		}
		
		/// <summary>
		/// Queries the talents table and adds the name of all skills to the CheckListBox
		/// for skills
		/// </summary>
		private void FillSkillsList()
		{
			DataSet ds = PerformQuery(skillsConnection, "SELECT skill_name FROM Skills", "Skills");
			DataRowCollection rows = ds.Tables["Skills"].Rows;
			List<string> skillList = new List<string>();

			foreach(DataRow dr in rows)
			{
				skillList.Add(dr[0].ToString());
			}
			skillList.Sort();

			foreach(string skill in skillList)
			{
				clbSkills.Items.Add(skill);
			}
		}
		#endregion

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

			CheckHomebrew();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.size = (string) cmbSize.SelectedItem;
			CheckHomebrew(); //Some talents depend on size
            //TODO: Update character information
        }

        private void Window_Load(object sender, EventArgs e)
        {
			//Default to "All 20s"
            cmbAttributeMethod.SelectedIndex = 0;
			
			//Default to medium
			cmbSize.SelectedIndex = 1;

			lblSpellsInstructions.Text = "Select the spells you wish to take. The number of spells you can know for each" + 
				Environment.NewLine + "school is equal to your modifier in that school.";
        }

        private void cmbAttributeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbAttributeMethod.SelectedIndex)
            {
                case 0: //All 20s
					foreach (Button btn in attrValuesList)
					{
						btn.Enabled = false;
						btn.Visible = false;
					}

					foreach(TextBox txt in attributeTextBoxes)
					{
						txt.Text = "20";
					}

					MakeReadOnly(attributeTextBoxes);
					UpdateAttributes();
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

		#region Updating character
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
		#endregion

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

		#region Text box modification
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

		private void ClearTextBoxes(List<TextBox> list)
		{
			foreach (TextBox txt in list)
			{
				txt.Text = "";
			}
		}
		#endregion

		#region Drag and drop
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

		private void txtAttributes_DragDrop(object sender, DragEventArgs e)
		{
			TextBox txt = (TextBox)sender;
			string oldText = txt.Text;

			txt.Text = e.Data.GetData(DataFormats.Text).ToString();

			if (oldText.Equals("")) //If nothing was there, disable the button
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
 
		private void btnAttr_MouseDown(object sender, MouseEventArgs e)
		{
			btnDropFrom = (Button) sender; //Keep track of where the drag data came from
			btnDropFrom.DoDragDrop(btnDropFrom.Text, DragDropEffects.Copy | DragDropEffects.Move);
		}
		#endregion

		private void Window_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Close all database connections
			spellsConnection.Close();
			talentsConnection.Close();
			skillsConnection.Close();
		}

		#region Homebrew checking
		private void CheckHomebrew()
		{
			bool hb = false; //Whether or not the character is homebrewed

			//Check if attributes are within [9,100]
			if(character.charisma < 9 || character.charisma > 100 ||
				character.constitution < 9 || character.constitution > 100 ||
				character.dexterity < 9 || character.dexterity > 100 ||
				character.intelligence < 9 || character.intelligence > 100 ||
				character.luck < 9 || character.luck > 100 ||
				character.strength < 9 || character.strength > 100 ||
				character.wisdom < 9 || character.wisdom > 100)
			{
				hb = true;
				goto finished;
			}

			//Check the number of primary skills (more than 5 is homebrewed)
			if(primarySkillCount > 5)
			{
				hb = true;
				goto finished;
			}

			//Check each spell
			foreach(string spell in character.spells)
			{
				if(CheckSpellHomebrew(spell))
				{
					hb = true;
					goto finished;
				}
			}

			//Check each talent
			foreach(string talent in character.talents)
			{
				if(CheckTalentHomebrew(talent))
				{
					hb = true;
					goto finished;
				}
			}

			//TODO: Check other homebrew things

finished: //If the function has determined the character is homebrewed, jump here to skip unnecessary checks
			chkHomebrew.Checked = hb;
		}

		/// <summary>
		/// Checks if the character is homebrewed based off of a spell
		/// </summary>
		/// <param name="spell">Spell to check</param>
		/// <returns>True if the character is homebrewed, false otherwise</returns>
		private bool CheckSpellHomebrew(string spell)
		{
			//Get the prerequisites for the spell from the database
			DataSet ds = PerformQuery(spellsConnection, "SELECT prereq FROM Spells WHERE spell_name = '" + spell + "'", "Spells");
			DataRow row = ds.Tables["Spells"].Rows[0];
			
			//Don't need to check prereqs if there are none
			if(row[0].ToString().Equals(""))
			{
				return false;
			}

			string[] prereqs = row[0].ToString().Split(','); //Split the prerequisites into an array for easier parsing

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
					string[] split = pr.Split(' ');

					//Check the skill value of the school associated with the meta magic spell
					if(character.GetSkillValue(character.metaSpells[spell]) < TryParseInteger(split[1]))
					{
						return true;
					}
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

		/// <summary>
		/// Checks if the character is homebrewed bassed off of a talent
		/// </summary>
		/// <param name="talent">Talent to check</param>
		/// <returns>True if the character is homebrewed, false otherwise</returns>
		private bool CheckTalentHomebrew(string talent)
		{
			DataSet ds = PerformQuery(talentsConnection, "SELECT prereq FROM Talents WHERE talent_name = '" + talent + "'", "Talents");
			DataRow row = ds.Tables["Talents"].Rows[0];

			//Check if there are any prereqs to check
			if(row[0].ToString().Equals(""))
			{
				return false;
			}

			string[] prereqs = row[0].ToString().Split(',');

			foreach(string p in prereqs)
			{
				string prereq = p.Trim();

				//Check if it's an attribute prereq
				if(prereq.StartsWith("CHA") ||
					prereq.StartsWith("CON") ||
					prereq.StartsWith("DEX") ||
					prereq.StartsWith("LCK") ||
					prereq.StartsWith("INT") ||
					prereq.StartsWith("SPD") ||
					prereq.StartsWith("STR") ||
					prereq.StartsWith("WIS"))
				{
					//Some talents must meet one of two attribute requirements
					if (prereq.Contains("or"))
					{
						//Split the string around the word 'or'
						Regex regex = new Regex(@"\bor\b");
						string[] tempArray = regex.Split(prereq); //Temporarily holds the strings until further processng
						string[][] attributeReqs = new string[2][]; //It's always between one attribute or another, safe to use constant

						//Split each element of tempArray around the space between the attribute and the value, also trimming spaces
						for (int i = 0; i < attributeReqs.Length; ++i)
						{
							tempArray[i] = tempArray[i].Trim();
							attributeReqs[i] = tempArray[i].Split(' ');
						}

						//Check the characters scores against the requirements
						if (character.GetAttributeValue(attributeReqs[0][0]) < TryParseInteger(attributeReqs[0][1]) &&
						   character.GetAttributeValue(attributeReqs[1][0]) < TryParseInteger(attributeReqs[1][1]))
						{
							return true;
						}
					}
					else
					{
						string[] attributeReq = prereq.Split(' ');

						if(character.GetAttributeValue(attributeReq[0]) < TryParseInteger(attributeReq[1]))
						{
							return true;
						}
					}
				}
				//Check if the prereq is one of the empulse spells
				else if(prereq.Equals("Empulse Spell"))
				{
					//Only need to check if they have Empulse I
					//(if the character doesn't, and has other empulse spells it's homebrewed anyways)
					if(!character.spells.Contains("Empulse I"))
					{
						return true;
					}
				}
				//Check if it's a talent prereq
				else if(clbTalents.Items.Contains(prereq))
				{
					if(!character.talents.Contains(prereq))
					{
						return true;
					}
				}
				//Check if it's a spell prereq
				else if(clbSpells.Items.Contains(prereq))
				{
					if(!character.spells.Contains(prereq))
					{
						return true;
					}
				}
				//Check if it's a size prereq
				else if(prereq.ToLower().Contains("creature") &&
					(prereq.ToLower().Contains("medium") || prereq.ToLower().Contains("large") ||
					prereq.ToLower().Contains("small")))
				{
					if(!prereq.ToLower().Contains(character.size.ToLower()))
					{
						return true;
					}
				}
				else
				{
					string[] splitPrereq = prereq.Split(' ');

					//Check if it's a skill prereq
					int skillValue = character.GetSkillValue(splitPrereq[0]);
					if(skillValue > -1 || prereq.ToLower().StartsWith("heavy armor") ||
						prereq.ToLower().Trim().StartsWith("light armor") ||
						prereq.ToLower().Trim().StartsWith("ranged combat") ||
						prereq.ToLower().Trim().StartsWith("sense motive") ||
						prereq.ToLower().Trim().StartsWith("sleight of hand") ||
						prereq.ToLower().Trim().StartsWith("unarmed combat") ||
						prereq.ToLower().Trim().StartsWith("melee weapon"))
					{
						if(skillValue < TryParseInteger(splitPrereq[splitPrereq.Length - 1]))
						{
							return true;
						}
					}
					else
					{
						Console.WriteLine(prereq); //Debug it just in case I missed something
					}
				}
			} //end foreach

			return false;
		}

		/// <summary>
		/// Checks if the specified string contains a valid school of magic
		/// </summary>
		/// <param name="school">String to check</param>
		/// <returns>True if the string contains a valid school of magic, false otherwise</returns>
		private bool IsValidSchool(string school)
		{
			school = school.ToLower();
			return school.Equals("alteration") || school.Equals("destruction") || school.Equals("restoration") || school.Equals("conjuration");
		}
		#endregion

		#region CheckListBox handlers
		private void clbSpells_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Get information about the spell
			string spellName = clbSpells.SelectedItem.ToString();

			DataSet ds = PerformQuery(spellsConnection,
				"SELECT cost, school, prereq, effect FROM Spells WHERE spell_name = '" + spellName + "'",
				"Spells");
			DataRow row = ds.Tables["Spells"].Rows[0];

			//Update the talent quick info view with the talent information
			txtSpellInfo.Text = spellName +
				Environment.NewLine + "School: " + row[1] +
				Environment.NewLine + "Cost: " + row[0] +
				Environment.NewLine + "Prerequisites: " +
				(string.IsNullOrWhiteSpace(row[2].ToString()) ? "None" : row[2]) +
				Environment.NewLine + row[3];
			txtSpellInfo.SelectionStart = 0;
			txtSpellInfo.SelectionLength = 0;
		}

		private void clbSpells_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.CurrentValue == CheckState.Checked)
			{
				character.spells.Remove(clbSpells.SelectedItem.ToString());
				character.metaSpells[clbSpells.SelectedItem.ToString()] = null;
			}
			else
			{
				//Check if the spell is a meta spell
				DataRow row = PerformQuery(spellsConnection, "SELECT school FROM Spells WHERE spell_name = '" + clbSpells.SelectedItem.ToString() + "'", "Spells").Tables["Spells"].Rows[0];

				if (row[0].ToString().Equals("Meta"))
				{
					//If the spell is meta magic, prompt the user to find out which school they want to use for the spell
					string school = "";
					school = Microsoft.VisualBasic.Interaction.InputBox("Which school would you like to use for the spell?",
																		"School selection");

					//Make sure the school is valid
					while (!IsValidSchool(school))
					{
						if (school.Equals(""))
						{
							e.NewValue = CheckState.Unchecked;
							return;
						}

						school = Microsoft.VisualBasic.Interaction.InputBox("Invalid school. Please use alteration, conjuration, destruction, or restoration",
																			"School selection");
					}

					//Make the school initial case (for later use)
					school = char.ToUpper(school[0]) + school.Substring(1).ToLower();
					character.metaSpells[clbSpells.SelectedItem.ToString()] = school;
				}

				character.spells.Add(clbSpells.SelectedItem.ToString());
			}

			CheckHomebrew();
		}

		private void clbSkills_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(e.NewValue == CheckState.Unchecked)
			{
				--primarySkillCount;
				character.skills[e.Index] = 10;
			}
			else
			{
				++primarySkillCount;
				character.skills[e.Index] = 25;
			}

			CheckHomebrew();

			//TODO Update skill values
		}

		private void clbTalents_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Get information about the talent
			string talentName = clbTalents.SelectedItem.ToString();
			
			DataSet ds = PerformQuery(talentsConnection,
				"SELECT prereq, desc FROM Talents WHERE talent_name = '" + talentName + "'",
				"Talents");
			DataRow row = ds.Tables["Talents"].Rows[0];

			//Update the talent quick info view with the talent information
			txtTalentInfo.Text = talentName +
				Environment.NewLine + "Prerequisites: " +
				(string.IsNullOrWhiteSpace(row[0].ToString()) ? "None" : row[0]) +
				Environment.NewLine + row[1];
			txtTalentInfo.SelectionStart = 0;
			txtTalentInfo.SelectionLength = 0;
		}

		private void clbTalents_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(e.CurrentValue == CheckState.Unchecked)
			{
				character.talents.Add(clbTalents.SelectedItem.ToString());
			}
			else
			{
				character.talents.Remove(clbTalents.SelectedItem.ToString());
			}

			CheckHomebrew();
		}

		private void clbSkills_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Get information about the skill
			string skillName = clbSkills.SelectedItem.ToString();
			DataSet ds = PerformQuery(skillsConnection, 
				"SELECT desc FROM Skills WHERE skill_name = '" + skillName + "'", "Skills");
			DataRow row = ds.Tables["Skills"].Rows[0];

			//Update the quick info panel with the skills information
			txtSkillInfo.Text = skillName + Environment.NewLine + row[0].ToString();
			txtSkillInfo.SelectionStart = 0;
			txtSkillInfo.SelectionStart = 0;
		}
		#endregion

	}
}
