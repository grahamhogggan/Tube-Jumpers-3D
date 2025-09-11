using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinnerText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TMP_Text>().text = WinManager.winningPlayer+" Won!";
    }
    public void PlayAgain()
    {
        PlayerSetup.RESET();
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
