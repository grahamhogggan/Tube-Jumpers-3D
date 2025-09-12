using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chucker : MonoBehaviour
{
    public GameObject[] stuff; 
    public float rate;
    private float delay; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay+=Time.deltaTime;
        if(delay>rate)
        {
            delay = 0;
            GameObject g = stuff[Random.Range(0,stuff.Length)];
            GameObject s = Instantiate(g,transform.position,Quaternion.Euler(new Vector3(1,1,1)*Random.Range(0,360)));
            s.AddComponent<Rigidbody>().velocity = new Vector3(5,1,Random.Range(-3f,3f));
        }
    }
}
