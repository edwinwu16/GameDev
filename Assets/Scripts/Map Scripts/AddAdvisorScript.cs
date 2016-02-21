using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AddAdvisorScript : MonoBehaviour {

	public int index;
	public GameObject advisorpanel;
	public Button self;
	// Use this for initialization
	void Start () {
		advisorpanel = GameObject.Find ("Adviser Panel");
		self.onClick.AddListener(() => { onClickAdd(index);}); 
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(int i) {
		Debug.Log ("CLICKY Add");
		advisorpanel.GetComponent<AdvisorScript> ().AddAdvisor (i);
	}
}