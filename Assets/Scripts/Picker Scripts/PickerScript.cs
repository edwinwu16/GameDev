using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickerThing {
	public string name;
	public string description;
	public Sprite pic;

	public PickerThing(string n, string d, Sprite p) {
		name = n;
		description = d;
		pic = p;
	}
}

public class PickerScript : MonoBehaviour {
	public Sprite HilSprite;
	public Sprite BernSprite;
	public Sprite TrumpSprite;

	public Text nametext;
	public Text desctext;
	public Image image;

	public List<PickerThing> things = new List<PickerThing>();
	public int thingindex = 0;
	// Use this for initialization
	void Start () {
		PickerThing hillaryPick = new PickerThing ("Hillary Clinton", "Hillary is a fierce, corporate America-loving, Democrat. She loves long walks on the beach with Bill" +
		                      " (and Monica too!). She's got great relationships with those in the Finance world. She'll be a good person to get you some quick early money from " +
		                      "Goldman.", HilSprite);
		PickerThing berniePick = new PickerThing ("Bernie Sanders", "Bernie is an old, establishment-hating, Democrat. He likes putting his index finger in the air in order to sense" +
			" the direction of the wind and look like an angry old guy. He's an environmentalist, so he's got a good relationship with the Hippies.", BernSprite);
		PickerThing trumpPick = new PickerThing ("Donald Trump", "Donnie is a beautiful blend of corporate America, celebrity, and politician. He likes " +
		                        " money and being in the spotlight. He's got a great relationship with big fence companies, but watch out, he'll hurt you with the Immigrant voters.", TrumpSprite);
			 

		things = new List<PickerThing> () {hillaryPick, berniePick};
		ShowPick (thingindex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void ShowPick(int index) {
		image.GetComponent<Image> ().sprite = things [index].pic;
		nametext.GetComponent<Text> ().text = things [index].name;
		desctext.GetComponent<Text> ().text = things [index].description;
	}

	public void RightArrowClicked() {
		thingindex += 1;
		ShowPick (thingindex % things.Count);
	}

	public void LeftArrowClicked() {
		thingindex -= 1;
		ShowPick (thingindex % things.Count);
	}
}
