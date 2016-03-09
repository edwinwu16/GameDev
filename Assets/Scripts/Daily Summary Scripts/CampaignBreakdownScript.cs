using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Globalization;

public class CampaignBreakdownScript : MonoBehaviour {
	public GameObject popup;
	public GameObject colski;
	public GameObject rowski;
	public GameObject breakdowntable;
	private string curregion;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void MakeRows() {
		float totalscreenwidth = RectTransformExtensions.GetWidth(breakdowntable.GetComponent<RectTransform>());
		float preferredwidth1 = totalscreenwidth * 0.20F;
		float preferredwidth2 = totalscreenwidth * 0.20F;
		float preferredwidth3 = totalscreenwidth * 0.20F;
		float preferredwidth4 = totalscreenwidth * 0.20F;
        float preferredwidth5 = totalscreenwidth * 0.20F;

		var children = new List<GameObject>();
		foreach (Transform child in breakdowntable.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		GameObject firstrow = Instantiate (rowski);
		firstrow.transform.parent = breakdowntable.transform;
		GameObject firstcol = Instantiate (colski);
		firstcol.GetComponent<Text> ().text = "Name";
		firstcol.transform.parent = firstrow.transform;
        GameObject firstseccol = Instantiate(colski);
        firstseccol.GetComponent<Text>().text = "Campaign Region";
        firstseccol.transform.parent = firstrow.transform;
        GameObject secondcol = Instantiate (colski);
		secondcol.GetComponent<Text> ().text = "Campaign Type";
		secondcol.transform.parent = firstrow.transform;
		
        GameObject thirdcol = Instantiate (colski);
		thirdcol.GetComponent<Text> ().text = "Votes Earned Yesterday";
		thirdcol.transform.parent = firstrow.transform;
		GameObject fourthcol = Instantiate (colski);
		fourthcol.GetComponent<Text> ().text = "Money Spent Yesterday";
		fourthcol.transform.parent = firstrow.transform;

		firstcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
        firstseccol.GetComponent<LayoutElement>().preferredWidth = preferredwidth5;
        secondcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
		thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
		fourthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;



		foreach(KeyValuePair<string, Region> entry in popup.GetComponent<PopupScript>().regions)
		{
			List<Campaign> curcamps = new List<Campaign> ();
			curcamps = popup.GetComponent<PopupScript> ().activecampaigns [entry.Key];
			foreach (Campaign camp in curcamps) {
				if (camp != null) {
					firstrow = Instantiate (rowski);
					firstrow.transform.parent = breakdowntable.transform;
					firstcol = Instantiate (colski);
					firstcol.GetComponent<Text> ().text = camp.name;
					firstcol.transform.parent = firstrow.transform;
                    firstseccol = Instantiate(colski);
                    firstseccol.GetComponent<Text>().text = camp.region;
                    firstseccol.transform.parent = firstrow.transform;
					secondcol = Instantiate (colski);
					secondcol.GetComponent<Text> ().text = camp.type;
					secondcol.transform.parent = firstrow.transform;
					thirdcol = Instantiate (colski);
					Debug.Log ("votesMINUS1" + camp.costovertimecamp [camp.votesovertimecamp.Count - 1]);
					Debug.Log ("votesMINUS2" + camp.costovertimecamp [camp.votesovertimecamp.Count - 2]);
					thirdcol.GetComponent<Text> ().text = String.Format("{0:n0}", camp.votesovertimecamp[camp.votesovertimecamp.Count-1] - camp.votesovertimecamp[camp.votesovertimecamp.Count-2]);
					thirdcol.transform.parent = firstrow.transform;
					fourthcol = Instantiate (colski);

					var original = new CultureInfo("en-us");
					var modified = (CultureInfo) original.Clone();
					modified.NumberFormat.CurrencyNegativePattern = 1; 
					float costdiff = camp.costovertimecamp [camp.costovertimecamp.Count - 1] - camp.costovertimecamp [camp.costovertimecamp.Count - 2];
//					string moneystring = costdiff.ToString(modified, "{0:}", );
//	 				if (costdiff < 0)
//						moneystring = moneystring.Substring(1);
					String cst = String.Format(modified, "{0:C2}", costdiff);
					if (cst [0] == '-') {
						cst = cst.Substring (1);
					}
					fourthcol.GetComponent<Text> ().text = cst;
					fourthcol.transform.parent = firstrow.transform;


					firstcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
                    firstseccol.GetComponent<LayoutElement>().preferredWidth = preferredwidth5;
					secondcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
					thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
					fourthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;
					// do something with entry.Value or entry.Key
				}


			}
		}


	}
}
