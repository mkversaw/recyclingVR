using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class health : MonoBehaviour
{
    [SerializeField] private int healthPoints = 100;
    [SerializeField] private int decreaseBy = 10;
    [SerializeField] private TextMeshProUGUI guiRefHealth;
    [SerializeField] private TextMeshProUGUI guiRefDestroyed;
    private int destroyed = 0;

    private void Start()
    {
        guiRefHealth.text = "Current health: " + healthPoints.ToString(); // initialize health display
        guiRefDestroyed.text = "Current destroyed: " + destroyed.ToString(); // initialize destroyed display
    }
    public void changeHealth()
    {
        healthPoints -= decreaseBy; // decrease the hitpoints
        guiRefHealth.text = "Current health: " + healthPoints.ToString(); // update the health display
    }
    
    public void changeDestroyed()
    {
        destroyed++;
        guiRefDestroyed.text = "Current destroyed: " + destroyed.ToString(); // update the health display
    }
}
