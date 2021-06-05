using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;
using System;
using System.Windows.Forms;
using UnityEngine.UI;

public class InputData : MonoBehaviour
{
    public void Click()
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "三体预设文件(*.3dstmn)\0*.3dstmn";
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        openFileName.initialDir = (UnityEngine.Application.dataPath + "\\Saves").Replace('/', '\\');//默认路径
        openFileName.title = "选择预设";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        if (LocalDialog.GetOpenFileName(openFileName)==true)
        {
            StreamReader sr = new StreamReader(openFileName.file);
            GameObject.Find("Canvas/Seter/m1").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/m2").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/m3").GetComponent<InputField>().text = sr.ReadLine();

            GameObject.Find("Canvas/Seter/x1").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/x2").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/x3").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/xp").GetComponent<InputField>().text = sr.ReadLine();

            GameObject.Find("Canvas/Seter/y1").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/y2").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/y3").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/yp").GetComponent<InputField>().text = sr.ReadLine();

            GameObject.Find("Canvas/Seter/z1").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/z2").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/z3").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/zp").GetComponent<InputField>().text = sr.ReadLine();

            GameObject.Find("Canvas/Seter/vx1").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vx2").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vx3").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vxp").GetComponent<InputField>().text = sr.ReadLine();

            GameObject.Find("Canvas/Seter/vy1").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vy2").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vy3").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vyp").GetComponent<InputField>().text = sr.ReadLine();

            GameObject.Find("Canvas/Seter/vz1").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vz2").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vz3").GetComponent<InputField>().text = sr.ReadLine();
            GameObject.Find("Canvas/Seter/vzp").GetComponent<InputField>().text = sr.ReadLine();

            sr.Close();
            sr.Dispose();
        }
    }
}
