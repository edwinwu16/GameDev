using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinueButtonScript : MonoBehaviour {
	public Button self;
	public GameObject tutpanel;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => { onClickContinue();});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onClickContinue() {
		Debug.Log ("clicking");
		tutpanel.GetComponent<TuttyScript> ().ContinueClicked ();
	}
}
