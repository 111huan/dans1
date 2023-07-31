using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class choose : MonoBehaviour
{
    public static int record;
    // Start is called before the first frame update   
    void Start()
    {
        download();
    }
    public void download()
    {
        /*string path = Application.dataPath + "/Resources/history.txt";
        string[] download = File.ReadAllLines(path);*/
        record = PlayerPrefs.GetInt("nowScene");
    }
}
