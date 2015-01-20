package com.solipstry.charactercreator;

import java.awt.Color;

import javax.swing.BorderFactory;
import javax.swing.JCheckBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.border.EmptyBorder;

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
		//TODO Prompt user to save work before exiting
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 750, 400);
		setResizable(false);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JTabbedPane tabbedPane = new JTabbedPane(JTabbedPane.TOP);
		tabbedPane.setBounds(0, 0, 600, 400);
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
		tabbedPane.addTab("Attributes", null, attributesPanel, "Character attributes");
		tabbedPane.addTab("Skills", null, skillsPanel, "Character skills");
		tabbedPane.addTab("Talents", null, talentsPanel, "Character talents");
		tabbedPane.addTab("Spells", null, spellsPanel, "Character spells");
		
		chkHomebrew = new JCheckBox("Homebrew");
		chkHomebrew.setBounds(600, 341, 97, 23);
		chkHomebrew.setEnabled(false);
		contentPane.add(chkHomebrew);
		
		//TODO Put number and name on same line
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
