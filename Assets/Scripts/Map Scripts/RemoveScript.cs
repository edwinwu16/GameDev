using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemoveScript : MonoBehaviour {
	public int index;
	public GameObject corppanel;
	public Button self;
	// Use this for initialization
	void Start () {
		corppanel = GameObject.Find ("Corp Panel");
		self.onClick.AddListener(() => { onClickRemove(index);}); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickRemove(int i) {
		Debug.Log ("CLICKY");
		corppanel.GetComponent<CorpScript> ().RemoveCorporation (i);
	}
}
