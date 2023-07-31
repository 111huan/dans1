using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene1 : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("demo1");
    }

    public static void backToMenu()
    {
        SceneManager.LoadScene("start");
    }
}
