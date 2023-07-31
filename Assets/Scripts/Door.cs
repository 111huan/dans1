using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    Transform me, left, right, win;
    public static bool openable = false;
    public static bool opened = false;
    int nowScene = 1;
    Vector3 winScal = new Vector3(0.8f,1.4f,0);
    // Start is called before the first frame update
    void Start()
    {
        openable = false;
        opened = false;
        transform.localScale = new Vector3(3, 3, 0);
        me = GameObject.Find("me").transform;
        left = GameObject.Find("doorL").transform;
        right = GameObject.Find("doorR").transform;
        //win.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Me.haveKey && me.position.x<= right.position.x && me.position.x >= left.position.x)
        {
            openable = true;
        }
        else
        {
            openable = false;
        }*/
        /*if (openable && Input.GetKey(KeyCode.F))
        {
            openable = false;
            opened = true;
            transform.localScale = new Vector3(0, 3, 0);
            upload();
            if(nowScene == 1)
            {
                SceneManager.LoadScene("demo2");
            }
            else if (nowScene == 2)
            {
                win.localScale = winScal;
            }
        }*/
    }

    void upload()
    {
        /*string path = Application.dataPath + "/Resources/history.txt";
        string[] download = File.ReadAllLines(path);*/
        if(SceneManager.GetActiveScene().name == "demo1")
        {
            nowScene = 1;
        }
        else if(SceneManager.GetActiveScene().name == "demo2")
        {
            nowScene = 2;
        }
        if (nowScene > PlayerPrefs.GetInt("nowScene"))
        {
            PlayerPrefs.SetInt("nowScene", nowScene);
        }
        /*if (nowScene > int.Parse(download[0]))//if present level is greater than the record
        {
            string[] lines = { nowScene.ToString() };
            File.WriteAllLines(path,lines);//update record
        }*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Me.haveKey)
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
            if (nowScene == 1)
            {
                SceneManager.LoadScene("chooseDemo");
            }
            else
            {
                win.localScale = winScal;
            }
        }
    }
}