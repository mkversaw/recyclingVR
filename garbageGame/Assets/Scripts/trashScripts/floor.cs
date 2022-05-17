using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floor : MonoBehaviour
{
	[SerializeField] private GameObject managerRef;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bomb" || other.tag == "Baby")
		{
			//print(other.gameObject.name + " hit the floor");
			//Destroy(other.gameObject);
			//SceneManager.LoadScene("game over scene");
		} else if (other.tag == "Trash Left" || other.tag == "Trash Right")
		{
			Destroy(other.gameObject);
			managerRef.GetComponent<score>().points -= 10;
			managerRef.GetComponent<spawnTrash>().speedUp();
		}
	}
}
