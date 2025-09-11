using System;
using UnityEngine;
public class PlayerSetup :MonoBehaviour
{
    #nullable enable
    public static string? name1=null;
    public static string? name2=null;
    public static string? name3=null;
    public static string? name4=null;
    public static string? name1P=null;
    public static string? name2P=null;
    public static string? name3P=null;
    public static string? name4P=null;
    #nullable disable

    public static void DebugNames()
    {
        name1P = name1;
        name2P = name2;
        name3P = name3;
        name4P = name4;
        Debug.Log("Name1: " + name1);
        Debug.Log("Name2: " + name2);
        Debug.Log("Name3: " + name3);
        Debug.Log("Name4: " + name4);
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public static void RESET()
    {
        name1 = name1P;
        name2 = name2P;
        name3 = name3P;
        name4 = name4P;
    }
}
