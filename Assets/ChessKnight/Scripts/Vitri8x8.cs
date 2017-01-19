using UnityEngine;
using System.Collections;

public class Vitri8x8 : MonoBehaviour
{
    float PosX, PosZ, Dis;
    public GameObject ConMa;

    void Start()
    {
        PosX = PosZ = 0.1034f;
        Dis = 0.0295f;
        //StartCoroutine(test());
        NewPos(7, 7);
    }

    void NewPos(float x, float y)
    {
        PosX -= Dis * (float)x;
        PosZ -= Dis * (float)y;
        ConMa.transform.position = new Vector3(PosX, 0, PosZ);
    }
}
