using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;

    public CharacterController controller;

    public Transform cam;

    public float lookSensitivity;

    public float minXRot;

    public float maxXRot;

    private float curXRot;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Move();
        if(Cursor.lockState == CursorLockMode.Locked)
            Look(); 
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();

        dir *= movespeed * Time.deltaTime;
        controller.Move(dir);
    }

    void Look()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        transform.eulerAngles += Vector3.up * x;
        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);
        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);
    }
}
