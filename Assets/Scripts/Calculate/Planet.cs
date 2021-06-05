using UnityEngine;

public class Planet : MonoBehaviour
{
    void setplace(double x, double y, double z)
    {
        Vector3 vec = new Vector3((float)x, (float)y, (float)z);
        transform.position = vec;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        setplace(Sun.xp, Sun.yp, Sun.zp);
        //this.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);
    }
}
