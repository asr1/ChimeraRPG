using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Solipstry_Character_Creator
{
    class Character
    {
		//Basic information
        public string name;
        public string _class;
        public string race;
		public string age;
        public string height;
        public string weight;
        public string occupation;
        public string aspiration;
        public string background;

        public string size; //Small, medium, large

		public int[] skills;
		public List<string> spells;
		public List<string> talents;

		public List<string> customTalents;
		public Dictionary<string, int> customSkills;
		public List<string> customSpells;

		//Keeps track of which school meta spells are using
		public Dictionary<string, string> metaSpells;

		//Attributes
        public int charisma;
        public int constitution;
        public int dexterity;
        public int intelligence;
        public int luck;
        public int speed;
        public int strength;
        public int wisdom;

		//Derived traits
		public int movement;
		public int hitPoints;
		public int magicTotal;
		public int magicRegen;
		public int fortunePoints;
		public int initiative;
		public int acLight;
		public int acHeavy;
		public int reflexHeavy;
		public int reflexLight;
		public int will;
		public int fortitude;
		public int enlightenment; //?

		public Character()
		{
			skills = new int[36];
			spells = new List<string>();
			talents = new List<string>();
			metaSpells = new Dictionary<string, string>();

			customTalents = new List<string>();
			customSkills = new Dictionary<string, int>();
			customSpells = new List<string>();

			//Set everything to its default values
			charisma = 20;
			constitution = 20;
			dexterity = 20;
			intelligence = 20;
			luck = 20;
			speed = 20;
			strength = 20;
			wisdom = 20;
			size = "Medium";
			initiative = 2;

			for (int i = 0; i < skills.Length; ++i)
			{
				skills[i] = 10;
			}
		}

        /// <summary>
        /// Calculates the character's AC if using heavy armor
        /// </summary>
        /// <returns>12 + heavy armor mod</returns>
        public int HeavyArmorClass()
        {
            return 12 + CalculateModifier(skills[Skills.HEAVY_ARMOR]);
        }

        /// <summary>
        /// Calculates the character's AC if using light armor
        /// </summary>
        /// <returns>7 + max(speed modifier, dex modifier) + light armor modifier</returns>
        public int LightArmorClass()
        {
            return 7 + Math.Max(CalculateModifier(speed), CalculateModifier(dexterity))
                + CalculateModifier(skills[Skills.LIGHT_ARMOR]);
        }

        public int CalculateModifier(int skill)
        {
			if(skill == 0)
			{
				return 0;
			}

            int sub = skill % 10;
            skill -= sub;
            return skill / 10;
        }

		/// <summary>
		/// Gets the skill level of a skill
		/// </summary>
		/// <param name="skill">Skill to get the level of</param>
		/// <returns>Level of the skill, -1 if the skill does not exist</returns>
		public int GetSkillValue(string skill)
		{
			int index;

			switch (skill.ToLower())
			{
				case "acrobatics":
					index = Skills.ACROBATICS;
					break;
				case "alteration":
					index = Skills.ALTERATION;
					break;
				case "athletics":
					index = Skills.ATHLETICS;
					break;
				case "block":
					index = Skills.BLOCK;
					break;
				case "chemistry":
					index = Skills.CHEMISTRY;
					break;
				case "conjuration":
					index = Skills.CONJURATION;
					break;
				case "craft":
					index = Skills.CRAFT;
					break;
				case "destruction":
					index = Skills.DESTRUCTION;
					break;
				case "disguise":
					index = Skills.DISGUISE;
					break;
				case "engineering":
					index = Skills.ENGINEERING;
					break;
				case "enlightenment":
					index = Skills.ENLIGHTENMENT;
					break;
				case "escape":
					index = Skills.ESCAPE;
					break;
				case "heavy armor":
				case "heavy_armor":
					index = Skills.HEAVY_ARMOR;
					break;
				case "interaction":
					index = Skills.INTERACTION;
					break;
				case "knowledge":
					index = Skills.KNOWLEDGE;
					break;
				case "language":
					index = Skills.LANGUAGE;
					break;
				case "light armor":
				case "light_armor":
					index = Skills.LIGHT_ARMOR;
					break;
				case "medicine":
					index = Skills.MEDICINE;
					break;
				case "melee weapon":
				case "melee_weapon":
					index = Skills.MELEE_WEAPON;
					break;
				case "survival":
					index = Skills.SURVIVAL;
					break;
				case "perception":
					index = Skills.PERCEPTION;
					break;
				case "ranged combat":
				case "ranged_combat":
					index = Skills.RANGED_COMBAT;
					break;
				case "restoration":
					index = Skills.RESTORATION;
					break;
				case "ride drive":
				case "ride/drive":
				case "ride_drive":
					index = Skills.RIDE_DRIVE;
					break;
				case "security":
					index = Skills.SECURITY;
					break;
				case "sense motive":
				case "sense_motive":
					index = Skills.SENSE_MOTIVE;
					break;
				case "sleight of hand":
				case "sleight_of_hand":
					index = Skills.SLEIGHT_OF_HAND;
					break;
				case "stealth":
					index = Skills.STEALTH;
					break;
				case "unarmed combat":
				case "unarmed_combat":
					index = Skills.UNARMED_COMBAT;
					break;
				default:
					Debug.Print("{0} is not a recognized skill", skill);
					return -1;
			}

			return skills[index];
		}

		public void UpdateSkillScore(string skill, int newValue)
		{
			int index;

			switch (skill.ToLower())
			{
				case "acrobatics":
					index = Skills.ACROBATICS;
					break;
				case "alteration":
					index = Skills.ALTERATION;
					break;
				case "athletics":
					index = Skills.ATHLETICS;
					break;
				case "block":
					index = Skills.BLOCK;
					break;
				case "chemistry":
					index = Skills.CHEMISTRY;
					break;
				case "conjuration":
					index = Skills.CONJURATION;
					break;
				case "craft":
					index = Skills.CRAFT;
					break;
				case "destruction":
					index = Skills.DESTRUCTION;
					break;
				case "disguise":
					index = Skills.DISGUISE;
					break;
				case "engineering":
					index = Skills.ENGINEERING;
					break;
				case "enlightenment":
					index = Skills.ENLIGHTENMENT;
					break;
				case "escape":
					index = Skills.ESCAPE;
					break;
				case "heavy armor":
				case "heavy_armor":
					index = Skills.HEAVY_ARMOR;
					break;
				case "interaction":
					index = Skills.INTERACTION;
					break;
				case "knowledge":
					index = Skills.KNOWLEDGE;
					break;
				case "language":
					index = Skills.LANGUAGE;
					break;
				case "light armor":
				case "light_armor":
					index = Skills.LIGHT_ARMOR;
					break;
				case "medicine":
					index = Skills.MEDICINE;
					break;
				case "melee weapon":
				case "melee_weapon":
					index = Skills.MELEE_WEAPON;
					break;
				case "survival":
					index = Skills.SURVIVAL;
					break;
				case "perception":
					index = Skills.PERCEPTION;
					break;
				case "ranged combat":
				case "ranged_combat":
					index = Skills.RANGED_COMBAT;
					break;
				case "restoration":
					index = Skills.RESTORATION;
					break;
				case "ride drive":
				case "ride/drive":
				case "ride_drive":
					index = Skills.RIDE_DRIVE;
					break;
				case "security":
					index = Skills.SECURITY;
					break;
				case "sense motive":
				case "sense_motive":
					index = Skills.SENSE_MOTIVE;
					break;
				case "sleight of hand":
				case "sleight_of_hand":
					index = Skills.SLEIGHT_OF_HAND;
					break;
				case "stealth":
					index = Skills.STEALTH;
					break;
				case "unarmed combat":
				case "unarmed_combat":
					index = Skills.UNARMED_COMBAT;
					break;
				default:
					Debug.Print("{0} is not a recognized skill", skill);
					return;
			}

			skills[index] = newValue;
		}
    
		/// <summary>
		/// Gets the score for an attribute
		/// </summary>
		/// <param name="attr">Attribute to get the score of. Should be
		/// the abbreviated name for the attribute (i.e. STR for Strength)</param>
		/// <returns>Score for the attribute, -1 for an invalid attribute</returns>
		public int GetAttributeValue(string attr)
		{
			switch(attr.ToUpper())
			{
				case "CHA":
					return charisma;
				case "CON":
					return constitution;
				case "DEX":
					return dexterity;
				case "INT":
					return intelligence;
				case "LCK":
					return luck;
				case "STR":
					return strength;
				case "SPD":
					return speed;
				case "WIS":
					return wisdom;
				default:
					Debug.Print("{0} is an invalid attribute", attr);
					return -1;
			}
		}
	}
}
