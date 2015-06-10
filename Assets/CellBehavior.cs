using UnityEngine;
using System.Collections;

public class CellBehavior : MonoBehaviour {

	GridBehavior grid;
	bool cellOccupied = false;
	public bool selected = false;
	Color compColor;
	public Color mouseOverColor;


	void Start () {
		grid = gameObject.GetComponentInParent<GridBehavior> ();
		compColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseEnter()
	{
		transform.localScale *= 2;
		gameObject.GetComponent<SpriteRenderer> ().color = mouseOverColor;

	}

	public void OnMouseDown()
	{
		if (!grid.creatingLine) {
			selected = true;
			grid.CreateLine (transform);
		}
		else
			if (!selected)
				grid.FinishLine (transform);
	}

	public void OnMouseExit()
	{
		transform.localScale /= 2;
		gameObject.GetComponent<SpriteRenderer> ().color = compColor;

	}
	public void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.tag == "Component") {
			gameObject.GetComponent<SpriteRenderer>().enabled = false; 
		}
	}
	public void OnTriggerExit2D(Collider2D obj)
	{
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;

	}
}
