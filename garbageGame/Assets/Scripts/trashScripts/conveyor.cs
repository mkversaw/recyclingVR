using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class conveyor : MonoBehaviour
{
	[SerializeField] private GameObject endPoint;
	[SerializeField] private float currentSpeed;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Trash Left" || other.tag == "Trash Right") // only move trash
		{
			while(true)
			{
				print(other.gameObject.name);
			}
			// get direction of endpoint from cur pos, then apply given speed over time
			//other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(endPoint.transform.position.x, 0, endPoint.transform.position.z), currentSpeed * Time.deltaTime);
			other.transform.position += new Vector3(-currentSpeed * Time.deltaTime, 0, 0);
		}
	}

}
