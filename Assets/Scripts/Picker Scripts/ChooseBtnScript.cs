using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseBtnScript : MonoBehaviour {
	public Button self;
	public GameObject popup;
	public GameObject picker;
//	public GameObject fighter;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => sendClick());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void sendClick() {
		string person = picker.GetComponent<PickerScript> ().things[picker.GetComponent<PickerScript> ().thingindex % picker.GetComponent<PickerScript> ().things.Count].name;
		popup.GetComponent<PopupScript> ().ChoosePlayer (person);
	}
}
