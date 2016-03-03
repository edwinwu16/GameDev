using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoteMarketPlaceButtonScript : MonoBehaviour {
	public Button self;
	public GameObject votepanel;
	public GameObject tutorial;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => { onClickMarket(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void onClickMarket() {
		votepanel.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0f, 0f);
		tutorial.SendMessage ("ThingClicked", "votemark");
//		self.transform.localPosition (false);
	}
}
