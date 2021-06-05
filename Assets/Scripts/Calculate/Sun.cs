using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System.Windows.Forms;

public class Sun : MonoBehaviour
{
    TrailRenderer k1, k2, k3, kp;
    public struct star
    {
        public double x, y, z, x1, y1, z1;
        public double vx, vy, vz;
        public double m;
        public double ekx, eky, ekz, fx, fy, fz;
    }
    public static star s1, s2, s3, sp;
    public static double r1, r2, r3, r4, r5, r6, f1, f2, f3, f4, f5, f6;
    double g, t;
    public static bool enablep = true;

    public static double step = 0, step1 = 10, k;
    public static double x1, x2, x3, y1, y2, y3, z1, z2, z3, xp, yp, zp;
    public static bool yes = false;
    public static bool e1 = false, e2 = false, e3 = false, change;

    int f;
    public static double maxtemp = 150, mintemp = -50;
    //时间
    Text ti;
    public static double time;
    public double TimeEachFrame = 0.5;

    string Getvalue(string num)
    {
        string[] ss = num.Split('.');
        for (int i = 4; i > ss[0].Length; i--) num = "  " + num;
        if (num.Contains(".") == false) num += ".0";
        return num;
    }
    // Start is called before the first frame update
    void Start()
    {
        int x, y;
        Text text;
        x = UnityEngine.Screen.width;
        y = UnityEngine.Screen.height;
        text = GameObject.Find("Canvas/fps").GetComponent<Text>();
        text.rectTransform.position = new Vector3(210, y - 15, 0);
        text = GameObject.Find("Canvas/1").GetComponent<Text>();
        text.rectTransform.position = new Vector3(210, y - 30, 0);
        text = GameObject.Find("Canvas/2").GetComponent<Text>();
        text.rectTransform.position = new Vector3(210, y - 45, 0);
        text = GameObject.Find("Canvas/3").GetComponent<Text>();
        text.rectTransform.position = new Vector3(210, y - 60, 0);
        text = GameObject.Find("Canvas/4").GetComponent<Text>();
        text.rectTransform.position = new Vector3(210, y - 75, 0);
        text = GameObject.Find("Canvas/Temp").GetComponent<Text>();
        text.rectTransform.position = new Vector3(210, y - 90, 0);

        try
        {
            StreamReader sr = new StreamReader(UnityEngine.Application.dataPath + @"\\start_up_parameter.txt");
            g = double.Parse(sr.ReadLine()); t = double.Parse(sr.ReadLine());
            s1.m = double.Parse(sr.ReadLine()); s2.m = double.Parse(sr.ReadLine()); s3.m = double.Parse(sr.ReadLine());
            s1.x = double.Parse(sr.ReadLine()); s2.x = double.Parse(sr.ReadLine()); s3.x = double.Parse(sr.ReadLine()); sp.x = double.Parse(sr.ReadLine());
            s1.y = double.Parse(sr.ReadLine()); s2.y = double.Parse(sr.ReadLine()); s3.y = double.Parse(sr.ReadLine()); sp.y = double.Parse(sr.ReadLine());
            s1.z = double.Parse(sr.ReadLine()); s2.z = double.Parse(sr.ReadLine()); s3.z = double.Parse(sr.ReadLine()); sp.z = double.Parse(sr.ReadLine());
            s1.vx = double.Parse(sr.ReadLine()); s2.vx = double.Parse(sr.ReadLine()); s3.vx = double.Parse(sr.ReadLine()); sp.vx = double.Parse(sr.ReadLine());
            s1.vy = double.Parse(sr.ReadLine()); s2.vy = double.Parse(sr.ReadLine()); s3.vy = double.Parse(sr.ReadLine()); sp.vy = double.Parse(sr.ReadLine());
            s1.vz = double.Parse(sr.ReadLine()); s2.vz = double.Parse(sr.ReadLine()); s3.vz = double.Parse(sr.ReadLine()); sp.vz = double.Parse(sr.ReadLine());
            maxtemp = double.Parse(sr.ReadLine()); mintemp = double.Parse(sr.ReadLine());
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        Output();


        k1 = GameObject.Find("StarA").GetComponent<TrailRenderer>();
        k2 = GameObject.Find("StarB").GetComponent<TrailRenderer>();
        k3 = GameObject.Find("StarC").GetComponent<TrailRenderer>();
        kp = GameObject.Find("Planet").GetComponent<TrailRenderer>();

        k1.Clear(); k2.Clear(); k3.Clear(); kp.Clear();

        //k1.time = 0; k2.time = 0; k3.time = 0; kp.time = 0;
        //k1.time = 5; k2.time = 5; k3.time = 5; kp.time = 5;
        /*
        g = 1; t = 0.04;
        s1.m = 500; s2.m = 500; s3.m = 500;
        s1.x = -200; s2.x = 0; s3.x = 200; sp.x = 100;
        s1.y = 150; s2.y = 0; s3.y = -150; sp.x = 100;
        s1.z = 0; s2.z = 0; s3.z = 0; sp.x = 0;
        s1.vx = 0; s2.vx = 0; s3.vx = 0; sp.x = 0;
        s1.vy = 0; s2.vy = 0; s3.vy = 0; sp.x = 0;
        s1.vz = 50; s2.vz = 0; s3.vz = -50; sp.x = 40;
        */
        ti = GameObject.Find("Canvas/Time").GetComponent<Text>();
        time = 0;
    }
    double Temp()
    {
        double t1, t2, t3; int y1, y2, y3;
        if (s1.m > 0) y1 = 1; else y1 = 0;
        if (s2.m > 0) y2 = 1; else y2 = 0;
        if (s3.m > 0) y3 = 1; else y3 = 0;
        t1 = Math.Sqrt(Math.Sqrt(38.6 / ((s1.x - sp.x) * (s1.x - sp.x) + (s1.y - sp.y) * (s1.y - sp.y) + (s1.z - sp.z) * (s1.z - sp.z)))) * s1.m * 4;
        t2 = Math.Sqrt(Math.Sqrt(38.6 / ((s2.x - sp.x) * (s2.x - sp.x) + (s2.y - sp.y) * (s2.y - sp.y) + (s2.z - sp.z) * (s2.z - sp.z)))) * s2.m * 4;
        t3 = Math.Sqrt(Math.Sqrt(38.6 / ((s3.x - sp.x) * (s3.x - sp.x) + (s3.y - sp.y) * (s3.y - sp.y) + (s3.z - sp.z) * (s3.z - sp.z)))) * s3.m * 4;
        return (t1 * y1 + t2 * y2 + t3 * y3) / 3 - 273.15;
    }

    // Update is called once per frame
    void Update()
    {
        calc();
        if (Input.GetKeyDown(KeyCode.Escape)) UnityEngine.Application.Quit();
    }
    void Output()
    {

        x1 = s1.x1;
        y1 = s1.y1;
        z1 = s1.z1;

        x2 = s2.x1;
        y2 = s2.y1;
        z2 = s2.z1;

        x3 = s3.x1;
        y3 = s3.y1;
        z3 = s3.z1;

        xp = sp.x1;
        yp = sp.y1;
        zp = sp.z1;
    }
    void calc()
    {
        time += TimeEachFrame;//时间加0.1年
        if (change == true)
        {
            change = false;
            k1.Clear(); k2.Clear(); k3.Clear(); kp.Clear();
            //k1.time = 0; k2.time = 0; k3.time = 0; kp.time = 0;
            //k1.time = 5; k2.time = 5; k3.time = 5; kp.time = 5;
            GameObject.Find("StarA").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("StarC").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("StarB").GetComponent<CanvasGroup>().alpha = 0;
            if (GameObject.Find("MainCamera").GetComponent<AudioSource>().isPlaying == false)
                GameObject.Find("MainCamera").GetComponent<AudioSource>().Play();
            GameObject.Find("DirectionalLight").GetComponent<AudioSource>().enabled = false;
        }
        try
        {
            //用距离计算公式，计算星球之间的距离
            r1 = Math.Sqrt((s1.x - s2.x) * (s1.x - s2.x) + (s1.y - s2.y) * (s1.y - s2.y) + (s1.z - s2.z) * (s1.z - s2.z));//1,2
            r2 = Math.Sqrt((s3.x - s2.x) * (s3.x - s2.x) + (s3.y - s2.y) * (s3.y - s2.y) + (s3.z - s2.z) * (s3.z - s2.z));//2,3
            r3 = Math.Sqrt((s1.x - s3.x) * (s1.x - s3.x) + (s1.y - s3.y) * (s1.y - s3.y) + (s1.z - s3.z) * (s1.z - s3.z));//3,1

            if (enablep == true)
            {
                r4 = Math.Sqrt((s1.x - sp.x) * (s1.x - sp.x) + (s1.y - sp.y) * (s1.y - sp.y) + (s1.z - sp.z) * (s1.z - sp.z));//1
                r5 = Math.Sqrt((sp.x - s2.x) * (sp.x - s2.x) + (sp.y - s2.y) * (sp.y - s2.y) + (sp.z - s2.z) * (sp.z - s2.z));//2
                r6 = Math.Sqrt((sp.x - s3.x) * (sp.x - s3.x) + (sp.y - s3.y) * (sp.y - s3.y) + (sp.z - s3.z) * (sp.z - s3.z));//3
            }

            //引力公式：F=G*M*m/R
            f1 = g * s1.m * s2.m / r1;
            f2 = g * s3.m * s2.m / r2;
            f3 = g * s1.m * s3.m / r3;

            if (enablep == true)
            {
                f4 = g * s1.m / r4;
                f5 = g * s2.m / r5;
                f6 = g * s3.m / r6;
            }

            //计算每个星体在x,y,z方向上受到的引力，力的空间正交分解
            s1.fx = f1 / r1 * (s2.x - s1.x) + f3 / r3 * (s3.x - s1.x);
            s1.fy = f1 / r1 * (s2.y - s1.y) + f3 / r3 * (s3.y - s1.y);
            s1.fz = f1 / r1 * (s2.z - s1.z) + f3 / r3 * (s3.z - s1.z);

            s2.fx = f1 / r1 * (s1.x - s2.x) + f2 / r2 * (s3.x - s2.x);
            s2.fy = f1 / r1 * (s1.y - s2.y) + f2 / r2 * (s3.y - s2.y);
            s2.fz = f1 / r1 * (s1.z - s2.z) + f2 / r2 * (s3.z - s2.z);

            s3.fx = f2 / r2 * (s2.x - s3.x) + f3 / r3 * (s1.x - s3.x);
            s3.fy = f2 / r2 * (s2.y - s3.y) + f3 / r3 * (s1.y - s3.y);
            s3.fz = f2 / r2 * (s2.z - s3.z) + f3 / r3 * (s1.z - s3.z);

            if (enablep == true)
            {
                sp.fx = f4 / r4 * (s1.x - sp.x) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.x - sp.x);
                sp.fy = f4 / r4 * (s1.y - sp.y) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.y - sp.y);
                sp.fz = f4 / r4 * (s1.z - sp.z) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.z - sp.z);
            }

