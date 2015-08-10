/*
 * Copyright (C) 2015 Jacob Long
 * 
 * This file is part of Solipstry Character Creator
 * 
 * Solipstry Character Creator is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * any later version.
 * 
 * Solipstry Character Creator is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Affero General Public License for more details.
 * 
 * You should have received a copy of the GNU Affero General Public License
 * along with Solipstry Character Creator. If not, see <http://www.gnu.org/licenses/>.
 */

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
using System.Net.Mail;
using System.Net;
using System.IO;

using Microsoft;

using iTextSharp.text.pdf;

namespace Solipstry_Character_Creator
{
    public partial class Window : Form
    {
		//Access strings for the databases
		private const string ABILITIES_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abilities.accdb";
		private const string TALENTS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Talents.accdb";
		private const string SKILLS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Skills.accdb";

		//States for displaying different schools of magic
		private const int DISPLAY_ALL_ABILITIES = 0;
		private const int DISPLAY_ALTERATION = 1;
		private const int DISPLAY_CREATION = 2;
		private const int DISPLAY_DESTRUCTION = 3;
		private const int DISPLAY_RESTORATION = 4;
		private const int DISPLAY_META = 5;

		//Spacing between talent names and the short description
		private const int TALENT_DESC_SPACING = 29;
		//Spacing between ability names and schools
		private const int ABILITY_SPACING = 30;

		//List of talents that modify attributes, skills, etc.
		private List<string> modifyingTalents;

		//List of talents that can be taken multiple times
		private List<string> multipleTimesTalents;

		private OleDbConnection abilitiesConnection;
		private OleDbConnection talentsConnection;
		private OleDbConnection skillsConnection;

        private Character character;
		private List<Button> attrValuesList;
		private List<TextBox> attributeTextBoxes;

		private List<string> customTalents;
		private List<CustomSkill> customSkills;
		private List<CustomAbility> customAbilities;

		//Keeps track of any modified attributes or skills
		private List<ModifiedScore> modifiedScores;

		//Modifiers to the number of abilities that can be taken per school
		//due to the Student of Magic talent
		private int somAlteration;
		private int somCreation;
		private int somDestruction;
		private int somRestoration;

		//Button that the drag and drop originated from
		private Button btnDropFrom;

		//Number of skills set as primary skills
		private int primarySkillCount;
		//Number of talents the user has chosen
		private int talentsTaken;

		//Number of alteration abilities the user has chosen
		private int alterationTaken;
		//Number of creation abilities the user has chosen
		private int creationTaken;
		//Number of destruction abilities the user has chosen
		private int destructionTaken;
		//Number of restoration abilities the user has taken
		private int restorationTaken;

		//Number of skills the use can select as primary
		private int primarySkillsAvailable;
		//Number of talents the character can have without being homebrewed 
		private int talentsAvailable;
		
		//Number of alteration abilities the character can have without being homebrewed
		private int alterationAvailable;
		//Number of creation abilities the character can have without being homebrewed
		private int creationAvailable;
		//Number of destruction abilities the character can have without being homebrewed
		private int destructionAvailable;
		//Number of restoration abilities the character can have without being homebrewed
		private int restorationAvailable;

		//Whether or not a CheckedListBox is being sorted
		private bool sorting; 

		//State machine variable for which school of magic to display
		private int abilityDisplay;

		#region Program setup
		public Window()
        {
            InitializeComponent();

			character = new Character();

			customTalents = new List<string>();
			customSkills = new List<CustomSkill>();
			customAbilities = new List<CustomAbility>();

			modifiedScores = new List<ModifiedScore>();

			somAlteration = 0;
			somCreation = 0;
			somDestruction = 0;
			somRestoration = 0;

			abilityDisplay = DISPLAY_ALL_ABILITIES;

			//Create context menu strips
			ContextMenuStrip talentsMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem newTalentItem = new ToolStripMenuItem("New Talent");
			newTalentItem.Name = "New Talent";
			newTalentItem.Click += new EventHandler(newTalentMenuItem_Click);

			talentsMenuStrip.Items.Add(newTalentItem);
			clbTalents.ContextMenuStrip = talentsMenuStrip;

			ContextMenuStrip skillsMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem newSkillItem = new ToolStripMenuItem("New Skill");
			newSkillItem.Name = "New Skill";
			newSkillItem.Click += new EventHandler(newSkillMenuItem_Click);

			skillsMenuStrip.Items.Add(newSkillItem);
			clbSkills.ContextMenuStrip = skillsMenuStrip;

			ContextMenuStrip abilitiesMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem newAbilityItem = new ToolStripMenuItem("New Ability");
			newAbilityItem.Name = "New Ability";
			newAbilityItem.Click += new EventHandler(newAbilityMenuItem_Click);

			abilitiesMenuStrip.Items.Add(newAbilityItem);
			clbAbilities.ContextMenuStrip = abilitiesMenuStrip;

			primarySkillsAvailable = 5; //Can only have 5 primary skills
			talentsAvailable = 1; //First level characters can only take one talent
			
			//User can take 1 of each ability by default
			alterationAvailable = 1;
			creationAvailable = 1;
			destructionAvailable = 1;
			restorationAvailable = 1;


			multipleTimesTalents = new List<string>
			{
				"Adaptive Skin",
				"Basic Training",
				"Devout Follower",
				"Far Shot",
				"Greater Magic",
				"Improved Defense",
				"Improved Initiative",
				"Improved Rushing",
				"Increased Teleportation",
				"Lucky Break",
				"Power Word II",
				"Power Word III",
				"Reprogrammable Augmentation",
				"Reslience",
				"Skill Specialization",
				"Student of Magic",
				"Thick Skin"
			};

			modifyingTalents = new List<string>
			{
				"Basic Training",
				"Devout Follower",
				"Greater Magic",
				"Improved Initiative",
				"Improved Magic Flow",
				"Lucky Break",
				"More Efficient, Less Wasteful",
				"Quick Steps",
				"Resilience",
				"Skill Specialization",
				"Student of Magic",
				"Thick Skin"
			};

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
			abilitiesConnection = new OleDbConnection(ABILITIES_ACCESS_STRING);
			talentsConnection = new OleDbConnection(TALENTS_ACCESS_STRING);
			skillsConnection = new OleDbConnection(SKILLS_ACCESS_STRING);
			try
			{
				abilitiesConnection.Open();
				talentsConnection.Open();
				skillsConnection.Open();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error opening connection to database: {0}", e.Message);
			}

			DisplayEligibleAbilities();
			DisplayEligibleTalents();
			FillSkillsList();

			UpdateInformation();
		}

		private void Window_Load(object sender, EventArgs e)
		{
			//Set combo boxes and radio buttons to default values
			cmbAttributeMethod.SelectedIndex = 0; //All 20s for attributes
			cmbSize.SelectedIndex = 1; //Medium size
			cmbSchoolDisplay.SelectedIndex = 0; //Display all schools of magic
			rdoHeavyArmor.Checked = true; //Heavy armor
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
			UpdateInformation();

			CheckHomebrew();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.size = (string) cmbSize.SelectedItem;
			UpdateInformation();
			CheckHomebrew(); //Some talents depend on size
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

			UpdateInformation();
        }

