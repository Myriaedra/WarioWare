using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_LaserBeam : MonoBehaviour {
	public Rigidbody rB;
	// Use this for initialization
	void Start () {
		StartCoroutine (Speed ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Speed()
	{
		rB.velocity = -transform.up * 35f;
		yield return new WaitForSecondsRealtime (0.2f);
		rB.velocity = new Vector3 (0, 0, 0);
	}
}
