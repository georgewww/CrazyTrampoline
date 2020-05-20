using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class MyStart : MonoBehaviour {

	public Text score;

	Vector2 initX;
	//Vector2 initBall;
	public GameObject panel;

	void Start()
	{
		
		initX = GameObject.FindGameObjectWithTag ("tra").GetComponent<Transform> ().position;
	//	initBall = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ().position;
	}

	// Update is called once per frame
	void Update () {
		
	}


	public void Clicked()
	{
		if (int.Parse (Time.timeScale.ToString ()) == 0) {
			
			Time.timeScale = 1;
			// Resume the game
			Move.countNo = 0;
			score.text = Move.countNo.ToString ();
			GameObject.FindGameObjectWithTag ("tra").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

			//GameObject.FindGameObjectWithTag ("tra").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
			//GameObject.FindGameObjectWithTag ("tra").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;

			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource>().Stop ();
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ().Play ();
			GameObject.FindGameObjectWithTag ("button").GetComponent<Image> ().sprite = Resources.Load <Sprite> ("pause");

			GameObject.FindGameObjectWithTag ("tra").GetComponent<Transform> ().position = initX;

			var mynewBall = Instantiate (GameObject.FindGameObjectWithTag ("Player").gameObject,new Vector2 (Random.Range(-3.5f, 3.5f), 2),Quaternion.identity);


			//mynewBall.transform.position = new Vector2 (Random.Range(-3.5f, 3.5f), 1);

			Destroy (GameObject.FindGameObjectWithTag ("Player").gameObject);


			mynewBall.name = "ball";

		//	GameObject.FindGameObjectWithTag ("panel1").GetComponent<SpriteRenderer> ().sortingOrder = -10;
			panel.SetActive (false);
			// Any other logic

		}

}
}
