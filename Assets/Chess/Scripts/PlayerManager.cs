using UnityEngine;
using System.Collections;
public class PlayerManager : MonoBehaviour
{

    public static PlayerManager main;
    public GameObject PlayerPref;
    PanelManager panel;
    void Awake()
    {
        main = this;
        panel = FindObjectOfType<PanelManager>();
    }
    void OnEnable()
    {
        CreatePlayer();
    }
    public void CreatePlayer()
    {
        GameObject player = Instantiate(PlayerPref, Vector3.zero, Quaternion.identity) as GameObject;
        Transform[] childAll = player.GetComponentsInChildren<Transform>(true);
        StartCoroutine(RenKnight(childAll));
    }
    IEnumerator RenKnight(Transform[] g)
    {

        foreach (Transform child in g)
        {
            if (child.gameObject.tag == "Player") continue;
            Vector3 posChild = panel.PosKnight.Dequeue();
            child.position = posChild;
            if (posChild.x < 0)
            {
                child.rotation = Quaternion.Euler(0, 180, 0);
            }
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
