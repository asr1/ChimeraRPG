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
			switch(skill.ToLower())
			{
				case "acrobatics":
					return skills[Skills.ACROBATICS];
				case "alteration":
					return  skills[Skills.ALTERATION];
				case "athletics":
					return skills[Skills.ATHLETICS];
				case "block":
					return skills[Skills.BLOCK];
				case "chemistry":
					return skills[Skills.CHEMISTRY];
				case "conjuration":
					return skills[Skills.CONJURATION];
				case "craft":
					return skills[Skills.CRAFT];
				case "destruction":
					return skills[Skills.DESTRUCTION];
				case "disguise":
					return skills[Skills.DISGUISE];
				case "engineering":
					return skills[Skills.ENGINEERING];
				case "enlightenment":
					return skills[Skills.ENLIGHTENMENT];
				case "escape":
					return skills[Skills.ESCAPE];
				case "heavy armor":
				case "heavy_armor":
					return skills[Skills.HEAVY_ARMOR];
				case "interaction":
					return skills[Skills.INTERACTION];
				case "knowledge":
					return skills[Skills.KNOWLEDGE];
				case "language":
					return skills[Skills.LANGUAGE];
				case "light armor":
				case "light_armor":
					return skills[Skills.LIGHT_ARMOR];
				case "medicine":
					return skills[Skills.MEDICINE];
				case "melee weapon":
				case "melee_weapon":
					return skills[Skills.MELEE_WEAPON];
				case "survival":
					return skills[Skills.SURVIVAL];
				case "perception":
					return skills[Skills.PERCEPTION];
				case "ranged combat":
				case "ranged_combat":
					return skills[Skills.RANGED_COMBAT];
				case "restoration":
					return skills[Skills.RESTORATION];
				case "ride drive":
				case "ride/drive":
				case "ride_drive":
					return skills[Skills.RIDE_DRIVE];
				case "security":
					return skills[Skills.SECURITY];
				case "sense motive":
				case "sense_motive":
					return skills[Skills.SENSE_MOTIVE];
				case "sleight of hand":
				case "sleight_of_hand":
					return skills[Skills.SLEIGHT_OF_HAND];
				case "stealth":
					return skills[Skills.STEALTH];
				case "unarmed combat":
				case "unarmed_combat":
					return skills[Skills.UNARMED_COMBAT];
				default:
					Debug.Print("{0} is not a recognized skill", skill);
					return -1;
			}
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
