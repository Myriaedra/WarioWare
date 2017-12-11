using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_01_GoalTrigger : MonoBehaviour {

	void OnCollisionEnter (Collision other)
	{
		Debug.Log("Win");
		StartCoroutine(Camera.main.GetComponent<_04_01_GameManager> ().Win ());
	}
}
