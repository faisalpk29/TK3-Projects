using org.umundo.core;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FlyHunter
{
	public partial class Form2 : Form
	{
		#region Globals
		Random randomeGenerator;
		Publisher pub;
		delegate void UpdateScoreBoardCallback();
		private Thread mainThread;
		#endregion

		public Form2()
		{
			InitializeComponent();

			#region Initialization of variables and values
			panelMain.Enabled = false;
			randomeGenerator = new Random();
			lblScore.Text = Globals.Score.ToString();
			#endregion

			#region Events Callbacks
			imgFly.Click += OnFlyClick;
			#endregion
		}

		/// <summary>
		/// Called when you tap/click on Fly.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		void OnFlyClick(object sender, EventArgs e)
		{
			lblScore.Text = (++Globals.Score).ToString(); //Increase my own score by one
			RelocateFly(); //Relocate the fly to some new(random) position
		}

		/// <summary>
		/// Prepare/Send the message to broadcast(publish).
		/// </summary>
		private void BroadcastMessageSend()
		{
			org.umundo.core.Message msg = new org.umundo.core.Message();

			msg.putMeta("userName", Globals.Username);
			msg.putMeta("newScore", Globals.Score.ToString());
			msg.putMeta("xPos", Globals.Players.xPos.ToString());
			msg.putMeta("yPos", Globals.Players.yPos.ToString());

			pub.send(msg);
		}

		/// <summary>
		/// Relocates the fly to (x,y) position, ensuring that it will not exceeds the screen limit.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		public void RelocateFly(int x, int y)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new FlyHunterReceiver.RelocateFlyDelegate(RelocateFly), x, y);
			}
			else
			{
				//Can avoid this code (Just to make sure that the relocation is not out of box :) )
				int max_x = panelMain.Size.Width - imgFly.Size.Width;
				int max_y = panelMain.Size.Height - imgFly.Size.Height;

				x = x < 0 ? 0 : (x > max_x ? max_x : x);
				y = y < 0 ? 0 : (y > max_y ? max_y : y);

				imgFly.Location = new Point(x, y);
			}
		}

		/// <summary>
		/// Relocates the fly to a random position.
		/// </summary>
		public void RelocateFly()
		{
			Globals.Players.xPos = randomeGenerator.Next(panelMain.Size.Width);
			Globals.Players.yPos = randomeGenerator.Next(panelMain.Size.Height);

			//Add the current user's score, refresh the score board and relocate the fly to new position
			Helper.AddScore(Globals.Username);
			UpdateScoreBoard();
			RelocateFly(Globals.Players.xPos, Globals.Players.yPos);

			//Tells everyone about the new position and scores
			BroadcastMessageSend();
		}

		/// <summary>
		/// Handles the Click event of the Login control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void btnLogin_Click(object sender, EventArgs e)
		{
			Globals.Username = txtName.Text;
			//If the user leaves the name empty show some error message
			if (String.IsNullOrWhiteSpace(Globals.Username))
			{
				MessageBox.Show("Please enter a valid username");
				return;
			}

			//Lock the text area and login button for further editing
			txtName.Enabled = false;
			btnLogin.Enabled = false;

			#region Initialize uMundo
			org.umundo.core.Node node = new org.umundo.core.Node();
			org.umundo.core.Discovery disc = new org.umundo.core.Discovery(Discovery.DiscoveryType.MDNS);
			disc.add(node);

			pub = new Publisher("coreGame");
			FlyHunterGreeter greeter = new FlyHunterGreeter(Globals.Username);
			greeter.UpdateScoreLocal += new FlyHunterGreeter.UpdateScoreLocalDelegate(UpdateScoreBoard);
			pub.setGreeter(greeter);
			FlyHunterReceiver recv = new FlyHunterReceiver();
			Globals.Players = new FlyHuntMessage();
			Globals.Players.Names.Add(Globals.Username);
			Globals.Players.Scores.Add("0");
			recv.UpdateScoreLocal += new FlyHunterReceiver.UpdateScoreLocalDelegate(UpdateScoreBoard);
			recv.RelocateFly += new FlyHunterReceiver.RelocateFlyDelegate(RelocateFly);

			Globals.sub = new Subscriber("coreGame");
			Globals.sub.setReceiver(recv);
			node.addPublisher(pub);
			node.addSubscriber(Globals.sub);
			#endregion

			//Enable the main panel where fly appears
			panelMain.Enabled = true;
		}

		/// <summary>
		/// Updates the score board.
		/// </summary>
		void UpdateScoreBoard()
		{
			if (this.listAllUsers.InvokeRequired)
			{
				UpdateScoreBoardCallback d = new UpdateScoreBoardCallback(UpdateScoreBoard);
				this.Invoke(d);
			}
			else
			{
				//Clears the current score board and list the new one
				listAllUsers.Items.Clear();

				for (int i = 0; i < Globals.Players.Names.Count; i++)
				{
					listAllUsers.Items.Add(new ListViewItem(new[] { Globals.Players.Names[i], Globals.Players.Scores[i] }));
				}

			}
		}
	}
}
