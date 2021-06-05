using UnityEngine;

public class RightmouseControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas/Seter").GetComponent<CanvasGroup>().alpha = 0;
    }

    private void ButtonRightClick()
    {
        GameObject.Find("Canvas/Seter").GetComponent<CanvasGroup>().alpha =
            1 - GameObject.Find("Canvas/Seter").GetComponent<CanvasGroup>().alpha;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ButtonRightClick();
        }
    }
}
