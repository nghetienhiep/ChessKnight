using UnityEngine;
using System.Collections;
using DG.Tweening;

public class KnightController : MonoBehaviour
{
    public GameObject platformCurent;
    void OnEnable()
    {
        transform.DOMoveY(0, 0.5f);
    }
    public void MoveKnight(Vector3 _coordToMove)
    {
        transform.DOMove(_coordToMove, 0.5f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            platformCurent = other.gameObject;
        }
    }
}
