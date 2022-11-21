using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void changeScene()
    {
        Me.equiped = false;
        Me.isAttacked = false;
        Me.attacking = false;
        zombieHealth.zombieDie = false;
        zombieHealth.slider.value = 1;
    }

    public void backTooMenu()
    {
        SceneManager.LoadScene("start");
    }
}
