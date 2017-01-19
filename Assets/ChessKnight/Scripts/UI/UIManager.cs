using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{

    public Image Shadow;
    public delegate void MyCallBack();
    public static UIManager main;
    void Awake()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowShadown(float time, MyCallBack callback = null)
    {
        Shadow.gameObject.SetActive(true);
        Shadow.DOFade(1, time).OnComplete(() =>
        {
            if (callback != null)
            {
                callback();
            }
            if (Shadow.color.a != 0)
            {
                Shadow.DOFade(0, time).OnComplete(() =>
                {
                    Shadow.gameObject.SetActive(false);
                });
            }
        });
    }
}
