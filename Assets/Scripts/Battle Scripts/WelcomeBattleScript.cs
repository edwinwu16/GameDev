using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WelcomeBattleScript : MonoBehaviour {
	public Button continuebutton;
	public GameObject self;
	public GameObject maincanvas;
	public GameObject battlecanvas;
	public GameObject battleobj;
	public string challenger;
	// Use this for initialization
	void Start () {
		continuebutton.onClick.AddListener(() => sendClick());
	}

	// Update is called once per frame
	void Update () {
		self.GetComponentInChildren<Text> ().text = "";
		self.GetComponentInChildren<Text> ().text = challenger + " Challenges YOU";


	}

	void sendClick (){
		self.transform.localPosition = new Vector3 (-1000.0F, -1000.0F, 0.0F);
		battleobj.GetComponent<BattleScript> ().inbattle = true;
	}

}