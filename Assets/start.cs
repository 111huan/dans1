using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public static bool isReplayed = false;
    private GameObject sword = GameObject.Find("sword");
    public void changeScene()
    {
        isReplayed = true;
        SceneManager.LoadScene("demo1");
    }
    
}
