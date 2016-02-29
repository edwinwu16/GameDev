using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextDayMoneyScript : MonoBehaviour {
    public Text text;
    public GameObject popup;
	// Use this for initialization
	void Start () {
        text.text = string.Format("Projected $$: {0:C}", popup.GetComponent<PopupScript>().getCost());
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = string.Format("Projected $$: {0:C}", popup.GetComponent<PopupScript>().getCost());

	}
}
