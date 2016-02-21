using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XVotePanelScript : MonoBehaviour {
	public Button xButton;
	public GameObject votepanel;


	// Use this for initialization
	void Start () {
		xButton.onClick.AddListener(() => sendClick());
	}

	// Update is called once per frame
	void Update () {

	}
	private void sendClick() {
		votepanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(3000f, 3000f, 0);
	}

}
