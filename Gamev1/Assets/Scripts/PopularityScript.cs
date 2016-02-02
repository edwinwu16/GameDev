using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PopularityScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UpdatePopularityText ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePopularityText ();
	}

	private void UpdatePopularityText () {
		int popVal = GameObject.Find ("West").GetComponent<RegionScript> ().popularityValue;
		popVal += GameObject.Find ("South").GetComponent<RegionScript> ().popularityValue;
		GameObject scoreTextObject = this.gameObject;
		Text textComponent = scoreTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Popularity: {0}", popVal);
	}
		
}
