using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTrash : MonoBehaviour
{
	[SerializeField] private bool left;
	[SerializeField] private GameObject managerRef;
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Trash Left")
		{
			if(left)
			{
				managerRef.GetComponent<score>().points += 10;
				Destroy(other.gameObject);
			} else // BAD!!!!
			{
				managerRef.GetComponent<score>().points -= 10;
				Destroy(other.gameObject);
			}

		} else if(other.tag == "Trash Right")
		{
			if(left) // BAD!!!!
			{
				managerRef.GetComponent<score>().points -= 10;
				Destroy(other.gameObject);
			} else
			{
				managerRef.GetComponent<score>().points += 10;
				Destroy(other.gameObject);
			}
		}
	}

	private void Start()
	{
		// DELETE THIS (TESTING)
		managerRef.GetComponent<score>().points += 70;
	}
}
