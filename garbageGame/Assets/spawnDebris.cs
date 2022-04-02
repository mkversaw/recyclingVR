using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDebris : MonoBehaviour
{

    public bool startSpawn = false; // whether debris spawns
    [SerializeField] private float radiusUpper; // upper bound on distance from the player that debris spawns
    [SerializeField] private float radiusLower; // lower bound on distance from the player that debris spawns
    [SerializeField] private float spawnFrequency; // time in seconds that debris spawns
    [SerializeField] private bool homingDebris; // whether debris should spawn with initial momentum in the player's current direction
    //[SerializeField] private Addressabl
    [SerializeField] private bool debugSpawnZone;
    [SerializeField] private GameObject[] debrisRefs;
    

    // Start is called before the first frame update
    void Start()
    {
        if(startSpawn)
        {
            InvokeRepeating("genDebris", 0.0f, spawnFrequency);
        }
    }

    public void begin(float freq = -1) // for invoking genDebris from outside
    {
        if(freq == -1)
        {
            InvokeRepeating("genDebris", 0.0f, spawnFrequency);
        } else
        {
            InvokeRepeating("genDebris", 0.0f, freq);
        }
    }

    /// <summary>
    /// create new instance of debris within random point between radii bounds, with random initial rotation, parented to this game object
    /// </summary>
    void genDebris()
    {
        if(startSpawn)
        {
            GameObject temp = Instantiate(debrisRefs[Random.Range(0,debrisRefs.Length-1)], transform.position + (Random.Range(radiusLower,radiusUpper) * Random.onUnitSphere), Random.rotation, this.transform);
            if (homingDebris)
            {
                temp.GetComponent<moveDebris>().startMove();
            }
        }
    }

    private void OnDrawGizmos() // used for debugging a nice value for radius
    {
        if (debugSpawnZone)
        {
            Gizmos.color = new Color(255, 0, 0, 0.6f); // red (wont spawn)
            Gizmos.DrawSphere(transform.position, radiusLower);
            Gizmos.color = new Color(0, 255, 0, 0.2f); // green (will spawn)
            Gizmos.DrawSphere(transform.position, radiusUpper);
        }
    }
}
