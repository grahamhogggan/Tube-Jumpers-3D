using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lines : MonoBehaviour
{
    public GameObject boat;
public GameObject raft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, boat.transform.position);
        GetComponent<LineRenderer>().SetPosition(1, raft.transform.position);
    }
}
