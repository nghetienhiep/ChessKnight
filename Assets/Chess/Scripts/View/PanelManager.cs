using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelManager : MonoBehaviour
{
    public GameObject ColliderPref;
    public float distance;
    public Vector3 Pos;
    public Transform[] PosStart;
    public Queue<Vector3> PosKnight;
    void Start()
    {
        PosKnight = new Queue<Vector3>();
        foreach (Transform pos in PosStart)
        {
            PosKnight.Enqueue(pos.position);
        }
        SpawnCollider();
    }
    public void SpawnCollider()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject pref = Instantiate(ColliderPref, Pos, Quaternion.identity) as GameObject;
                pref.transform.SetParent(transform, true);
                pref.name = i + "" + j + "";
                Pos.x += distance;
            }
            Pos.x -= distance * 8;
            Pos.z += distance;
        }
        SpawnPlayer();
    }
    void SpawnPlayer()
    {
        GameObject player = GameObject.Find("GameManager");
        player.GetComponent<PlayerManager>().enabled = true;
    }
}