		#region Updating character
		private void UpdateInformation()
		{
			UpdateAttributes();
			CalculateDerivedTraits();
			UpdateFromTalents();
			UpdateQuickPane();
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

		private void UpdateFromTalents()
		{
			foreach(ModifiedScore mod in modifiedScores)
			{
				switch(mod.modifiedBy)
				{
					case "Devout Follower":
						character.enlightenment += 10;
						break;
					case  "Greater Magic":
						character.magicTotal += 10;
						break;
					case "Improved Magic Flow":
						character.magicRegen += 5;
						break;
					case "Improved Initiative":
						character.initiative += 2;
						break;
					case "Lucky Break":
						++character.fortunePoints;
						break;
					case "Quick Steps":
						++character.movement;
						break;
					case "Resilience":
						++character.reflexHeavy;
						++character.reflexLight;
						++character.will;
						++character.fortitude;
						break;
					case "Thick Skin":
						character.hitPoints += 5;
						break;
					case "Skill Specialization":
						if(mod.modifiedScore.Equals("Enlightenment"))
						{
							character.enlightenment = character.GetSkillValue("Enlightenment");
							character.enlightenment += 3;
						}
						break;
				}
			}
		}

		private void UpdateBasicInformation()
		{
			character.name = txtName.Text;
			character.race = txtRace.Text;
			character.height = txtHeight.Text;
			character.weight = txtWeight.Text;
			character.occupation = txtOccupation.Text;
			character.aspiration = txtAspiration.Text;
			character.background = txtBackground.Text;
			character.age = txtAge.Text;
		}

		private void CalculateDerivedTraits()
		{
			character.movement = 3 + character.CalculateModifier(character.speed);
			character.hitPoints = (int)Math.Truncate(1.5 * (double)character.constitution);
			character.initiative = character.CalculateModifier(character.speed);

			character.magicTotal = 5 * character.CalculateModifier(character.wisdom);
			character.magicRegen = character.CalculateModifier(character.intelligence);
			character.fortunePoints = character.CalculateModifier(character.luck);
			character.enlightenment = character.skills[Skills.ENLIGHTENMENT];

			character.acLight = 7 + character.CalculateModifier(Math.Max(character.speed, character.dexterity)) + character.CalculateModifier(character.skills[Skills.LIGHT_ARMOR]);
			character.acHeavy = 12 + character.CalculateModifier(character.skills[Skills.HEAVY_ARMOR]);
			
			character.reflexLight = 5 + character.CalculateModifier(Math.Max(character.speed, character.dexterity)) + character.CalculateModifier(character.skills[Skills.LIGHT_ARMOR]);
			character.reflexHeavy = character.CalculateModifier(Math.Max(character.speed, character.dexterity)) + character.CalculateModifier(character.skills[Skills.HEAVY_ARMOR]);
			
			character.will = 10 + character.CalculateModifier(character.wisdom);
			character.fortitude = 10 + character.CalculateModifier(character.constitution);

			character.magicTotal = 5 * character.wisdom;
			character.magicRegen = character.intelligence;

			switch(cmbSize.SelectedIndex)
			{
				case 0: //Small
					++character.reflexHeavy;
					++character.reflexLight;
					break;
				case 2: //Large
					--character.reflexHeavy;
					--character.reflexLight;
					break;
			}
		}

		private void UpdateQuickPane()
		{
			lblQuickCharisma.Text = character.charisma.ToString();
			lblQuickConstitution.Text = character.constitution.ToString();
			lblQuickDexterity.Text = character.dexterity.ToString();
			lblQuickIntelligence.Text = character.intelligence.ToString();
			lblQuickLuck.Text = character.luck.ToString();
			lblQuickSpeed.Text = character.speed.ToString();
			lblQuickStrength.Text = character.strength.ToString();
			lblQuickWisdom.Text = character.wisdom.ToString();

			lblHP.Text = character.hitPoints.ToString();
			lblInitiative.Text = character.initiative.ToString();
			
			//Display AC based on current armor chocie
			if(rdoHeavyArmor.Checked)
			{
				lblAc.Text = character.acHeavy.ToString();
			}
			else
			{
				lblAc.Text = character.acLight.ToString();
			}

			lblMagicTotal.Text = character.magicTotal.ToString();
			lblMagicRegen.Text = character.magicRegen.ToString();
			lblEnlightenment.Text = (character.enlightenment + character.CalculateModifier(character.GetAttributeValue("CHA"))).ToString();
			lblFortunePoints.Text = character.fortunePoints.ToString();

			lblWill.Text = character.will.ToString();
			lblFortitude.Text = character.fortitude.ToString();

			//Display reflex based on current armor choice
			if(rdoHeavyArmor.Checked)
			{
				lblReflex.Text = character.reflexHeavy.ToString();
			}
			else
			{
				lblReflex.Text = character.reflexLight.ToString();
			}
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

			UpdateInformation();
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
			abilitiesConnection.Close();
			talentsConnection.Close();
			skillsConnection.Close();
		}

		#region Homebrew checking
		private void CheckHomebrew()
		{
			bool hb = false; //Whether or not the character is homebrewed

			//Check custom talents, abilities, and talents
			if(character.customTalents.Count > 0 || customSkills.Count > 0 || character.customAbilities.Count > 0)
			{
				hb = true;
				goto finished;
			}

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
			if(primarySkillCount > primarySkillsAvailable)
			{
				hb = true;
				goto finished;
			}

			//Check the number of talents taken
			if(talentsTaken > talentsAvailable)
			{
				hb = true;
				goto finished;
			}

			//Check the number of each ability the user has taken
			if(alterationTaken > alterationAvailable + somAlteration ||
				creationTaken > creationAvailable + somCreation ||
				destructionTaken > destructionAvailable + somDestruction ||
				restorationTaken > restorationAvailable + somRestoration)
			{
				hb = true;
				goto finished;
			}

			//Check each ability
			foreach(string ability in character.abilities)
			{
				DataSet ds = PerformQuery(abilitiesConnection, "SELECT prereq FROM Abilities WHERE ability_name = '" + ability + "'", "Abilities");
				DataRow row = ds.Tables["Abilities"].Rows[0];

				if (row[0] == null)
				{
					continue;
				}

				string prereq = row[0].ToString();

				if (CheckAbilityHomebrew(prereq, ability))
				{
					hb = true;
					goto finished;
				}
			}

			//Check each talent
			foreach(string talent in character.talents)
			{
				DataSet ds = PerformQuery(talentsConnection, "SELECT prereq FROM Talents WHERE talent_name = '" + talent + "'", "Talents");
				DataRow row = ds.Tables["Talents"].Rows[0];

				if(row[0] == null)
				{
					continue;
				}

				string prereq = row[0].ToString();

				if(CheckTalentHomebrew(talent))
				{
					hb = true;
					goto finished;
				}
			}

		finished: //If the function has determined the character is homebrewed, jump here to skip unnecessary checks
			lblHomebrewed.Visible = hb;
		}

		/// <summary>
		/// Checks if the character is homebrewed based off of a ability
		/// </summary>
		/// <param name="ability">Ability to check</param>
		/// <returns>True if the character is homebrewed, false otherwise</returns>
		private bool CheckAbilityHomebrew(string prerequisite, string abilityName)
		{			
			//Don't need to check prereqs if there are none
			if(prerequisite.Equals(""))
			{
				return false;
			}
			
			string[] prereqs = prerequisite.Split(','); //Split the prerequisites into an array for easier parsing

			foreach(string pr in prereqs)
			{
				//Check which kind of prereq it is (skill level or other ability)
				if(pr.StartsWith("Destruction") ||
				   pr.StartsWith("Creation") ||
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
					//If the character hasn't taken the ability and chosen a school for it, don't mark it as homebrewed
					if(!character.abilities.Contains(abilityName))
					{
						continue;
					}

					string[] split = pr.Split(' ');

					//Check the skill value of the school associated with the meta magic ability
					if(character.GetSkillValue(character.metaAbilities[abilityName]) < TryParseInteger(split[1]))
					{
						return true;
					}
				}
				else
				{
					//If the character doesn't have the prerequisite abilities, its homebrewed
					if(!character.abilities.Contains(pr))
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
		private bool CheckTalentHomebrew(string prerequisite)
		{
			//Check if there are any prereqs to check
			if(prerequisite.ToString().Equals(""))
			{
				return false;
			}

			string[] prereqs = prerequisite.ToString().Split(',');

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
				//Check if the prereq is one of the empulse abilities
				else if(prereq.Equals("Empulse Ability"))
				{
					//Only need to check if they have Empulse I
					//(if the character doesn't, and has other empulse abilities it's homebrewed anyways)
					if(!character.abilities.Contains("Empulse I"))
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
					else if(!character.abilities.Contains(prereq) && !character.talents.Contains(prereq))
					{
						return true;
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
			return school.Equals("alteration") || school.Equals("destruction") || school.Equals("restoration") || school.Equals("creation");
		}
		#endregion

		#region CheckListBox handlers
		private void clbAbilities_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Only use the substring if displaying the school
			string abilityName = clbAbilities.SelectedItem.ToString();
			if(abilityName.Length > ABILITY_SPACING)
			{
				abilityName = abilityName.Substring(0, ABILITY_SPACING);
			}

			//Get information about the ability
			if(IsCustomAbility(abilityName))
			{
				CustomAbility ability = GetCustomAbility(abilityName);

				txtAbilityInfo.Text = abilityName + Environment.NewLine +
					"School: " + ability.school + Environment.NewLine +
					"Cost: " + ability.cost;
			}
			else
			{
				DataSet ds = PerformQuery(abilitiesConnection,
					"SELECT cost, school, prereq, effect FROM Abilities WHERE ability_name = '" + abilityName + "'",
					"Abilities");
				DataRow row = ds.Tables["Abilities"].Rows[0];

				//Update the talent quick info view with the talent information
				txtAbilityInfo.Text = abilityName +
					Environment.NewLine + "School: " + row[1] +
					Environment.NewLine + "Cost: " + row[0] +
					Environment.NewLine + "Prerequisites: " +
					(string.IsNullOrWhiteSpace(row[2].ToString()) ? "None" : row[2]) +
					Environment.NewLine + row[3];
				txtAbilityInfo.SelectionStart = 0;
				txtAbilityInfo.SelectionLength = 0;
			}
		}

		private void clbAbilities_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(sorting)
			{
				return;
			}


			string abilityName = clbAbilities.Items[e.Index].ToString();
			//Remove the school display from the ability name if necessary
			if(abilityName.Length > ABILITY_SPACING)
			{
				abilityName = abilityName.Substring(0, ABILITY_SPACING);
			}

			abilityName = abilityName.Trim();

			if(IsCustomAbility(abilityName))
			{
				 if(e.NewValue == CheckState.Unchecked)
				 {
					 character.customAbilities.Remove(abilityName);
				 }
				 else
				 {
					 character.customAbilities.Add(abilityName);
				 }
			}
			else
			{
				string school = GetAbilitySchool(abilityName);

				if (e.NewValue == CheckState.Unchecked)
				{
					//If the ability is a meta ability, use the chosen school. Otherwise use the school for the ability
					//as listed in the database
					switch (school.Equals("Meta") ? character.metaAbilities[abilityName] : school)
					{
						case "Alteration":
							--alterationTaken;
							break;
						case "Creation":
							--creationTaken;
							break;
						case "Destruction":
							--destructionTaken;
							break;
						case "Restoration":
							--restorationTaken;
							break;
					}

					character.abilities.Remove(abilityName);
					character.metaAbilities[abilityName] = null;
				}
				else
				{
					if (school.Equals("Meta"))
					{
						List<string> schools = new List<string>();
						schools.Add("Alteration");
						schools.Add("Creation");
						schools.Add("Destruction");
						schools.Add("Restoration");
					
						//Have the user select which school to use for the meta ability
						SelectionDialog schoolSelector = new SelectionDialog(schools, "Select a school to use");
						DialogResult result = schoolSelector.ShowDialog();

						if(result == DialogResult.OK)
						{
							character.metaAbilities[abilityName] = schoolSelector.GetSelectedItem();
						}
						else
						{
							e.NewValue = e.CurrentValue;
							return;
						}
					}

					//If the ability is a meta ability, use the chosen school. Otherwise use the school for the ability
					//as listed in the database
					switch (school.Equals("Meta") ? character.metaAbilities[abilityName] : school)
					{
						case "Alteration":
							++alterationTaken;
							break;
						case "Creation":
							++creationTaken;
							break;
						case "Destruction":
							++destructionTaken;
							break;
						case "Restoration":
							++restorationTaken;
							break;
					}

					character.abilities.Add(abilityName);
				}
			}

			UpdateAbilitiesRemainingLabels();

			CheckHomebrew();
		}

		private void clbSkills_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(sorting)
			{
				return;
			}

			string skillName = clbSkills.SelectedItem.ToString();

			//Custom skills
			if (IsCustomSkill(skillName))
			{
				if(e.NewValue == CheckState.Unchecked)
				{
					--primarySkillCount;
					character.customSkills[skillName] -= 15;
				}
				else
				{
					++primarySkillCount;
					character.customSkills[skillName] += 15;
				}
			}
			//Built in skills
			else
			{
				if (e.NewValue == CheckState.Unchecked)
				{
					--primarySkillCount;
					character.skills[e.Index] = 10;
				}
				else
				{
					++primarySkillCount;
					character.skills[e.Index] = 25;
				}
			}

			//Show how many primary skills over/under the homebrew limit the user is
			int primarySkillsRemaining = primarySkillsAvailable - primarySkillCount;

			if(primarySkillsRemaining < 0)
			{
				lblPrimarySkillsRemaining.Text = Math.Abs(primarySkillsRemaining)
					+ " primary skill(s) over limit";
				lblPrimarySkillsRemaining.ForeColor = Color.Red;
			}
			else
			{
				lblPrimarySkillsRemaining.Text = primarySkillsRemaining
					+ " primary skill(s) remaining";
				lblPrimarySkillsRemaining.ForeColor = Color.Black;
			}

			CheckHomebrew();

			UpdateInformation();

			alterationAvailable = character.CalculateModifier(character.skills[Skills.ALTERATION]);
			creationAvailable = character.CalculateModifier(character.skills[Skills.CREATION]);
			destructionAvailable = character.CalculateModifier(character.skills[Skills.DESTRUCTION]);
			restorationAvailable = character.CalculateModifier(character.skills[Skills.RESTORATION]);

			UpdateAbilitiesRemainingLabels();	
		}

		private void clbSkills_SelectedIndexChanged(object sender, EventArgs e) 
		{
			//Get information about the skill
			string skillName = clbSkills.SelectedItem.ToString().Trim();

			if (IsCustomSkill(skillName))
			{
				CustomSkill skill = GetCustomSkill(skillName);
				txtSkillInfo.Text = skillName + Environment.NewLine + skill.governingAttribute + " based.";
			}
			else
			{
				DataSet ds = PerformQuery(skillsConnection,
					"SELECT desc FROM Skills WHERE skill_name = '" + skillName + "'", "Skills");
				DataRow row = ds.Tables["Skills"].Rows[0];

				//Update the quick info panel with the skills information
				txtSkillInfo.Text = skillName + Environment.NewLine + row[0].ToString();
				txtSkillInfo.SelectionStart = 0;
				txtSkillInfo.SelectionStart = 0;
			}
		}

		private void clbTalents_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(clbTalents.SelectedItem == null)
			{
				return;
			}

			//Get information about the talent
			string talentName = clbTalents.SelectedItem.ToString();
			if(talentName.Length > TALENT_DESC_SPACING)
			{
				talentName = talentName.Substring(0, TALENT_DESC_SPACING).Trim();
			}

			if(customTalents.Contains(talentName))
			{
				txtTalentInfo.Text = talentName;
			}
			else 
			{
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
		}

		private void clbTalents_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(sorting)
			{
				return;
			}

			string talentName = clbTalents.SelectedItem.ToString();
			if(talentName.Length > TALENT_DESC_SPACING)
			{
				talentName = talentName.Substring(0, TALENT_DESC_SPACING).Trim();
			}

			//Custom talents
			if(customTalents.Contains(talentName))
			{
				if(e.NewValue == CheckState.Checked)
				{
					character.customTalents.Add(talentName);
					++talentsTaken;
				}
				else
				{
					character.customTalents.Remove(talentName);
					--talentsTaken;
				}
			}
			//Built in talents
			else
			{
				if(e.NewValue == CheckState.Checked)
				{
					character.talents.Add(talentName);

					//Check if the talent modifies anything (attributes, skills, etc)
					if(modifyingTalents.Contains(talentName))
					{
						ModifiedScore modified = new ModifiedScore();
						modified.modifiedBy = talentName;
						modified.modifiedScore = null;
						modified.userMarks = false;

						SelectionDialog selection;
						DialogResult result;

						switch(talentName)
						{
							case "Adaptive Skin":
							case "Iron Resolve":
							case "Power Word":
							case "Power Word II":
							case "Power Word III":
								modified.userMarks = true;
								break;
							case "Basic Training":
								modified.userMarks = true;
								
								//Have the user select a skill
								selection = new SelectionDialog(clbSkills.Items, "Select a Skill");
								result = selection.ShowDialog();

								if (result == DialogResult.OK)
								{
									modified.modifiedScore = selection.GetSelectedItem();
								}
								else
								{
									e.NewValue = e.CurrentValue;
									return;
								}

								break;
							case "Skill Specialization": //+3 to any skill
								//Have the user select a skill
								selection = new SelectionDialog(clbSkills.Items, "Select a Skill");
								result = selection.ShowDialog();

								if(result == DialogResult.OK)
								{
									modified.modifiedScore = selection.GetSelectedItem();
								}
								else
								{
									e.NewValue = e.CurrentValue;
									return;
								}

								break;
							case "Student of Magic": //additional abilities with requirements met
								//Figure out which abilities the user can take
								List<string> validAbilities = new List<string>();

								DataSet ds = PerformQuery(abilitiesConnection,
									"SELECT prereq, ability_name FROM Abilities", "Abilities");
								DataTable table = ds.Tables["Abilities"];

								foreach(DataRow row in table.Rows)
								{
									if(row[0] == null || !CheckAbilityHomebrew(row[0].ToString(), row[1].ToString()))
									{
										validAbilities.Add(row[1].ToString());
									}
								}

								foreach(CustomAbility customAbility in customAbilities)
								{
									validAbilities.Add(customAbility.name);
								}

								//Have the user select the ability they want
								selection = new SelectionDialog(validAbilities, "Select an Ability");
								result = selection.ShowDialog();

								if(result == DialogResult.OK)
								{
									modified.modifiedScore = selection.GetSelectedItem();
									clbAbilities.SelectedItem = modified.modifiedScore;
									clbAbilities.SetItemChecked(clbAbilities.SelectedIndex, true);

									switch(GetAbilitySchool(selection.GetSelectedItem()))
									{
										case "Alteration":
											++somAlteration;
											break;
										case "Creation":
											++somCreation;
											break;
										case "Destruction":
											++somDestruction;
											break;
										case "Restoration":
											++somRestoration;
											break;
									}
								}
								else
								{
									e.NewValue = e.CurrentValue;
									return;
								}

								UpdateAbilitiesRemainingLabels();

								break;
						}

						modifiedScores.Add(modified);
					} //endif for checking for modifying from talents


					//Check if the talent can be taken multiple times
					if (multipleTimesTalents.Contains(talentName))
					{
						//Add the talent to the list so it can be taken again
						clbTalents.Items.Add(clbTalents.SelectedItem.ToString());
						SortCheckedListBox(clbTalents);
						clbTalents.SelectedIndex = e.Index + 1;
					}

					++talentsTaken;
				} //endif new value == checked
				else
				{
					character.talents.Remove(clbTalents.SelectedItem.ToString());

					//Check if the talent modifies anything (attributes, skills, etc)
					if (modifyingTalents.Contains(talentName))
					{
						DialogResult result;

						switch (talentName)
						{
							case "Basic Training":
							case "Skill Specialization":
								List<string> modifiedSkills = new List<string>();

								//Find the skills that were modified
								foreach (ModifiedScore mod in modifiedScores)
								{
									if (mod.modifiedBy.Equals(talentName))
									{
										modifiedSkills.Add(mod.modifiedScore);
									}
								}

								SelectionDialog skillSelector = new SelectionDialog(modifiedSkills, "Which skill to remove from?");
								result = skillSelector.ShowDialog();
	
								if(result == DialogResult.OK)
								{
									for(int n = 0; n < modifiedScores.Count; ++n)
									{
										if(modifiedScores[n].modifiedScore.Equals(skillSelector.GetSelectedItem()) &&
											modifiedScores[n].modifiedBy.Equals(talentName))
										{
											modifiedScores.RemoveAt(n);
											break;
										}
									}
								}
								else
								{
									e.NewValue = e.CurrentValue;
									return;
								}

								break;
							case "Student of Magic": //additional ability with requirements met
								List<string> modifiedAbilities = new List<string>();

								//Find the abilities that were added with Student of Magic
								foreach(ModifiedScore mod in modifiedScores)
								{
									if(mod.modifiedBy.Equals("Student of Magic"))
									{
										modifiedAbilities.Add(mod.modifiedScore);
									}
								}

								SelectionDialog abilitySelector = new SelectionDialog(modifiedAbilities, "Which ability to remove?");
								result = abilitySelector.ShowDialog();

								if(result == DialogResult.OK)
								{
									//Remove the ability from the list of modified abilities
									for(int n = 0; n > modifiedScores.Count; ++n)
									{
										if(modifiedScores[n].modifiedScore.Equals(abilitySelector.GetSelectedItem()))
										{
											modifiedScores.RemoveAt(n);
											break;
										}
									}

									clbAbilities.SelectedItem = abilitySelector.GetSelectedItem();
									clbAbilities.SetItemChecked(clbAbilities.SelectedIndex, false);

									switch (GetAbilitySchool(abilitySelector.GetSelectedItem()))
									{
										case "Alteration":
											--somAlteration;
											break;
										case "Creation":
											--somCreation;
											break;
										case "Destruction":
											--somDestruction;
											break;
										case "Restoration":
											--somRestoration;
											break;
									}
								}
								else
								{
									e.NewValue = e.CurrentValue;
									return;
								}

								UpdateAbilitiesRemainingLabels();

								break;
							default:
								for(int n = 0; n < modifiedScores.Count; ++n)
								{
									if(modifiedScores[n].modifiedBy.Equals(talentName))
									{
										modifiedScores.RemoveAt(n);
										break;
									}
								}
								
								break;
						} //end switch

						UpdateInformation();
					}

					//Check if the talent can be taken multiple times
					if(multipleTimesTalents.Contains(talentName))
					{
						clbTalents.Items.RemoveAt(e.Index);
					}

					--talentsTaken;
				}
			}

			//Show how many talents over/under the homebrew limit the user is
			int talentsRemaining = talentsAvailable - talentsTaken;

			if(talentsRemaining < 0)
			{
				lblTalentsRemaining.Text = Math.Abs(talentsRemaining)
					+ " talent(s) over limit";
				lblTalentsRemaining.ForeColor = Color.Red;
			}
			else
			{
				lblTalentsRemaining.Text = talentsRemaining + " talent(s) remaining";
				lblTalentsRemaining.ForeColor = Color.Black;
			}

			UpdateInformation();
			
			CheckHomebrew();
		}
		#endregion

		#region Menu stuff
		private void sendBugReportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BugReportDialog bugReport = new BugReportDialog();
			DialogResult result = bugReport.ShowDialog();

			if(result == DialogResult.OK)
			{
				string bugDesc = bugReport.txtBugDesc.Text;
				string messageText = "User email: " + bugReport.txtFromEmail.Text + Environment.NewLine +
					"Bug report: " + Environment.NewLine + bugDesc;

				SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
				//Actual SmtpCredentials file witheld from repo for security reasons
				client.Credentials = new NetworkCredential(SmtpCredentials.USERNAME,SmtpCredentials.PASSWORD);
				client.EnableSsl = true;
				client.Send("solipstrybugreport@gmail.com", "builder@solipstry.com", "Solipstry Bug Report", messageText);

			}
		}

		private void viewSourceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Link to the github page for Solipstry
			System.Diagnostics.Process.Start("https://github.com/asr1/Solipstry/tree/master/Character%20Builder/CSharp/Solipstry%20Character%20Creator");
		}


