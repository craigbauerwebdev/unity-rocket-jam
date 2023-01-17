using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float mianThrust = 1000f;
    [SerializeField] float rotationThrust = 50f;
    Rigidbody rb;
   AudioSource audioSource; 

    // member var = global in this space

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get reference to rigidBody
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        processThrust();
        processRotation();
    }

    void processThrust() {
        //Debug.Log("UP");
        if(Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * mianThrust * Time.deltaTime); //0, 1, 0 <-same;
            if(!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    void processRotation() {
        if(Input.GetKey(KeyCode.A)) {
            //Debug.Log("Rotating Left");
            ApplyRotation(rotationThrust);
            //transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D)) {
            //Debug.Log("Rotating Right");
            ApplyRotation(-rotationThrust);
            //transform.Rotate(-Vector3.forward * rotationThrust * Time.deltaTime);
        }
    }

    void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; //freezing physics system
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //un-freezing physics system
    }   
}
