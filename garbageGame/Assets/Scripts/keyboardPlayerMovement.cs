using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Elevation");

        Vector3 move_direction = transform.right * x + transform.up * y + transform.forward * z;

        controller.Move(move_direction * speed * Time.deltaTime);
    }
}
