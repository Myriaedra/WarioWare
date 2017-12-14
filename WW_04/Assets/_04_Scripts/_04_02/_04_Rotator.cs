using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_Rotator : MonoBehaviour {
	public float angularSpeed;
	public bool yDiff;
	void Start () 
	{
		if (yDiff) {
			transform.localRotation = Quaternion.Euler (-20, 0, 0); 
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!yDiff) {
			transform.localRotation = Quaternion.Euler (0, transform.localEulerAngles.y + angularSpeed, 0); 
		}
	}
}
