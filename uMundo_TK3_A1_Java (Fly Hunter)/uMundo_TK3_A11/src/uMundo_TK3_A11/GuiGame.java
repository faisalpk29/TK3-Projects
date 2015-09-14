package uMundo_TK3_A11;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *
 * @author Qasim
 */
public class GuiGame {

	/**
	 * Creates new form ClientGUI
	 *
	 */
	// Variables declaration
	public boolean GameStarted = false;
	public JFrame myFrame;
	public javax.swing.JButton jButtonStart;
	public javax.swing.JLabel jLabelCS;
	public javax.swing.JLabel jLabelCurrentScore;
	public javax.swing.JLabel jLabelFly;
	public javax.swing.JLabel jLabelName;
	public javax.swing.JLabel jLabelScore;
	public javax.swing.JList jListScores;
	public javax.swing.JPanel jPanelFly;
	public javax.swing.JPanel jPanelMain;
	public javax.swing.JPanel jPanelScore;
	public javax.swing.JScrollPane jScrollPane1;
	public javax.swing.JTextField jTextFieldName;
	// End of variables declaration

	public CoreGame cGame;

	public GuiGame() {
		try {
			myFrame = new JFrame("!!!Fly Hunting!!!");
			initComponents();
			myFrame.setVisible(true);
		} catch (Exception e) {
		}
	}

	/**
	 * This method is called from within the constructor to initialize the form.
	 */
	@SuppressWarnings("unchecked")
	private void initComponents() {

		jPanelMain = new javax.swing.JPanel();
		jPanelFly = new javax.swing.JPanel();
		jLabelFly = new javax.swing.JLabel();
		jPanelScore = new javax.swing.JPanel();
		jScrollPane1 = new javax.swing.JScrollPane();
		jListScores = new javax.swing.JList();
		jLabelScore = new javax.swing.JLabel();
		jButtonStart = new javax.swing.JButton();
		jLabelName = new javax.swing.JLabel();
		jTextFieldName = new javax.swing.JTextField();
		jLabelCS = new javax.swing.JLabel();
		jLabelCurrentScore = new javax.swing.JLabel();

		myFrame.setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
		myFrame.setMinimumSize(new java.awt.Dimension(524, 560));
		myFrame.addWindowListener(new java.awt.event.WindowAdapter() {
			@Override
			public void windowClosing(java.awt.event.WindowEvent windowEvent) {
				try {
				} catch (Exception ex) {
				} finally {
					myFrame.dispose();
				}
			}
		});

		jPanelMain.setBackground(new java.awt.Color(0, 0, 0));

		jPanelFly.setBackground(new java.awt.Color(255, 255, 255));

		jLabelFly.setIcon(new javax.swing.ImageIcon(getClass().getResource(
				"/Image/fly.jpg"))); // NOI18N
		jLabelFly.addMouseListener(new java.awt.event.MouseAdapter() {
			@Override
			public void mouseClicked(java.awt.event.MouseEvent evt) {
				try {
					jLabelFlyMouseClicked(evt);
				} catch (Exception e) {
				}
			}
		});

		javax.swing.GroupLayout jPanelFlyLayout = new javax.swing.GroupLayout(
				jPanelFly);
		jPanelFly.setLayout(jPanelFlyLayout);
		jPanelFlyLayout.setHorizontalGroup(jPanelFlyLayout.createParallelGroup(
				javax.swing.GroupLayout.Alignment.LEADING).addGroup(
				jPanelFlyLayout.createSequentialGroup().addContainerGap()
						.addComponent(jLabelFly)
						.addContainerGap(336, Short.MAX_VALUE)));
		jPanelFlyLayout.setVerticalGroup(jPanelFlyLayout.createParallelGroup(
				javax.swing.GroupLayout.Alignment.LEADING).addGroup(
				jPanelFlyLayout
						.createSequentialGroup()
						.addContainerGap()
						.addComponent(jLabelFly)
						.addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE,
								Short.MAX_VALUE)));

