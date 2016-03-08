using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IncrementWeekButton : MonoBehaviour {
	public Button self;
	public GameObject popup;
	public GameObject breakdownpane;
	// Use this for initialization
	public GameObject corpbreakdownpane;
	void Start () {
		self.onClick.AddListener(() => { onClickAdd(); });
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd()
	{
		popup.GetComponent<PopupScript>().decrementDaysLeft();
		breakdownpane.GetComponent<CampaignBreakdownScript> ().MakeRows ();
		corpbreakdownpane.GetComponent<CorpBreakdownScript> ().MakeRows ();
	}
}