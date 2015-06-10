using UnityEngine;
using System.Collections;

public class GridRender : MonoBehaviour {

	public int gridSizeX, gridSizeY;

	private Vector2[,] gridNodes;
	
	public Vector2 gridPosition = Vector2.zero;

	public GameObject gridSprite;

	Vector3 boardCenter;

	public Material lineMaterial;

	void Awake () {

		boardCenter =  new Vector3 (gridSizeX / 2, gridSizeY / 2, -1);
		GameObject Grid = new GameObject ();
		Grid.name = "Grid";
		Grid.tag = "Grid";
		Grid.AddComponent<GridBehavior> ();
		Grid.transform.position = boardCenter; 
		Grid.transform.parent = gameObject.transform;
		gridNodes = new Vector2[gridSizeX, gridSizeY];
		int cellIndex = 1;
		for (int x = 0; x < gridSizeX; x++) 
		{
			for (int y = 0; y < gridSizeY; y++ )
			{

				gridPosition = new Vector2 (x-(gridSizeX/2), y-(gridSizeY/2));
				gridNodes[x,y] = gridPosition;
				GameObject gridCell =(GameObject)Instantiate(gridSprite, gridPosition, Quaternion.identity);
				gridCell.name += cellIndex.ToString();
				gridCell.transform.parent = Grid.transform;
				gridCell.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
				cellIndex ++;
			}

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
