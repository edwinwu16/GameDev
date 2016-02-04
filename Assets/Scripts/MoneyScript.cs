using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UpdateMoneyText ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMoneyText ();
	}

	private void UpdateMoneyText () {
//		int monVal = GameObject.Find ("West").GetComponent<RegionScript> ().moneyValue;
//		monVal += GameObject.Find ("South").GetComponent<RegionScript> ().moneyValue;
//		GameObject scoreTextObject = this.gameObject;
//		Text textComponent = scoreTextObject.GetComponent<Text>();
//		textComponent.text = string.Format("Money: {0}", monVal);
	}
}
