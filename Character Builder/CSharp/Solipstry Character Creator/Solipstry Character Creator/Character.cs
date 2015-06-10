using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solipstry_Character_Creator
{
    class Character
    {
		//Basic information
        public string name;
        public string _class;
        public string race;
        public string height;
        public string weight;
        public string occupation;
        public string aspiration;
        public string background;

        public string size; //Small, medium, large

		public int[] skills;
		public List<string> spells;
		public List<string> talents;

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
		public int enlightenment; //?
		public int numLanguages;  //?

		public Character()
		{
			skills = new int[36];
			spells = new List<string>();
			talents = new List<string>();
			metaSpells = new Dictionary<string, string>();

			//Set everything to its default values
			charisma = 20;
			constitution = 20;
			dexterity = 20;
			intelligence = 20;
			luck = 20;
			speed = 20;
			strength = 20;
			wisdom = 20;

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
				case "craft smith":
				case "craft/smith":
					return skills[Skills.CRAFT_SMITH];
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
					return skills[Skills.HEAVY_ARMOR];
				case "interaction":
					return skills[Skills.INTERACTION];
				case "knowledge":
					return skills[Skills.KNOWLEDGE];
				case "language":
					return skills[Skills.LANGUAGE];
				case "light armor":
					return skills[Skills.LIGHT_ARMOR];
				case "medicine":
					return skills[Skills.MEDICINE];
				case "melee weapon":
					return skills[Skills.MELEE_WEAPON];
				case "nature":
					return skills[Skills.NATURE];
				case "perception":
					return skills[Skills.PERCEPTION];
				case "ranged combat":
					return skills[Skills.RANGED_COMBAT];
				case "restoration":
					return skills[Skills.RESTORATION];
				case "ride drive":
				case "ride/drive":
					return skills[Skills.RIDE_DRIVE];
				case "security":
					return skills[Skills.SECURITY];
				case "sense motive":
					return skills[Skills.SENSE_MOTIVE];
				case "sleight of hand":
					return skills[Skills.SLEIGHT_OF_HAND];
				case "stealth":
					return skills[Skills.STEALTH];
				case "unarmed combat":
					return skills[Skills.UNARMED_COMBAT];
				default:
					Console.WriteLine("Unrecognized skill: {0}", skill);
					return -1;
			}
		}
    }
}
