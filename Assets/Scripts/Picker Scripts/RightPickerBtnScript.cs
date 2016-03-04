using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RightPickerBtnScript : MonoBehaviour {
	public Button self;
	public GameObject pickerpanel;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => { onClickRight(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void onClickRight() {
		pickerpanel.SendMessage ("RightArrowClicked");
	}
}
