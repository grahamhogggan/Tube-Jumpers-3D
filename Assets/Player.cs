using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float wind = 0.1f;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(wind, 0, 0), ForceMode.Acceleration);
        if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-speed, 0, 0), ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(speed, 0, 0), ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -speed), ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed), ForceMode.Acceleration);
        }
    }
}
