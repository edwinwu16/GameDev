using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
	public GameObject USA;
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
		GameObject scoreTextObject = this.gameObject;
		Text textComponent = scoreTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Money: {0:C}", money);
	}
}
