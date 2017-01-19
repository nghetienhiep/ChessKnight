using UnityEngine;
using System.Collections;
using DG.Tweening;
public class CameraManager : MonoBehaviour
{

    public GameObject Cam1;
    public GameObject Cam2;
    void Start()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam1View();
    }

    void Update()
    {

    }
    void SetCamPlay()
    {
        Cam1.SetActive(false);
        Cam2.SetActive(true);
    }
    void Cam1View()
    {
        Cam1.transform.localPosition = new Vector3(-0.321f, 0.125f, -0.572f);
        Cam1.transform.DOLocalMoveX(0.3f, 25).SetEase(Ease.Linear).OnComplete(() => { ChangeCam(); });
    }
    public void ChangeCam()
    {
        UIManager.main.ShowShadown(0.7f, SetCamPlay);
    }
}
