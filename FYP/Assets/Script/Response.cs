using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Response : MonoBehaviour {
	public Image joyFG;
	public Image joyBG;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Dragging() {
		Vector3 newPos = Input.mousePosition;
		newPos.z = 10.0f;
		newPos = Camera.main.ScreenToWorldPoint (newPos);

		Vector3 middleBG = joyBG.transform.position;
		middleBG.z = 10.0f;
		middleBG = Camera.main.ScreenToWorldPoint (middleBG);

		var distance = (newPos - middleBG).sqrMagnitude;

		Debug.Log (distance);

		if ((newPos - middleBG).magnitude > 1.6f) {
			Vector3 final = new Vector3 (((newPos - middleBG).normalized.x), ((newPos - middleBG).normalized.y), 1.0f);

			joyFG.transform.position = newPos;
		} else {
			joyFG.transform.position = newPos;
		}
	}

	public void Release() {
		joyFG.transform.position = new Vector3 (joyBG.transform.position.x, joyBG.transform.position.y, 1.0f);
	}
}
