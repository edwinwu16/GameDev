using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalizeAttackAddScript : MonoBehaviour {
	public Attack index;
	public GameObject attackpanel;
	public Button self;
	// Use this for initialization
	void Start () {
		attackpanel = GameObject.Find ("AttackMarketplacePanel");
		self.onClick.AddListener(() => { onClickAdd(attackpanel.GetComponent<AttackMarketplaceScript>().curattacktoadd);});
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(Attack i) {
		//			attackpanel.GetComponent<AttackMarketplaceScript>().AddAttack(i);
		attackpanel.GetComponent<AttackMarketplaceScript> ().AddAttack (i);
	}
}