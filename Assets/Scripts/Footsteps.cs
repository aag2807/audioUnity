using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public AudioClip[] footsteps;
    public AudioSource AudioSource;

    public CharacterController controller;

    public float footstepThreshhold;
    public float footstepRate;
    private float lastFootstepTime;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(controller.velocity.magnitude > footstepThreshhold)
        {
            if(Time.time - lastFootstepTime > footstepRate)
            {
                lastFootstepTime = Time.time;
                AudioSource.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
            }
        }
    }

}
