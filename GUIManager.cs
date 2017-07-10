using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public GUIText gameOverText, instructionsText, runnerText, distanceText, cointText;
	public GUIText logoutText, highscoreText, arrowText, sprintText;

	private int zero = 0;

	private static GUIManager instance;

	string getscoreurl = "http://nerdislander.com/apps/conquestking/getscore.php";
	string updatescoreurl = "http://nerdislander.com/apps/conquestking/updatescore.php";

	void Start () {
		instance = this;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;
		highscoreText.enabled = false;


	}
	
	void Update () {
		if(Input.GetButtonDown("Jump")){
			GameEventManager.TriggerGameStart();
		}

		if (Input.GetButtonDown ("Logout")) {
			Application.LoadLevel("login");
				}
		if (Input.GetButtonDown ("Highscore")) {
			Application.LoadLevel("highscore");		
		}

	}

	private void GameStart () {
		gameOverText.enabled = false;
		instructionsText.enabled = false;
		arrowText.enabled = false;
		sprintText.enabled = false;
		runnerText.enabled = false;
		logoutText.enabled = false;
		highscoreText.enabled = false;
		enabled = false;
		instance.cointText.text = zero.ToString ();
	}

	private void GameOver () {
		gameOverText.enabled = true;
		instructionsText.enabled = true;
		arrowText.enabled = true;
		sprintText.enabled = true;
		highscoreText.enabled = true;
		logoutText.enabled = true;
		enabled = true;
		int score = (int)PlayerController.distanceTraveled;
		StartCoroutine (getHighScore (LoginMenu.userName, LoginMenu.passWord, score));

	}

	public static void SetDistance(float distance)
	{
		instance.distanceText.text = distance.ToString("f0");
	}

	public static void Coins(int coin)
	{
		instance.cointText.text = coin.ToString ("f0");
	}

	IEnumerator getHighScore(string userNamez, string passWordz, int currentscore)
	{
		string getscore_url = getscoreurl + "?username=" + userNamez + "&password=" + passWordz + "&highscore=" + currentscore;
		WWW scoreReader = new WWW (getscore_url);
		yield return scoreReader;

		if (scoreReader.error != null) {
						highscoreText.text = "Could not locate page";
				} else {
					string dbscore = scoreReader.text;
					
					
					highscoreText.text = "Highscore: " + dbscore;
					
				}
	}


}
