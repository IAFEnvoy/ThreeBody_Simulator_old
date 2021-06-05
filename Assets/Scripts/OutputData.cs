using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class OutputData : MonoBehaviour
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
        openFileName.initialDir = (UnityEngine.Application.dataPath+"\\Saves").Replace('/', '\\');//默认路径
        openFileName.title = "保存预设";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        if (LocalDialog.GetSaveFileName(openFileName) == true)
        {
            if (openFileName.file.Contains(".3dstmn") == false) openFileName.file += ".3dstmn";
            StreamWriter sw = new StreamWriter(openFileName.file,true);

            sw.WriteLine(GameObject.Find("Canvas/Seter/m1/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/m2/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/m3/Text").GetComponent<Text>().text);

            sw.WriteLine(GameObject.Find("Canvas/Seter/x1/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/x2/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/x3/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/xp/Text").GetComponent<Text>().text);

            sw.WriteLine(GameObject.Find("Canvas/Seter/y1/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/y2/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/y3/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/yp/Text").GetComponent<Text>().text);

            sw.WriteLine(GameObject.Find("Canvas/Seter/z1/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/z2/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/z3/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/zp/Text").GetComponent<Text>().text);

            sw.WriteLine(GameObject.Find("Canvas/Seter/vx1/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vx2/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vx3/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vxp/Text").GetComponent<Text>().text);

            sw.WriteLine(GameObject.Find("Canvas/Seter/vy1/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vy2/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vy3/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vyp/Text").GetComponent<Text>().text);

            sw.WriteLine(GameObject.Find("Canvas/Seter/vz1/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vz2/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vz3/Text").GetComponent<Text>().text);
            sw.WriteLine(GameObject.Find("Canvas/Seter/vzp/Text").GetComponent<Text>().text);

            sw.Close();
            sw.Dispose();
        }
    }
}
