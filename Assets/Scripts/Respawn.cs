using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {



	public Text count;
	public Text HiScore;

	public GameObject ball;
	// Use this for initialization
	void Start () {
		HiScore.text =  PlayerPrefs.GetInt ("highscore",0).ToString ();
	//	Instantiate (ball);
	}

	void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore)
			PlayerPrefs.SetInt("highscore", newHighscore);
	}

	void OnTriggerEnter2D( Collider2D other)
	{
		
		if (other.tag == "Player")
		{
					

			var mynewBall = Instantiate (other.gameObject,new Vector2 (Random.Range(-3.5f, 3.5f), 2),Quaternion.identity);


			//mynewBall.transform.position = new Vector2 (Random.Range(-3.5f, 3.5f), 1);

			Destroy (other.gameObject);


			mynewBall.name = "ball";
		//	DestroyObject (other);

			StoreHighscore (Move.countNo);


				Move.countNo = 0;
				count.text = Move.countNo.ToString ();
			

			HiScore.text = PlayerPrefs.GetInt ("highscore",0).ToString ();

		}



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