		private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new CreditsDialog().ShowDialog();
		}
		#endregion

		private void BasicInformationTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateBasicInformation();
		}

		#region Context menu handlers
		private void newTalentMenuItem_Click(object sender, EventArgs e)
		{
			string talentName = Microsoft.VisualBasic.Interaction.InputBox("New talent name");

			if(!String.IsNullOrWhiteSpace(talentName))
			{
				customTalents.Add(talentName);

				//Add the talent to the check list box and check it
				clbTalents.Items.Add(talentName);
				clbTalents.SelectedItem = talentName;
				clbTalents.SetItemChecked(clbTalents.Items.Count - 1, true);

				//Switch to showing homebrew options for talents
				chkAllTalents.Checked = true;
			}

			CheckHomebrew();
		}

		private void newAbilityMenuItem_Click(object sender, EventArgs e)
		{
			CustomAbilityForm frmAbility = new CustomAbilityForm();
			DialogResult result = frmAbility.ShowDialog();

			if(result == DialogResult.OK)
			{
				CustomAbility newAbility = new CustomAbility();
				newAbility.name = frmAbility.GetAbilityName();
				newAbility.school = frmAbility.GetSchool();
				newAbility.cost = frmAbility.GetCost();
				newAbility.effect = frmAbility.GetEffect();

				customAbilities.Add(newAbility);

				//Add the ability to the check list box and check it
				clbAbilities.Items.Add(newAbility.name);
				clbAbilities.SetItemChecked(clbAbilities.Items.Count - 1, true);

				SortCheckedListBox(clbAbilities);
				clbAbilities.SelectedItem = newAbility.name;

				//Switch to showing homebrew options for abilities
				chkAllAbilities.Checked = true;

				//If not displaying all schools, switch to the school of the new ability
				if(abilityDisplay != DISPLAY_ALL_ABILITIES)
				{
					cmbSchoolDisplay.SelectedItem = newAbility.school;
				}
				
			}

			CheckHomebrew();
		}

		private void newSkillMenuItem_Click(object sender, EventArgs e)
		{
			CustomSkillForm frmSkill = new CustomSkillForm();
			DialogResult result = frmSkill.ShowDialog();

			if(result == DialogResult.OK)
			{
				CustomSkill newSkill = new CustomSkill();
				newSkill.name = frmSkill.GetSkillName();
				newSkill.governingAttribute = frmSkill.GetGoverningAttribute();

				character.customSkills[newSkill.name] = frmSkill.IsPrimarySkill() ? 25 : 10;

				customSkills.Add(newSkill);

				//Add the skill to the check list box and check it if the user wants it to be a primary skill
				clbSkills.Items.Add(newSkill.name);
				clbSkills.SetItemChecked(clbSkills.Items.Count - 1, frmSkill.IsPrimarySkill());

				SortCheckedListBox(clbSkills);
				clbSkills.SelectedItem = newSkill.name;
			}

			CheckHomebrew();
		}
		#endregion

		/// <summary>
		/// Checks if the specified skill is a custom skill
		/// </summary>
		/// <param name="skillName">Skill to check</param>
		/// <returns>True if the skill is custom, false otherwise</returns>
		private bool IsCustomSkill(string skillName)
		{
			foreach(CustomSkill skill in customSkills)
			{
				if(skill.name.Equals(skillName))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Gets information about a custom skill
		/// </summary>
		/// <param name="skillName">Name of the skill to get</param>
		/// <returns>CustomSkill object if the skill is a custom skill, null otherwise</returns>
		private CustomSkill GetCustomSkill(string skillName)
		{
			foreach(CustomSkill skill in customSkills)
			{
				if(skill.name.Equals(skillName))
				{
					return skill;
				}
			}

			return null;
		}

		/// <summary>
		/// Checks if the specified ability is a custom ability
		/// </summary>
		/// <param name="abilityName">Ability to check</param>
		/// <returns>True if the ability is custom, false otherwise</returns>
		private bool IsCustomAbility(string abilityName)
		{
			foreach(CustomAbility ability in customAbilities)
			{
				if(ability.name.Equals(abilityName))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Gets information about a custom ability
		/// </summary>
		/// <param name="abilityName">Name of the ability to get</param>
		/// <returns>CustomAbility object if the ability is a custom ability, null otherwise</returns>
		private CustomAbility GetCustomAbility(string abilityName)
		{
			foreach (CustomAbility ability in customAbilities)
			{
				if (ability.name.Equals(abilityName))
				{
					return ability;
				}
			}

			return null;
		}

		/// <summary>
		/// Sorts the items in the specified CheckedListBox, preserving checked items
		/// </summary>
		/// <param name="clb">CheckedListBox to sort</param>
		private void SortCheckedListBox(CheckedListBox clb)
		{
			List<string> checkedItems = new List<string>();
			List<string> items = new List<string>();

			foreach(object item in clb.CheckedItems)
			{
				checkedItems.Add(item.ToString());
			}

			foreach(object item in clb.Items)
			{
				items.Add(item.ToString());
			}

			sorting = true;

			items.Sort();

			clb.Items.Clear();

			foreach(string item in items)
			{
				if(checkedItems.Contains(item))
				{
					clb.Items.Add(item, true);
					checkedItems.Remove(item);
				}
				else
				{
					clb.Items.Add(item, false);
				}
			}

			sorting = false;
		}

		#region Display all/only eligible abilities and talents
		private void chkAllTalents_CheckedChanged(object sender, EventArgs e)
		{
			//Keep track of which talents were checked
			List<string> checkedTalents = new List<string>();
			checkedTalents.AddRange(character.customTalents);
			checkedTalents.AddRange(character.talents);

			clbTalents.Items.Clear();

			//Display all talents if the check box is checked
			if (chkAllTalents.Checked)
			{
				DisplayAllTalents();
			}
			//Display only eligible talents if the check box is not checked
			else
			{
				DisplayEligibleTalents();
			}

			sorting = true; //Don't do anything when check states change

			//Re-check anything that needs to be checked
			for (int n = 0; n < clbTalents.Items.Count; ++n)
			{
				string talentName = clbTalents.Items[n].ToString();

				if (talentName.Length > TALENT_DESC_SPACING)
				{
					talentName = talentName.Substring(0, TALENT_DESC_SPACING).Trim();
				}

				if (checkedTalents.Contains(talentName))
				{
					clbTalents.SetItemChecked(n, true);
					checkedTalents.Remove(talentName);

					//Re-add the talent if it can be taken multiple times
					if(multipleTimesTalents.Contains(talentName))
					{
						clbTalents.Items.Add(clbTalents.Items[n].ToString());
					}
				}
			}

			SortCheckedListBox(clbTalents);

			sorting = false;
		}

		private void chkAllAbilities_CheckedChanged(object sender, EventArgs e)
		{
			//Keep track of which abilities were checked
			List<string> checkedAbilities = new List<string>();
			checkedAbilities.AddRange(character.abilities);
			checkedAbilities.AddRange(character.customAbilities);

			clbAbilities.Items.Clear();

			//Display all abilities if the check box is checked
			if (chkAllAbilities.Checked)
			{
				DisplayAllAbilities();
			}
			//Display only eligible abilities if the check box is not checked
			else
			{
				DisplayEligibleAbilities();
			}

			sorting = true; //Don't do anything when check states change

			//Re-check anything that needs to be checked
			for (int n = 0; n < clbAbilities.Items.Count; ++n)
			{
				//Truncate the string if it contains the ability's school
				string abilityName = clbAbilities.Items[n].ToString();
				if(abilityName.Length > ABILITY_SPACING)
				{
					abilityName = abilityName.Substring(0, ABILITY_SPACING);
				}

				if (checkedAbilities.Contains(abilityName.Trim()))
				{
					clbAbilities.SetItemChecked(n, true);
					checkedAbilities.Remove(abilityName);
				}
			}

			SortCheckedListBox(clbAbilities);

			sorting = false;
		}

		/// <summary>
		/// Adds only the talents the character is qualified for to the talents CheckedListBox
		/// </summary>
		private void DisplayEligibleTalents()
		{
			clbTalents.Items.Clear();

			//Query the talent database for all talents
			DataSet ds = PerformQuery(talentsConnection, "SELECT talent_name, short_desc, prereq FROM Talents", "Talents");

			//Add only eligible talents
			foreach(DataRow row in ds.Tables["Talents"].Rows)
			{
				string talentName = row[0].ToString();

				if(row[2] == null || !CheckTalentHomebrew(row[2].ToString()))
				{
					clbTalents.Items.Add(String.Format("{0,-" + TALENT_DESC_SPACING + "} {1}", talentName, row[1].ToString()));
				}
			}
		}

		/// <summary>
		/// Adds all talents to the talents CheckedListBox
		/// </summary>
		private void DisplayAllTalents()
		{
			clbTalents.Items.Clear();

			//Query the talent database for all talents
			DataSet ds = PerformQuery(talentsConnection, "SELECT talent_name, short_desc FROM Talents", "Talents");

			//Add only eligible talents
			foreach (DataRow row in ds.Tables["Talents"].Rows)
			{
				string talentName = row[0].ToString();
				clbTalents.Items.Add(String.Format("{0,-" + TALENT_DESC_SPACING + "} {1}", talentName, row[1].ToString()));
			}
		}

		/// <summary>
		/// Displays only abilities the character is qualified to take. This method also takes into account
		/// the school of magic the user was viewing
		/// </summary>
		private void DisplayEligibleAbilities()
		{
			clbAbilities.Items.Clear();

			DataSet ds = PerformQuery(abilitiesConnection, "SELECT ability_name, school, prereq FROM Abilities", "Abilities");
			DataTable table = ds.Tables["Abilities"];

			if(abilityDisplay == DISPLAY_ALL_ABILITIES)
			{
				foreach (DataRow row in table.Rows)
				{
					if (row[2] != null && !CheckAbilityHomebrew(row[2].ToString(), row[0].ToString()))
					{
						//Display the ability name followed by spaces (to align with the other abilities) followed by the school
						clbAbilities.Items.Add(String.Format("{0,-" + ABILITY_SPACING + "} {1}",
							row[0].ToString(), row[1].ToString()));
					}
				}
			}
			else
			{
				string school = null;

				switch(abilityDisplay)
				{
					case DISPLAY_ALTERATION:
						school = "Alteration";
						break;
					case DISPLAY_CREATION:
						school = "Creation";
						break;
					case DISPLAY_DESTRUCTION:
						school = "Destruction";
						break;
					case DISPLAY_RESTORATION:
						school = "Restoration";
						break;
					case DISPLAY_META:
						school = "Meta";
						break;
				}

				foreach(DataRow row in table.Rows)
				{
					//Make sure the ability is the right school to display
					if(!row[1].ToString().Equals(school))
					{
						continue;
					}

					if (row[2] != null && !CheckAbilityHomebrew(row[2].ToString(), row[0].ToString()))
					{
						//Only display the ability name
						clbAbilities.Items.Add(row[0].ToString());
					}
				}
			}

			SortCheckedListBox(clbAbilities);
		}

		/// <summary>
		/// Displays all abilities. This method also takes into account the school of magic the user was viewing
		/// </summary>
		private void DisplayAllAbilities()
		{
			clbAbilities.Items.Clear();

			List<string> abilities;

			if (abilityDisplay == DISPLAY_ALL_ABILITIES)
			{
				abilities = new List<string>();

				DataSet ds = PerformQuery(abilitiesConnection, "SELECT ability_name, school FROM ABilities", "Abilities");

				foreach (DataRow row in ds.Tables["Abilities"].Rows)
				{
					abilities.Add(String.Format("{0,-" + ABILITY_SPACING + "} {1}",
						row[0].ToString(), row[1].ToString()));
				}

				foreach(CustomAbility ability in customAbilities)
				{
					abilities.Add(ability.name);
				}
			}
			else
			{
				abilities = GetAbilitiesBySchool();
			}

			clbAbilities.Items.AddRange(abilities.ToArray());

			SortCheckedListBox(clbAbilities);
		}
		#endregion

		/// <summary>
		/// Queries the abilities database for only abilities of the school specified by the user (stored in abilityDisplay)
		/// </summary>
		/// <returns>Abilities of the specified school in  list</returns>
		private List<string> GetAbilitiesBySchool()
		{
			List<string> abilities = new List<string>();

			string school = null;
			switch (abilityDisplay)
			{
				case DISPLAY_ALTERATION:
					school = "Alteration";
					break;
				case DISPLAY_CREATION:
					school = "Creation";
					break;
				case DISPLAY_DESTRUCTION:
					school = "Destruction";
					break;
				case DISPLAY_RESTORATION:
					school = "Restoration";
					break;
				case DISPLAY_META:
					school = "Meta";
					break;
			}

			string query = "SELECT ability_name FROM Abilities WHERE school='" + school + "'";
			DataSet ds = PerformQuery(abilitiesConnection, query, "Abilities");

			foreach(DataRow row in ds.Tables["Abilities"].Rows)
			{
				abilities.Add(row[0].ToString());
			}

			foreach(CustomAbility ability in customAbilities)
			{
				if(ability.school.Equals(school))
				{
					abilities.Add(ability.name);
				}
			}

			return abilities;
		}

		/// <summary>
		/// Gets the sechool the specified ability belongs to
		/// </summary>
		/// <param name="abilityName">Ability to get the school of</param>
		/// <returns>School of the ability</returns>
		private string GetAbilitySchool(string abilityName)
		{
			string school = null;

			if (IsCustomAbility(abilityName))
			{
				foreach(CustomAbility ability in customAbilities)
				{
					if(ability.name.Equals(abilityName))
					{
						school = ability.school;
						break;
					}
				}
			}
			else
			{
				//Query the ability database for the school
				string query = "SELECT school FROM Abilities WHERE ability_name='" + abilityName + "'";
				DataSet ds = PerformQuery(abilitiesConnection, query, "Abilities");
				school = ds.Tables["Abilities"].Rows[0][0].ToString();
			}

			return school;
		}

		private void cmbSchoolDisplay_SelectedIndexChanged(object sender, EventArgs e)
		{
			abilityDisplay = cmbSchoolDisplay.SelectedIndex;

			//Keep track of which abilities were checked
			List<string> checkedAbilities = new List<string>();
			checkedAbilities.AddRange(character.abilities);
			checkedAbilities.AddRange(character.customAbilities);

			sorting = true; //Don't do anything when check states change

			clbAbilities.Items.Clear();

			if (chkAllAbilities.Checked)
			{
				DisplayAllAbilities();
			}
			else
			{
				DisplayEligibleAbilities();
			}

			//Re-check anything that needs to be checked
			for (int n = 0; n < clbAbilities.Items.Count; ++n)
			{
				//Truncate the string if it contains the ability's school
				string abilityName = clbAbilities.Items[n].ToString();
				if(abilityName.Length > ABILITY_SPACING)
				{
					abilityName = abilityName.Substring(0, ABILITY_SPACING);
				}
				
				if (checkedAbilities.Contains(abilityName.Trim()))
				{
					clbAbilities.SetItemChecked(n, true);
					checkedAbilities.Remove(abilityName);
				}
			}

			sorting = false;
		}

		private void UpdateAbilitiesRemainingLabels()
		{
			//How many abilities from each school the user has taken over the homebrew limit
			int alterationRemaining = alterationAvailable - alterationTaken + somAlteration;
			int creationRemaining = creationAvailable - creationTaken + somCreation;
			int destructionRemaining = destructionAvailable - destructionTaken + somDestruction;
			int restorationRemaining = restorationAvailable - restorationTaken + somRestoration;

			//Tell user how many abilities over/under the limit they are
			if(alterationRemaining < 0)
			{
				lblAlterationRemaining.Text = Math.Abs(alterationRemaining) + " Alteration" + 
					(alterationRemaining == -1 ? " ability " : " abilities ") + "over limit";
				lblAlterationRemaining.ForeColor = Color.Red;
			}
			else
			{
				lblAlterationRemaining.Text = alterationRemaining + " Alteration" + 
					(alterationRemaining == 1 ? " ability " : " abilities ") + "remaining";
				lblAlterationRemaining.ForeColor = Color.Black;
			}
			
			if(creationRemaining < 0)
			{
				lblCreationRemaining.Text = Math.Abs(creationRemaining) + " Creation" + 
					(creationRemaining == -1 ? " ability " : " abilities ") + "over limit";
				lblCreationRemaining.ForeColor = Color.Red;
			}
			else
			{
				lblCreationRemaining.Text = creationRemaining + " Creation" + 
					(creationRemaining == 1 ? " ability " : " abilities ") + "remaining";
				lblCreationRemaining.ForeColor = Color.Black;
			}

			if(destructionRemaining < 0)
			{
				lblDestructionRemaining.Text = Math.Abs(destructionRemaining) + " Destruction" +
					(destructionRemaining == -1 ? " ability " : " abilities ") + "over limit";
				lblDestructionRemaining.ForeColor = Color.Red;
			}
			else
			{
				lblDestructionRemaining.Text = destructionRemaining + " Destruction" + 
					(destructionRemaining == 1 ? " ability " : " abilities ") + "remaining";
				lblDestructionRemaining.ForeColor = Color.Black;
			}

			if(restorationRemaining < 0)
			{
				lblRestorationRemaining.Text = Math.Abs(restorationRemaining) + " Restoration" +
					(restorationRemaining == -1 ? " ability " : " abilities ") + "over limit";
				lblRestorationRemaining.ForeColor = Color.Red;
			}
			else
			{
				lblRestorationRemaining.Text = restorationRemaining + " Restoration" + 
					(restorationRemaining == 1 ? " ability " : " abilities ") + "remaining";
				lblRestorationRemaining.ForeColor = Color.Black;
			}
		}

		#region PDF export
		private void btnExport_Click(object sender, EventArgs e)
		{
			//Check if the user didn't fill something out
			string missingThings = "";

			if(primarySkillsAvailable - primarySkillCount > 0)
			{
				missingThings += "\nPrimary skills";
			}

			if(talentsAvailable - talentsTaken > 0)
			{
				missingThings += "\nTalents";
			}

			if(alterationAvailable - alterationTaken + somAlteration > 0 ||
				creationAvailable - creationTaken + somCreation > 0 ||
				destructionAvailable - destructionTaken + somDestruction > 0 ||
				restorationAvailable - restorationTaken + somRestoration > 0)
			{
				missingThings += "\nAbilities";
			}

			//If the user didn't fill something out, prompt them if they wish to continue
			if(!String.IsNullOrWhiteSpace(missingThings))
			{
				DialogResult result = MessageBox.Show("You didn't fill out the following fields:\n" + missingThings + 
					"\n\nContinue without filling them out?", "Missing fields", MessageBoxButtons.YesNo);

				if(result == DialogResult.No)
				{
					return;
				}
			}

			//Display a dialog to obtain file name
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
			saveDialog.Filter = "PDF (*.pdf)|";
			saveDialog.FilterIndex = 1;

			if (saveDialog.ShowDialog() == DialogResult.OK)
			{
				string file = saveDialog.FileName;
				if (!file.EndsWith(".pdf"))
				{
					file = file + ".pdf";
				}

				ExportPDF(file);
			}
		}

		private void ExportPDF(string saveLocation)
		{
			UpdateInformation(); //Make sure the character's information is up to date

			bool halfCostAbilities = false;
			foreach (ModifiedScore mod in modifiedScores)
			{
				if (mod.modifiedBy.Equals("More Efficient, Less Wasteful"))
				{
					halfCostAbilities = true;
					break;
				}
			}

			//Notify the user about anything they need to mark on their own
			MessageBox.Show("You need to write down the effects of talents marked with *");

			//Load the pdf
			PdfReader reader = new PdfReader("Editable Character Sheet.pdf");
			PdfStamper stamper = new PdfStamper(reader, new FileStream(saveLocation, FileMode.Create));
			AcroFields fields = stamper.AcroFields;

			//Fill out the fields
			fields.SetField("name", character.name);
			fields.SetField("race", character.race);
			fields.SetField("height", character.height);
			fields.SetField("weight", character.weight);
			fields.SetField("age", character.age);
			fields.SetField("occupation", character.occupation);
			fields.SetField("aspiration", character.aspiration);
			fields.SetField("background", character.background);

			fields.SetField("hp_total", character.hitPoints.ToString());
			fields.SetField("mp_total", character.magicTotal.ToString());
			fields.SetField("mp_regen", character.magicRegen.ToString());

			fields.SetField("cha_score", character.charisma.ToString());
			fields.SetField("con_score", character.constitution.ToString());
			fields.SetField("dex_score", character.dexterity.ToString());
			fields.SetField("int_score", character.intelligence.ToString());
			fields.SetField("lck_score", character.luck.ToString());
			fields.SetField("spd_score", character.speed.ToString());
			fields.SetField("str_score", character.strength.ToString());
			fields.SetField("wis_score", character.wisdom.ToString());
			fields.SetField("cha_mod", character.CalculateModifier(character.charisma).ToString());
			fields.SetField("con_mod", character.CalculateModifier(character.constitution).ToString());
			fields.SetField("dex_mod", character.CalculateModifier(character.dexterity).ToString());
			fields.SetField("int_mod", character.CalculateModifier(character.intelligence).ToString());
			fields.SetField("lck_mod", character.CalculateModifier(character.luck).ToString());
			fields.SetField("spd_mod", character.CalculateModifier(character.speed).ToString());
			fields.SetField("str_mod", character.CalculateModifier(character.strength).ToString());
			fields.SetField("wis_mod", character.CalculateModifier(character.wisdom).ToString());

			fields.SetField("armor_class", (rdoHeavyArmor.Checked ? character.acHeavy : character.acLight).ToString());
			fields.SetField("will", character.will.ToString());
			fields.SetField("fortitude", character.fortitude.ToString());
			fields.SetField("reflex", (rdoHeavyArmor.Checked ? character.reflexHeavy : character.reflexLight).ToString());
			fields.SetField("fortune_base", character.CalculateModifier(character.luck).ToString());
			fields.SetField("movement", character.movement.ToString());
			fields.SetField("initiative", character.initiative.ToString());

			fields.SetField("enlightenment_total", character.enlightenment.ToString());

			#region Export skills
			foreach (string skillName in Skills.SKILLS)
			{
				//Transform the skill name to the representation used in the character sheet
				string skill = skillName.Replace(' ', '_').Replace('/', '_').ToLower();

				string strScore = skill + "_score";
				string strMod = skill + "_mod";

				//Calculate the final score for the skill
				DataSet ds = PerformQuery(skillsConnection,
					"SELECT governing_attr FROM Skills WHERE skill_name='" + skillName + "'", "Skills");
				DataRow row = ds.Tables["Skills"].Rows[0];
				string governingAttr = row[0].ToString();

				int score = character.GetSkillValue(skill);

				score += character.CalculateModifier(character.GetAttributeValue(governingAttr));

				foreach(ModifiedScore modScore in modifiedScores)
				{
					if(modScore.modifiedBy.Equals("Skill Specialization") && modScore.modifiedScore.Equals(skillName))
					{
						score += 3;
					}
				}

				if(skillName.Equals("Stealth"))
				{
					switch(cmbSize.SelectedIndex)
					{
						case 0: //Small
							score += 5;
							break;
						case 2: //Large
							score -= 5;
							break;
					}
				}

				int mod = character.CalculateModifier(score);

				fields.SetField(strScore, score.ToString());
				fields.SetField(strMod, mod.ToString());
			}

			int customSkillNum = 1;
			foreach (CustomSkill skill in customSkills)
			{
				string strName = "custom_skill_" + customSkillNum + "_name";
				string strAttr = "custom_skill_" + customSkillNum + "_attribute";
				string strScore = "custom_skill_" + customSkillNum + "_score";
				string strMod = "custom_skill_" + customSkillNum + "_mod";
				++customSkillNum;

				fields.SetField(strName, skill.name);
				fields.SetField(strAttr, skill.governingAttribute);
				fields.SetField(strScore, character.customSkills[skill.name].ToString());
				fields.SetField(strMod, character.CalculateModifier(character.customSkills[skill.name]).ToString());
			}
			#endregion

			#region Export talents/skill perks
			int talentNum = 1;
			foreach (string talent in character.talents)
			{
				string infoToWrite = talent;

				//Check if the talent modifies anything
				if (modifyingTalents.Contains(talent))
				{
					for (int n = 0; n < modifiedScores.Count; ++n)
					{
						if (modifiedScores[n].modifiedBy.Equals(talent))
						{
							string fieldValue = talent;

							//Indicate that the user needs to mark what they took the talent for
							if (modifiedScores[n].userMarks)
							{
								fieldValue += "*";
							}

							//Indicate what the user took the talent for
							if (!string.IsNullOrWhiteSpace(modifiedScores[n].modifiedScore))
							{
								fieldValue += " - " + modifiedScores[n].modifiedScore;
							}

							fields.SetField("talent_skill_" + talentNum, fieldValue);

							modifiedScores.RemoveAt(n);
						}
					}
				}
				else
				{
					fields.SetField("talent_skill_" + talentNum, talent);
				}

				++talentNum;
			}

			foreach (string talent in character.customTalents)
			{
				fields.SetField("talent_skill_" + talentNum, talent + "*");
				++talentNum;
			}

			//Skill perks
			foreach (string skill in Skills.SKILLS)
			{
				//Query for skill perks the character is eligible for
				string query = "SELECT perk FROM Perks WHERE skill_name='" + ConvertToProperName(skill) + "' AND min_score<=" + character.GetSkillValue(skill);
				DataTable perkTable = PerformQuery(skillsConnection, query, "Perks").Tables["Perks"];

				foreach (DataRow row in perkTable.Rows)
				{
					fields.SetField("talent_skill_" + talentNum, row[0].ToString());

					++talentNum;
				}
			}

			#endregion

			#region Export abilities
			int abilityNum = 1;
			foreach (string ability in character.abilities)
			{
				string strName = "spell" + abilityNum + "_name";
				string strCost = "spell_" + abilityNum + "_cost";
				string strSchool = "spell_" + abilityNum + "_school";
				string strEffect = "spell_" + abilityNum + "_effect";
				++abilityNum;

				DataSet ds = PerformQuery(abilitiesConnection,
					"SELECT cost, school, effect FROM Abilities WHERE ability_name='" + ability + "'",
					"Ablilities");
				DataRow row = ds.Tables["Abilities"].Rows[0];

				fields.SetField(strName, ability);
				fields.SetField(strCost, halfCostAbilities ? (TryParseInteger(row[0].ToString()) / 2).ToString() : row[0].ToString());
				fields.SetField(strSchool, row[1].ToString());
				fields.SetField(strEffect, row[2].ToString());

				string school = row[1].ToString();
				if (school.Equals("Meta"))
				{
					school = character.metaAbilities[ability];
				}

				fields.SetField(strSchool, school);
			}

			foreach (string ability in character.customAbilities)
			{
				string strName = "spell_" + abilityNum + "_name";
				string strCost = "spell_" + abilityNum + "_cost";
				string strSchool = "spell_" + abilityNum + "_school";
				string strEffect = "spell_" + abilityNum + "_effect";
				++abilityNum;

				CustomAbility customAbility = GetCustomAbility(ability);

				fields.SetField(strName, ability);
				fields.SetField(strCost, halfCostAbilities ? (TryParseInteger(customAbility.cost) / 2).ToString() : customAbility.cost);
				fields.SetField(strSchool, customAbility.school);
				fields.SetField(strEffect, customAbility.effect);
			}
			#endregion

			stamper.FormFlattening = false;
			stamper.Close();

			//Open the PDF if the user wants it opened
			if (chkOpenSheet.Checked) 
			{
				System.Diagnostics.Process.Start(saveLocation);
			}
		}

		/// <summary>
		/// Converts a skill name to it's proper name (i.e. heavy_armor to Heavy Armor)
		/// </summary>
		/// <param name="skillName">Skill to convert</param>
		/// <returns>Proper name of the skill</returns>
		private string ConvertToProperName(string skillName)
		{
			skillName = skillName.Replace('_', ' ');
			//Make each word in the string initial case (heavy armor to Heavy Armor)
			skillName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(skillName.ToLower());

			return skillName;
		}
		#endregion

		private void rdoHeavyArmor_CheckedChanged(object sender, EventArgs e)
		{
			UpdateInformation();
		}

		#region Searching talents/abilities
		private void txtAbilitiesSearch_TextChanged(object sender, EventArgs e)
		{
			string search = txtAbilitiesSearch.Text;

			//Keep track of which talents were checked
			List<string> checkedAbilities = new List<string>();
			checkedAbilities.AddRange(character.abilities);
			checkedAbilities.AddRange(character.customAbilities);

			//Only perform query if there is something to search for
			if (!String.IsNullOrWhiteSpace(search))
			{
				clbAbilities.Items.Clear();

				string query = "SELECT ability_name, school, prereq FROM Abilities WHERE effect LIKE '%" + search + "%' OR ability_name LIKE '%" + search + "%'";
				DataSet ds = PerformQuery(abilitiesConnection, query, "Abilities");

				foreach (DataRow row in ds.Tables["Abilities"].Rows)
				{
					string abilityName = row[0].ToString();

					if (chkAllAbilities.Checked && row[2] != null && CheckAbilityHomebrew(row[2].ToString(), row[0].ToString()))
					{
						continue;
					}

					//Only display an ability if it has the same school as what the user selected
					if (abilityDisplay != DISPLAY_ALL_ABILITIES)
					{
						string schoolToDisplay = null;

						switch (abilityDisplay)
						{
							case DISPLAY_ALTERATION:
								schoolToDisplay = "Alteration";
								break;
							case DISPLAY_CREATION:
								schoolToDisplay = "Creation";
								break;
							case DISPLAY_DESTRUCTION:
								schoolToDisplay = "Destruction";
								break;
							case DISPLAY_META:
								schoolToDisplay = "Meta";
								break;
							case DISPLAY_RESTORATION:
								schoolToDisplay = "Restoration";
								break;
						}

						if (!schoolToDisplay.Equals(row[1].ToString()))
						{
							continue;
						}
					}

					clbAbilities.Items.Add(abilityName);
				}
			}

			sorting = true; //Don't do anything when check states change

			//Re-check anything that needs to be checked
			for (int n = 0; n < clbAbilities.Items.Count; ++n)
			{
				//Truncate the string if it contains the ability's school
				string abilityName = clbAbilities.Items[n].ToString();
				if (abilityName.Length > ABILITY_SPACING)
				{
					abilityName = abilityName.Substring(0, ABILITY_SPACING);
				}

				if (checkedAbilities.Contains(abilityName.Trim()))
				{
					clbAbilities.SetItemChecked(n, true);
					checkedAbilities.Remove(abilityName);
				}
			}

			SortCheckedListBox(clbAbilities);

			sorting = false;
		}

		private void txtTalentsSearch_TextChanged(object sender, EventArgs e)
		{
			string search = txtTalentsSearch.Text;

			//Keep track of which talents were checked
			List<string> checkedTalents = new List<string>();
			checkedTalents.AddRange(character.talents);
			checkedTalents.AddRange(character.customTalents);

			//Only perform query if there is something to search for
			if (!String.IsNullOrWhiteSpace(search))
			{
				clbTalents.Items.Clear();

				string query = "SELECT talent_name, prereq FROM Talents WHERE desc LIKE '%" + search + "%' OR talent_name LIKE '%" + search + "%'";
				DataSet ds = PerformQuery(talentsConnection, query, "Talents");

				foreach (DataRow row in ds.Tables["Talents"].Rows)
				{
					string talentName = row[0].ToString();

					if (chkAllTalents.Checked && row[1] != null && CheckTalentHomebrew(row[1].ToString()))
					{
						continue;
					}

					clbTalents.Items.Add(talentName);
				}
			}

			sorting = true; //Don't do anything when check states change

			//Re-check anything that needs to be checked
			for (int n = 0; n < clbTalents.Items.Count; ++n)
			{
				string talentName = clbTalents.Items[n].ToString();

				if (talentName.Length > TALENT_DESC_SPACING)
				{
					talentName = talentName.Substring(0, TALENT_DESC_SPACING).Trim();
				}
				if (checkedTalents.Contains(talentName))
				{
					clbTalents.SetItemChecked(n, true);
					checkedTalents.Remove(talentName);

					//Re-add the talent if it can be taken multiple times
					if (multipleTimesTalents.Contains(talentName))
					{
						clbTalents.Items.Add(clbTalents.Items[n].ToString());
					}
				}
			}

			SortCheckedListBox(clbTalents);

			sorting = false;
		}
		#endregion
	}
}
