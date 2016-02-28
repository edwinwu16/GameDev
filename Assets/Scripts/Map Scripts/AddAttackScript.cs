using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddAttackScript: MonoBehaviour {
	public int index;
	public GameObject attackpanel;
	public GameObject popup;
	public Button self;
	// Use this for initialization
	void Start () {
		popup = GameObject.Find("PopupRegion");

		attackpanel = GameObject.Find ("AttackMarketplacePanel");
		self.onClick.AddListener(() => { onClickAdd(index);});
		self.onClick.AddListener(() => { self.interactable = false; });
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(int i) {
			attackpanel.GetComponent<AttackMarketplaceScript>().AddAttack(i);
		attackpanel.GetComponent<AttackMarketplaceScript> ().ShowDropdown ();
	}
}
