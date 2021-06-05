using System;
using UnityEngine;
using UnityEngine.UI;

public class camera_move : MonoBehaviour
{
    //public Transform target=new Transform();
    public static double a, b, distance;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 vec = new Vector3(0, 0, 0);
        //target.position = vec;
        //a =Math.PI; b = Math.PI / 2 - 0.1; 
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        distance = 200;
        setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0) - transform.position), 10);
    }
    public void setplace(float x, float y, float z)
    {
        Vector3 vec = new Vector3(x, y, z);
        if (transform.parent == null) transform.position = vec;
        else transform.position = vec + transform.parent.position;
    }
    Vector2 now = new Vector2();
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Canvas/Seter").GetComponent<CanvasGroup>().alpha < 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                now = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 new1 = Input.mousePosition;
                a -= (new1.x - now.x) * 0.01;
                b -= (new1.y - now.y) * 0.004;
                if (b <= -Math.PI / 2) b = -Math.PI / 2 + 0.04;
                if (b >= Math.PI / 2) b = Math.PI / 2 - 0.04;
                setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                if (transform.parent == null) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0) - transform.position), 10);
                else transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.parent.position - transform.position), 10);
                now = new1;
            }
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                distance -= Input.mouseScrollDelta.y * 50;
                if (distance < 50) distance = 50;
                setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                text.text = "中心视角";
                transform.parent = null;
                setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                text.text = "恒星A视角";
                transform.parent = GameObject.Find("StarA").GetComponent<Transform>();
                setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                text.text = "恒星B视角";
                transform.parent = GameObject.Find("StarB").GetComponent<Transform>();
                setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                text.text = "恒星C视角";
                transform.parent = GameObject.Find("StarC").GetComponent<Transform>();
                setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                text.text = "行星视角";
                transform.parent = GameObject.Find("Planet").GetComponent<Transform>();
                setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
            }
        }
    }
}
