package com.solipstry.charactercreator;

import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.JButton;
import javax.swing.JCheckBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.JTextField;
import javax.swing.TransferHandler;
import javax.swing.UIManager;
import javax.swing.border.EmptyBorder;
import javax.swing.SwingConstants;

public class MainWindow extends JFrame
{
	private JPanel contentPane;
	
	//Shows whether the user is creating a homebrewed character
	private JCheckBox chkHomebrew;

	private final JTabbedPane tabbedPane;
	
	//Panels for use in the tabbedPane
	private JPanel detailsPanel;
	private JPanel attributesPanel;
	private JPanel skillsPanel;
	private JPanel talentsPanel;
	private JPanel spellsPanel;
	
	//Labels for quick stats
	private JLabel lblHp;
	private JLabel lblMagicPoints;
	private JLabel lblMagicRegen;
	private JLabel lblAc;
	private JLabel lblReflex;
	private JLabel lblWill;
	private JLabel lblFortitude;
	private JLabel lblFortune;
	private JLabel lblMovement;
	private JLabel lblInitiative;
	
	private JTextField txtName;
	private JTextField txtClass;
	private JTextField txtRace;
	private JTextField txtHeight;
	private JTextField txtWeight;
	private JTextField txtAge;
	private JTextField txtOccupation;
	private JTextField txtAspiration;
	private JTextField txtBackground;
	private JLabel lblCharisma;
	private JLabel lblConstitution;
	private JLabel lblDexterity;
	private JLabel lblInt;
	private JLabel lblLuck;
	private JLabel lblSpeed;
	private JLabel lblStr;
	private JLabel lblWis;
	private JTextField txtCharisma;
	private JTextField txtConstitution;
	private JTextField txtDexterity;
	private JTextField txtIntelligence;
	private JTextField txtLuck;
	private JTextField txtSpeed;
	private JTextField txtStrength;
	private JTextField txtWisdom;
	private JButton btnAttribute1;
	private JButton btnAttribute2;
	private JButton btnAttribute3;
	private JButton btnAttribute4;
	private JButton btnAttribute5;
	private JButton btnAttribute6;
	private JButton btnAttribute7;
	private JButton btnAttribute8;
	
	private Character character;
	private JButton btnAttrNext;
	private JTextField txtCustomSkill1Name;
	private JTextField txtCustomSkill2Name;
	private JTextField txtCustomSkill3Name;
	private JTextField txtCustomSkill4Name;
	private JTextField txtCustomSkill5Name;
	
	public static void main(String args[])
	{
		MainWindow window = new MainWindow();
		window.setVisible(true);
	}
	
