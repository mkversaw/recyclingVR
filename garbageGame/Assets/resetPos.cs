using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class resetPos : MonoBehaviour
{
    private Vector3[] initialPositions;

    void Start()
    {
        initialPositions = new Vector3[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            initialPositions[i] = transform.GetChild(i).position;
        }
    }

    public void reset()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position = initialPositions[i];
        }
    }
}
