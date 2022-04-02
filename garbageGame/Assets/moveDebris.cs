using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDebris : MonoBehaviour
{
    [SerializeField] private GameObject playerRef;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private GameObject managerRef;
    private Rigidbody rbody;
    private bool spin = false;
    private int rotateBy;
    private Vector3 rotationVec;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Debris") // hit another debris
        {
            // splitting func will go here
        } else if (collision.gameObject.tag == "Player") // hit the player!
        {
            managerRef.GetComponent<health>().changeHealth(); // use the change health function on the manager to update the player's health
            Destroy(gameObject); // delete the debris
        } else if (collision.gameObject.tag == "Earth")
        {
            managerRef.GetComponent<health>().changeDestroyed();
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Gun")
        {
            spin = false;
        }
    }

    private void Start()
    {
        // randomly generate the axis of rotation
        int rotationAxis = Random.Range(0, 2); // 0 -> x , 1 -> y , 2 -> z
        if(rotationAxis == 0)
        {
            rotationVec = new Vector3(1,0,0);
        } else if (rotationAxis == 1)
        {
            rotationVec = new Vector3(0, 1, 0);
        } else
        {
            rotationVec = new Vector3(0, 0, 1);
        }
    }
    private void Update()
    {
        if(spin)
        {
            transform.Rotate((rotationVec * (rotateBy * Time.deltaTime)), Space.Self); // rotate on given axis
        }
    }

    public void startMove()
    {
        spin = true;
        rotateBy = Random.Range(15, 120);
        transform.Rotate(new Vector3(Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359)), Space.Self);
        rbody = GetComponent<Rigidbody>(); // get the rigidbody component from the debris instance
        float randForce = Random.Range(minSpeed, maxSpeed); // generate a random amount of force given the preset bounds
        Vector3 relativePos = playerRef.transform.position - gameObject.transform.position; // get current pos of the player, this is the direction force is added in
        rbody.AddForce(randForce * relativePos.normalized); // add the force, normalize the relativePos so randForce applies as a scalar
    }

    

}