	/**
	 * Create the frame.
	 */
	public MainWindow()
	{
		character = new Character();
		
		setTitle("Solipstry Character Creator");
		
		//TODO Prompt user to save work before exiting
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		//TODO Get icon to work
		
		setBounds(100, 100, 750, 400);
		setResizable(false);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setBounds(0, 0, 600, 371);
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		tabbedPane = new JTabbedPane(JTabbedPane.TOP);
		tabbedPane.setBounds(0, 0, 600, 371);
		contentPane.add(tabbedPane);

		//Instantiate the tabs and set their layout to absolute
		detailsPanel = new JPanel();
		detailsPanel.setLayout(null);
		
		attributesPanel = new JPanel();
		attributesPanel.setLayout(null);
		
		skillsPanel = new JPanel();
		skillsPanel.setLayout(null);
		
		talentsPanel = new JPanel();
		talentsPanel.setLayout(null);
		
		spellsPanel = new JPanel();
		spellsPanel.setLayout(null);
		
		setupDetailsPanel();
		setupAttributesPanel();
		setupSkillsPanel();
		setupTalentsPanel();
		setupSpellsPanel();
		
		tabbedPane.addTab("Details", null, detailsPanel, "Character details");
		tabbedPane.addTab("Attributes", null, attributesPanel, "Character attributes");
		tabbedPane.addTab("Skills", null, skillsPanel, "Character skills");
		
		JCheckBox chckbxAlteration = new JCheckBox("Alteration");
		chckbxAlteration.setBounds(6, 33, 97, 23);
		skillsPanel.add(chckbxAlteration);
		
		JCheckBox chckbxAcrobatics = new JCheckBox("Acrobatics");
		chckbxAcrobatics.setBounds(6, 7, 97, 23);
		skillsPanel.add(chckbxAcrobatics);
		
		JCheckBox chckbxAthletics = new JCheckBox("Athletics");
		chckbxAthletics.setBounds(6, 59, 97, 23);
		skillsPanel.add(chckbxAthletics);
		
		JCheckBox chckbxBlock = new JCheckBox("Block");
		chckbxBlock.setBounds(6, 85, 97, 23);
		skillsPanel.add(chckbxBlock);
		
		JCheckBox chckbxChemistry = new JCheckBox("Chemistry");
		chckbxChemistry.setBounds(6, 111, 97, 23);
		skillsPanel.add(chckbxChemistry);
		
		JCheckBox chckbxConjuration = new JCheckBox("Conjuration");
		chckbxConjuration.setBounds(6, 137, 97, 23);
		skillsPanel.add(chckbxConjuration);
		
		JCheckBox chckbxCraft = new JCheckBox("Craft");
		chckbxCraft.setBounds(6, 163, 97, 23);
		skillsPanel.add(chckbxCraft);
		
		JCheckBox chckbxDestruction = new JCheckBox("Destruction");
		chckbxDestruction.setBounds(6, 189, 97, 23);
		skillsPanel.add(chckbxDestruction);
		
		JCheckBox chckbxDiscipline = new JCheckBox("Discipline");
		chckbxDiscipline.setBounds(6, 215, 97, 23);
		skillsPanel.add(chckbxDiscipline);
		
		JCheckBox chckbxDisguise = new JCheckBox("Disguise");
		chckbxDisguise.setBounds(6, 241, 97, 23);
		skillsPanel.add(chckbxDisguise);
		
		JCheckBox chckbxEndurance = new JCheckBox("Endurance");
		chckbxEndurance.setBounds(6, 267, 97, 23);
		skillsPanel.add(chckbxEndurance);
		
		JCheckBox chckbxEngineering = new JCheckBox("Engineering");
		chckbxEngineering.setBounds(6, 293, 97, 23);
		skillsPanel.add(chckbxEngineering);
		
		JCheckBox chckbxEnlightenment = new JCheckBox("Enlightenment");
		chckbxEnlightenment.setBounds(105, 7, 118, 23);
		skillsPanel.add(chckbxEnlightenment);
		
		JCheckBox chckbxEscape = new JCheckBox("Escape");
		chckbxEscape.setBounds(105, 33, 97, 23);
		skillsPanel.add(chckbxEscape);
		
		JCheckBox chckbxHeavyArmor = new JCheckBox("Heavy Armor");
		chckbxHeavyArmor.setBounds(105, 59, 118, 23);
		skillsPanel.add(chckbxHeavyArmor);
		
		JCheckBox chckbxInteraction = new JCheckBox("Interaction");
		chckbxInteraction.setBounds(105, 85, 97, 23);
		skillsPanel.add(chckbxInteraction);
		
		JCheckBox chckbxKnowledge = new JCheckBox("Knowledge");
		chckbxKnowledge.setBounds(105, 111, 97, 23);
		skillsPanel.add(chckbxKnowledge);
		
		JCheckBox chckbxLanguage = new JCheckBox("Language");
		chckbxLanguage.setBounds(105, 137, 97, 23);
		skillsPanel.add(chckbxLanguage);
		
		JCheckBox chckbxLightArmor = new JCheckBox("Light Armor");
		chckbxLightArmor.setBounds(105, 163, 97, 23);
		skillsPanel.add(chckbxLightArmor);
		
		JCheckBox chckbxMedicine = new JCheckBox("Medicine");
		chckbxMedicine.setBounds(105, 189, 97, 23);
		skillsPanel.add(chckbxMedicine);
		
		JCheckBox chckbxMeleeWeapon = new JCheckBox("Melee Weapon");
		chckbxMeleeWeapon.setBounds(105, 215, 118, 23);
		skillsPanel.add(chckbxMeleeWeapon);
		
		JCheckBox chckbxNature = new JCheckBox("Nature");
		chckbxNature.setBounds(105, 241, 97, 23);
		skillsPanel.add(chckbxNature);
		
		JCheckBox chckbxPerception = new JCheckBox("Perception");
		chckbxPerception.setBounds(105, 267, 97, 23);
		skillsPanel.add(chckbxPerception);
		
		JCheckBox chckbxRangedCombat = new JCheckBox("Ranged Combat");
		chckbxRangedCombat.setBounds(105, 293, 118, 23);
		skillsPanel.add(chckbxRangedCombat);
		
		JCheckBox chckbxRestoration = new JCheckBox("Restoration");
		chckbxRestoration.setBounds(225, 7, 97, 23);
		skillsPanel.add(chckbxRestoration);
		
		JCheckBox chckbxRide = new JCheckBox("Ride");
		chckbxRide.setBounds(225, 33, 97, 23);
		skillsPanel.add(chckbxRide);
		
		JCheckBox chckbxSecurity = new JCheckBox("Security");
		chckbxSecurity.setBounds(225, 59, 97, 23);
		skillsPanel.add(chckbxSecurity);
		
		JCheckBox chckbxSenseMotive = new JCheckBox("Sense Motive");
		chckbxSenseMotive.setBounds(225, 85, 149, 23);
		skillsPanel.add(chckbxSenseMotive);
		
		JCheckBox chckbxSleightOfHand = new JCheckBox("Sleight of Hand");
		chckbxSleightOfHand.setBounds(225, 111, 162, 23);
		skillsPanel.add(chckbxSleightOfHand);
		
		JCheckBox chckbxStealth = new JCheckBox("Stealth");
		chckbxStealth.setBounds(225, 137, 97, 23);
		skillsPanel.add(chckbxStealth);
		
		JCheckBox chckbxUnarmedCombat = new JCheckBox("Unarmed Combat");
		chckbxUnarmedCombat.setBounds(225, 163, 173, 23);
		skillsPanel.add(chckbxUnarmedCombat);
		
		JCheckBox chckbxCustomSkill1 = new JCheckBox("");
		chckbxCustomSkill1.setBounds(225, 189, 21, 23);
		skillsPanel.add(chckbxCustomSkill1);
		
		JCheckBox chckbxCustomSkill2 = new JCheckBox("");
		chckbxCustomSkill2.setBounds(225, 215, 21, 23);
		skillsPanel.add(chckbxCustomSkill2);
		
		JCheckBox chckbxCustomSkill3 = new JCheckBox("");
		chckbxCustomSkill3.setBounds(225, 241, 21, 23);
		skillsPanel.add(chckbxCustomSkill3);
		
		JCheckBox chckbxCustomSkill4 = new JCheckBox("");
		chckbxCustomSkill4.setBounds(225, 267, 21, 23);
		skillsPanel.add(chckbxCustomSkill4);
		
		JCheckBox chckbxCustomSkill5 = new JCheckBox("");
		chckbxCustomSkill5.setBounds(225, 293, 21, 23);
		skillsPanel.add(chckbxCustomSkill5);
		
		txtCustomSkill1Name = new JTextField();
		txtCustomSkill1Name.setText("Custom Skill");
		txtCustomSkill1Name.setColumns(10);
		txtCustomSkill1Name.setBounds(252, 192, 200, 20);
		skillsPanel.add(txtCustomSkill1Name);
		
		txtCustomSkill2Name = new JTextField();
		txtCustomSkill2Name.setText("Custom Skill");
		txtCustomSkill2Name.setColumns(10);
		txtCustomSkill2Name.setBounds(252, 216, 200, 20);
		skillsPanel.add(txtCustomSkill2Name);
		
		txtCustomSkill3Name = new JTextField();
		txtCustomSkill3Name.setText("Custom Skill");
		txtCustomSkill3Name.setColumns(10);
		txtCustomSkill3Name.setBounds(252, 242, 200, 20);
		skillsPanel.add(txtCustomSkill3Name);
		
		txtCustomSkill4Name = new JTextField();
		txtCustomSkill4Name.setText("Custom Skill");
		txtCustomSkill4Name.setColumns(10);
		txtCustomSkill4Name.setBounds(252, 268, 200, 20);
		skillsPanel.add(txtCustomSkill4Name);
		
		txtCustomSkill5Name = new JTextField();
		txtCustomSkill5Name.setText("Custom Skill");
		txtCustomSkill5Name.setColumns(10);
		txtCustomSkill5Name.setBounds(252, 296, 200, 20);
		skillsPanel.add(txtCustomSkill5Name);
		
		JLabel lblSkillsInstructions = new JLabel("Instructions:");
		lblSkillsInstructions.setVerticalAlignment(SwingConstants.TOP);
		lblSkillsInstructions.setBounds(368, 11, 217, 97);
		skillsPanel.add(lblSkillsInstructions);
		JLabel lblSkillsInstructions2 = new JLabel("Select 5 skills to have a base score of 25");
		lblSkillsInstructions2.setVerticalAlignment(SwingConstants.TOP);
		lblSkillsInstructions2.setBounds(368,25,217,97);
		skillsPanel.add(lblSkillsInstructions2);
		
		tabbedPane.addTab("Talents", null, talentsPanel, "Character talents");
		tabbedPane.addTab("Spells", null, spellsPanel, "Character spells");
		
		chkHomebrew = new JCheckBox("Homebrew");
		chkHomebrew.setBounds(600, 341, 131, 23);
		chkHomebrew.setEnabled(false);
		contentPane.add(chkHomebrew);
		
		JLabel lblHpName = new JLabel("HP");
		lblHpName.setBounds(603, 20, 100, 14);
		contentPane.add(lblHpName);
		
		lblHp = new JLabel("0");
		lblHp.setBounds(703, 20, 100, 14);
		contentPane.add(lblHp);
		
		JLabel lblMagicPointsName = new JLabel("Magic Points");
		lblMagicPointsName.setBounds(603, 40, 100, 14);
		contentPane.add(lblMagicPointsName);
		
		lblMagicPoints = new JLabel("0");
		lblMagicPoints.setBounds(703, 40, 100, 14);
		contentPane.add(lblMagicPoints);
		
		JLabel lblMagicRegenName = new JLabel("Magic Regen");
		lblMagicRegenName.setBounds(603, 60, 100, 14);
		contentPane.add(lblMagicRegenName);
		
		lblMagicRegen = new JLabel("0");
		lblMagicRegen.setBounds(703, 60, 100, 14);
		contentPane.add(lblMagicRegen);
		
		JLabel lblAcName = new JLabel("AC");
		lblAcName.setBounds(603, 80, 100, 14);
		contentPane.add(lblAcName);
		
		lblAc = new JLabel("0");
		lblAc.setBounds(703, 80, 100, 14);
		contentPane.add(lblAc);
		
		JLabel lblReflexName = new JLabel("Reflex");
		lblReflexName.setBounds(603, 100, 100, 14);
		contentPane.add(lblReflexName);
		
		lblReflex = new JLabel("0");
		lblReflex.setBounds(703, 100, 100, 14);
		contentPane.add(lblReflex);
		
		JLabel lblWillName = new JLabel("Will");
		lblWillName.setBounds(603, 120, 100, 14);
		contentPane.add(lblWillName);
		
		lblWill = new JLabel("0");
		lblWill.setBounds(703, 120, 100, 14);
		contentPane.add(lblWill);
		
		JLabel lblFortitudeName = new JLabel("Fortitude");
		lblFortitudeName.setBounds(603, 140, 100, 14);
		contentPane.add(lblFortitudeName);
		
		lblFortitude = new JLabel("0");
		lblFortitude.setBounds(703, 140, 100, 14);
		contentPane.add(lblFortitude);
		
		JLabel lblFortuneName = new JLabel("Fortune");
		lblFortuneName.setBounds(603, 160, 100, 14);
		contentPane.add(lblFortuneName);
		
		lblFortune = new JLabel("0");
		lblFortune.setBounds(703, 160, 100, 14);
		contentPane.add(lblFortune);
		
		JLabel lblMovementName = new JLabel("Movement");
		lblMovementName.setBounds(603, 180, 100, 14);
		contentPane.add(lblMovementName);
		
		lblMovement = new JLabel("0");
		lblMovement.setBounds(703, 180, 100, 14);
		contentPane.add(lblMovement);
		
		JLabel lblInitiativeName = new JLabel("Initiative");
		lblInitiativeName.setBounds(603, 200, 100, 14);
		contentPane.add(lblInitiativeName);
		
		lblInitiative = new JLabel("0");
		lblInitiative.setBounds(703, 200, 100, 14);
		contentPane.add(lblInitiative);
	}	
	
