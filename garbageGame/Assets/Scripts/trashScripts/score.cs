using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score : MonoBehaviour
{
    public int points;
    [SerializeField] private TextMeshProUGUI guiRef;
    private void Start()
    {
        guiRef.text = "Current points: " + points.ToString(); // initialize points display
    }

    private void Update()
    {
        guiRef.text = "Current points: " + points.ToString(); // update points display
    }
}
