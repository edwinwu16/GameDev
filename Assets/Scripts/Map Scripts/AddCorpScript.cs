using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddCorpScript: MonoBehaviour {
	public int index;
	public GameObject corppanel;
	public Button self;
	// Use this for initialization
	void Start () {
		corppanel = GameObject.Find ("Corp Panel");
		self.onClick.AddListener(() => { onClickAdd(index);}); 
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(int i) {
		Debug.Log ("CLICKY Add");
		corppanel.GetComponent<CorpScript> ().AddCorporation (i);
	}
}
