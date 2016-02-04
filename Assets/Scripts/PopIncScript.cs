using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopIncScript : MonoBehaviour {
	public Button btntoIncreasePop;
	public int amounttoIncreasePop;
	public GameObject popupregion;
	// Use this for initialization
	void Start () {
		btntoIncreasePop.onClick.AddListener(() => increasePop(amounttoIncreasePop));
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	void increasePop(int i) {
		Debug.Log ("clickyyyy");
		popupregion.SendMessage ("IncreasePopularity", 10);
	}
}
