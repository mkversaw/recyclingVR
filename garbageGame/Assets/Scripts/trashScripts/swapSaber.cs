
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapSaber : MonoBehaviour
{
	[SerializeField] private Transform leftTransform;
	[SerializeField] private Transform rightTransform;

	AudioSource source;
	private void Start()
	{
		source = GetComponent<AudioSource>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Trash Left" || other.tag == "Trash Right") // only applies to trash
		{
			source.Play();
			if (other.gameObject.GetComponent<trash>().left) // if object is on left conveyor
			{
				// teleport it to right side
				other.gameObject.GetComponent<trash>().left = false;
				other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, rightTransform.position.z);
			} else // if object is on right conveyor
			{
				// teleport it to left side
				other.gameObject.GetComponent<trash>().left = true;
				other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, leftTransform.position.z);
			}
		}
	}
}
