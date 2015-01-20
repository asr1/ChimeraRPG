package com.solipstry.charactercreator;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JCheckBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;

public class MainWindow extends JFrame
{
	private JPanel contentPane;
	
	//Shows whether the user is creating a homebrewed character
	private JCheckBox chkHomebrew;

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
	private JTextField txtAttribute1;
	private JTextField txtAttribute2;
	private JTextField txtAttribute3;
	private JTextField txtAttribute4;
	private JTextField txtAttribute5;
	private JTextField txtAttribute6;
	private JTextField txtAttribute7;
	private JTextField txtAttribute8;
	
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
		
		JTabbedPane tabbedPane = new JTabbedPane(JTabbedPane.TOP);
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
		
		tabbedPane.addTab("Details", null, detailsPanel, "Character details");
		
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
		
		tabbedPane.addTab("Attributes", null, attributesPanel, "Character attributes");
		
		JButton btnAll20 = new JButton("All 20");
		btnAll20.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				txtAttribute1.setVisible(true);
				txtAttribute2.setVisible(true);
				txtAttribute3.setVisible(true);
				txtAttribute4.setVisible(true);
				txtAttribute5.setVisible(true);
				txtAttribute6.setVisible(true);
				txtAttribute7.setVisible(true);
				txtAttribute8.setVisible(true);
				
				txtAttribute1.setText("20");
				txtAttribute2.setText("20");
				txtAttribute3.setText("20");
				txtAttribute4.setText("20");
				txtAttribute5.setText("20");
				txtAttribute6.setText("20");
				txtAttribute7.setText("20");
				txtAttribute8.setText("20");
				
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
		btnAll20.setBounds(427, 11, 158, 23);
		attributesPanel.add(btnAll20);
		
		JButton btnOption1 = new JButton("30 30 20 20 20 20 10 10");
		btnOption1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				txtAttribute1.setVisible(true);
				txtAttribute2.setVisible(true);
				txtAttribute3.setVisible(true);
				txtAttribute4.setVisible(true);
				txtAttribute5.setVisible(true);
				txtAttribute6.setVisible(true);
				txtAttribute7.setVisible(true);
				txtAttribute8.setVisible(true);
				
				txtAttribute1.setText("30");
				txtAttribute2.setText("30");
				txtAttribute3.setText("20");
				txtAttribute4.setText("20");
				txtAttribute5.setText("20");
				txtAttribute6.setText("20");
				txtAttribute7.setText("10");
				txtAttribute8.setText("10");
				
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
		btnOption1.setBounds(427, 45, 158, 23);
		attributesPanel.add(btnOption1);
		
		JButton btnOption2 = new JButton("30 30 30 20 20 10 10 10");
		btnOption2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				txtAttribute1.setVisible(true);
				txtAttribute2.setVisible(true);
				txtAttribute3.setVisible(true);
				txtAttribute4.setVisible(true);
				txtAttribute5.setVisible(true);
				txtAttribute6.setVisible(true);
				txtAttribute7.setVisible(true);
				txtAttribute8.setVisible(true);
				
				txtAttribute1.setText("30");
				txtAttribute2.setText("30");
				txtAttribute3.setText("30");
				txtAttribute4.setText("20");
				txtAttribute5.setText("20");
				txtAttribute6.setText("10");
				txtAttribute7.setText("10");
				txtAttribute8.setText("10");
				
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
		btnOption2.setBounds(427, 79, 158, 23);
		attributesPanel.add(btnOption2);
		
		JButton btnRolled = new JButton("I rolled my attributes");
		btnRolled.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				txtAttribute1.setVisible(false);
				txtAttribute2.setVisible(false);
				txtAttribute3.setVisible(false);
				txtAttribute4.setVisible(false);
				txtAttribute5.setVisible(false);
				txtAttribute6.setVisible(false);
				txtAttribute7.setVisible(false);
				txtAttribute8.setVisible(false);
				
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
		btnRolled.setBounds(427, 113, 158, 23);
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
		
		txtCharisma = new JTextField();
		txtCharisma.setBounds(134, 46, 86, 20);
		attributesPanel.add(txtCharisma);
		txtCharisma.setColumns(10);
		txtCharisma.getDocument().addDocumentListener(new DocumentListener()
		{
			public void changedUpdate(DocumentEvent e)
			{
				//TODO Update skills, etc
			}
			
			public void removeUpdate(DocumentEvent e) {}
			public void insertUpdate(DocumentEvent e) {}
		});
		
