using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {

	string highscore_url = "http://nerdislander.com/apps/conquestking/highscore.php";

	string[] playerData;

	public GUIText score1, score2, score3, score4, score5;

	void Start()
	{
		//Debug.Log ("Starting...");
		StartCoroutine(getHighScores ());
		//Debug.Log ("Finished...");
		
		}
	void Update () {
			if (Input.GetButtonDown ("Jump")) {
					Application.LoadLevel("Scene3");
				}
		}

	IEnumerator getHighScores()
	{
		WWW highReader = new WWW (highscore_url);
		//Debug.Log ("Reader waiting...");
		yield return highReader;

		if (highReader.error != null) {
			 //Debug.Log (highReader.error);
			;
		} else {
			//Debug.Log("Reader returned");
			string highscores = highReader.text;
			//Debug.Log (highscores);
			string[] playerEntries = highscores.Split('\n');

			foreach(string entry in playerEntries)
			{
			    playerData = entry.Split( '-' );
				string playerName = playerData[ 0 ];
				string playerScore =  playerData[ 1 ];
				//Debug.Log(playerName);
				//Debug.Log (playerScore);
				//Debug.Log (playerData[2]);
			}

			score1.text+=" "+ playerData[0] +"     "+ playerData[1];
			score2.text+=" "+ playerData[2] +"     "+ playerData[3];
			score3.text+=" "+ playerData[4] +"     "+ playerData[5];
			score4.text+=" "+ playerData[6] +"     "+ playerData[7];
			score5.text+=" "+ playerData[8] +"     "+ playerData[9];

			
		}

	}

}
