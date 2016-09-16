using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Response : MonoBehaviour {
	public GameObject joyFG;
	public GameObject joyBG;

	public GameObject Character;

	bool move = false;
	// Use this for initialization
	void Start () {
		//Debug.Log (
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			Debug.Log (Character.transform.position);

			if(	Character.transform.position.x <= Screen.width && 
				Character.transform.position.x >= 0f && 

				(gameObject.tag == "Player 1" &&
				Character.transform.position.y <= Screen.height / 2 &&
				Character.transform.position.y >= 0f) || 

				(gameObject.tag == "Player 2" && 
				Character.transform.position.y <= Screen.height &&
				Character.transform.position.y >= Screen.height / 2)) 
			{
				RectTransform rt = Character.GetComponent<RectTransform> ();


				Vector2 newPos = Input.mousePosition;
				Vector2 middleBG = joyBG.transform.position;

				Vector2 offset = newPos - middleBG;
				var hiro = Vector2.ClampMagnitude (offset, 35.0f);

				joyFG.transform.position = hiro + middleBG;

				Vector3 Chara_Move = new Vector3 (hiro.x * Time.deltaTime, hiro.y * Time.deltaTime, 0f);

				Character.transform.position += Chara_Move * 7f;
			}
		} 

		if (Character.transform.position.x < 0f)			
			Character.transform.position = new Vector3(0f, Character.transform.position.y, Character.transform.position.z);			
		else if (Character.transform.position.x > Screen.width)			
			Character.transform.position = new Vector3(Screen.width, Character.transform.position.y, Character.transform.position.z);
						
		if (Character.transform.position.y < 0f && gameObject.tag == "Player 1")			
			Character.transform.position = new Vector3(Character.transform.position.x, 0.1f, Character.transform.position.z);			
		else if (Character.transform.position.y > Screen.height / 2 && gameObject.tag == "Player 1" || (Character.transform.position.y < Screen.height / 2 && gameObject.tag == "Player 2"))				
			Character.transform.position = new Vector3(Character.transform.position.x, Screen.height / 2, Character.transform.position.z);
		else if (Character.transform.position.y > Screen.height && gameObject.tag == "Player 2")
			Character.transform.position = new Vector3(Character.transform.position.x, Screen.height, Character.transform.position.z);
		
	}

	public void Dragging() {
		move = true;
	}

	public void Release() {
		joyFG.transform.position = joyBG.transform.position;
		move = false;
	}
}
