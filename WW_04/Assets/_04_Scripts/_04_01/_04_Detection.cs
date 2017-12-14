using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_Detection : MonoBehaviour {
	public Transform startingPoint;
	public Transform endingPoint;
	public float moveSpeed;
	public AnimationCurve moveCurve;

	void Start()
	{
		StartCoroutine (MoveLight ());
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.GetComponent<_04_Dash> () != null) 
		{
			Debug.Log ("VU !");
			StartCoroutine (Camera.main.GetComponent<_04_01_GameManager> ().Loose ());
			other.gameObject.GetComponent<_04_Dash> ().StopControl ();

		}
	}

	IEnumerator MoveLight()
	{
		float t = 0;
		while (t < 1) 
		{
			transform.position = Vector3.Lerp (startingPoint.position, endingPoint.position, moveCurve.Evaluate(t));
			t += moveSpeed*Time.deltaTime;
			yield return null;
		}
		t = 0;
		while (t < 1) 
		{
			transform.position = Vector3.Lerp (endingPoint.position, startingPoint.position, t);
			t += moveSpeed*Time.deltaTime;;
			yield return null;
		}
		StartCoroutine (MoveLight ());
	}
}
