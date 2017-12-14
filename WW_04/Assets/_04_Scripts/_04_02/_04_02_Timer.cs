using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _04_02_Timer : MonoBehaviour {
	public float timeLimit;
	bool end = false;
	public Slider timeBar;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Time.time >= timeLimit && !end) {
			StartCoroutine(Camera.main.GetComponent<_04_02_GameManager> ().Win());
			end = true;
		} 
		else if (!end)
		{
			float remainingTime = timeLimit - Time.time;
			timeBar.value = 1-remainingTime / timeLimit;
		}
	}

	public void End()
	{
		end = true;
	}
}
