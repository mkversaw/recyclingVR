using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSite : MonoBehaviour
{
	[SerializeField] private GameObject managerRef;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bomb")
		{
			managerRef.GetComponent<score>().points += 100; // reward more
			Destroy(other.gameObject);
		}
	}
}
