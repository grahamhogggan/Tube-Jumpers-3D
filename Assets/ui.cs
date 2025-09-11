using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public void ToggleObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
    public void HideObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void ShowObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void LoadScene(int scene)
    {
                PlayerSetup.DebugNames();

        SceneManager.LoadScene(scene);
    }
}
