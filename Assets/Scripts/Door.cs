using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    Transform me, left, right;
    public static bool openable = false;
    public static bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 0);
        me = GameObject.Find("me").transform;
        left = GameObject.Find("doorL").transform;
        right = GameObject.Find("doorR").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Me.haveKey && me.position.x<= right.position.x && me.position.x >= left.position.x)
        {
            openable = true;
        }
        else
        {
            openable = false;
        }
        if (openable && Input.GetKey(KeyCode.F))
        {
            openable = false;
            opened = true;
            transform.localScale = new Vector3(0, 3, 0);
            upload();
        }
    }

    void upload()
    {
        int nowScene = 0;

        string path = Application.dataPath + "/Resources/history.txt";
        string[] download = File.ReadAllLines(path);
        if(SceneManager.GetActiveScene().name == "demo1")
        {
            nowScene = 1;
        }
        else if(SceneManager.GetActiveScene().name == "demo2")
        {
            nowScene = 2;
        }

        if (nowScene > int.Parse(download[0]))//if present level is greater than the record
        {
            string[] lines = { nowScene.ToString() };
            File.WriteAllLines(path,lines);//update record
        }
    }
}