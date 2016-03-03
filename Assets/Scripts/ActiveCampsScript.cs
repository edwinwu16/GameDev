using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActiveCampsScript : MonoBehaviour {
	public GameObject tutorial;
	public Button self;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => sendClick());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void sendClick() {
		tutorial.SendMessage ("ThingClicked", "activecamps");
	}
}
