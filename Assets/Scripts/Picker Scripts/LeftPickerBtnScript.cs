using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeftPickerBtnScript : MonoBehaviour {
	public Button self;
	public GameObject pickerpanel;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => { onClickLeft(); });
	}

	// Update is called once per frame
	void Update () {

	}

	private void onClickLeft() {
		pickerpanel.SendMessage ("LeftArrowClicked");
	}
}