            //引力->加速度，牛顿第二定律：F=ma
            s1.ekx = s1.fx / s1.m;
            s1.eky = s1.fy / s1.m;
            s1.ekz = s1.fz / s1.m;

            s2.ekx = s2.fx / s2.m;
            s2.eky = s2.fy / s2.m;
            s2.ekz = s2.fz / s2.m;

            s3.ekx = s3.fx / s3.m;
            s3.eky = s3.fy / s3.m;
            s3.ekz = s3.fz / s3.m;

            if (enablep == true)
            {
                sp.ekx = sp.fx;
                sp.eky = sp.fy;
                sp.ekz = sp.fz;
            }

            //矢量计算，叠加加速度
            s1.vx += s1.ekx * t;
            s1.vy += s1.eky * t;
            s1.vz += s1.ekz * t;

            s2.vx += s2.ekx * t;
            s2.vy += s2.eky * t;
            s2.vz += s2.ekz * t;

            s3.vx += s3.ekx * t;
            s3.vy += s3.eky * t;
            s3.vz += s3.ekz * t;

            if (enablep == true)
            {
                sp.vx += sp.ekx * t;
                sp.vy += sp.eky * t;
                sp.vz += sp.ekz * t;
            }

            //计算位置
            s1.x1 = s1.vx * t + s1.x;
            s1.y1 = s1.vy * t + s1.y;
            s1.z1 = s1.vz * t + s1.z;

