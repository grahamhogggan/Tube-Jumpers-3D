using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float wind = 0.1f;
    public float speed = 1f;
    public string keybind;
    public NameInput.playerNumber p;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSetup.DebugNames();
        switch(p)
        {
            case NameInput.playerNumber.one:
                if(PlayerSetup.name1==null)
                {
                    Destroy(gameObject);
                                                            Debug.Log("destroyed because p1 was absent");

                }
                break;
                case NameInput.playerNumber.two:
                if(PlayerSetup.name2==null)
                {
                    Destroy(gameObject);
                                                            Debug.Log("destroyed because p2 was absent");

                }
                break;
                case NameInput.playerNumber.three:
                if(PlayerSetup.name3==null)
                {
                    Destroy(gameObject);
                                        Debug.Log("destroyed because p3 was absent");

                }
                break;
                case NameInput.playerNumber.four:
                if(PlayerSetup.name4==null)
                {
                    Destroy(gameObject);
                    Debug.Log("destroyed because p4 was absent");
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string[] keybinds = keybind.Split('/');
        GetComponent<Rigidbody>().AddForce(new Vector3(wind, 0, 0), ForceMode.Acceleration);
        if(Input.GetKey(keybinds[0]))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-speed, 0, 0), ForceMode.Acceleration);
        }
        if(Input.GetKey(keybinds[1]))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(speed, 0, 0), ForceMode.Acceleration);
        }
        if(Input.GetKey(keybinds[2]))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -speed), ForceMode.Acceleration);
        }
        if(Input.GetKey(keybinds[3]))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed), ForceMode.Acceleration);
        }
        if(transform.position.y<-10)
        {
            Debug.Log("DIED");
            switch(p)
            {
                case NameInput.playerNumber.one:
                PlayerSetup.name1 = null;
                break;
                case NameInput.playerNumber.two:
                PlayerSetup.name2 = null;
                break;
                case NameInput.playerNumber.three:
                PlayerSetup.name3 = null;
                break;
                case NameInput.playerNumber.four:
                PlayerSetup.name4 = null;
                break;
            }
            Destroy(gameObject);
        }
    }
}