		jPanelScore.setBackground(new java.awt.Color(255, 255, 255));

		jListScores.setModel(new javax.swing.AbstractListModel() {
			String[] strings = { "........" };

			public int getSize() {
				return strings.length;
			}

			public Object getElementAt(int i) {
				return strings[i];
			}
		});
		jScrollPane1.setViewportView(jListScores);

		jLabelScore.setFont(new java.awt.Font("Tahoma", 1, 14)); // NOI18N
		jLabelScore.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
		jLabelScore.setText("Scores");

		javax.swing.GroupLayout jPanelScoreLayout = new javax.swing.GroupLayout(
				jPanelScore);
		jPanelScore.setLayout(jPanelScoreLayout);
		jPanelScoreLayout
				.setHorizontalGroup(jPanelScoreLayout
						.createParallelGroup(
								javax.swing.GroupLayout.Alignment.LEADING)
						.addGroup(
								jPanelScoreLayout
										.createSequentialGroup()
										.addContainerGap()
										.addGroup(
												jPanelScoreLayout
														.createParallelGroup(
																javax.swing.GroupLayout.Alignment.LEADING)
														.addComponent(
																jScrollPane1,
																javax.swing.GroupLayout.DEFAULT_SIZE,
																91,
																Short.MAX_VALUE)
														.addComponent(
																jLabelScore,
																javax.swing.GroupLayout.DEFAULT_SIZE,
																javax.swing.GroupLayout.DEFAULT_SIZE,
																Short.MAX_VALUE))
										.addContainerGap()));
		jPanelScoreLayout
				.setVerticalGroup(jPanelScoreLayout
						.createParallelGroup(
								javax.swing.GroupLayout.Alignment.LEADING)
						.addGroup(
								javax.swing.GroupLayout.Alignment.TRAILING,
								jPanelScoreLayout
										.createSequentialGroup()
										.addContainerGap()
										.addComponent(
												jLabelScore,
												javax.swing.GroupLayout.PREFERRED_SIZE,
												35,
												javax.swing.GroupLayout.PREFERRED_SIZE)
										.addPreferredGap(
												javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
										.addComponent(
												jScrollPane1,
												javax.swing.GroupLayout.PREFERRED_SIZE,
												294,
												javax.swing.GroupLayout.PREFERRED_SIZE)
										.addContainerGap()));

		javax.swing.GroupLayout jPanelMainLayout = new javax.swing.GroupLayout(
				jPanelMain);
		jPanelMain.setLayout(jPanelMainLayout);
		jPanelMainLayout
				.setHorizontalGroup(jPanelMainLayout
						.createParallelGroup(
								javax.swing.GroupLayout.Alignment.LEADING)
						.addGroup(
								jPanelMainLayout
										.createSequentialGroup()
										.addContainerGap()
										.addComponent(
												jPanelFly,
												javax.swing.GroupLayout.PREFERRED_SIZE,
												javax.swing.GroupLayout.DEFAULT_SIZE,
												javax.swing.GroupLayout.PREFERRED_SIZE)
										.addPreferredGap(
												javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
										.addComponent(
												jPanelScore,
												javax.swing.GroupLayout.DEFAULT_SIZE,
												javax.swing.GroupLayout.DEFAULT_SIZE,
												Short.MAX_VALUE)
										.addContainerGap()));
		jPanelMainLayout
				.setVerticalGroup(jPanelMainLayout
						.createParallelGroup(
								javax.swing.GroupLayout.Alignment.LEADING)
						.addGroup(
								javax.swing.GroupLayout.Alignment.TRAILING,
								jPanelMainLayout
										.createSequentialGroup()
										.addContainerGap()
										.addGroup(
												jPanelMainLayout
														.createParallelGroup(
																javax.swing.GroupLayout.Alignment.TRAILING)
														.addComponent(
																jPanelScore,
																javax.swing.GroupLayout.DEFAULT_SIZE,
																javax.swing.GroupLayout.DEFAULT_SIZE,
																Short.MAX_VALUE)
														.addComponent(
																jPanelFly,
																javax.swing.GroupLayout.DEFAULT_SIZE,
																javax.swing.GroupLayout.DEFAULT_SIZE,
																Short.MAX_VALUE))
										.addContainerGap()));

		jButtonStart.setFont(new java.awt.Font("Tahoma", 1, 18)); // NOI18N
		jButtonStart.setText("Start");
		jButtonStart.addMouseListener(new java.awt.event.MouseAdapter() {
			public void mouseClicked(java.awt.event.MouseEvent evt) {
				jButtonStartMouseClicked(evt);
			}
		});

		jLabelName.setFont(new java.awt.Font("Tahoma", 1, 14)); // NOI18N
		jLabelName.setText("Name: ");

		jTextFieldName.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N

		jLabelCS.setFont(new java.awt.Font("Tahoma", 1, 14)); // NOI18N
		jLabelCS.setText("Score:");

		jLabelCurrentScore.setFont(new java.awt.Font("Tahoma", 1, 18)); // NOI18N
		jLabelCurrentScore.setText("0");

		javax.swing.GroupLayout layout = new javax.swing.GroupLayout(
				myFrame.getContentPane());
		myFrame.getContentPane().setLayout(layout);
		layout.setHorizontalGroup(layout
				.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
				.addGroup(
						layout.createSequentialGroup()
								.addContainerGap()
								.addGroup(
										layout.createParallelGroup(
												javax.swing.GroupLayout.Alignment.LEADING)
												.addComponent(
														jPanelMain,
														javax.swing.GroupLayout.DEFAULT_SIZE,
														javax.swing.GroupLayout.DEFAULT_SIZE,
														Short.MAX_VALUE)
												.addGroup(
														layout.createSequentialGroup()
																.addGroup(
																		layout.createParallelGroup(
																				javax.swing.GroupLayout.Alignment.LEADING)
																				.addGroup(
																						layout.createSequentialGroup()
																								.addComponent(
																										jLabelCS)
																								.addPreferredGap(
																										javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
																								.addComponent(
																										jLabelCurrentScore))
																				.addGroup(
																						layout.createSequentialGroup()
																								.addPreferredGap(
																										javax.swing.LayoutStyle.ComponentPlacement.RELATED)))
																.addPreferredGap(
																		javax.swing.LayoutStyle.ComponentPlacement.RELATED,
																		javax.swing.GroupLayout.DEFAULT_SIZE,
																		Short.MAX_VALUE)
																.addGroup(
																		layout.createParallelGroup(
																				javax.swing.GroupLayout.Alignment.LEADING)
																				.addComponent(
																						jTextFieldName,
																						javax.swing.GroupLayout.PREFERRED_SIZE,
																						150,
																						javax.swing.GroupLayout.PREFERRED_SIZE)
																				.addComponent(
																						jLabelName,
																						javax.swing.GroupLayout.PREFERRED_SIZE,
																						54,
																						javax.swing.GroupLayout.PREFERRED_SIZE))
																.addPreferredGap(
																		javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
																.addComponent(
																		jButtonStart,
																		javax.swing.GroupLayout.PREFERRED_SIZE,
																		119,
																		javax.swing.GroupLayout.PREFERRED_SIZE)))
								.addContainerGap()));
		layout.setVerticalGroup(layout
				.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
				.addGroup(
						layout.createSequentialGroup()
								.addContainerGap()
								.addGroup(
										layout.createParallelGroup(
												javax.swing.GroupLayout.Alignment.LEADING)
												.addGroup(
														layout.createParallelGroup(
																javax.swing.GroupLayout.Alignment.BASELINE)
																.addComponent(
																		jLabelCS)
																.addComponent(
																		jLabelCurrentScore))
												.addGroup(
														layout.createParallelGroup(
																javax.swing.GroupLayout.Alignment.TRAILING,
																false)
																.addComponent(
																		jButtonStart,
																		javax.swing.GroupLayout.PREFERRED_SIZE,
																		47,
																		javax.swing.GroupLayout.PREFERRED_SIZE)
																.addGroup(
																		layout.createSequentialGroup()
																				.addComponent(
																						jLabelName)
																				.addPreferredGap(
																						javax.swing.LayoutStyle.ComponentPlacement.RELATED,
																						javax.swing.GroupLayout.DEFAULT_SIZE,
																						Short.MAX_VALUE)
																				.addGroup(
																						layout.createParallelGroup(
																								javax.swing.GroupLayout.Alignment.BASELINE)
																								.addComponent(
																										jTextFieldName,
																										javax.swing.GroupLayout.PREFERRED_SIZE,
																										javax.swing.GroupLayout.DEFAULT_SIZE,
																										javax.swing.GroupLayout.PREFERRED_SIZE)))))
								.addPreferredGap(
										javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
								.addComponent(jPanelMain,
										javax.swing.GroupLayout.DEFAULT_SIZE,
										javax.swing.GroupLayout.DEFAULT_SIZE,
										Short.MAX_VALUE).addContainerGap()));

		myFrame.pack();
	}

	/**
	 * 
	 * This event is called when the user kills the fly
	 */
	private void jLabelFlyMouseClicked(java.awt.event.MouseEvent evt) {

		// TODO add your handling code here:
		if (GameStarted) {
			cGame.scored();
		} else {
			System.out.println("Please Start the game first.");
		}
	}

	/**
	 * 
	 * This method is called when the User Starts the application
	 */
	private void jButtonStartMouseClicked(java.awt.event.MouseEvent evt) {

		if (!jTextFieldName.getText().equals("")) {
			jTextFieldName.setEditable(false);
			jButtonStart.setText("Started..");
			jButtonStart.setEnabled(false);

			cGame = new CoreGame(jTextFieldName.getText(), this);
			GameStarted = true;
		} else {
			JOptionPane.showMessageDialog(null,
					"Please enter your name and than press Start.", "Alert",
					JOptionPane.ERROR_MESSAGE);
		}
	}

	/**
	 * 
	 * @param x
	 * @param y
	 *            THis method is called to update the location of the bug
	 */
	public void newLocation(int x, int y) {
		jPanelFly.remove(jLabelFly);
		jPanelFly.validate();
		jPanelFly.add(jLabelFly);
		jLabelFly.setLocation(x, y);
		jPanelFly.repaint();
	}

	/**
	 * The Starting point of the Application
	 */
	public static void main(String args[]) {
		try {
			for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager
					.getInstalledLookAndFeels()) {
				if ("Nimbus".equals(info.getName())) {
					javax.swing.UIManager.setLookAndFeel(info.getClassName());
					break;
				}
			}
		} catch (ClassNotFoundException ex) {
			// java.util.logging.Logger.getLogger(ClientGUI.class.getName()).log(java.util.logging.Level.SEVERE,
			// null, ex);
		} catch (InstantiationException ex) {
			// java.util.logging.Logger.getLogger(ClientGUI.class.getName()).log(java.util.logging.Level.SEVERE,
			// null, ex);
		} catch (IllegalAccessException ex) {
			// java.util.logging.Logger.getLogger(ClientGUI.class.getName()).log(java.util.logging.Level.SEVERE,
			// null, ex);
		} catch (javax.swing.UnsupportedLookAndFeelException ex) {
			// java.util.logging.Logger.getLogger(ClientGUI.class.getName()).log(java.util.logging.Level.SEVERE,
			// null, ex);
		}
		new GuiGame();
	}

	/**
	 * 
	 * This funtion is used to update the Score Board
	 */
	public void MakeScoreList(final String[] Players) {
		// Sett all Scores
		jListScores.setModel(new javax.swing.AbstractListModel() {
			String[] stringScore = Players;

			public int getSize() {
				return stringScore.length;
			}

			public Object getElementAt(int i) {
				return stringScore[i];
			}
		});
	}

}
