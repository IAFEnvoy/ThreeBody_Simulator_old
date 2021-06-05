using UnityEngine;
public class starA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setplace(Sun.x1, Sun.y1, Sun.z1);
    }
    // Update is called once per frame
    void setplace(double x, double y, double z)
    {
        Vector3 vec = new Vector3((float)x, (float)y, (float)z);
        transform.position = vec;
    }

    [System.Obsolete]
    void Update()
    {
        setplace(Sun.x1, Sun.y1, Sun.z1);
        //this.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
    }
}
