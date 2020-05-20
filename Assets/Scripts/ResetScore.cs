using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetScore : MonoBehaviour {


	public int myscore;
	public Text hiscore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void wheniclick()
	{
		PlayerPrefs.SetInt("highscore", 0);
		myscore = 0;
		hiscore.text = "0";
	//	hiscore = myscore.ToString ();
		int k = 1;
	}
}
