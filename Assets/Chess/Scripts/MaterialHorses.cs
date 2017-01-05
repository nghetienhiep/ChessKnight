using UnityEngine;
using System.Collections;

public class MaterialHorses : MonoBehaviour {
	public Material mat;
	public Texture texture;
	public GameObject horses;
	// Use this for initialization
	void Start () {
		horses.GetComponent<MeshRenderer>().material = mat;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
