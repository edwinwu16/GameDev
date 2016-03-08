using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
	public GameObject USA;
	public GameObject popup;
	// Use this for initialization
	void Start () {
		UpdateMoneyText ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMoneyText ();
	}

	private void UpdateMoneyText () {
		float money = USA.GetComponent<USAScript> ().money;
		List<float> moneylist = new List<float> ();
		moneylist = popup.GetComponent<PopupScript> ().moneyovertime;
		Debug.Log (String.Format("MoneyChecker: {0}", moneylist [moneylist.Count-1]));
		GameObject scoreTextObject = this.gameObject;
		Text textComponent = scoreTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Money: {0:C}", money);
	}
}
