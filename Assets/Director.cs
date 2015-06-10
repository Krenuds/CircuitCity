using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	Vector3 mousePosition;
	void Update () {
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.DrawLine (new Vector3 (mousePosition.x, mousePosition.y, -5), new Vector3 (mousePosition.x, mousePosition.y, 5));
	}
}
