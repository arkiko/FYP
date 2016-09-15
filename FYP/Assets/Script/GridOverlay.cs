﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridOverlay : MonoBehaviour {
	public bool showMain = true;
	public bool showSub = false;

	private int gridSizeX = 16;
	private int gridSizeY = 10;
	private int gridSizeZ = 0;

	private float smallStep = 1;
	private float largeStep = 1;

	private float startX = -8;
	private float startY = -5;
	private float startZ = 0;

	private float scrollRate = 0.1f;
	private float lastScroll = 0f;

	private Material lineMaterial;

	private Color mainColor = new Color(0f,1f,0f,1f);
	private Color subColor = new Color(0f,0.5f,0f,1f);

	private Plane _groundPlane;

	public GameObject Tile_Clone;
	private bool Menu_Active = false;
	private bool Place_Delete = true;

	void Start () 
	{
		_groundPlane = new Plane(Vector3.forward, new Vector3(-8, -5, 0));

		GameObject text = GameObject.Find ("First_Value");
		if (text != null) {
			text.GetComponent<Text> ().text = gridSizeX.ToString ();
		}

		text = GameObject.Find ("Second_Value");
		if (text != null) {
			text.GetComponent<Text> ().text = gridSizeY.ToString ();
		}

		text = GameObject.Find ("Third_Value");
		if (text != null) {
			text.GetComponent<Text> ().text = smallStep.ToString ();
		}

		text = GameObject.Find ("Fouth_Value");
		if (text != null) {
			text.GetComponent<Text> ().text = largeStep.ToString ();
		}

		text = GameObject.Find ("Fifth_Value");
		if (text != null) {
			text.GetComponent<Text> ().text = startX.ToString ();
		}

		text = GameObject.Find ("Sixth_Value");
		if (text != null) {
			text.GetComponent<Text> ().text = startY.ToString ();
		}
	}

	void Update () 
	{
		var menu = GameObject.Find("Canvas").transform.Find ("Menu_Active").gameObject;
		if (menu.activeSelf == false)
			Menu_Active = false;

		if (lastScroll + scrollRate < Time.time) {
			if (EventSystem.current.currentSelectedGameObject != null) {
				Debug.Log (EventSystem.current.currentSelectedGameObject.name);

				bool found = false;
				string temp = EventSystem.current.currentSelectedGameObject.name;
				if (temp == "Menu") {
					menu = GameObject.Find("Canvas").transform.Find ("Menu_Active").gameObject;
					menu.SetActive (!menu.activeSelf);

					if (menu.activeSelf == true)
						Menu_Active = true;

					found = true;
				}

				if (temp == "Place_Delete") {
					if (Place_Delete == true) {
						Place_Delete = false;
						GameObject.Find ("Canvas").transform.Find ("Menu_Active").transform.Find ("Place_Delete").GetComponentInChildren<Text> ().text = "Delete";
					} else {
						Place_Delete = true;
						GameObject.Find ("Canvas").transform.Find ("Menu_Active").transform.Find ("Place_Delete").GetComponentInChildren<Text> ().text = "Place";
					}

					found = true;
				}

				if (temp == "First_Minus") {
					gridSizeX -= 1;
					if (gridSizeX <= 0) {
						gridSizeX = 1;
					}

					found = true;
					GameObject text = GameObject.Find ("First_Value");
					text.GetComponent<Text> ().text = gridSizeX.ToString ();
				} else if (temp == "First_Plus") {
					gridSizeX += 1;

					found = true;
					GameObject text = GameObject.Find ("First_Value");
					text.GetComponent<Text> ().text = gridSizeX.ToString ();
				} else if (temp == "Second_Minus") {
					gridSizeY -= 1;
					if (gridSizeY <= 0) {
						gridSizeY = 1;
					}

					found = true;
					GameObject text = GameObject.Find ("Second_Value");
					text.GetComponent<Text> ().text = gridSizeY.ToString ();
				} else if (temp == "Second_Plus") {
					gridSizeY += 1;

					found = true;
					GameObject text = GameObject.Find ("Second_Value");
					text.GetComponent<Text> ().text = gridSizeY.ToString ();
				} else if (temp == "Third_Minus") {
					smallStep -= 1;
					if (smallStep <= 0) {
						smallStep = 1;
					}

					found = true;
					GameObject text = GameObject.Find ("Third_Value");
					text.GetComponent<Text> ().text = smallStep.ToString ();
				} else if (temp == "Third_Plus") {
					smallStep += 1;

					found = true;
					GameObject text = GameObject.Find ("Third_Value");
					text.GetComponent<Text> ().text = smallStep.ToString ();
				} else if (temp == "Fouth_Minus") {
					largeStep -= 1;
					if (largeStep <= 0) {
						largeStep = 1;
					}

					found = true;
					GameObject text = GameObject.Find ("Fouth_Value");
					text.GetComponent<Text> ().text = largeStep.ToString ();
				} else if (temp == "Fouth_Plus") {
					largeStep += 1;

					found = true;
					GameObject text = GameObject.Find ("Fouth_Value");
					text.GetComponent<Text> ().text = largeStep.ToString ();
				} else if (temp == "Fifth_Minus") {
					startX -= 1;

					found = true;
					GameObject text = GameObject.Find ("Fifth_Value");
					text.GetComponent<Text> ().text = startX.ToString ();
				} else if (temp == "Fifth_Plus") {
					startX += 1;

					found = true;
					GameObject text = GameObject.Find ("Fifth_Value");
					text.GetComponent<Text> ().text = startX.ToString ();
				} else if (temp == "Sixth_Minus") {
					startY -= 1;

					found = true;
					GameObject text = GameObject.Find ("Sixth_Value");
					text.GetComponent<Text> ().text = startY.ToString ();
				} else if (temp == "Sixth_Plus") {
					startY += 1;

					found = true;
					GameObject text = GameObject.Find ("Sixth_Value");
					text.GetComponent<Text> ().text = startY.ToString ();
				}

				if (found == true) {
					lastScroll = Time.time;
					GameObject myEventSystem = GameObject.Find ("EventSystem");
					myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
				}
			}
		}

		if (Input.GetMouseButtonDown (0) && !Menu_Active) {
			Debug.Log ("Mouse Down2");
			Debug.Log (Input.mousePosition);

			int x = 0;
			int y = 0;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			float distance;
			if (_groundPlane.Raycast (ray, out distance)) {
				Vector3 worldPosition = ray.GetPoint (distance);
				x = Mathf.RoundToInt (worldPosition.x - 0.5f);
				y = Mathf.RoundToInt (worldPosition.y - 0.5f);

				Debug.DrawLine (Camera.main.transform.position, worldPosition);
				Debug.LogFormat ("Clicked positions: {0} | {1}", x, y);

				if (Place_Delete) 
				{
					GameObject gameObj = (GameObject)Instantiate (Tile_Clone);
					gameObj.transform.position = new Vector3 (x + 0.5f, y + 0.5f, 0);
				} 
				else {
					foreach(GameObject Delete_Tile in GameObject.FindGameObjectsWithTag("Tile"))
					{
						Vector3 temp_pos = new Vector3 (x + 0.5f, y + 0.5f, 0);
						if (Delete_Tile.transform.position == temp_pos) {
							Destroy (Delete_Tile);
						}
					}
				}
			}
		}
	}

	void CreateLineMaterial() 
	{
		if( !lineMaterial ) {
			lineMaterial = new Material (Shader.Find ("Particles/Alpha Blended"));

			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;}
	}

	void OnPostRender() 
	{        
		CreateLineMaterial();
		// set the current material
		lineMaterial.SetPass( 0 );

		GL.Begin( GL.LINES );

		if(showSub)
		{
			GL.Color(subColor);

			//Layers
			for(float j = 0; j <= gridSizeY; j += smallStep)
			{
				//X axis lines
				for(float i = 0; i <= gridSizeZ; i += smallStep)
				{
					GL.Vertex3( startX, j + startY, startZ + i);
					GL.Vertex3( startX + gridSizeX, j + startY, startZ + i);
				}

				//Z axis lines
				for(float i = 0; i <= gridSizeX; i += smallStep)
				{
					GL.Vertex3( startX + i, j + startY, startZ);
					GL.Vertex3( startX + i, j + startY, gridSizeZ);
				}
			}

			//Y axis lines
			for(float i = 0; i <= gridSizeZ; i += smallStep)
			{
				for(float k = 0; k <= gridSizeX; k += smallStep)
				{
					GL.Vertex3( startX + k, startY, startZ + i);
					GL.Vertex3( startX + k, gridSizeY + startY, startZ + i);
				}
			}
		}

		if(showMain)
		{
			GL.Color(mainColor);

			//Layers
			for(float j = 0; j <= gridSizeY; j += largeStep)
			{
				//X axis lines
				for(float i = 0; i <= gridSizeZ; i += largeStep)
				{
					GL.Vertex3( startX, j + startY, startZ + i);
					GL.Vertex3( startX + gridSizeX, j + startY, startZ + i);
				}

				//Z axis lines
				for(float i = 0; i <= gridSizeX; i += largeStep)
				{
					GL.Vertex3( startX + i, j + startY, startZ);
					GL.Vertex3( startX + i, j + startY, gridSizeZ);
				}
			}

			//Y axis lines
			for(float i = 0; i <= gridSizeZ; i += largeStep)
			{
				for(float k = 0; k <= gridSizeX; k += largeStep)
				{
					GL.Vertex3( startX + k, startY, startZ + i);
					GL.Vertex3( startX + k, gridSizeY + startY, startZ + i);
				}
			}
		}

		if (smallStep <= 0)
			smallStep = 1;

		if (largeStep <= 0)
			largeStep = 1;

		GL.End();
	}
}
