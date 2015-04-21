using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solipstry_Character_Creator
{
    class Character
    {
        private string name;
        private string _class;
        private string race;
        private string height;
        private string weight;
        private string occupation;
        private string aspiration;
        private string background;

        private string size; //Small, medium, large, ...

        private int[] skills = new int[36];

        private int charisma;
        private int constitution;
        private int dexterity;
        private int intelligence;
        private int luck;
        private int speed;
        private int strength;
        private int wisdom;

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
