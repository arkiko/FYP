using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {
	public Text print_info;

	public GameObject button;
	public GameObject image;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ClickedButton() {
		Scene scene = SceneManager.GetActiveScene();
		print_info.text = scene.name;

		image.SetActive (!image.activeSelf);
	}
}
