using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishBattleScript : MonoBehaviour {
	public Button continuebutton;
	public GameObject self;
	public GameObject maincanvas;
	public GameObject battlecanvas;
	public GameObject battleobj;
	public string winner;
	// Use this for initialization
	void Start () {
		continuebutton.onClick.AddListener(() => sendClick());

	}
	
	// Update is called once per frame
	void Update () {
		self.GetComponentInChildren<Text> ().text = "";
		self.GetComponentInChildren<Text> ().text = winner + " WINS: AP POLL SUGGESTS A " + "10% JUMP IN VOTES";

	
	}

	void sendClick (){
		self.transform.localPosition = new Vector3 (-1000.0F, -1000.0F, 0.0F);
		maincanvas.SetActive (true);
		battlecanvas.SetActive (false);
		battleobj.GetComponent<BattleScript> ().inbattle = false;
		Debug.Log ("inFinishBattleScript");

	}

}