            s2.x1 = s2.vx * t + s2.x;
            s2.y1 = s2.vy * t + s2.y;
            s2.z1 = s2.vz * t + s2.z;

            s3.x1 = s3.vx * t + s3.x;
            s3.y1 = s3.vy * t + s3.y;
            s3.z1 = s3.vz * t + s3.z;

            if (enablep == true)
            {
                sp.x1 = sp.vx * t + sp.x;
                sp.y1 = sp.vy * t + sp.y;
                sp.z1 = sp.vz * t + sp.z;
            }

            //输出
            Output();


            ti.text = Getvalue(Math.Round(time / 10.0, 1).ToString()) + "年";

            f++;
            if (f == 5)
            {
                k = Math.Round(Temp(), 2);
                Text text = GameObject.Find("Canvas/Temp").GetComponent<Text>();
                if (k > maxtemp) text.color = Color.red;
                else if (k < mintemp) text.color = Color.blue;
                else text.color = Color.green;
                text.text = "行星表面温度：" + Math.Round(k, 2).ToString() + "℃";

                f = 0;
                text = GameObject.Find("Canvas/fps").GetComponent<Text>();
                text.text = "摄像机距离：" + camera_move.distance.ToString() + " fps:" + Math.Round(1.0 / Time.deltaTime, 2).ToString();

                text = GameObject.Find("Canvas/1").GetComponent<Text>();
                text.text = "恒星A：X=" + Math.Round(s1.x, 1) + " Y=" + +Math.Round(s1.y, 1) + " Z=" + Math.Round(s1.z, 1);
                text = GameObject.Find("Canvas/2").GetComponent<Text>();
                text.text = "恒星B：X=" + Math.Round(s2.x, 1) + " Y=" + +Math.Round(s2.y, 1) + " Z=" + Math.Round(s2.z, 1);
                text = GameObject.Find("Canvas/3").GetComponent<Text>();
                text.text = "恒星C：X=" + Math.Round(s3.x, 1) + " Y=" + +Math.Round(s3.y, 1) + " Z=" + Math.Round(s3.z, 1);
                text = GameObject.Find("Canvas/4").GetComponent<Text>();
                text.text = "行星  ：X=" + Math.Round(sp.x, 1) + " Y=" + +Math.Round(sp.y, 1) + " Z=" + Math.Round(sp.z, 1);
            }

            //准备下一帧
            s1.x = s1.x1;
            s1.y = s1.y1;
            s1.z = s1.z1;

            s2.x = s2.x1;
            s2.y = s2.y1;
            s2.z = s2.z1;

            s3.x = s3.x1;
            s3.y = s3.y1;
            s3.z = s3.z1;

            if (enablep == true)
            {
                sp.x = sp.x1;
                sp.y = sp.y1;
                sp.z = sp.z1;
            }
        }
        catch (Exception ex) //捕捉异常信息
        {
            MessageBox.Show("Script Sun:" + ex.Message);
        }
    }
}
