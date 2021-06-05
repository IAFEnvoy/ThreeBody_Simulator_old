using System;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public void Click()
    {
        GameObject.Find("Canvas/Seter").GetComponent<CanvasGroup>().alpha =
            1 - GameObject.Find("Canvas/Seter").GetComponent<CanvasGroup>().alpha;

        try
        {
            Sun.s1.m = Double.Parse(GameObject.Find("Canvas/Seter/m1/Text").GetComponent<Text>().text);
            Sun.s1.x = Double.Parse(GameObject.Find("Canvas/Seter/x1/Text").GetComponent<Text>().text);
            Sun.s1.y = Double.Parse(GameObject.Find("Canvas/Seter/y1/Text").GetComponent<Text>().text);
            Sun.s1.z = Double.Parse(GameObject.Find("Canvas/Seter/z1/Text").GetComponent<Text>().text);
            Sun.s1.vx = Double.Parse(GameObject.Find("Canvas/Seter/vx1/Text").GetComponent<Text>().text);
            Sun.s1.vy = Double.Parse(GameObject.Find("Canvas/Seter/vy1/Text").GetComponent<Text>().text);
            Sun.s1.vz = Double.Parse(GameObject.Find("Canvas/Seter/vz1/Text").GetComponent<Text>().text);

            Sun.s2.m = Double.Parse(GameObject.Find("Canvas/Seter/m2/Text").GetComponent<Text>().text);
            Sun.s2.x = Double.Parse(GameObject.Find("Canvas/Seter/x2/Text").GetComponent<Text>().text);
            Sun.s2.y = Double.Parse(GameObject.Find("Canvas/Seter/y2/Text").GetComponent<Text>().text);
            Sun.s2.z = Double.Parse(GameObject.Find("Canvas/Seter/z2/Text").GetComponent<Text>().text);
            Sun.s2.vx = Double.Parse(GameObject.Find("Canvas/Seter/vx2/Text").GetComponent<Text>().text);
            Sun.s2.vy = Double.Parse(GameObject.Find("Canvas/Seter/vy2/Text").GetComponent<Text>().text);
            Sun.s2.vz = Double.Parse(GameObject.Find("Canvas/Seter/vz2/Text").GetComponent<Text>().text);

            Sun.s3.m = Double.Parse(GameObject.Find("Canvas/Seter/m3/Text").GetComponent<Text>().text);
            Sun.s3.x = Double.Parse(GameObject.Find("Canvas/Seter/x3/Text").GetComponent<Text>().text);
            Sun.s3.y = Double.Parse(GameObject.Find("Canvas/Seter/y3/Text").GetComponent<Text>().text);
            Sun.s3.z = Double.Parse(GameObject.Find("Canvas/Seter/z3/Text").GetComponent<Text>().text);
            Sun.s3.vx = Double.Parse(GameObject.Find("Canvas/Seter/vx3/Text").GetComponent<Text>().text);
            Sun.s3.vy = Double.Parse(GameObject.Find("Canvas/Seter/vy3/Text").GetComponent<Text>().text);
            Sun.s3.vz = Double.Parse(GameObject.Find("Canvas/Seter/vz3/Text").GetComponent<Text>().text);

            Sun.sp.x = Double.Parse(GameObject.Find("Canvas/Seter/xp/Text").GetComponent<Text>().text);
            Sun.sp.y = Double.Parse(GameObject.Find("Canvas/Seter/yp/Text").GetComponent<Text>().text);
            Sun.sp.z = Double.Parse(GameObject.Find("Canvas/Seter/zp/Text").GetComponent<Text>().text);
            Sun.sp.vx = Double.Parse(GameObject.Find("Canvas/Seter/vxp/Text").GetComponent<Text>().text);
            Sun.sp.vy = Double.Parse(GameObject.Find("Canvas/Seter/vyp/Text").GetComponent<Text>().text);
            Sun.sp.vz = Double.Parse(GameObject.Find("Canvas/Seter/vzp/Text").GetComponent<Text>().text);
            Sun.time = 0;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "An error occur!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
