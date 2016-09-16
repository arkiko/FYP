using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public float width = 32.0f;
	public float height = 32.0f;

	public int row = 5;
	public int column = 5;

	public Color color = Color.white;
	public GameObject centre;

	void OnDrawGizmos() {
		//Vector3 pos = Camera.current.transform.position;
		Vector3 pos = centre.transform.position;
		Gizmos.color = this.color;

		float total_width = this.width * this.column;
		float total_height = this.height * this.row;

		float startpoint_x = pos.x - total_width / 2;
		float startpoint_y = pos.y - total_height / 2;

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

		/*
		for (float y = pos.y - (total_linedrawn_height / 2); y < pos.y + (total_linedrawn_height / 2); y += this.height) 
		{
			Gizmos.DrawLine (new Vector3 (-(total_width / 2), Mathf.Floor (y / this.height) * this.height, 0.0f),
				new Vector3 ((total_width / 2), Mathf.Floor (y / this.height) * this.height, 0.0f));
		}

		for (float x = pos.x - (total_linedrawn_width / 2); x < pos.x + (total_linedrawn_width / 2); x += this.width) 
		{
			Gizmos.DrawLine(new Vector3(Mathf.Floor(x / this.width) * this.width, -(total_height / 2), 0.0f),
				new Vector3(Mathf.Floor(x / this.width) * this.width, (total_height / 2), 0.0f));
		}*/
	}
}
