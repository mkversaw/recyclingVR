using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTrash : MonoBehaviour
{

	[SerializeField] private Transform spawnPos1; // where to spawn
	[SerializeField] private Transform spawnPos2; // where to spawn
	[SerializeField] private GameObject[] trashRefs; // what to spawn
	[SerializeField] private float spawnSpeedLower; // in 
	[SerializeField] private float spawnSpeedUpper; // in 

	private IEnumerator coroutine1;
	private IEnumerator coroutine2;

	private void Start()
	{
		coroutine1 = Spawn(1);
		StartCoroutine(coroutine1);
		coroutine2 = Spawn(2);
		StartCoroutine(coroutine2);
	}

	IEnumerator Spawn(int which)
	{
		int randIdx;
		if (which == 1) // left
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(Random.Range(spawnSpeedLower, spawnSpeedUpper)); // only run every (spawnSpeeds) seconds
				randIdx = Random.Range(0, trashRefs.Length); // which trash to spawn
				GameObject temp = Instantiate(trashRefs[randIdx], spawnPos1.position, Random.rotation); // generate the object at spawnPos 1, with a random rotation
				temp.GetComponent<trash>().left = true;
			}
		} else
		{
			while (true) // right
			{
				yield return new WaitForSecondsRealtime(Random.Range(spawnSpeedLower, spawnSpeedUpper)); // only run every (spawnSpeeds) seconds
				randIdx = Random.Range(0, trashRefs.Length); // which trash to spawn
				Instantiate(trashRefs[randIdx], spawnPos2.position, Random.rotation); // generate the object at spawnPos 2, with a random rotation
			}
		}
	}
}
