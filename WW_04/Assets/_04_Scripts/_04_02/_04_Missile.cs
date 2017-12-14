using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_Missile : MonoBehaviour {
	public Rigidbody rB;
	public AnimationCurve launchCurve;
	// Use this for initialization
	void Start () {
		StartCoroutine (Launch ());
		Destroy (gameObject, 7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Launch()
	{
		float t = 0;

		while (rB.velocity.magnitude < 3) 
		{
			float force = launchCurve.Evaluate (t)*3;
			rB.AddForce (transform.up*force);
			t += Time.deltaTime;
			yield return null;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<_04_Satelite> () != null) 
		{
			other.gameObject.GetComponent<_04_Satelite> ().Explodes ();
			Explodes ();
		}
		StartCoroutine(Camera.main.GetComponent<_04_02_GameManager> ().Lose ());
	}

	void Explodes()
	{
		Destroy (gameObject);
	}
}
