using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class conveyor : MonoBehaviour
{
	[SerializeField] private GameObject endPoint;
	[SerializeField] private float currentSpeed;

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Trash Left" || other.tag == "Trash Right") // only move trash
		{
			//other.gameObject.GetComponent<trash>().move = true;
			// get direction of endpoint from cur pos, then apply given speed over time
			other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(endPoint.transform.position.x, endPoint.transform.position.y, endPoint.transform.position.z), currentSpeed * Time.deltaTime);
			//other.transform.position += new Vector3(-currentSpeed * Time.deltaTime, 0, 0);
		}
	}

	//private void OnTriggerExit(Collider other)
	//{
	//	if (other.tag == "Trash Left" || other.tag == "Trash Right") // only move trash
	//	{
	//		other.gameObject.GetComponent<trash>().move = false;
	//	}
	//}

}
