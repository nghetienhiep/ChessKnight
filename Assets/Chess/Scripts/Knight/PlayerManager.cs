using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager main;
    public GameObject PlayerPref;
    PanelManager panel;
    public Material[] matPlayer;
    public int numberPlayer;
    void Awake()
    {
        main = this;
        panel = FindObjectOfType<PanelManager>();
    }

    void OnEnable()
    {
        CreatePlayer(matPlayer[numberPlayer]);
    }

    public void CreatePlayer(Material mat)
    {
        StartCoroutine(RenKnight(Instantiate(PlayerPref).GetComponentsInChildren<KnightController>(true), mat));
    }

    IEnumerator RenKnight(KnightController[] g, Material mat)
    {
        foreach (KnightController child in g)
        {
            Vector3 posChild = panel.PosKnight.Dequeue();
            posChild.y -= 0.3f;
            child.gameObject.transform.position = posChild;
            foreach (Renderer ren in child.GetComponentsInChildren<Renderer>())
            {
                ren.material = mat;
            }
            if (posChild.z < 0)
                child.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                child.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
        numberPlayer = 1;
        CreatePlayer2(matPlayer[numberPlayer]);
    }
    //=--------------------------------------------------
    public void CreatePlayer2(Material color)
    {
        StartCoroutine(RenKnight2(Instantiate(PlayerPref).GetComponentsInChildren<KnightController>(true), color));
    }

    IEnumerator RenKnight2(KnightController[] g, Material color)
    {
        foreach (KnightController child in g)
        {
            Vector3 posChild = panel.PosKnight.Dequeue();
            posChild.y -= 0.3f;
            child.gameObject.transform.position = posChild;
            foreach (Renderer ren in child.GetComponentsInChildren<Renderer>())
            {
                ren.material = color;
            }
            if (posChild.z < 0)
                child.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                child.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
        //CreatePlayer2 (Color.black);
    }


}
