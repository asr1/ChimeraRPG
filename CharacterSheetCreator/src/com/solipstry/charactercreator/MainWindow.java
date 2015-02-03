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
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.JTextField;
import javax.swing.TransferHandler;
import javax.swing.UIManager;
import javax.swing.border.EmptyBorder;

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
		character.charisma = Integer.parseInt(txtCharisma.getText());
		character.constitution = Integer.parseInt(txtConstitution.getText());
		character.dexterity = Integer.parseInt(txtDexterity.getText());
		character.intelligence = Integer.parseInt(txtIntelligence.getText());
		character.luck = Integer.parseInt(txtLuck.getText());
		character.speed = Integer.parseInt(txtSpeed.getText());
		character.wisdom = Integer.parseInt(txtWisdom.getText());
		
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
//		btnAll20.doClick();
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
