using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_WaveManager : MonoBehaviour {
	public bool[] firstWave = new bool[20];
	public bool[] secondWave = new bool[20];
	public bool[] thirdWave = new bool[20];
	public bool[] fourthWave = new bool[20];

	public GameObject missile;
	Coroutine program;
	// Use this for initialization
	void Start () {
		program = StartCoroutine (WavesProgramm ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CallWave(bool[] wave)
	{
		for (int i = 0; i < wave.Length; i++) 
		{
			if (wave [i]) 
			{
				Instantiate (missile, transform.position, Quaternion.Euler (0, 0, i * 360 / wave.Length));
			}
		}
	}

	IEnumerator WavesProgramm()
	{
		CallWave (firstWave);
		yield return new WaitForSecondsRealtime(2f);

		CallWave (secondWave);
		yield return new WaitForSecondsRealtime(2f);

		CallWave (thirdWave);
		yield return new WaitForSecondsRealtime(2f);

		CallWave (fourthWave);
	}

	public void StopWaves()
	{
		StopCoroutine (program);
	}
}
