using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour
{
    public Text text;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray touchMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(touchMouse, out rhInfo, 500.0f);
            if (didHit)
            {
                Debug.Log(rhInfo.collider.name);
                text.text = rhInfo.collider.name;
            }
            else
            {
                //Debug.Log("a");
            }
        }
    }
}
