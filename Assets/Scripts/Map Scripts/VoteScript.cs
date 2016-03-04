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
    public bool _newday = true;
    public float preferredwidth4 = 0.2F;
    public List<Voter> voters = new List<Voter>()
    {
        new Voter (1000000, "Leak Information that Trump is Bald", 1500000),
        new Voter (10000000, "Make a Wild Promise (i.e. Free Education, Single-Payer, Breaking up the Banks", 5000000),
        new Voter (1000000, "Stuff Ballet Boxes", 1000000),
        new Voter (10000000, "Start a Cult, Blow up Trump Tower Fight Club Style", 8000000),
        new Voter (50000000, "Note that Trump Hates Immigrations but Has a Slovenian Wife", 50000000)
    };
	// Use this for initialization
	void Start () {
		
		makeRows ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void makeRows() {
        if (_newday) {
            _newday = false;
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

        for (int i = 0; i < 3; i++)
        {
            int j = UnityEngine.Random.Range(0, voters.Count - 1);
            GameObject newrowski = Instantiate(rowski);
            Voter curvoter = voters[j];
            newrowski.transform.parent = votestbl.transform;
            GameObject cost2buycol = Instantiate(colski);
            cost2buycol.GetComponent<Text>().text = String.Format("{0:C}", curvoter.costtobuy);
            cost2buycol.transform.parent = newrowski.transform;
            GameObject namecol = Instantiate(colski);
            namecol.GetComponent<Text>().text = String.Format("{0}", curvoter.name);
            namecol.transform.parent = newrowski.transform;
            GameObject numownedcol = Instantiate(colski);
            numownedcol.GetComponent<Text>().text = String.Format("{0}", curvoter.numowned);
            numownedcol.transform.parent = newrowski.transform;
            GameObject buybtn1 = Instantiate(buybtn);
            buybtn1.GetComponent<VoteBuyScript>().index = curvoter;
            buybtn1.GetComponent<VoteBuyScript>().amount = curvoter.costtobuy;
            buybtn1.GetComponent<VoteBuyScript>().votespanel = votestbl;
            buybtn1.transform.parent = newrowski.transform;
            cost2buycol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
            namecol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
            numownedcol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
        }
		}
	}

	public void buyVotes(Voter index, int amount){
		Debug.Log ("INBUYVOTES");
        voters.Remove(index);
		popup.GetComponent<PopupScript>().IncreaseMoney (-index.costtobuy);
		popup.GetComponent<PopupScript> ().IncreasePopularityGeneral (index.numowned);
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
