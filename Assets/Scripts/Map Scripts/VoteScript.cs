using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class VoteScript : MonoBehaviour {
	public GameObject votestbl;
	public GameObject buybtn;
	public GameObject rowski;
	public GameObject colski;
	public GameObject self;
	public GameObject popup;
    public float preferredwidth1 = 0.3F;
    public float preferredwidth2 = 0.3F;
    public float preferredwidth3 = 0.2F;
    public float preferredwidth4 = 0.2F;
	public List<Voter> voters = new List<Voter> ();
	// Use this for initialization
	void Start () {
		Voter hisp = new Voter (1000, "Hispanic", 10000);
		voters.Add (hisp);
		makeRows ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void makeRows() {
        float totalscreenwidth = RectTransformExtensions.GetWidth(votestbl.GetComponent<RectTransform>());
        float firstrowwidth = totalscreenwidth * preferredwidth1;
        float secondrowwidth = totalscreenwidth * preferredwidth2;
        float thirdrowwidth = totalscreenwidth * preferredwidth3;
        float fourthrowwidth = totalscreenwidth * preferredwidth4;
		var children = new List<GameObject>();
		foreach (Transform child in votestbl.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		GameObject firstrow = Instantiate (rowski);
		firstrow.transform.parent = votestbl.transform;
		GameObject firstcol = Instantiate (colski);
		firstcol.GetComponent<Text> ().text = "Cost to Buy";
		firstcol.transform.parent = firstrow.transform;
		GameObject secondcol = Instantiate (colski);
		secondcol.GetComponent<Text> ().text = "Type of Voter";
		secondcol.transform.parent = firstrow.transform;
		GameObject thirdcol = Instantiate (colski);
		thirdcol.GetComponent<Text> ().text = "Amount Owned";
		thirdcol.transform.parent = firstrow.transform;
		GameObject fourthcol = Instantiate (colski);
		fourthcol.GetComponent<Text> ().text = "";
		fourthcol.transform.parent = firstrow.transform;
        firstcol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
        secondcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
        thirdcol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
        fourthcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;

		for (int i = 0; i < voters.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Voter curvoter = voters [i];
			newrowski.transform.parent = votestbl.transform;
			GameObject cost2buycol = Instantiate (colski);
			cost2buycol.GetComponent<Text> ().text = String.Format("{0:C}", curvoter.costtobuy);
			cost2buycol.transform.parent = newrowski.transform;
			GameObject namecol = Instantiate (colski);
			namecol.GetComponent<Text> ().text = String.Format("{0}", curvoter.name);
			namecol.transform.parent = newrowski.transform;
			GameObject numownedcol = Instantiate (colski);
			numownedcol.GetComponent<Text> ().text = String.Format("{0}", curvoter.numowned);
			numownedcol.transform.parent = newrowski.transform;
			GameObject buybtn1 = Instantiate (buybtn);
			buybtn1.GetComponent<VoteBuyScript> ().index = i;
			buybtn1.GetComponent<VoteBuyScript> ().amount = 1000;
			buybtn1.GetComponent<VoteBuyScript> ().votespanel = votestbl;
			buybtn1.transform.parent = newrowski.transform;
            cost2buycol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
            namecol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
            numownedcol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;

		}
	}

	public void buyVotes(int index, int amount){
		Debug.Log ("INBUYVOTES");
		voters [index].numowned += amount;
		popup.GetComponent<PopupScript>().IncreaseMoney (-amount);
		popup.GetComponent<PopupScript> ().IncreasePopularityGeneral (amount);
		makeRows ();
	}
}
public class Voter {
	public int costtobuy;
	public string name;
	public int numowned;
	public Voter(int cost, string nme, int numownd) {
		costtobuy = cost;
		name = nme;
		numowned = numownd;
	}
}
