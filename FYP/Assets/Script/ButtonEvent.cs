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
			if (temp == "Menu") {
				var menu = GameObject.Find("Canvas").transform.Find ("Menu_Active").gameObject;
				if (menu != null) {
					menu.SetActive (!menu.activeSelf);

					GameObject myEventSystem = GameObject.Find ("EventSystem");
					myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
				} else {
					Debug.Log ("Cant find");
				}
			}
		}


	}
}
