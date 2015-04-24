using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solipstry_Character_Creator
{
    class Character
    {
        public string name;
        public string _class;
        public string race;
        public string height;
        public string weight;
        public string occupation;
        public string aspiration;
        public string background;

        public string size; //Small, medium, large, ...

        public int[] skills = new int[36];

        public int charisma;
        public int constitution;
        public int dexterity;
        public int intelligence;
        public int luck;
        public int speed;
        public int strength;
        public int wisdom;

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
            int sub = skill % 10;
            skill -= sub;
            return skill / 10;
        }
    }
}
