using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	private Animator animator;

	public GameObject arrow_Up;
	public GameObject arrow_Down;
	public GameObject arrow_Left;
	public GameObject arrow_Right;

	private bool Up;
	private bool Down;
	private bool Left;
	private bool Right;

	private int Dir;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		Dir = 0;
		Up = false;
		Down = false;
		Left = false;
		Right = false;
	}

	// Update is called once per frame
	void Update () {
		//animator.SetBool ("Idle", false);
		animator.SetInteger ("Direction", Dir);

		if (!Up && !Down && !Left && !Right) 
			animator.SetBool ("Idle", true);
		 else 
			animator.SetBool ("Idle", false);
	}

	public void ClickedUp() {
		Up = true;
		Dir = 2;
	}

	public void Not_ClickedUp() {
		Up = false;
	}

	public void ClickedDown() {
		Down = true;
		Dir = 0;
	}

	public void Not_ClickedDown() {
		Down = false;
	}

	public void ClickedLeft() {
		Left = true;
		Dir = 1;
	}

	public void Not_ClickedLeft() {
		Left = false;
	}

	public void ClickedRight() {
		Right = true;
		Dir = 3;
	}

	public void Not_ClickedRight() {
		Right = false;
	}
}
