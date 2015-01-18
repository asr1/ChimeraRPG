package com.solipstry.charactercreator;

import javax.swing.JCheckBox;
import javax.swing.JComponent;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.border.EmptyBorder;
import javax.swing.JButton;
import javax.swing.JLabel;

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
		setBounds(100, 100, 700, 400);
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
		
		JLabel lblHpName = new JLabel("HP");
		lblHpName.setBounds(603, 11, 46, 14);
		contentPane.add(lblHpName);
		
		lblHp = new JLabel("0");
		lblHp.setBounds(603, 25, 46, 14);
		contentPane.add(lblHp);
		
		
	}	
}
