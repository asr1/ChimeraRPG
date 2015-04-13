using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solipstry_Character_Creator
{
    class Skills
    {
        ACROBATICS = 0;
        ALTERATION = 1;
        ATHLETICS = 2;
        BLOCK = 3;
        CHEMISTRY = 4;
        CONJURATION = 5;
        CRAFT_SMITH = 6;
        DESTRUCTION = 7;
        DISCIPLINE = 8;
        DISGUISE = 9;
        ENDURANCE = 10;
        ENGINEERING = 11;
        ENLIGHTENMENT = 12;
        ESCAPE = 13;
        HEAVY_ARMOR = 14;
        INTERACTION = 15;
        KNOWLEDGE = 16;
        LANGUAGE = 17;
        LIGHT_ARMOR = 18;
        MEDICINE = 19;
        MELEE_WEAPON = 20;
        NATURE = 21;
        PERCEPTION = 22;
        RANGED_COMBAT = 23;
        RESTORATION = 24;
        RIDE_DRIVE = 25;
        SECURITY = 26;
        SENSE_MOTIVE = 27;
        SLEIGHT_OF_HAND = 28;
        STEALTH = 29;
        UNARMED_COMBAT = 30;
        CUSTOM_1 = 31;
        CUSTOM_2 = 32;
        CUSTOM_3 = 33;
        CUSTOM_4 = 34;
        CUSTOM_5 = 35
    };

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
        /// Calculats the character's AC if using heavy armor
        /// </summary>
        /// <returns>12 + heavy armor mod</returns>
        public int heavyArmorClass()
        {
            return 12 + calculateModifier(skills[Skills.HEAVY_ARMOR]);
        }

        public int calculateModifier(int skill)
        {
            int sub = skill % 10;
            skill -= sub;
            return skill / 10;
        }
    }
}
