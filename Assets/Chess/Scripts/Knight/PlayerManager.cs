using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

	public static PlayerManager main;
	public GameObject PlayerPref;
	PanelManager panel;

	void Awake ()
	{
		main = this;
		panel = FindObjectOfType<PanelManager> ();
	}

	void OnEnable ()
	{
		CreatePlayer (Color.white);
	}

	public void CreatePlayer (Color color)
	{
		StartCoroutine (RenKnight (Instantiate (PlayerPref).GetComponentsInChildren<Transform> (true), color));
	}

	IEnumerator RenKnight (Transform[] g, Color color)
	{

		foreach (Transform child in g) {
			if (child.gameObject.tag == "Player")
				continue;
			Vector3 posChild = panel.PosKnight.Dequeue ();
			posChild.y -= 0.3f;
			child.position = posChild;
			child.GetComponent<Renderer> ().material.color = color;
			if (posChild.z < 0)
				child.rotation = Quaternion.Euler (0, 90, 0);
			else
				child.rotation = Quaternion.Euler (0, -90, 0);
			child.gameObject.SetActive (true);
			yield return new WaitForSeconds (0.3f);
		}
		CreatePlayer2 (Color.black);
	}
	//=--------------------------------------------------
	public void CreatePlayer2 (Color color)
	{
		StartCoroutine (RenKnight2 (Instantiate (PlayerPref).GetComponentsInChildren<Transform> (true), color));
	}

	IEnumerator RenKnight2 (Transform[] g, Color color)
	{

		foreach (Transform child in g) {
			if (child.gameObject.tag == "Player")
				continue;
			Vector3 posChild = panel.PosKnight.Dequeue ();
			posChild.y -= 0.3f;
			child.position = posChild;
			child.GetComponent<Renderer> ().material.color = color;
			if (posChild.z < 0)
				child.rotation = Quaternion.Euler (0, 90, 0);
			else
				child.rotation = Quaternion.Euler (0, -90, 0);
			child.gameObject.SetActive (true);
			yield return new WaitForSeconds (0.3f);
		}
	}


}
