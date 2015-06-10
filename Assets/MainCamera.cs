using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public GameObject motherBoard;
	BoxCollider2D myCollider;
	GridRender moboGridRender;

	void Start () {
		moboGridRender = motherBoard.GetComponent<GridRender> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
