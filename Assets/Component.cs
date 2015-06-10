using UnityEngine;
using System.Collections;

public class Component : MonoBehaviour {
	public bool mouseOver;
	bool selected = false;
	void Start () {
		gameObject.transform.parent = GameObject.FindGameObjectWithTag("Grid").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		gameObject.GetComponentInParent<GridBehavior> ().componentSelected = true;
	}

	public void OnMouseDrag()
	{

		Vector3 newPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position =  new Vector3 (Mathf.Round(newPos.x),Mathf.Round(newPos.y), transform.position.z) ;
	}

	public void OnMouseUp()
	{
		gameObject.GetComponentInParent<GridBehavior> ().componentSelected = false;
		gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}

	public void OnMouseOver()
	{
		gameObject.GetComponentInParent<GridBehavior> ().componentHover = true;
	}

	public void OnMouseExit()
	{
		gameObject.GetComponentInParent<GridBehavior> ().componentHover = false;
	}
}