using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManageCorporationsButtonScript : MonoBehaviour {
	public Button self;
	public GameObject corppanel;
	public GameObject tutorial;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => { onClickCorp(); });
	}

	// Update is called once per frame
	void Update () {

	}
	void onClickCorp() {
		corppanel.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0f, 0f);
		corppanel.GetComponent<CorpScript> ().makeRows ();
		tutorial.SendMessage ("ThingClicked", "managecorps");
		//		self.transform.localPosition (false);
	}
}
