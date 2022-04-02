using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crib : MonoBehaviour
{
	[SerializeField] private GameObject managerRef;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Baby")
		{
			managerRef.GetComponent<score>().points += 100; // reward more
			Destroy(other.gameObject);
		}
	}
}
