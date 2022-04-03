using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSite : MonoBehaviour
{
	[SerializeField] private GameObject managerRef;
	[SerializeField] private bool crib = false;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bomb" && !crib)
		{
			managerRef.GetComponent<score>().points += 100; // reward more
			Destroy(other.gameObject);
		} else if (other.tag == "Baby" && crib)
		{
			managerRef.GetComponent<score>().points += 100; // reward more
			Destroy(other.gameObject);
		}
	}
}
