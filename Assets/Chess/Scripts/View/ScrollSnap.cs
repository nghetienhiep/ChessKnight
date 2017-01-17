using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollSnap : MonoBehaviour
{
	public float distanceScale;
	public RectTransform panel;
	public GameObject[] btn;
	public RectTransform center;
	[Range (0.1f, 1f)]
	public float subScale = 0.7f;
	public Sprite[] typeSprite; 
	public Image imgType;
	private float[] distance;
	private float[] disRePosition;
	private bool dragging = false;
	private int btnDistance;
	private int minButtonNum;
	private int btnLenght;

	// Use this for initialization
	void Start ()
	{
		btnLenght = btn.Length;
		distance = new float[btnLenght];
		disRePosition = new float[btnLenght];
		Init ();
		btnDistance = (int)Mathf.Abs (btn [1].GetComponent<RectTransform> ().anchoredPosition.x - btn [0].GetComponent<RectTransform> ().anchoredPosition.x);
	}

	void Init ()
	{
		foreach (GameObject g in btn) {
			g.transform.localScale = Vector3.one * (1 - subScale);
		}
	}
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < btn.Length; i++) {
			disRePosition [i] = center.GetComponent<RectTransform> ().position.x - btn [i].GetComponent<RectTransform> ().position.x;
			distance [i] = Mathf.Abs (disRePosition [i]);
			if (distance [i] < distanceScale) {
				float x = Percent (distance [i], subScale);
				btn [i].transform.localScale = new Vector3 (x, x, x);
				ChangAlpha (btn [i].GetComponent<Image> (), x);
			} else if (distance [i] > distanceScale) {
				ChangAlpha (btn [i].GetComponent<Image> (), Percent (distance [i], subScale));
			}
			if (disRePosition [i] > 200) {
				float curX = btn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = btn [i].GetComponent<RectTransform> ().anchoredPosition.y;
				Vector2 newAnchorPos = new Vector2 (curX + (btnLenght * btnDistance), curY);
				btn [i].GetComponent<RectTransform> ().anchoredPosition = newAnchorPos;
			}
			if (disRePosition [i] < -200) {
				float curX = btn [i].GetComponent<RectTransform> ().anchoredPosition.x;
				float curY = btn [i].GetComponent<RectTransform> ().anchoredPosition.y;
				Vector2 newAnchorPos = new Vector2 (curX - (btnLenght * btnDistance), curY);
				btn [i].GetComponent<RectTransform> ().anchoredPosition = newAnchorPos;
			}
		}
		float minDistance = Mathf.Min (distance);
		for (int i = 0; i < btn.Length; i++) {
			if (minDistance == distance [i]) {
				minButtonNum = i;
			}
		}
		if (!dragging) {
			LeftToBtn (-btn [minButtonNum].GetComponent<RectTransform> ().anchoredPosition.x);
			int num = minButtonNum % 3;
			if (num == 0 && currentNum != num) {
				currentNum = 0;
				imgType.sprite = typeSprite[num];
			} else if (num == 1 && currentNum != num) {
				currentNum = 1;
				imgType.sprite = typeSprite[num];
			} else if (num == 2 && currentNum != num) {
				currentNum = 2;
				imgType.sprite = typeSprite[num];
			}
		}
	}
	int currentNum = -1;
	float Percent (float current, float p)
	{
		return  1 - Mathf.Abs ((current * p) / distanceScale);
	}

	void ChangAlpha (Image img, float alpha)
	{
		Color c = img.color;
		c.a = alpha;
		img.color = c;
	}

	void LeftToBtn (float position)
	{
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);
		panel.anchoredPosition = newPosition;
	}

	public void StartDrag ()
	{
		dragging = true;
	}

	public void EndDrag ()
	{
		dragging = false;
	}
}
