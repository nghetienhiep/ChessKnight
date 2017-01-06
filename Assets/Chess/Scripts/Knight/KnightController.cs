using UnityEngine;
using System.Collections;
using DG.Tweening;

public class KnightController : MonoBehaviour
{
	void OnEnable ()
	{
		transform.DOMoveY (0, 0.5f);
	}
	public void MoveKnight (Vector3 _coordToMove)
	{
		transform.DOMove (_coordToMove,0.5f);
		GetComponent<Renderer> ().material.color = Color.white;
	}
}
