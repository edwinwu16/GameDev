using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegionScript : MonoBehaviour {
	public int popularityValue;
	public Button region;
	public GameObject maincamera;
	public GameObject popup;
	public GameObject tutorial;

	// Use this for initialization
	void Start () {
		popularityValue = 70;
		region.onClick.AddListener(() => sendClick());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void sendClick() {
		maincamera.SendMessage ("ShowBox");
		popup.SendMessage ("SetClickedRegion", region.name);
		if (region.name == "West") {
			Debug.Log ("SENDITBRAAA");
			tutorial.SendMessage ("ThingClicked", "west");
		}
		Debug.Log (region.name + "clicked");
	}
}