	/**
	 * Updates the character object with the information on the details tab
	 */
	private void updateCharacterDetails()
	{
		character.name = txtName.getText();
		character._class = txtClass.getText();
		character.race = txtRace.getText();
		character.height = txtHeight.getText();
		character.weight = txtWeight.getText();
		character.age = txtAge.getText();
		character.occupation = txtOccupation.getText();
		character.aspiration = txtAspiration.getText();
		character.background = txtBackground.getText();
	}
	
	/**
	 * Updates the information about the character that is affected by attributes
	 */
	private void updateCharacterAttributes()
	{
		boolean invalidInput = false;
		
		try
		{
			character.charisma = Integer.parseInt(txtCharisma.getText());
		}
		catch(NumberFormatException e)
		{
			character.charisma = 0;
			invalidInput = true;
		}
		
		try
		{
			character.constitution = Integer.parseInt(txtConstitution.getText());
		}
		catch(NumberFormatException e)
		{
			character.constitution = 0;
			invalidInput = true;
		}
		
		
		try
		{
			character.dexterity = Integer.parseInt(txtDexterity.getText());
		}
		catch(NumberFormatException e)
		{
			character.dexterity = 0;
			invalidInput = true;
		}
		
		
		try 
		{
			character.intelligence = Integer.parseInt(txtIntelligence.getText());
		}
		catch(NumberFormatException e)
		{
			 character.intelligence = 0;
			 invalidInput = true;
		}
		
		
		try
		{
			character.luck = Integer.parseInt(txtLuck.getText());
		}
		catch(NumberFormatException e)
		{
			character.luck = 0;
			invalidInput = true;
		}
		
		try
		{
			character.speed = Integer.parseInt(txtSpeed.getText());
		}
		catch(NumberFormatException e)
		{
			character.speed = 0;
			invalidInput = true;
		}
		
		
		try
		{
			character.wisdom = Integer.parseInt(txtWisdom.getText());
		}
		catch(NumberFormatException e)
		{
			character.wisdom = 0;
			invalidInput = true;
		}
		
		//Notify user of invalid input
		if(invalidInput)
		{
			JOptionPane.showMessageDialog(null, "Please enter integer values only", "Invalid Input", JOptionPane.INFORMATION_MESSAGE);
		}
        
		//Calculate derived traits
		character.movement = 3 + Character.getModifier(character.speed);
		character.hp = (int) Math.floor(1.5 * character.constitution);
		character.magicPoints = 5 * character.wisdom;
		character.magicRegen = character.intelligence;
		character.fortunePoints = Character.getModifier(character.luck);
		character.initiative = Character.getModifier(character.speed);
		character.fortitude = 10 + Character.getModifier(character.constitution);
		character.will = 10 + Character.getModifier(character.wisdom);
		
		//Display the information in the quick view
		lblMovement.setText(Integer.toString(character.movement));
		lblHp.setText(Integer.toString(character.hp));
		lblMagicPoints.setText(Integer.toString(character.magicPoints));
		lblMagicRegen.setText(Integer.toString(character.magicRegen));
		lblFortune.setText(Integer.toString(character.fortunePoints));
		lblFortitude.setText(Integer.toString(character.fortitude));
		lblWill.setText(Integer.toString(character.will));
	}
	
