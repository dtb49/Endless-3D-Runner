using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	AudioSource randAudio;
	public AudioSource[] audios;
	public AudioSource dying;
	//AudioSource errorAudio;
	
	void Start() {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;

		//audios = GetComponents<AudioSource>();
		randAudio = audios [Random.Range (0, audios.Length)];
		randAudio.volume = 1.0f;
		randAudio.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!randAudio.isPlaying)
		{
			randAudio = audios [Random.Range (0, audios.Length)];
			randAudio.Play ();
				}

	}

	private void GameStart()
	{
		randAudio.volume = 0.5f;
		dying.Stop ();
		//randAudio.Stop ();
		//audios = GetComponents<AudioSource>();
		//randAudio = audios [Random.Range (0, audios.Length)];
		//randAudio.Play ();
	}

	private void GameOver()
	{
		randAudio.volume = 0.2f;
		//randAudio.Stop ();
		dying.Play ();
		//dying.SetScheduledEndTime (5);

	}
}
