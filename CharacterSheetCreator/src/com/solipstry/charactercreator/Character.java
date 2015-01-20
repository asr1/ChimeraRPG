package com.solipstry.charactercreator;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

/**
 * The Character class represents a character in Solipstry. The class stores information about
 * the character such as its name, attributes, and skills.
 * @author Jake Long
 */
public class Character
{
	/**
	 * Creates a new Character object. It really just instantiates the objects.
	 */
	public Character()
	{
		spells = new HashSet<Spell>();
		talents = new HashSet<Talent>();
		equipment = new ArrayList<String>();
		skills = new HashMap<Skill, Integer>();
		
		//All skills are 10 by default
		skills.put(Skill.ACROBATICS, 10);
		skills.put(Skill.ALTERATION, 10);
		skills.put(Skill.ATHLETICS, 10);
		skills.put(Skill.BLOCK, 10);
		skills.put(Skill.CHEMISTRY, 10);
		skills.put(Skill.CONJURATION, 10);
		skills.put(Skill.CRAFT, 10);
		skills.put(Skill.DESTRUCTION, 10);
		skills.put(Skill.DISCIPLINE, 10);
		skills.put(Skill.DISGUISE, 10);
		skills.put(Skill.ENDURANCE, 10);
		skills.put(Skill.ENGINEERING, 10);
		skills.put(Skill.ENLIGHTENMENT, 10);
		skills.put(Skill.ESCAPE, 10);
		skills.put(Skill.HEAVY_ARMOR, 10);
		skills.put(Skill.INTERACTION, 10);
		skills.put(Skill.KNOWLEDGE, 10);
		skills.put(Skill.LANGUAGE, 10);
		skills.put(Skill.LIGHT_ARMOR, 10);
		skills.put(Skill.MEDICINE, 10);
		skills.put(Skill.MELEE_WEAPON, 10);
		skills.put(Skill.NATURE, 10);
		skills.put(Skill.PERCEPTION, 10);
		skills.put(Skill.RANGED_COMBAT, 10);
		skills.put(Skill.RESTORATION, 10);
		skills.put(Skill.RIDE, 10);
		skills.put(Skill.SECURITY, 10);
		skills.put(Skill.SENSE_MOTIVE, 10);
		skills.put(Skill.SLEIGHT_OF_HAND, 10);
		skills.put(Skill.STEALTH, 10);
		skills.put(Skill.UNARMED_COMBAT, 10);
	}
	
	/** The character's name */
	public String name;
	
	/** The character's class */
	public String _class; //Yay poor naming
	
	/** The character's race */
	public String race;
	
	/** The character's height */
	public String height;
	
	/** The character's weight */
	public String weight;
	
	/** The character's age */
	public String age; //No reason to make it an int
	
	/** The character's occupation */
	public String occupation;
	
	/** The character's aspiration */
	public String aspiration;
	
	/** The character's background */
	public String background;
	
	/** The character's skills. Key for the map is the Skill enum */
	public Map<Skill, Integer> skills;
	
	/** The character's hit points */
	public int hp;
	
	/** The character's magic points */
	public int magicPoints;
	
	/** The character's magic regen */
	public int magicRegen;
	
	/** The character's charisma */
	public int charisma;
	
	/** The character's constitution */
	public int constitution;
	
	/** The character's dexterity */
	public int dexterity;
	
	/** The character's intelligence */
	public int intelligence;
	
	/** The character's luck */
	public int luck;
	
	/** The character's speed */
	public int speed;
	
	/** The character's strength */
	public int strength;
	
	/** The character's wisdom */
	public int wisdom;
	
	/** The character's armor class */
	public int ac;
	
	/** The character's reflex */
	public int reflex;
	
	/** The character's will */
	public int will;
	
	/** The character's fortitude */
	public int fortitude;
	
	/** The character's fortune points */
	public int fortunePoints;
	
	/** The character's movement */
	public int movement;
	
	/** The character's initiative modifier */
	public int initiative;
	
	/** The character's enlightenment points */
	public int enlightenment;
	
	/** The character's currency */
	public String currency;
	
	/** The character's spells */
	public HashSet<Spell> spells;
	
	/** The character's talents */
	public HashSet<Talent> talents;
	
	/** The character's equipment */
	public ArrayList<String> equipment;
	
	/** Any custom skills the character has */
	public CustomSkill customSkills[] = new CustomSkill[5];
	
	/** Any custom spells the character has */
	public ArrayList<CustomSpell> customSpells = new ArrayList<CustomSpell>();
	
	/** 
	 * Calculates the modifier for the given integer value.
	 * The modifier is equal to the tens place and beyond.
	 * @param value The value of the skill or attribute the modifier is being calculated for.
	 * @return The modifier for the skill or attribute supplied.
	 */
	public static int getModifier(int value)
	{
		value -= value % 10;
		return value/10;
	}
}

