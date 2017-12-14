using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_Satelite : MonoBehaviour {
	public GameObject explosion;
	public GameObject laser;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Explodes()
	{
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	public void ShootLaser()
	{
		Instantiate (laser, transform.position, transform.rotation);
	}
}
