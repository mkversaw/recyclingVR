using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLookCamera : MonoBehaviour
{
    public float mouse_sensitivity = 150f;
    public Transform player;

    float rotation_x = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        rotation_x -= mouse_y;
        rotation_x = Mathf.Clamp(rotation_x, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation_x, 0f, 0f);
        player.Rotate(Vector3.up * mouse_x);
        

    }
}
