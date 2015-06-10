using UnityEngine;
using System.Collections;

public class GridBehavior : MonoBehaviour {

	int lineIndex = 1;
	Vector3 mousePosition;
	RaycastHit2D hit;

	LineRenderer lRend;
	CellBehavior cell;
	public bool componentSelected, componentHover;
	public bool creatingLine =  false;

	public struct Line
	{
		public Vector3 start;
		public Vector3 end;
		public float length;
	}

	Line CurrentLine;

	Material lineMaterial;
	void Start () {
		lineMaterial = gameObject.GetComponentInParent<GridRender> ().lineMaterial;
		CurrentLine = new Line ();
	}
	
	// Update is called once per frame
	void Update () {
		if (creatingLine) {
			OptimizeLine(CurrentLine.start);
		}
	}

	public void CreateLine(Transform start)
	{
		if (!creatingLine && !componentSelected && !componentHover) {
			creatingLine = true;
			CurrentLine.start = start.position;
			GameObject line = new GameObject ();
			lRend = line.AddComponent<LineRenderer> ();
			lRend.material = lineMaterial;
			lRend.SetWidth(.3f,.3f);
			line.name = "Line_" + lineIndex.ToString ();
			lRend.SetPosition (0, new Vector3(start.position.x, start.position.y, -1));
			lineIndex++;

		}
	}

	public void FinishLine(Transform end)
	{
		lRend.SetPosition (1, new Vector3(end.position.x, end.position.y, -1));
		creatingLine = false;
	}

	void OptimizeLine(Vector3 startLine)
	{
		Vector3 adjustedLine;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 adjustedMousePos = startLine - Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if ( Mathf.Abs(adjustedMousePos.x) > Mathf.Abs(adjustedMousePos.y))
		{
			adjustedLine = new Vector3(mousePosition.x, startLine.y, startLine.z);
		}
		else 
			if (Mathf.Abs(adjustedMousePos.y) > Mathf.Abs(adjustedMousePos.x))
		{
			adjustedLine = new Vector3(startLine.x, mousePosition.y, startLine.z);
		}
		else
		adjustedLine = startLine;
		lRend.SetPosition(1, adjustedLine);
	}
}