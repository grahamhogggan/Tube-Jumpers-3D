using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class NameInput : MonoBehaviour
{
    public enum playerNumber
    {
        one,
        two,
        three,
        four
    }
    public playerNumber p;
    public TMP_InputField inputField;
        private bool sceneIsUnloading = false;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputField.text==null||inputField.text =="")
        {
            inputField.text = "-";
        }
        if(inputField.text.Length==2)
        {
            inputField.text = inputField.text.Replace("-","");
        }
        switch(p)
        {
            case playerNumber.one:
                PlayerSetup.name1 = inputField.text;
                break;
            case playerNumber.two:
                PlayerSetup.name2 = inputField.text;
                break;
            case playerNumber.three:
                PlayerSetup.name3 = inputField.text;
                break;
            case playerNumber.four:
                PlayerSetup.name4 = inputField.text;
                break;
        }
    }
    public void Disable()
    {
        Debug.Log("DISABLED");
        switch(p)
        {
            case playerNumber.one:
                PlayerSetup.name1 = null;
                break;
            case playerNumber.two:
                PlayerSetup.name2 = null;
                break;
            case playerNumber.three:
                PlayerSetup.name3 = null;
                break;
            case playerNumber.four:
                PlayerSetup.name4 = null;
                break;
        }
    }
    
}
