using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _04_01_Timer : MonoBehaviour {
	public float timeLimit;
	bool end = false;
	public Text timeText;
	public Slider timeBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timeLimit && !end) {
			Debug.Log ("Too late");
			StartCoroutine(Camera.main.GetComponent<_04_01_GameManager> ().Loose());
			end = true;
		} 
		else if (!end)
		{
			float remainingTime = timeLimit - Time.time;
			/*timeText.text = remainingTime.ToString("F0") ;*/
			timeBar.value = remainingTime / timeLimit;
		}
	}
}
