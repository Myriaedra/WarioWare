using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour {
	public Transform selectedTransform;
	public Color selectedOriginColor;
	public GameObject effectPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DoRaycast ();

		if (Input.GetMouseButtonDown (0)) {
			DoRaycastEffect();
		}
	}

	void DoRaycastEffect()
	{
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast (myRay, out hit)) 
		{
			GameObject effectInstance = (GameObject)Instantiate (effectPrefab, hit.point, Quaternion.identity);
			Destroy (effectInstance, 3);
		}
	}

	void DoRaycast()
	{
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		float myRayLength = 100;

		Debug.DrawRay (myRay.origin, myRay.direction * myRayLength, Color.gray);

		RaycastHit hit;

		if (Physics.Raycast (myRay, out hit)) 
		{
			Debug.DrawRay (myRay.origin, myRay.direction * hit.distance, Color.magenta);

			if (selectedTransform != hit.transform) 
			{
				if (selectedTransform != null) {
					selectedTransform.GetComponent<Renderer> ().material.color = selectedOriginColor;
					selectedTransform = null;
				}

				selectedTransform = hit.transform;
				selectedOriginColor = hit.transform.GetComponent<Renderer> ().material.color;
			}

			hit.transform.GetComponent<Renderer> ().material.color = Color.red;

		} 
		else 
		{
			if (selectedTransform != null) {
				selectedTransform.GetComponent<Renderer> ().material.color = selectedOriginColor;
				selectedTransform = null;
			}
		}
	}
}
