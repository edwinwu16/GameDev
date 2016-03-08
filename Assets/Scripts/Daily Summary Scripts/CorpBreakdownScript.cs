using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Globalization;

public class CorpBreakdownScript : MonoBehaviour {
	public GameObject popup;
	public GameObject colski;
	public GameObject rowski;
	public GameObject breakdowntable;
	public GameObject corpobj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakeRows() {
		float totalscreenwidth = RectTransformExtensions.GetWidth(breakdowntable.GetComponent<RectTransform>());
		float preferredwidth1 = totalscreenwidth * 0.33333F;
		float preferredwidth2 = totalscreenwidth * 0.33333F;
		float preferredwidth3 = totalscreenwidth * 0.33333F;
//		float preferredwidth4 = totalscreenwidth * 0.20F;
//		float preferredwidth5 = totalscreenwidth * 0.20F;

		var children = new List<GameObject>();
		foreach (Transform child in breakdowntable.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		GameObject firstrow = Instantiate (rowski);
		firstrow.transform.parent = breakdowntable.transform;
		GameObject firstcol = Instantiate (colski);
		firstcol.GetComponent<Text> ().text = "Name";
		firstcol.transform.parent = firstrow.transform;
		GameObject secondcol = Instantiate(colski);
		secondcol.GetComponent<Text>().text = "Total Money Earned";
		secondcol.transform.parent = firstrow.transform;
		GameObject thirdcol = Instantiate (colski);
		thirdcol.GetComponent<Text> ().text = "Money Earned Yesterday";
		thirdcol.transform.parent = firstrow.transform;

//		GameObject thirdcol = Instantiate (colski);
//		thirdcol.GetComponent<Text> ().text = "Votes Earned (1D)";
//		thirdcol.transform.parent = firstrow.transform;
//		GameObject fourthcol = Instantiate (colski);
//		fourthcol.GetComponent<Text> ().text = "Money Spent (1D)";
//		fourthcol.transform.parent = firstrow.transform;

		firstcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
		secondcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
		thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
//		thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
//		fourthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;



		foreach(Corporation corp in corpobj.GetComponent<CorpScript>().corporationsowned)
		{
//			List<Campaign> curcamps = new List<Campaign> ();
//			curcamps = popup.GetComponent<PopupScript> ().activecampaigns [entry.Key];
			firstrow = Instantiate (rowski);
			firstrow.transform.parent = breakdowntable.transform;
			firstcol = Instantiate (colski);
			firstcol.GetComponent<Text> ().text = corp.name;
			firstcol.transform.parent = firstrow.transform;
			secondcol = Instantiate(colski);
			float moneysum = 0.0f;
			foreach (float m in corp.weeklymonies) {
				moneysum += m;
			}

			string moneysumstr = String.Format ("{0:C2}", moneysum);
			secondcol.GetComponent<Text> ().text = moneysumstr;
			secondcol.transform.parent = firstrow.transform;
			secondcol = Instantiate (colski);

			thirdcol = Instantiate (colski);
			string moneystr = String.Format ("{0:C2}", corp.weeklymonies [corp.weeklymonies.Count - 1]);
			thirdcol.GetComponent<Text> ().text = moneystr;
			thirdcol.transform.parent = firstrow.transform;

//			firstcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
//			secondcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
//			thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
					// do something with entry.Value or entr


		}
	}
}
