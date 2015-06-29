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

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Solipstry_Character_Creator
{
    public partial class Window : Form
    {
		//Access strings for the databases
		private const string SPELLS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Spells.accdb";
		private const string TALENTS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Talents.accdb";
		private const string SKILLS_ACCESS_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Skills.accdb";

		//States for displaying different schools of magic
		private const int DISPLAY_ALL_SPELLS = 0;
		private const int DISPLAY_ALTERATION = 1;
		private const int DISPLAY_CONJURATION = 2;
		private const int DISPLAY_DESTRUCTION = 3;
		private const int DISPLAY_RESTORATION = 4;
		private const int DISPLAY_META = 5;

		//List of talents that modify attributes, skills, etc.
		private List<string> modifyingTalents;

		//List of talents that can be taken multiple times
		private List<string> multipleTimesTalents;

		private OleDbConnection spellsConnection;
		private OleDbConnection talentsConnection;
		private OleDbConnection skillsConnection;

        private Character character;
		private List<Button> attrValuesList;
		private List<TextBox> attributeTextBoxes;

		private List<string> customTalents;
		private List<CustomSkill> customSkills;
		private List<CustomSpell> customSpells;

		//Keeps track of any modified attributes or skills
		private List<ModifiedScore> modifiedScores;

		//Button that the drag and drop originated from
		private Button btnDropFrom;

		//Number of skills set as primary skills
		private int primarySkillCount;
		//Number of talents the user has chosen
		private int talentsTaken;

		//Number of skills the use can select as primary
		private int primarySkillsAvailable;
		//Number of talents the character can have without being homebrewed 
		private int talentsAvailable;

		//Whether to display all talents/spells or only ones the character is eligble for
		private bool displayHomebrewOptions; 

		//Whether or not a CheckedListBox is being sorted
		private bool sorting; 

		//State machine variable for which school of magic to display
		private int spellDisplay;

		#region Program setup
		public Window()
        {
            InitializeComponent();

			character = new Character();

			customTalents = new List<string>();
			customSkills = new List<CustomSkill>();
			customSpells = new List<CustomSpell>();

			modifiedScores = new List<ModifiedScore>();

			displayHomebrewOptions = false;

			spellDisplay = DISPLAY_ALL_SPELLS;

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

			ContextMenuStrip spellsMenuStrip = new ContextMenuStrip();
			ToolStripMenuItem newSpellItem = new ToolStripMenuItem("New Spell");
			newSpellItem.Name = "New Spell";
			newSpellItem.Click += new EventHandler(newSpellMenuItem_Click);

			spellsMenuStrip.Items.Add(newSpellItem);
			clbSpells.ContextMenuStrip = spellsMenuStrip;

			primarySkillsAvailable = 5; //Can only have 5 primary skills
			talentsAvailable = 1; //First level characters can only take one talent

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

			DisplayEligibleSpells();
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

			lblSpellsInstructions.Text = "Select the spells you wish to take. The number of spells you can" +
				Environment.NewLine + "know for each school is equal to your modifier in that school.";
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

            //TODO: Update character information

			CheckHomebrew();
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            character.size = (string) cmbSize.SelectedItem;
			CheckHomebrew(); //Some talents depend on size
            //TODO: Update character information
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
						character.UpdateSkillScore(mod.modifiedScore, character.GetSkillValue(mod.modifiedScore) + 3);

						if(mod.modifiedScore.Equals("Enlightenment"))
						{
							character.enlightenment = character.GetSkillValue("Enlightenment");
						}
						break;
				}
			}
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
			character.age = txtAge.Text;
		}

		private void CalculateDerivedTraits()
		{
			character.movement = 3 + character.CalculateModifier(character.speed);
			character.hitPoints = (int)Math.Truncate(1.5 * (double)character.CalculateModifier(character.constitution));
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

			//TODO Update these from talents
			//TODO Calculate enlightenment points
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
			lblACHeavy.Text = character.acHeavy.ToString();
			lblACLight.Text = character.acLight.ToString();

			lblMagicTotal.Text = character.magicTotal.ToString();
			lblMagicRegen.Text = character.magicRegen.ToString();
			lblEnlightenment.Text = character.enlightenment.ToString();
			lblFortunePoints.Text = character.fortunePoints.ToString();

			lblWill.Text = character.will.ToString();
			lblFortitude.Text = character.fortitude.ToString();
			lblReflexHeavy.Text = character.reflexHeavy.ToString();
			lblReflexLight.Text = character.reflexLight.ToString();
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
			spellsConnection.Close();
			talentsConnection.Close();
			skillsConnection.Close();
		}

		#region Homebrew checking
		private void CheckHomebrew()
		{
			bool hb = false; //Whether or not the character is homebrewed

			//Check custom talents, spells, and talents
			if(character.customTalents.Count > 0 || customSkills.Count > 0 || character.customSpells.Count > 0)
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
					if(!character.spells.Contains(spell))
					{
						return false;
					}

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

			if(IsCustomSpell(spellName))
			{
				CustomSpell spell = GetCustomSpell(spellName);

				txtSpellInfo.Text = spellName + Environment.NewLine +
					"School: " + spell.school + Environment.NewLine +
					"Cost: " + spell.cost;
			}
			else
			{
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
		}

		private void clbSpells_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(sorting)
			{
				return;
			}

			string spellName = clbSpells.Items[e.Index].ToString();

			if(IsCustomSpell(spellName))
			{
				 if(e.NewValue == CheckState.Unchecked)
				 {
					 character.customSpells.Remove(spellName);
				 }
				 else
				 {
					 character.customSpells.Add(spellName);
				 }
			}
			else
			{
				if (e.NewValue == CheckState.Unchecked)
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
			}

			CheckHomebrew();
		}

		private void clbSkills_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(sorting)
			{
				return;
			}

			string skillName = clbSkills.SelectedItem.ToString();

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

			lblPrimarySkillsRemaining.Text = Math.Max(primarySkillsAvailable - primarySkillCount, 0).ToString() + " primary skills remaining";

			CheckHomebrew();

			UpdateInformation();
		}

		private void clbSkills_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Get information about the skill
			string skillName = clbSkills.SelectedItem.ToString();

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

			string talentName = clbTalents.Items[e.Index].ToString();

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
							case "Student of Magic": //additional spell with requirements met
								//Figure out which spells the user can take
								List<string> validSpells = new List<string>();

								foreach(string spell in clbSpells.Items)
								{
									//Spell is valid if it is not taken, not homebrewed, and the character meets the requirements
									if(!clbSpells.CheckedItems.Contains(spell) && !IsCustomSpell(spell) && !CheckSpellHomebrew(spell))
									{
										validSpells.Add(spell);
									}
								}

								//Have the user select the spell they want
								selection = new SelectionDialog(validSpells, "Select a Spell");
								result = selection.ShowDialog();

								if(result == DialogResult.OK)
								{
									modified.modifiedScore = selection.GetSelectedItem();
									clbSpells.SelectedItem = modified.modifiedScore;
									clbSpells.SetItemChecked(clbSpells.SelectedIndex, true);
								}
								else
								{
									e.NewValue = e.CurrentValue;
									return;
								}

								break;
						}

						modifiedScores.Add(modified);
					} //endif for checking for modifying from talents


					//Check if the talent can be taken multiple times
					if (multipleTimesTalents.Contains(talentName))
					{
						//Add the talent to the list so it can be taken again
						clbTalents.Items.Add(talentName);
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
							case "Student of Magic": //additional spell with requirements met
								List<string> modifiedSpells = new List<string>();

								//Find the spells that were added with Student of Magic
								foreach(ModifiedScore mod in modifiedScores)
								{
									if(mod.modifiedBy.Equals("Student of Magic"))
									{
										modifiedSpells.Add(mod.modifiedScore);
									}
								}

								SelectionDialog spellSelector = new SelectionDialog(modifiedSpells, "Which spell to remove?");
								result = spellSelector.ShowDialog();

								if(result == DialogResult.OK)
								{
									for(int n = 0; n < modifiedScores.Count; ++n)
									{
										if(modifiedScores[n].modifiedScore.Equals(spellSelector.GetSelectedItem()) &&
											modifiedScores[n].modifiedBy.Equals("Student of Magic"))
										{
											clbSpells.SelectedItem = modifiedScores[n].modifiedScore;
											clbSpells.SetItemChecked(clbSpells.SelectedIndex, false);

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

			lblTalentsRemaining.Text = Math.Max(talentsAvailable - talentsTaken, 0).ToString() + " talent(s) remaining";

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

		private void ExportPDF(string saveLocation)
		{
			UpdateInformation(); //Make sure the character's information is up to date

			bool halfCostSpells = false;
			foreach(ModifiedScore mod in modifiedScores)
			{
				if(mod.modifiedBy.Equals("More Efficient, Less Wasteful"))
				{
					halfCostSpells = true;
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
			fields.SetField("class", character._class);
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
			//Make iterating through the skills easier
			string[] skills = 
			{
				"acrobatics",
				"alteration",
				"athletics",
				"block",
				"chemistry",
				"conjuration",
				"craft",
				"destruction",
				"disguise",
				"engineering",
				"enlightenment",
				"escape",
				"heavy_armor",
				"interaction",
				"knowledge",
				"language",
				"light_armor",
				"medicine",
				"melee_weapon",
				"survival",
				"perception",
				"ranged_combat",
				"restoration",
				"ride_drive",
				"security",
				"sense_motive",
				"sleight_of_hand",
				"stealth",
				"unarmed_combat"
			};

			foreach(string skill in skills)
			{
				string strScore = skill + "_score";
				string strMod = skill + "_mod";

				int score = character.GetSkillValue(skill);
				int mod = character.CalculateModifier(score);

				fields.SetField(strScore, score.ToString());
				fields.SetField(strMod, mod.ToString());
			}

			int customSkillNum = 1;
			foreach(CustomSkill skill in customSkills)
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
			foreach(string talent in character.talents)
			{
				string infoToWrite = talent;

				//Check if the talent modifies anything
				if(modifyingTalents.Contains(talent))
				{
					for(int n = 0; n < modifiedScores.Count; ++n)
					{
						if(modifiedScores[n].modifiedBy.Equals(talent))
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

			foreach(string talent in character.customTalents)
			{
				fields.SetField("talent_skill_" + talentNum, talent + "*");
				++talentNum;
			}

			//Skill perks
			foreach(string skill in skills)
			{
				//Query for skill perks the character is eligible for
				string query = "SELECT perk FROM Perks WHERE skill_name='" + ConvertToProperName(skill) + "' AND min_score<=" + character.GetSkillValue(skill);
				DataTable perkTable = PerformQuery(skillsConnection, query, "Perks").Tables["Perks"];

				foreach(DataRow row in perkTable.Rows)
				{
					fields.SetField("talent_skill_" + talentNum, row[0].ToString());

					++talentNum;
				}
			}

			#endregion

			#region Export spells
			int spellNum = 1;
			foreach(string spell in character.spells)
			{
				string strName = "spell_" + spellNum + "_name";
				string strCost = "spell_" + spellNum + "_cost";
				string strSchool = "spell_" + spellNum + "_school";
				string strEffect = "spell_" + spellNum + "_effect";
				++spellNum;

				DataSet ds = PerformQuery(spellsConnection,
					"SELECT cost, school, effect FROM Spells WHERE spell_name='" + spell + "'",
					"Spells");
				DataRow row = ds.Tables["Spells"].Rows[0];

				fields.SetField(strName, spell);
				fields.SetField(strCost, halfCostSpells ? (TryParseInteger(row[0].ToString()) / 2).ToString() : row[0].ToString());
				fields.SetField(strSchool, row[1].ToString());
				fields.SetField(strEffect, row[2].ToString());

				string school = row[1].ToString();
				if(school.Equals("Meta"))
				{
					school = character.metaSpells[spell];
				}

				fields.SetField(strSchool, school);
			}

			foreach(string spell in character.customSpells)
			{
				string strName = "spell_" + spellNum + "_name";
				string strCost = "spell_" + spellNum + "_cost";
				string strSchool = "spell_" + spellNum + "_school";
				string strEffect = "spell_" + spellNum + "_effect";
				++spellNum;

				CustomSpell customSpell = GetCustomSpell(spell);

				fields.SetField(strName, spell);
				fields.SetField(strCost, halfCostSpells ? (TryParseInteger(customSpell.cost) / 2).ToString() : customSpell.cost);
				fields.SetField(strSchool, customSpell.school);
				fields.SetField(strEffect, customSpell.effect);
			}
			#endregion
			
			//TODO Custom things

			stamper.FormFlattening = false;
			stamper.Close();
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

		private void exportPDFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Display a dialog to obtain file name
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
			saveDialog.Filter = "PDF (*.pdf)|";
			saveDialog.FilterIndex = 1;

			if(saveDialog.ShowDialog() == DialogResult.OK)
			{
				string file = saveDialog.FileName;
				if(!file.EndsWith(".pdf"))
				{
					file = file + ".pdf";
				}

				ExportPDF(file);
			}
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
				clbTalents.SetItemChecked(clbTalents.Items.Count - 1, true);

				SortCheckedListBox(clbTalents);
				clbTalents.SelectedItem = talentName;
			}

			CheckHomebrew();
		}

		private void newSpellMenuItem_Click(object sender, EventArgs e)
		{
			CustomSpellForm frmSpell = new CustomSpellForm();
			DialogResult result = frmSpell.ShowDialog();

			if(result == DialogResult.OK)
			{
				CustomSpell newSpell = new CustomSpell();
				newSpell.name = frmSpell.GetSpellName();
				newSpell.school = frmSpell.GetSchool();
				newSpell.cost = frmSpell.GetCost();
				newSpell.effect = frmSpell.GetEffect();

				customSpells.Add(newSpell);

				//Add the spell to the check list box and check it
				clbSpells.Items.Add(newSpell.name);
				clbSpells.SetItemChecked(clbSpells.Items.Count - 1, true);

				SortCheckedListBox(clbSpells);
				clbSpells.SelectedItem = newSpell.name;
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
		/// Checks if the specified spell is a custom spell
		/// </summary>
		/// <param name="spellName">Skill to check</param>
		/// <returns>True if the spell is custom, false otherwise</returns>
		private bool IsCustomSpell(string spellName)
		{
			foreach(CustomSpell spell in customSpells)
			{
				if(spell.name.Equals(spellName))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Gets information about a custom spell
		/// </summary>
		/// <param name="spellName">Name of the spell to get</param>
		/// <returns>CustomSpell object if the spell is a custom spell, null otherwise</returns>
		private CustomSpell GetCustomSpell(string spellName)
		{
			foreach (CustomSpell spell in customSpells)
			{
				if (spell.name.Equals(spellName))
				{
					return spell;
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

		private void viewHomebrewOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			displayHomebrewOptions = viewHomebrewOptionsToolStripMenuItem.Checked;
			
			//Keep track of which talents and spells were checked
			List<string> checkedTalents = new List<string>();
			List<string> checkedSpells = new List<string>();

			checkedTalents.AddRange(character.talents);
			checkedSpells.AddRange(character.spells);

			sorting = true; //Don't do anything when check states change

			clbTalents.Items.Clear();
			clbSpells.Items.Clear();

			if (displayHomebrewOptions)
			{
				//Display talents and spells the character is not eligible to take
				DisplayAllTalents();
				DisplayAllSpells();
			}
			else
			{
				//Disply only talents and spells the character is eligible for
				DisplayEligibleTalents();
				DisplayEligibleSpells();
			}

			//Re-check anything that needs to be checked
			for (int n = 0; n < clbTalents.Items.Count; ++n)
			{
				if(checkedTalents.Contains(clbTalents.Items[n].ToString()))
				{
					clbTalents.SetItemChecked(n, true);
					checkedTalents.Remove(clbTalents.Items[n].ToString());
				}
			}
			
			for (int n = 0; n < clbSpells.Items.Count; ++n)
			{
				if(checkedSpells.Contains(clbSpells.Items[n].ToString()))
				{
					clbSpells.SetItemChecked(n, true);
					checkedSpells.Remove(clbSpells.Items[n].ToString());
				}
			}
			
			sorting = false;
		}

		/// <summary>
		/// Adds only the talents the character is qualified for to the talents CheckedListBox
		/// </summary>
		private void DisplayEligibleTalents()
		{
			//Query the talent database for all talents
			DataSet ds = PerformQuery(talentsConnection, "SELECT talent_name FROM Talents", "Talents");

			//Add only eligible talents
			foreach(DataRow row in ds.Tables["Talents"].Rows)
			{
				string talentName = row[0].ToString();

				if(!CheckTalentHomebrew(talentName))
				{
					clbTalents.Items.Add(talentName);
				}
			}
		}

		/// <summary>
		/// Adds all talents to the talents CheckedListBox
		/// </summary>
		private void DisplayAllTalents()
		{
			//Query the talent database for all talents
			DataSet ds = PerformQuery(talentsConnection, "SELECT talent_name FROM Talents", "Talents");

			//Add only eligible talents
			foreach (DataRow row in ds.Tables["Talents"].Rows)
			{
				string talentName = row[0].ToString();
				clbTalents.Items.Add(talentName);
			}
		}

		/// <summary>
		/// Displays only spells the character is qualified to take. This method also takes into account
		/// the school of magic the user was viewing
		/// </summary>
		private void DisplayEligibleSpells()
		{
			List<string> spells;
		
			if(spellDisplay == DISPLAY_ALL_SPELLS)
			{
				spells = new List<string>();

				DataSet ds = PerformQuery(spellsConnection, "SELECT spell_name FROM Spells", "Spells");

				foreach(DataRow row in ds.Tables["Spells"].Rows)
				{
					spells.Add(row[0].ToString());
				}
			}
			else
			{
				spells = GetSpellsBySchool();	
			}

			foreach(string spell in spells)
			{
				if(!CheckSpellHomebrew(spell))
				{
					clbSpells.Items.Add(spell);
				}
			}
		}

		/// <summary>
		/// Displays all spells. This method also takes into account the school of magic the user was viewing
		/// </summary>
		private void DisplayAllSpells()
		{
			List<string> spells;

			if (spellDisplay == DISPLAY_ALL_SPELLS)
			{
				spells = new List<string>();

				DataSet ds = PerformQuery(spellsConnection, "SELECT spell_name FROM Spells", "Spells");

				foreach (DataRow row in ds.Tables["Spells"].Rows)
				{
					spells.Add(row[0].ToString());
				}
			}
			else
			{
				spells = GetSpellsBySchool();
			}

			clbSpells.Items.AddRange(spells.ToArray());
		}

		/// <summary>
		/// Queries the spells database for only spells of the school specified by the user (stored in spellDisplay)
		/// </summary>
		/// <returns>Spells of the specified school in  list</returns>
		private List<string> GetSpellsBySchool()
		{
			List<string> spells = new List<string>();

			string school = null;
			switch (spellDisplay)
			{
				case DISPLAY_ALTERATION:
					school = "Alteration";
					break;
				case DISPLAY_CONJURATION:
					school = "Conjuration";
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

			string query = "SELECT spell_name FROM Spells WHERE school='" + school + "'";
			DataSet ds = PerformQuery(spellsConnection, query, "Spells");

			foreach(DataRow row in ds.Tables["Spells"].Rows)
			{
				spells.Add(row[0].ToString());
			}

			return spells;
		}

		private void cmbSchoolDisplay_SelectedIndexChanged(object sender, EventArgs e)
		{
			spellDisplay = cmbSchoolDisplay.SelectedIndex;

			//Keep track of which spells were checked
			List<string> checkedSpells = new List<string>();

			checkedSpells.AddRange(character.spells);

			sorting = true; //Don't do anything when check states change
			clbSpells.Items.Clear();

			if (displayHomebrewOptions)
			{
				DisplayAllSpells();
			}
			else
			{
				DisplayEligibleSpells();
			}

			//Re-check anything that needs to be checked
			for (int n = 0; n < clbSpells.Items.Count; ++n)
			{
				if (checkedSpells.Contains(clbSpells.Items[n].ToString()))
				{
					clbSpells.SetItemChecked(n, true);
					checkedSpells.Remove(clbSpells.Items[n].ToString());
				}
			}

			sorting = false;
		}
	}
}
