using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Button : MonoBehaviour
{
	// Has the game been paused?
	private bool isPaused;
	// Has the game gone through it's pause transition?
	private bool hasPaused = false;
	Sprite myStart;
	Sprite myPause;
	public GameObject panel;

	public void Start()
	{
		panel.SetActive (true);
		myStart = Resources.Load <Sprite> ("start");
		 myPause = Resources.Load <Sprite> ("pause");
		// Default to not paused.
		this.isPaused = false;
		pauseGame ();
	}

	public void Clicked()
	{    
		
			// And nothing has initialized
		if(int.Parse (Time.timeScale.ToString ()) == 1) {
				// Pause the game
				this.pauseGame();
				this.hasPaused = true;
		}else if(int.Parse (Time.timeScale.ToString ()) == 0 ) {
				this.resumeGame();
				this.hasPaused = false;

		}
	}

	public void pauseGame()
	{
		// Pause the game

		var tra = GameObject.FindGameObjectWithTag ("tra");
		var rigidBody2D = tra.GetComponent<Rigidbody2D> ();
		rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource>().Pause ();
		GameObject.FindGameObjectWithTag ("button").GetComponent<Image> ().sprite = myStart;

		panel.SetActive (true);

		Time.timeScale = 0;
		// Any other logic
	}

	public void resumeGame()
	{
		// Resume the game
		Time.timeScale = 1;
		panel.SetActive (false);

		GameObject.FindGameObjectWithTag ("tra").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

		//GameObject.FindGameObjectWithTag ("tra").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
		//GameObject.FindGameObjectWithTag ("tra").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;

		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource>().UnPause();
		GameObject.FindGameObjectWithTag ("button").GetComponent<Image> ().sprite = myPause;
		// Any other logic
	}

	public void changePauseState()
	{
		// Alternate bool value per button click
		this.isPaused = !this.isPaused;
	}
}