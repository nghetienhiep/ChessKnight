using UnityEngine;
using System.Collections;
using DG.Tweening;
public class KnightController : MonoBehaviour
{
    void OnEnable()
    {
        transform.DOMoveY(0, 0.5f);
    }
}
