using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Xattackpanelscript : MonoBehaviour {
	public Button xButton;
	public GameObject atkpanel;
	public GameObject tutorial;
	// Use this for initialization
	void Start () {
		xButton.onClick.AddListener(() => sendClick());
	}

	// Update is called once per frame
	void Update () {

	}
	private void sendClick() {
		atkpanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(3000f, 3000f, 0);
		tutorial.SendMessage ("ThingClicked", "atkx");
	}
}
