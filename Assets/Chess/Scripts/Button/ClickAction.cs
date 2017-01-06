using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour
{
	Ray touchMouse;
	RaycastHit rhInfo;
	public Text text;

	void Update ()
	{
		if (gameState < 2) {
			if (Input.GetMouseButtonDown (0)) {
				touchMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (touchMouse, out rhInfo, 500.0f)) {
					if (rhInfo.collider.gameObject.tag == "Knight") {
						text.text = rhInfo.collider.gameObject.name;
						SelectKnight (rhInfo.collider.gameObject);
						ChangeState (1);
					}
				} 
			}
		}
		if (gameState == 1) {
			Vector2 selectedCoord;

			// On Left Click
			if (Input.GetMouseButtonUp (0)) {
				touchMouse = Camera.main.ScreenPointToRay (Input.mousePosition); // Specify the ray to be casted from the position of the mouse click

				// Raycast and verify that it collided
				if (Physics.Raycast (touchMouse, out rhInfo, 500.0f)) {

					// Select the piece if it has the good Tag
					if (rhInfo.collider.gameObject.tag == "Platform") {
						selectedCoord = new Vector2 (rhInfo.collider.gameObject.transform.position.x, rhInfo.collider.gameObject.transform.position.y);
						MoveKnight (selectedCoord);
						ChangeState (0);
					}
				}
			}	
		}
	}

	public int gameState = 0;
	// In this state, the code is waiting for : 0 = Piece selection, 1 = Piece animation, 2 = Player2/AI movement
	//private int activePlayer = 0;		// 0 = Player1, 1 = Player2, 2 = AI, to be used later
	private GameObject SelectedKnight;
	// Selected Piece
	void SelectKnight (GameObject _KnightToSelect)
	{
		if (SelectedKnight) {
			SelectedKnight.GetComponent<Renderer> ().material.color = Color.white;
		}
		SelectedKnight = _KnightToSelect;
		SelectedKnight.GetComponent<Renderer> ().material.color = Color.red;
	}

	public void ChangeState (int _newState)
	{
		gameState = _newState;
		Debug.Log ("GameState = " + _newState);
	}

	public void MoveKnight (Vector2 _coordToMove)
	{
		SelectedKnight.transform.position = _coordToMove;		// Move the piece
		SelectedKnight.GetComponent<Renderer> ().material.color = Color.white;	// Change it's color back
		SelectedKnight = null;									// Unselect the Piece
	}
}
