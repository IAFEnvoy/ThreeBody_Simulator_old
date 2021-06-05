using UnityEngine;

public class SeeCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = GameObject.Find("MainCamera").GetComponent<Camera>().transform.rotation;
    }
}
