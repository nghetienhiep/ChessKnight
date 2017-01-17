using UnityEngine;
using System.Collections;

public class ButtonUIController : MonoBehaviour
{

    public GameObject[] Cam;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonChangView()
    {
        if (Cam[1].activeSelf)
        {
            Cam[1].SetActive(false);
            Cam[0].SetActive(true);
            ClickAction.main.CamCurrent = Cam[0].GetComponentInChildren<Camera>();
        }
        else
        {
            Cam[0].SetActive(false);
            Cam[1].SetActive(true);
            ClickAction.main.CamCurrent = Cam[1].GetComponent<Camera>();
        }
    }
}
