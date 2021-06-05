using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Kaishi : MonoBehaviour
{
    Text text, text2;
    float x, y, k;
    // Start is called before the first frame update
    void Start()
    {
        x = Screen.width;
        y = Screen.height;
        k = x / 35;
        text = GameObject.Find("Canvas/fps").GetComponent<Text>();
        text.transform.position = new Vector3(100, y - 30, 0);
        text = GameObject.Find("Canvas/Temp").GetComponent<Text>();
        text.transform.position = new Vector3(100, y - 45, 0);
        if (File.Exists(Application.dataPath + @"\start_up_parameter.txt") == false)
        {
            StreamWriter sw = new StreamWriter(Application.dataPath + @"\start_up_parameter.txt", true);
            sw.WriteLine("1"); sw.WriteLine("0.04");
            sw.WriteLine("500"); sw.WriteLine("500"); sw.WriteLine("500");
            sw.WriteLine("-20"); sw.WriteLine("0"); sw.WriteLine("20"); sw.WriteLine("10");
            sw.WriteLine("15"); sw.WriteLine("0"); sw.WriteLine("-15"); sw.WriteLine("10");
            sw.WriteLine("0"); sw.WriteLine("0"); sw.WriteLine("0"); sw.WriteLine("0");
            sw.WriteLine("0"); sw.WriteLine("0"); sw.WriteLine("0"); sw.WriteLine("0");
            sw.WriteLine("0"); sw.WriteLine("0"); sw.WriteLine("0"); sw.WriteLine("0");
            sw.WriteLine("50"); sw.WriteLine("0"); sw.WriteLine("-50"); sw.WriteLine("40");
            sw.WriteLine("150"); sw.WriteLine("-50");
            sw.Close();
        }
        if (File.Exists(Application.dataPath+@"\setting") == true)
            GameObject.Find("Music2").GetComponent<AudioSource>().enabled = true;
        else GameObject.Find("Music1").GetComponent<AudioSource>().enabled = true;

    }
}
