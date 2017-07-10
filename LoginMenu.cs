using UnityEngine;
using System.Collections;

public class LoginMenu : MonoBehaviour {

	string loginURL = "http://nerdislander.com/apps/conquestking/login.php";
	string registerURL = "http://nerdislander.com/apps/conquestking/register.php";
	string getscoreurl = "http://nerdislander.com/apps/conquestking/getscore.php";

	public static string userName = "";
	public static string passWord = "";
	string problem = "";

	void OnGUI()
	{
		GUI.Window (0, new Rect (Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), LoginWindow, "Login");
	}

	//create GUI
	void LoginWindow(int windowID) 
	{
		//GUI.Label (new Rect (140, 40, 130, 100), "    Username    ");
		GUI.Label (new Rect (210, 40, 130, 100), "    Username    ");
		userName = GUI.TextField (new Rect (65, 60, 375, 30), userName);

		GUI.Label (new Rect (210, 92, 130, 100), "    Password    ");
		passWord = GUI.PasswordField (new Rect (65, 112, 375, 30), passWord, "*"[0]);

		if (GUI.Button (new Rect (65, 160, 175, 50), "Login"))
						StartCoroutine (handleLogin (userName, passWord));
			//StartCoroutine (getHighScore (userName, passWord, 10));

		if (GUI.Button (new Rect (265, 160, 175, 50), "Register"))
			StartCoroutine (handleRegister (userName, passWord));

		GUI.Label (new Rect (85, 222, 250, 100), problem);
	}

	//if login button is pressed
	IEnumerator handleLogin(string userNamez, string passWordz)
	{
		problem = "Checking username and password. . .";
		string login_URL = loginURL + "?username=" + userNamez + "&password=" + passWordz;
		WWW loginReader = new WWW (login_URL);
		yield return loginReader;

		if (loginReader.error != null) {
						problem = "Could not locate page";
				} else {
			if(loginReader.text == "right")
			{
				problem = "Logged in";
				//play the game
				Application.LoadLevel("Scene3");
			}else{
				problem = "Invalid username/password.";
			}
				}
	}

	//if register button is pressed
	IEnumerator handleRegister(string userNamez, string passWordz)
	{
		problem = "Checking username and password. . .";
		string register_URL = registerURL + "?username=" + userNamez + "&password=" + passWordz;
		WWW registerReader = new WWW (register_URL);
		yield return registerReader;
		
		if (registerReader.error != null) {
			problem = "Could not locate page";
		} else {
			if(registerReader.text == "registered")
			{
				problem = "Registered!";
			}else{
				problem = "invalid user/pass";
			}
		}
	}



	/*IEnumerator getHighScore(string userNamez, string passWordz, float currentscore)
	{
		string getscore_url = getscoreurl + "?username=" + userNamez + "&password=" + passWordz;
		WWW scoreReader = new WWW (getscore_url);
		yield return scoreReader;
		
		if (scoreReader.error != null) {
			problem = "Could not locate page";
		} else {
			//string dbscore = scoreReader.text;
			problem = scoreReader.text;
			//float highscore = int.Parse(dbscore);
			//if(currentscore > highscore)
			//{
			//	problem += highscore;
				
				//updateHighScore(userNamez,passWordz,currentscore);
			//}else{
				//if not better score do nothing
			//	;
			//}
		}
	}*/
}
