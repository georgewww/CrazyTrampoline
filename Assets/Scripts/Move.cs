using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Move : MonoBehaviour {

	float speed = 37.0f;
	public static int countNo = 0 ;
	public Text count;
	public AudioClip source;
	private Vector2 touchCache;
	private bool touched = false;
	public Rigidbody2D rb;

	void Start () {
		
		//	Instantiate (ball);

	//	count.text = "Score: " + countNo.ToString ();
		source = GetComponent<AudioClip>();
	}

	void Update () 
	{
		//If running game in editor
		#if UNITY_EDITOR
		//If mouse button 0 is down


				var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
				transform.position += move * speed * Time.deltaTime;

		#endif
		//If a touch is detected
	
		if (Input.touchCount >= 1)
			{
				//For each touch
				foreach (var touch in Input.touches)
				{
					//Cache touch position
					touchCache = touch.position;
					//If touch x position is less than or equal to a fraction of the screen width
				var traVectinPix = Camera.main.WorldToScreenPoint(transform.position);
				if (touch.position.x < traVectinPix.x +150 && touch.position.x > traVectinPix.x -150)
					{
					
					transform.position = new Vector2(Camera.main.ScreenToWorldPoint (touch.position).x,transform.position.y);

				}
					
				}
				touched = true;
			}
	

	//	var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
	//	transform.position += move * speed * Time.deltaTime;
	}

	void FixedUpdate()
	{
		if (touched)
		{
			//Transform rackets
		//	player1.transform.position = player1Pos;
		//	player2.transform.position = player2Pos;
			touched = false;
		}
	}

	void OnTriggerEnter2D( Collider2D other)
	{

		if(other.gameObject.tag == "Player")
		countNo++;
		count.text = countNo.ToString ();

		var effector = this.gameObject.GetComponent<BuoyancyEffector2D> ();
		effector.flowAngle = Random.Range (-900, 900);
		effector.flowMagnitude = Random.Range (-50, 50);



		other.GetComponent <AudioSource>().Play ();
	}


}