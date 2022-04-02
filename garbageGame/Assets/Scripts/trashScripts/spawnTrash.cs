using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTrash : MonoBehaviour
{

	[SerializeField] private Transform spawnPos1; // where to spawn
	[SerializeField] private Transform spawnPos2; // where to spawn
	[SerializeField] private GameObject[] trashRefs; // what to spawn

	[SerializeField] private GameObject babyRef;
	[SerializeField] private GameObject bombRef;

	[SerializeField] private float spawnSpeedLower; // in 
	[SerializeField] private float spawnSpeedUpper; // in 
	[SerializeField] private int specialChance = 10; // 1 out of x chance

	public float currentSpeed = 0.3f;

	private IEnumerator coroutine1;
	private IEnumerator coroutine2;

	private void Start()
	{
		coroutine1 = Spawn(1);
		StartCoroutine(coroutine1);
		coroutine2 = Spawn(2);
		StartCoroutine(coroutine2);
	}

	private void speedUp()
	{

	}

	IEnumerator Spawn(int which)
	{
		int randIdx;
		if (which == 1) // left
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(Random.Range(spawnSpeedLower, spawnSpeedUpper)); // only run every (spawnSpeeds) seconds

				randIdx = Random.Range(0, specialChance);
				if(randIdx == 1) // special happened!!!
				{
					randIdx = Random.Range(0, 2);
					if(randIdx == 0) // bomb
					{
						Instantiate(bombRef, spawnPos1.position, Random.rotation); // generate the object at spawnPos 1, with a random rotation
					} else // da baby
					{
						Instantiate(babyRef, spawnPos1.position, Random.rotation); // generate the object at spawnPos 1, with a random rotation
					}
				} else
				{
					randIdx = Random.Range(0, trashRefs.Length); // which trash to spawn
					GameObject temp = Instantiate(trashRefs[randIdx], spawnPos1.position, Random.rotation); // generate the object at spawnPos 1, with a random rotation
					temp.GetComponent<trash>().left = true;
				}
			}
		} else
		{
			while (true) // right
			{
				yield return new WaitForSecondsRealtime(Random.Range(spawnSpeedLower, spawnSpeedUpper)); // only run every (spawnSpeeds) seconds

				randIdx = Random.Range(0, specialChance);
				if (randIdx == 1) // special happened!!!
				{
					randIdx = Random.Range(0, 2);
					if (randIdx == 0) // bomb
					{
						Instantiate(bombRef, spawnPos2.position, Random.rotation); // generate the object at spawnPos 1, with a random rotation
					}
					else // da baby
					{
						Instantiate(babyRef, spawnPos2.position, Random.rotation); // generate the object at spawnPos 1, with a random rotation
					}
				} else
				{
					randIdx = Random.Range(0, trashRefs.Length); // which trash to spawn
					Instantiate(trashRefs[randIdx], spawnPos2.position, Random.rotation); // generate the object at spawnPos 2, with a random rotation
				}
			}
		}
	}
}
