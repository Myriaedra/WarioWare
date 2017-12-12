using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_Detection : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("VU !");
		StartCoroutine(Camera.main.GetComponent<_04_01_GameManager> ().Loose());
		other.gameObject.GetComponent<_04_Dash> ().StopControl ();
	}
}