		txtConstitution = new JTextField();
		txtConstitution.setBounds(134, 71, 86, 20);
		attributesPanel.add(txtConstitution);
		txtConstitution.setColumns(10);
		txtConstitution.getDocument().addDocumentListener(new DocumentListener()
		{
			public void changedUpdate(DocumentEvent e)
			{
				//TODO Update skills, etc
				lblHp.setText(Integer.toString((int) Math.floor(1.5 * Integer.parseInt(txtConstitution.getText()))));
			}
			
			public void removeUpdate(DocumentEvent e) {}
			public void insertUpdate(DocumentEvent e) {}
		});
		
		txtDexterity = new JTextField();
		txtDexterity.setBounds(134, 96, 86, 20);
		attributesPanel.add(txtDexterity);
		txtDexterity.setColumns(10);
		
		txtIntelligence = new JTextField();
		txtIntelligence.setBounds(134, 121, 86, 20);
		attributesPanel.add(txtIntelligence);
		txtIntelligence.setColumns(10);
		
		txtLuck = new JTextField();
		txtLuck.setBounds(134, 146, 86, 20);
		attributesPanel.add(txtLuck);
		txtLuck.setColumns(10);
		
		txtSpeed = new JTextField();
		txtSpeed.setBounds(134, 171, 86, 20);
		attributesPanel.add(txtSpeed);
		txtSpeed.setColumns(10);
		
		txtStrength = new JTextField();
		txtStrength.setBounds(134, 196, 86, 20);
		attributesPanel.add(txtStrength);
		txtStrength.setColumns(10);
		
		txtWisdom = new JTextField();
		txtWisdom.setBounds(134, 221, 86, 20);
		attributesPanel.add(txtWisdom);
		txtWisdom.setColumns(10);
		
		txtAttribute1 = new JTextField();
		txtAttribute1.setBounds(304, 46, 86, 20);
		attributesPanel.add(txtAttribute1);
		txtAttribute1.setColumns(10);
		txtAttribute1.setDragEnabled(true);
		
		txtAttribute2 = new JTextField();
		txtAttribute2.setBounds(304, 71, 86, 20);
		attributesPanel.add(txtAttribute2);
		txtAttribute2.setColumns(10);
		txtAttribute2.setDragEnabled(true);
		
		txtAttribute3 = new JTextField();
		txtAttribute3.setBounds(304, 96, 86, 20);
		attributesPanel.add(txtAttribute3);
		txtAttribute3.setColumns(10);
		txtAttribute3.setDragEnabled(true);
		
		txtAttribute4 = new JTextField();
		txtAttribute4.setBounds(304, 121, 86, 20);
		attributesPanel.add(txtAttribute4);
		txtAttribute4.setColumns(10);
		txtAttribute4.setDragEnabled(true);
		
		txtAttribute5 = new JTextField();
		txtAttribute5.setBounds(304, 146, 86, 20);
		attributesPanel.add(txtAttribute5);
		txtAttribute5.setColumns(10);
		txtAttribute5.setDragEnabled(true);
		
		txtAttribute6 = new JTextField();
		txtAttribute6.setBounds(304, 171, 86, 20);
		attributesPanel.add(txtAttribute6);
		txtAttribute6.setColumns(10);
		txtAttribute6.setDragEnabled(true);
		
		txtAttribute7 = new JTextField();
		txtAttribute7.setBounds(304, 196, 86, 20);
		attributesPanel.add(txtAttribute7);
		txtAttribute7.setColumns(10);
		txtAttribute7.setDragEnabled(true);
		
		txtAttribute8 = new JTextField();
		txtAttribute8.setBounds(304, 221, 86, 20);
		attributesPanel.add(txtAttribute8);
		txtAttribute8.setColumns(10);
		txtAttribute8.setDragEnabled(true);
		
		tabbedPane.addTab("Skills", null, skillsPanel, "Character skills");
		tabbedPane.addTab("Talents", null, talentsPanel, "Character talents");
		tabbedPane.addTab("Spells", null, spellsPanel, "Character spells");
		
		chkHomebrew = new JCheckBox("Homebrew");
		chkHomebrew.setBounds(600, 341, 97, 23);
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
		
		JLabel lblFortuneName = new JLabel("Fortune Points");
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
}
