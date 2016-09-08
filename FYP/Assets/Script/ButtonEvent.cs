using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (EventSystem.current.currentSelectedGameObject != null) {
			Debug.Log (EventSystem.current.currentSelectedGameObject.name);

			string temp = EventSystem.current.currentSelectedGameObject.name;
			if (temp == "") {

			}
		}
	}
}
