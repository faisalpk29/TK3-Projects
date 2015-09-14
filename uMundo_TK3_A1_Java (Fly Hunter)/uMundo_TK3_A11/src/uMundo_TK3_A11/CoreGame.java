package uMundo_TK3_A11;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Random;

import org.umundo.core.*;
import org.umundo.core.Discovery.DiscoveryType;

public class CoreGame {

	public Discovery disc;
	public Node gameNode;
	public Subscriber gameSub;
	public Publisher gamePub;

	public GuiGame guiObj;

	public String transData;
	public String uName;
	public HashMap<String, String> participants = new HashMap<String, String>();
	public BufferedReader reader = new BufferedReader(new InputStreamReader(
			System.in));

	public FlyHuntMessage players = new FlyHuntMessage();

	/**
	 * Initializing all the components
	 * 
	 * @param uName
	 * @param Gobj
	 */
	public CoreGame(String uName, GuiGame Gobj) {

		players.PlayerName = uName;
		players.Names.add(players.PlayerName);
		players.Scores.add("0");

		this.uName = uName;
		this.guiObj = Gobj;
		disc = new Discovery(DiscoveryType.MDNS);

		gameNode = new Node();
		gameSub = new Subscriber("coreGame"); // The group is named "coreGame"
												// for the user to subscribe
		gameSub.setReceiver(new GameReceiver());

		gamePub = new Publisher("coreGame"); // The publisher group

		disc.add(gameNode);

		gamePub.setGreeter(new GameGreeter());
		gameNode.addPublisher(gamePub);
		gameNode.addSubscriber(gameSub);

		guiObj.newLocation(50, 50);
	}

	class GameReceiver extends Receiver {

		/**
		 * This method is called when ever the message received from the
		 * subscribed group is received
		 */
		@Override
		public void receive(Message msg) {
			if (msg.getMeta().containsKey("participant")) { // When new user
															// arrives this
															// condition is true
				CoreGame.this.participants.put(msg.getMeta("subscriber"),
						msg.getMeta("participant"));

				players.Names.add(msg.getMeta("participant").split(";")[0]);
				players.Scores.add(msg.getMeta("participant").split(";")[1]);

				updateScoreLocal();
			} else { // Called when someone else scores before you
				addScore((msg.getMeta("userName")));
				guiObj.newLocation(Integer.parseInt(msg.getMeta("xPos")),
						Integer.parseInt(msg.getMeta("yPos")));
				updateScoreLocal();
			}
		}
	}

	class GameGreeter extends Greeter {

		/**
		 * Whenever user joins the game the welcome message is published to all the current users containing your information
		 */
		@Override
		public void welcome(Publisher pub, SubscriberStub subStub) {
			Message greeting = Message.toSubscriber(subStub.getUUID());
			greeting.putMeta(
					"participant",
					players.PlayerName
							+ ";"
							+ players.Scores.get(players.Names
									.indexOf(players.PlayerName)));
			greeting.putMeta("subscriber", CoreGame.this.gameSub.getUUID());
			pub.send(greeting);
		}

		/**
		 * Whenever users leave a Farewell message is send to all the users so that they know that you have left
		 */
		@Override
		public void farewell(Publisher pub, SubscriberStub subStub) {
			if (CoreGame.this.participants.containsKey(subStub.getUUID())) {

				String leftUser = CoreGame.this.participants.get(subStub
						.getUUID());
				int index = players.Names.indexOf(leftUser.split(";")[0]);

				// Deleting the User from the current list
				players.Scores.remove(index);
				players.Names.remove(index);
				CoreGame.this.participants.remove(subStub.getUUID());
				updateScoreLocal();
			}
		}
	}

	/**
	 * When ever you score, all users are notified byt message and new location are send along for the bug
	 */
	public void scored() {

		broadCastNewLocation();
		addScore(players.PlayerName);
		updateScoreLocal();
		scoredMessage();
	}

	/**
	 * Message regarding you new score is send
	 */
	public void scoredMessage() {
		Message msg = new Message();
		msg.putMeta("userName", players.PlayerName);
		msg.putMeta("newScore",
				players.Scores.get(players.Names.indexOf(players.PlayerName)));
		msg.putMeta("xPos", String.valueOf(players.xPos));
		msg.putMeta("yPos", String.valueOf(players.yPos));
		gamePub.send(msg);
	}
	
	/**
	 * Local scorecard is updated
	 */
	public void updateScoreLocal() {
		guiObj.jLabelCurrentScore.setText(players.Scores.get(players.Names
				.indexOf(players.PlayerName)));
		String[] disScores = new String[players.Names.size()];
		for (int i = 0; i < players.Names.size(); i++) {
			disScores[i] = players.Names.get(i) + " ----> "
					+ players.Scores.get(i);
		}
		guiObj.MakeScoreList(disScores);
	}

	/**
	 * 
	 * Helper function to add score to a particular user
	 */
	public void addScore(String updateName) {
		int newScore = Integer.parseInt(players.Scores.get(players.Names
				.indexOf(updateName))) + 1;
		players.Scores.set(players.Names.indexOf(updateName), newScore + "");

	}

	/**
	 * Calculate the new random location of the bugs and share
	 */
	public void broadCastNewLocation() {
		int min = 0;
		int max = 280;
		Random rand = new Random();
		players.xPos = rand.nextInt((max - min) + 1) + min;
		players.yPos = rand.nextInt((max - min) + 1) + min;
		guiObj.newLocation(players.xPos, players.yPos);
	}

}
