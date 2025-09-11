using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static string winningPlayer;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==2)
        {
            Destroy(gameObject);
            return;
        }
        string name1 = PlayerSetup.name1;
                string name2 = PlayerSetup.name2;

        string name3 = PlayerSetup.name3;

        string name4 = PlayerSetup.name4;

        if(name1==null&&name2==null&&name3==null&&name4!=null)
        {
            winningPlayer = name4;
            Win();
        }
        if(name1!=null&&name2==null&&name3==null&&name4==null)
        {
            winningPlayer = name1;
            Win();
        }
        if(name1==null&&name2!=null&&name3==null&&name4==null)
        {
            winningPlayer = name2;
            Win();
        }
        if(name1==null&&name2==null&&name3!=null&&name4==null)
        {
            winningPlayer = name3;
            Win();
        }
    }
    void Win()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
