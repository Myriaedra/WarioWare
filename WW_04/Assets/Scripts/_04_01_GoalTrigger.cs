using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_01_GoalTrigger : MonoBehaviour {
	public GameObject blood;

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.GetComponent<_04_Dash>() != null) {
			Debug.Log ("Win");
			StartCoroutine (Camera.main.GetComponent<_04_01_GameManager> ().Win ());

			ParticleSystem tempBlood = Instantiate (blood, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(-90,0,0)).GetComponent<ParticleSystem>();
			var col = tempBlood.collision;
			col.collidesWith  = LayerMask.GetMask ("Default");

			other.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			StartCoroutine (Death());
		}
	}

	IEnumerator Death()
	{
		Debug.Log ("Dying");
		transform.GetComponent<Rigidbody> ().isKinematic = true;
		float rotated = 0f;
		while (rotated <= 69.41f) 
		{
			rotated+=3;
			transform.rotation = Quaternion.Euler(rotated, -133, 0);
			Debug.Log (transform.eulerAngles.x);
			yield return null;
		}

	}
}
