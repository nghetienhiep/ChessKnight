using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelManager : MonoBehaviour
{
	public GameObject ColliderPref;
	public float distance;
	public Vector3 Pos;
	public Queue<Vector3> PosKnight;

	void Start ()
	{
		PosKnight = new Queue<Vector3> ();
		SpawnCollider ();
	}

	public void SpawnCollider ()
	{
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				GameObject pref = Instantiate (ColliderPref);
				pref.transform.SetParent (transform, true);
                pref.transform.localPosition = Pos;
                pref.name = i + "" + j + "";

				if ((i == 0 || i == 7)) {
					if (j == 0 || j == 1 || j == 2 || j == 5 || j == 6 || j == 7)
						PosKnight.Enqueue (pref.transform.position);
				}
				Pos.x += distance;
			}
			Pos.x -= distance * 8;
			Pos.z += distance;
		}
		SpawnPlayer ();
	}

	void SpawnPlayer ()
	{
        GameObject player = GameObject.Find("GameManager");
        player.GetComponent<PlayerManager>().enabled = true;
    }
}
