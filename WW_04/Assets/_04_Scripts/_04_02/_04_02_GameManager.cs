using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_02_GameManager : MonoBehaviour {
	public _04_WaveManager waveMan;
	public _04_Satelite satelite;
	public _04_SatRotation satRotation;
	public _04_02_Timer timerScript;

	public AudioSource aS;
	public AudioClip victory;
	public AudioClip defeat;

	bool gameEnded;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Lose()
	{
		if (!gameEnded) 
		{
			gameEnded = true;
			timerScript.End ();

			waveMan.StopWaves ();
			//aS.PlayOneShot (defeat);
		
			yield return new WaitForSeconds(2);
			//Camera.main.GetComponent<Transition>().Lose();

		}
	}

	public IEnumerator Win()
	{
		if (!gameEnded) 
		{
			gameEnded = true;
			satRotation.StopOrbit ();
			satelite.ShootLaser ();
			//aS.PlayOneShot (victory);
		

			yield return new WaitForSeconds(2);
			//Camera.main.GetComponent<Transition>.Win();
		}
	}
}
