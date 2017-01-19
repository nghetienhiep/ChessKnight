using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour
{
    public static ClickAction main;
	Ray touchMouse;
	RaycastHit rhInfo;
	public Text text;

	private Vector3 startTouch, endTouch;
    public Material[] clickMat;
    public Camera CamCurrent;
    void Awake()
    {
        main = this;
    }
    void Start()
    {
        CamCurrent = GameObject.Find("Cam2").GetComponent<Camera>();
    }
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			startTouch = Input.mousePosition;
			if (gameState < 2) {
				touchMouse = CamCurrent.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (touchMouse, out rhInfo, 500.0f)) {
					if (rhInfo.collider.gameObject.tag == "Knight") {
						text.text = rhInfo.collider.gameObject.name;
						SelectKnight (rhInfo.collider.gameObject);
						ChangeState (1);
					}
				}
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			endTouch = Input.mousePosition;
			if (Vector3.Distance (startTouch, endTouch) < 25) {
				if (gameState == 1) {
					Vector3 selectedCoord;
                    print(CamCurrent.name);
                    touchMouse = CamCurrent.ScreenPointToRay (Input.mousePosition); // Specify the ray to be casted from the position of the mouse click

					// Raycast and verify that it collided
					if (Physics.Raycast (touchMouse, out rhInfo, 500.0f)) {

						// Select the piece if it has the good Tag
						if (rhInfo.collider.gameObject.tag == "Platform" || rhInfo.collider.gameObject.tag == "King" || rhInfo.collider.gameObject.tag == "Queen") {
							selectedCoord = new Vector3 (rhInfo.collider.gameObject.transform.position.x, 0, rhInfo.collider.gameObject.transform.position.z);
							Move (selectedCoord);
							ChangeState (0);
						}
					}	
				}
			}
		}
	}

	public int gameState = 0;
	private GameObject SelectedKnight;

	void SelectKnight (GameObject _KnightToSelect)
	{
		if (SelectedKnight) {
            SelectedKnight.GetComponent<KnightController>().platformCurent.GetComponent<MeshRenderer>().enabled = false;
        }
		SelectedKnight = _KnightToSelect;
        MeshRenderer platformCurent = SelectedKnight.GetComponent<KnightController>().platformCurent.GetComponent<MeshRenderer>();
        platformCurent.material = clickMat[0];
        platformCurent.enabled = true;
    }

	public void ChangeState (int _newState)
	{
		gameState = _newState;
	}

	public void Move (Vector3 pos)
	{
        SelectedKnight.GetComponent<KnightController>().platformCurent.GetComponent<MeshRenderer>().enabled = false;
        SelectedKnight.GetComponent<KnightController> ().MoveKnight (pos);
		SelectedKnight = null;
	}
}
