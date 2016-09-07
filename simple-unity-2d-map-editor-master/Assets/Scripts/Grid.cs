using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public float width = 32.0f;
	public float height = 32.0f;

	public int row = 5;
	public int column = 5;

	public Color color = Color.white;

	public GameObject centre;

	public Transform tilePrefab;

	public TileSet tileSet;

	public bool draggable;

	void OnDrawGizmos(){
		Vector3 pos = Camera.current.transform.position;
		Vector3 pos2 = centre.transform.position;
		Gizmos.color = this.color;

		float total_width = this.width * this.column;
		float total_height = this.height * this.row;

		float startpoint_x = pos.x - total_width / 2;
		float startpoint_y = pos.y - total_height / 2;

		/*for(float y = pos.y - 800.0f; y < pos.y + 800.0f; y+= this.height){
			Gizmos.DrawLine(new Vector3(-1000000.0f, Mathf.Floor(y/this.height)*this.height, 0.0f), 
			                new Vector3(1000000.0f, Mathf.Floor(y/this.height)*this.height, 0.0f));
		}

		for(float x = pos.x -1200.0f; x < pos.x + 1200.0f; x+= this.width){
			Gizmos.DrawLine(new Vector3(Mathf.Floor(x/this.width)*this.width,-1000000.0f, 0.0f), 
			                new Vector3(Mathf.Floor(x/this.width)*this.width, 1000000.0f, 0.0f));
		}*/

		for (int y = 0; y <= column; y++) {
			Gizmos.DrawLine (new Vector3 (pos.x - (total_width / 2), startpoint_y, 0.0f),
				new Vector3 (pos.x + (total_width / 2), startpoint_y, 0.0f));

			startpoint_y += this.height;
		}

		for (int x = 0; x <= row; x++) {
			Gizmos.DrawLine(new Vector3(startpoint_x, pos.y - (total_height / 2), 0.0f),
				new Vector3(startpoint_x, pos.y + (total_height / 2), 0.0f));

			startpoint_x += this.width;
		}
	}

}
