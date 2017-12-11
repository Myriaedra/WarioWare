using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_01_GameManager : MonoBehaviour {
	public _04_Dash playerDash;

	public AudioSource aS;
	public AudioClip victory;
	public AudioClip defeat;

	bool gameEnded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Loose()
	{
		if (!gameEnded) 
		{
			playerDash.StopControl ();
			gameEnded = true;
			aS.PlayOneShot (defeat);
		
			yield return new WaitForSeconds(2);
			//Teacher line
		}
	}

	public IEnumerator Win()
	{
		if (!gameEnded) 
		{
			playerDash.StopControl ();
			gameEnded = true;
			aS.PlayOneShot (victory);
		

			yield return new WaitForSeconds(2);
			//Teacher line
		}
	}
}
