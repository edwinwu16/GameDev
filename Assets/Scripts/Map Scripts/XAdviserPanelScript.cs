using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class XAdviserPanelScript : MonoBehaviour {
	public Button xButton;
	public GameObject adviserpanel;


	// Use this for initialization
	void Start () {
		xButton.onClick.AddListener(() => sendClick());
	}

	// Update is called once per frame
	void Update () {

	}
	private void sendClick() {
		adviserpanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(3000f, 3000f, 0);
	}
}