	private void setupDetailsPanel()
	{

		JLabel lblName = new JLabel("Name");
		lblName.setBounds(90, 43, 100, 14);
		detailsPanel.add(lblName);
		
		JLabel lblClass = new JLabel("Class");
		lblClass.setBounds(90, 74, 100, 14);
		detailsPanel.add(lblClass);
		
		JLabel lblRace = new JLabel("Race");
		lblRace.setBounds(90, 105, 100, 14);
		detailsPanel.add(lblRace);
		
		JLabel lblHeight = new JLabel("Height");
		lblHeight.setBounds(90, 136, 100, 14);
		detailsPanel.add(lblHeight);
		
		JLabel lblWeight = new JLabel("Weight");
		lblWeight.setBounds(90, 169, 100, 14);
		detailsPanel.add(lblWeight);
		
		JLabel lblAge = new JLabel("Age");
		lblAge.setBounds(90, 200, 100, 14);
		detailsPanel.add(lblAge);
		
		JLabel lblOccupation = new JLabel("Occupation");
		lblOccupation.setBounds(90, 231, 100, 14);
		detailsPanel.add(lblOccupation);
		
		JLabel lblAspiration = new JLabel("Aspiration");
		lblAspiration.setBounds(90, 262, 100, 14);
		detailsPanel.add(lblAspiration);
		
		JLabel lblBackground = new JLabel("Background");
		lblBackground.setBounds(90, 293, 100, 14);
		detailsPanel.add(lblBackground);
		
		txtName = new JTextField();
		txtName.setBounds(200, 40, 200, 20);
		detailsPanel.add(txtName);
		txtName.setColumns(10);
		
		txtClass = new JTextField();
		txtClass.setBounds(200, 71, 200, 20);
		detailsPanel.add(txtClass);
		txtClass.setColumns(10);
		
		txtRace = new JTextField();
		txtRace.setBounds(200, 102, 200, 20);
		detailsPanel.add(txtRace);
		txtRace.setColumns(10);
		
		txtHeight = new JTextField();
		txtHeight.setBounds(200, 133, 200, 20);
		detailsPanel.add(txtHeight);
		txtHeight.setColumns(10);
		
		txtWeight = new JTextField();
		txtWeight.setBounds(200, 166, 200, 20);
		detailsPanel.add(txtWeight);
		txtWeight.setColumns(10);
		
		txtAge = new JTextField();
		txtAge.setBounds(200, 197, 200, 20);
		detailsPanel.add(txtAge);
		txtAge.setColumns(10);
		
		txtOccupation = new JTextField();
		txtOccupation.setBounds(200, 228, 200, 20);
		detailsPanel.add(txtOccupation);
		txtOccupation.setColumns(10);
		
		txtAspiration = new JTextField();
		txtAspiration.setBounds(200, 259, 200, 20);
		detailsPanel.add(txtAspiration);
		txtAspiration.setColumns(10);
		
		txtBackground = new JTextField();
		txtBackground.setBounds(200, 290, 200, 20);
		detailsPanel.add(txtBackground);
		txtBackground.setColumns(10);
		
		JButton btnDetailsNext = new JButton("Next");
		btnDetailsNext.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent arg0) 
			{
				updateCharacterDetails();
				checkHomebrew();
				tabbedPane.setSelectedIndex(1);
			}
		});
		btnDetailsNext.setBounds(496, 309, 89, 23);
		detailsPanel.add(btnDetailsNext);
	}
	
	private void setupAttributesPanel()
	{
		btnAttribute1 = new JButton();
		btnAttribute2 = new JButton();
		btnAttribute3 = new JButton();
		btnAttribute4 = new JButton();
		btnAttribute5 = new JButton();
		btnAttribute6 = new JButton();
		btnAttribute7 = new JButton();
		btnAttribute8 = new JButton();
		
		btnAttribute1.setBounds(232, 43, 86, 20);
		btnAttribute1.setBackground(UIManager.getColor("Label.background"));
		btnAttribute1.setFocusPainted(false);
		btnAttribute1.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute1.setContentAreaFilled(false);
		btnAttribute1.setOpaque(false);
		TransferHandler transfer1 = new TransferHandler("text");
		btnAttribute1.setTransferHandler(transfer1);
		btnAttribute1.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		btnAttribute2.setBounds(232, 68, 86, 20);
		btnAttribute2.setBackground(UIManager.getColor("Label.background"));
		btnAttribute2.setFocusPainted(false);
		btnAttribute2.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute2.setContentAreaFilled(false);
		btnAttribute2.setOpaque(false);
		TransferHandler transfer2 = new TransferHandler("text");
		btnAttribute2.setTransferHandler(transfer2);
		btnAttribute2.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		btnAttribute3.setBounds(232, 93, 86, 20);
		btnAttribute3.setBackground(UIManager.getColor("Label.background"));
		btnAttribute3.setFocusPainted(false);
		btnAttribute3.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute3.setContentAreaFilled(false);
		btnAttribute3.setOpaque(false);
		TransferHandler transfer3 = new TransferHandler("text");
		btnAttribute3.setTransferHandler(transfer3);
		btnAttribute3.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		btnAttribute4.setBounds(232, 118, 86, 20);
		btnAttribute4.setBackground(UIManager.getColor("Label.background"));
		btnAttribute4.setFocusPainted(false);
		btnAttribute4.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute4.setContentAreaFilled(false);
		btnAttribute4.setOpaque(false);
		TransferHandler transfer4 = new TransferHandler("text");
		btnAttribute4.setTransferHandler(transfer4);
		btnAttribute4.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		btnAttribute5.setBounds(232, 143, 86, 20);
		btnAttribute5.setBackground(UIManager.getColor("Label.background"));
		btnAttribute5.setFocusPainted(false);
		btnAttribute5.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute5.setContentAreaFilled(false);
		btnAttribute5.setOpaque(false);
		TransferHandler transfer5 = new TransferHandler("text");
		btnAttribute5.setTransferHandler(transfer5);
		btnAttribute5.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		btnAttribute6.setBounds(232, 168, 86, 20);
		btnAttribute6.setBackground(UIManager.getColor("Label.background"));
		btnAttribute6.setFocusPainted(false);
		btnAttribute6.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute6.setContentAreaFilled(false);
		btnAttribute6.setOpaque(false);
		TransferHandler transfer6 = new TransferHandler("text");
		btnAttribute6.setTransferHandler(transfer6);
		btnAttribute6.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		btnAttribute7.setBounds(232, 193, 86, 20);
		btnAttribute7.setBackground(UIManager.getColor("Label.background"));
		btnAttribute7.setFocusPainted(false);
		btnAttribute7.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute7.setContentAreaFilled(false);
		btnAttribute7.setOpaque(false);
		TransferHandler transfer7 = new TransferHandler("text");
		btnAttribute7.setTransferHandler(transfer7);
		btnAttribute7.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		btnAttribute8.setBounds(232, 221, 86, 20);
		btnAttribute8.setBackground(UIManager.getColor("Label.background"));
		btnAttribute8.setFocusPainted(false);
		btnAttribute8.setMargin(new Insets(0, 0, 0, 0));
		btnAttribute8.setContentAreaFilled(false);
		btnAttribute8.setOpaque(false);
		TransferHandler transfer8 = new TransferHandler("text");
		btnAttribute8.setTransferHandler(transfer8);
		btnAttribute8.addMouseListener(new MouseAdapter()
		{
			public void mousePressed(MouseEvent e)
			{
				JButton button = (JButton) e.getSource();
				TransferHandler handler = button.getTransferHandler();
				if(button.isEnabled())
				{
					handler.exportAsDrag(button, e, TransferHandler.COPY);
				}
				button.setEnabled(false);
			}
		});
		
		attributesPanel.add(btnAttribute1);
		attributesPanel.add(btnAttribute2);
		attributesPanel.add(btnAttribute3);
		attributesPanel.add(btnAttribute4);
		attributesPanel.add(btnAttribute5);
		attributesPanel.add(btnAttribute6);
		attributesPanel.add(btnAttribute7);
		attributesPanel.add(btnAttribute8);
		
		txtCharisma = new JTextField();
		txtConstitution = new JTextField();
		txtDexterity = new JTextField();
		txtIntelligence = new JTextField();
		txtLuck = new JTextField();
		txtSpeed = new JTextField();
		txtStrength = new JTextField();
		txtWisdom = new JTextField();
		
		JButton btnAll20 = new JButton("All 20");
		btnAll20.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				btnAttribute1.setVisible(false);
				btnAttribute2.setVisible(false);
				btnAttribute3.setVisible(false);
				btnAttribute4.setVisible(false);
				btnAttribute5.setVisible(false);
				btnAttribute6.setVisible(false);
				btnAttribute7.setVisible(false);
				btnAttribute8.setVisible(false);
				btnAttribute1.setEnabled(false);
				btnAttribute2.setEnabled(false);
				btnAttribute3.setEnabled(false);
				btnAttribute4.setEnabled(false);
				btnAttribute5.setEnabled(false);
				btnAttribute6.setEnabled(false);
				btnAttribute7.setEnabled(false);
				btnAttribute8.setEnabled(false);
				
				txtCharisma.setText("20");
				txtConstitution.setText("20");
				txtDexterity.setText("20");
				txtIntelligence.setText("20");
				txtLuck.setText("20");
				txtSpeed.setText("20");
				txtStrength.setText("20");
				txtWisdom.setText("20");
			}
		});
		btnAll20.setBounds(359, 11, 196, 23);
		btnAll20.doClick();
		attributesPanel.add(btnAll20);
		
		JButton btnOption1 = new JButton("30 30 20 20 20 20 10 10");
		btnOption1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				btnAttribute1.setVisible(true);
				btnAttribute2.setVisible(true);
				btnAttribute3.setVisible(true);
				btnAttribute4.setVisible(true);
				btnAttribute5.setVisible(true);
				btnAttribute6.setVisible(true);
				btnAttribute7.setVisible(true);
				btnAttribute8.setVisible(true);
				btnAttribute1.setEnabled(true);
				btnAttribute2.setEnabled(true);
				btnAttribute3.setEnabled(true);
				btnAttribute4.setEnabled(true);
				btnAttribute5.setEnabled(true);
				btnAttribute6.setEnabled(true);
				btnAttribute7.setEnabled(true);
				btnAttribute8.setEnabled(true);
				
				btnAttribute1.setText("30");
				btnAttribute2.setText("30");
				btnAttribute3.setText("20");
				btnAttribute4.setText("20");
				btnAttribute5.setText("20");
				btnAttribute6.setText("20");
				btnAttribute7.setText("10");
				btnAttribute8.setText("10");
				
				txtCharisma.setText("");
				txtConstitution.setText("");
				txtDexterity.setText("");
				txtIntelligence.setText("");
				txtLuck.setText("");
				txtSpeed.setText("");
				txtStrength.setText("");
				txtWisdom.setText("");
			}
		});
		btnOption1.setBounds(359, 44, 196, 23);
		attributesPanel.add(btnOption1);
		
		JButton btnOption2 = new JButton("30 30 30 20 20 10 10 10");
		btnOption2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				btnAttribute1.setVisible(true);
				btnAttribute2.setVisible(true);
				btnAttribute3.setVisible(true);
				btnAttribute4.setVisible(true);
				btnAttribute5.setVisible(true);
				btnAttribute6.setVisible(true);
				btnAttribute7.setVisible(true);
				btnAttribute8.setVisible(true);
				btnAttribute1.setEnabled(true);
				btnAttribute2.setEnabled(true);
				btnAttribute3.setEnabled(true);
				btnAttribute4.setEnabled(true);
				btnAttribute5.setEnabled(true);
				btnAttribute6.setEnabled(true);
				btnAttribute7.setEnabled(true);
				btnAttribute8.setEnabled(true);
				
				btnAttribute1.setText("30");
				btnAttribute2.setText("30");
				btnAttribute3.setText("30");
				btnAttribute4.setText("20");
				btnAttribute5.setText("20");
				btnAttribute6.setText("10");
				btnAttribute7.setText("10");
				btnAttribute8.setText("10");
				
				txtCharisma.setText("");
				txtConstitution.setText("");
				txtDexterity.setText("");
				txtIntelligence.setText("");
				txtLuck.setText("");
				txtSpeed.setText("");
				txtStrength.setText("");
				txtWisdom.setText("");
			}
		});
		btnOption2.setBounds(359, 79, 196, 23);
		attributesPanel.add(btnOption2);
		
		JButton btnRolled = new JButton("I rolled my attributes");
		btnRolled.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				btnAttribute1.setVisible(false);
				btnAttribute2.setVisible(false);
				btnAttribute3.setVisible(false);
				btnAttribute4.setVisible(false);
				btnAttribute5.setVisible(false);
				btnAttribute6.setVisible(false);
				btnAttribute7.setVisible(false);
				btnAttribute8.setVisible(false);
				btnAttribute1.setEnabled(false);
				btnAttribute2.setEnabled(false);
				btnAttribute3.setEnabled(false);
				btnAttribute4.setEnabled(false);
				btnAttribute5.setEnabled(false);
				btnAttribute6.setEnabled(false);
				btnAttribute7.setEnabled(false);
				btnAttribute8.setEnabled(false);
				
				txtCharisma.setText("");
				txtConstitution.setText("");
				txtDexterity.setText("");
				txtIntelligence.setText("");
				txtLuck.setText("");
				txtSpeed.setText("");
				txtStrength.setText("");
				txtWisdom.setText("");
			}
		});
		btnRolled.setBounds(359, 115, 196, 23);
		attributesPanel.add(btnRolled);
		
		lblCharisma = new JLabel("Charisma");
		lblCharisma.setBounds(24, 49, 100, 14);
		attributesPanel.add(lblCharisma);
		
		lblConstitution = new JLabel("Constitution");
		lblConstitution.setBounds(24, 74, 100, 14);
		attributesPanel.add(lblConstitution);
		
		lblDexterity = new JLabel("Dexterity");
		lblDexterity.setBounds(24, 99, 100, 14);
		attributesPanel.add(lblDexterity);
		
		lblInt = new JLabel("Intelligence");
		lblInt.setBounds(24, 124, 100, 14);
		attributesPanel.add(lblInt);
		
		lblLuck = new JLabel("Luck");
		lblLuck.setBounds(24, 149, 100, 14);
		attributesPanel.add(lblLuck);
		
		lblSpeed = new JLabel("Speed");
		lblSpeed.setBounds(24, 174, 100, 14);
		attributesPanel.add(lblSpeed);
		
		lblStr = new JLabel("Strength");
		lblStr.setBounds(24, 199, 100, 14);
		attributesPanel.add(lblStr);
		
		lblWis = new JLabel("Wisdom");
		lblWis.setBounds(24, 224, 100, 14);
		attributesPanel.add(lblWis);
		
		txtCharisma.setBounds(134, 46, 86, 20);
		attributesPanel.add(txtCharisma);
		txtCharisma.setColumns(10);

		txtConstitution.setBounds(134, 71, 86, 20);
		attributesPanel.add(txtConstitution);
		txtConstitution.setColumns(10);

		txtDexterity.setBounds(134, 96, 86, 20);
		attributesPanel.add(txtDexterity);
		txtDexterity.setColumns(10);

		txtIntelligence.setBounds(134, 121, 86, 20);
		attributesPanel.add(txtIntelligence);
		txtIntelligence.setColumns(10);

		txtLuck.setBounds(134, 146, 86, 20);
		attributesPanel.add(txtLuck);
		txtLuck.setColumns(10);

		txtSpeed.setBounds(134, 171, 86, 20);
		attributesPanel.add(txtSpeed);
		txtSpeed.setColumns(10);

		txtStrength.setBounds(134, 196, 86, 20);
		attributesPanel.add(txtStrength);
		txtStrength.setColumns(10);
		
		txtWisdom.setBounds(134, 221, 86, 20);
		attributesPanel.add(txtWisdom);
		txtWisdom.setColumns(10);
		
		btnAttrNext = new JButton("Next");
		btnAttrNext.addActionListener(new ActionListener() 
		{
			public void actionPerformed(ActionEvent e) 
			{
				updateCharacterAttributes();
				checkHomebrew();
				tabbedPane.setSelectedIndex(2);
			}
		});
		btnAttrNext.setBounds(496, 309, 89, 23);
		attributesPanel.add(btnAttrNext);
	}
	
	private void setupSkillsPanel()
	{
		
	}
	
	private void setupTalentsPanel()
	{
		
	}
	
	private void setupSpellsPanel()
	{
		
	}

	/**
	 * Checks to see if the character is homebrewed or not. If the character is homebrewed, mark the homebrew checkbox.
	 */
	private void checkHomebrew()
	{
		if(character.charisma < 3 || character.charisma > 30 ||
				character.constitution < 3 || character.constitution > 30 ||
				character.dexterity < 3 || character.dexterity > 30 ||
				character.intelligence < 3 || character.intelligence > 30 ||
				character.luck < 3 || character.luck > 30 ||
				character.speed < 3 || character.speed > 30 ||
				character.wisdom < 3 || character.wisdom > 30)
		{
			chkHomebrew.setSelected(true);
		}
	}
}
