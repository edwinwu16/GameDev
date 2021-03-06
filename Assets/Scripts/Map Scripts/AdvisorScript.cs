﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Advisor{


	public string name;
	public List<string> type;
	public float price;
	//public float weeklycost;
    public List<int> tier;
	public bool hired;
    public List<Campaign> campaigns = new List<Campaign>();


	public Advisor(string n, List<string> typ, float pr, List<int> ter) {
		name = n;
		type = typ;
		price = pr;
        tier = ter;
        
		//weeklycost = wkcost;
	}

    public Advisor(string n, List<string> typ, float pr, List<int> ter, List<Campaign> camp)
    {
        name = n;
        type = typ;
        price = pr;
        tier = ter;
        campaigns = camp;

        //weeklycost = wkcost;
    }
}


public class AdvisorScript : MonoBehaviour {
	

	public List<Advisor> myAdvisors = new List<Advisor> ();
    public float preferredwidth1 = 0.3F;
    public float preferredwidth2 = 0.3F;
    public float preferredwidth3 = 0.2F;
    public float preferredwidth4 = 0.2F;
    public bool _newday = true;


	public List<Advisor> availableAdvisors = new List<Advisor> ()
    {
        new Advisor("Bulbasaur", new List<string>(){"Environment"}, 100000.0F, new List<int>(){1}),
        new Advisor("Charmander", new List<string>(){"Finance"}, 100000.0F, new List<int>(){1}),
        new Advisor("Pikachu", new List<string>(){"Immigration"}, 100000.0F, new List<int>(){1}),
        new Advisor("Squirtle", new List<string>(){"Healthcare"}, 100000.0F, new List<int>(){1}),
        new Advisor("Ivysaur", new List<string>(){"Environment"}, 200000.0F, new List<int>(){2}),
        new Advisor("Charmeleon", new List<string>(){"Finance"}, 200000.0F, new List<int>(){2}),
        new Advisor("Raichu", new List<string>(){"Immigration"}, 200000.0F, new List<int>(){2}),
        new Advisor("Wartortle", new List<string>(){"Healthcare"}, 200000.0F, new List<int>(){2}),
        new Advisor("Venosaur", new List<string>(){"Environment"}, 300000.0F, new List<int>(){3}),
        new Advisor("Charmeleon", new List<string>(){"Finance"}, 300000.0F, new List<int>(){3}),
        new Advisor("Shiny Pikachu", new List<string>(){"Immigration"}, 300000.0F, new List<int>(){3}),
        new Advisor("Blastoise", new List<string>(){"Healthcare"}, 300000.0F, new List<int>(){3}),
  
        new Advisor("Koch Brothers", new List<string>(){"Finance"}, 175000.0F, new List<int>(){2}),
        new Advisor("John Oliver", new List<string>(){"Healthcare"}, 125000.0F, new List<int>(){1}, new List<Campaign>(){new Campaign ("Last Week Tonight Interviews", 100, 25, 40, 20, "General")}),
        new Advisor("LLoyd Blankfein", new List<string>(){"Finance"}, 450000.0F, new List<int>(){4}, new List<Campaign>(){new Campaign("Let Goldman Get You NYC Voters", 1000, 100, 440, 20, "Finance")}),
        new Advisor("Bill Nye", new List<string>(){"Environment", "Healthcare"}, 200000.0F, new List<int>(){2, 2}, new List<Campaign>(){new Campaign("Get Bill to Talk to Millenials for You", 500, 50, 230, 20, "General")}),
        new Advisor("Queen Elizabeth", new List<string>(){"Immigration"}, 110000.0F, new List<int>(){1}, new List<Campaign>(){new Campaign("Get the British-American Vote", 800, 200, 400, 20, "General")}),



        new Advisor("James Dimon", new List<string>(){"Finance"}, 280000.0F, new List<int>(){3}),
        new Advisor("Bob Dudley", new List<string>(){"Environment", "Finance"}, 150000.0F, new List<int>(){1, 2}),

		new Advisor("Hector Sanchez", new List<string>(){"Immigration"}, 210000.0F, new List<int>(){2}),
		new Advisor("Cecilia Muñoz", new List<string>(){"Immigration"}, 100000.0F, new List<int>(){1}),
		new Advisor("Alan Greenspan", new List<string>(){"Finance"}, 290000.0F, new List<int>(){3}),
        new Advisor("John Stewart", new List<string>(){"Immigration"}, 110000.0F, new List<int>(){1}),
        new Advisor("Chris Jennings", new List<string>(){"Healthcare"}, 90000.0F, new List<int>(){1}),
		new Advisor("Howard Frumkin", new List<string>(){"Environment", "Healthcare"}, 100000.0F, new List<int>(){1, 1}),
		new Advisor("Barack Obama", new List<string>(){"Healthcare", "Finance"}, 220000.0F, new List<int>(){2, 2}),
        new Advisor("George W. Bush", new List<string>(){"Environment", "Finance", "Healthcare", "Immigration"}, 210000.0F, new List<int>(){1, 1, 1, 1}, new List <Campaign>(){new Campaign("Look Smarter By Comparison to George W.", 50, 25, 150, 15, "General")}),
        new Advisor("Bob Greenhill", new List<string>(){"Finance"}, 100000.0F, new List<int>(){1}),
        new Advisor("Bill Gates", new List<string>(){"Environment", "Finance", "Healthcare", "Immigration"}, 350000.0F, new List<int>(){2, 3, 2, 3}, new List<Campaign>(){new Campaign("Melinda & Gates Foundation Voice of Support", 600, 60, 350, 35, "General")}),
		new Advisor("Scott Serota", new List<string>(){"Healthcare"}, 250000.0F, new List<int>(){2}),
        new Advisor("Ben Bernanke", new List<string>(){"Finance"}, 100090.0F, new List<int>(){3}),

    };

	public GameObject colski;
	public GameObject rowski;
	public GameObject activeadviserpane;
	public GameObject removeadvisorbtn;
	public GameObject addadvisorbtn;
	public GameObject advisorpanel;
	public GameObject popupregion;
    public GameObject availableadviserpane;

	public float totalAdvisorCost;

	// Use this for initialization
	void Start () {
		PopulateAdvisors();
		makeRows ();
	}

	// Update is called once per frame
	void Update () {
//		foreach (Advisor advis in myAdvisors) {
//			if (advis.hired == false) {
//				myAdvisors.Remove (advis);
//				availableAdvisors.Add (advis);
//			}
//		}
//		foreach (Advisor advis in availableAdvisors) {
//			if (advis.hired == true) {
//				availableAdvisors.Remove (advis);			
//				myAdvisors.Add (advis);
//				}
//		}
//		GetTotalAdvisorCost ();
	}

//	public Advisor GenerateAdvisor(){
//		List<string> nameList = new List<string> ();
//	}

	void BuyAdvisor(Advisor advisor){
		advisor.hired = true;
		makeRows ();
	}
	void FireAdvisor(Advisor advisor){
		advisor.hired = false;
		makeRows ();
	}
	public void RemoveAdvisor (int i) {
		Advisor advisor = myAdvisors [i];
		myAdvisors.RemoveAt (i);
		availableAdvisors.Add (advisor);
		makeRows ();
	}
	public void AddAdvisor (Advisor curadvisor) {
		availableAdvisors.Remove (curadvisor);
		popupregion.GetComponent<PopupScript> ().IncreaseMoney (-curadvisor.price);
        GameObject[] corpbuts = GameObject.FindGameObjectsWithTag("AdvBut");
        for (int j = 0; j < corpbuts.Length; j++)
        {
            if (corpbuts[j].GetComponent<AddAdvisorScript>().curadvisor == curadvisor)
                Destroy(corpbuts[j].transform.parent.gameObject);
        }

		myAdvisors.Add (curadvisor);
        popupregion.GetComponent<PopupScript>().addToAllCampaigns(curadvisor);
		makeRows ();
	}


	void PopulateAdvisors(){
        foreach (Advisor adviser in availableAdvisors)
        {
            for (int i = 0; i < adviser.type.Count; i ++ )
            {
                for (int j = 0; j < adviser.tier[i]; j++)
                {
                    adviser.campaigns.AddRange(popupregion.GetComponent<PopupScript>().specialcampaigns[adviser.type[i]][j]);
                }
            }
        }
		}

	public float GetTotalAdvisorCost(){
		float cost = 0;
		foreach (Advisor advis in myAdvisors) 
			cost += advis.price;
		totalAdvisorCost = cost;
		return totalAdvisorCost;
	}

	public void makeRows () {
        float totalscreenwidth = RectTransformExtensions.GetWidth(activeadviserpane.GetComponent<RectTransform>());
        float firstrowwidth = totalscreenwidth * preferredwidth1;
        float secondrowwidth = totalscreenwidth * preferredwidth2;
        float thirdrowwidth = totalscreenwidth * preferredwidth3;
        float fourthrowwidth = totalscreenwidth * preferredwidth4;
		var children = new List<GameObject>();
		foreach (Transform child in activeadviserpane.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

        GameObject firstrowski = Instantiate(rowski);
        firstrowski.transform.parent = activeadviserpane.transform;

        GameObject fstcol = Instantiate(colski);
        fstcol.GetComponent<Text>().text = "Cost to Buy";
        fstcol.transform.parent = firstrowski.transform;
        fstcol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;

        GameObject scndcol = Instantiate(colski);
        scndcol.GetComponent<Text>().text = "Name";
        scndcol.transform.parent = firstrowski.transform;
        scndcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;

        GameObject thrdcol = Instantiate(colski);
        thrdcol.GetComponent<Text>().text = "Types (Campaign Tier)";
        thrdcol.transform.parent = firstrowski.transform;
        thrdcol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;


        GameObject lstcol = Instantiate(colski);
        lstcol.GetComponent<Text>().text = "";
        lstcol.transform.parent = firstrowski.transform;
        lstcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;

		for (int i = 0; i < myAdvisors.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Advisor curadvisor = myAdvisors [i];
			newrowski.transform.parent = activeadviserpane.transform;
			GameObject col1 = Instantiate (colski);
			col1.GetComponent<Text> ().text = String.Format("{0:C}", curadvisor.price);
			col1.transform.parent = newrowski.transform;
			GameObject col2 = Instantiate (colski);
			col2.GetComponent<Text> ().text = String.Format("{0:C}", curadvisor.name);
			col2.transform.parent = newrowski.transform;
			GameObject col3 = Instantiate (colski);
            string type = "";
            for (int k = 0; k < curadvisor.type.Count; k++)
            {
                type = type + curadvisor.type[k] + "(" + curadvisor.tier[k] + ") ";
            }
            col3.GetComponent<Text>().text = String.Format("{0:C}", type);
			col3.transform.parent = newrowski.transform;
			GameObject remove = Instantiate (removeadvisorbtn);
			remove.GetComponent<RemoveAdvisorScript> ().index = i;
			remove.GetComponent<RemoveAdvisorScript> ().advisorpanel = advisorpanel;
			remove.transform.parent = newrowski.transform;
            col1.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
            col2.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
            col3.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;

		} 
		GameObject blankrowski = Instantiate (rowski);
		blankrowski.transform.parent = availableadviserpane.transform;
        totalscreenwidth = RectTransformExtensions.GetWidth(availableadviserpane.GetComponent<RectTransform>());
        firstrowwidth = totalscreenwidth * preferredwidth1;
        secondrowwidth = totalscreenwidth * preferredwidth2;
        thirdrowwidth = totalscreenwidth * preferredwidth3;
        fourthrowwidth = totalscreenwidth * preferredwidth4;
        if (_newday) {
            foreach (Transform child in availableadviserpane.transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
            GameObject firstrowski1 = Instantiate(rowski);
            firstrowski1.transform.parent = availableadviserpane.transform;

            GameObject fstcol1 = Instantiate(colski);
            fstcol1.GetComponent<Text>().text = "Cost to Buy";
            fstcol1.transform.parent = firstrowski1.transform;
            fstcol1.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;

            GameObject scndcol1 = Instantiate(colski);
            scndcol1.GetComponent<Text>().text = "Name";
            scndcol1.transform.parent = firstrowski1.transform;
            scndcol1.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;

            GameObject thrdcol1 = Instantiate(colski);
            thrdcol1.GetComponent<Text>().text = "Types (Campaign Tier)";
            thrdcol1.transform.parent = firstrowski1.transform;
            thrdcol1.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;


            GameObject lstcol1 = Instantiate(colski);
            lstcol1.GetComponent<Text>().text = "";
            lstcol1.transform.parent = firstrowski1.transform;
            lstcol1.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
            _newday = false;
            List<int> b = new List<int>();
		    for (int j = 0; j < 3; j++) {
                
                int i = UnityEngine.Random.Range(0, availableAdvisors.Count);
                while (b.Contains(i)){
                    i = UnityEngine.Random.Range(0, availableAdvisors.Count);
                }
                b.Add(i);
			    Debug.Log ("availableAdvisors: " + availableAdvisors.Count);
			    GameObject newrowski = Instantiate (rowski);
			    Advisor curadvisor = availableAdvisors [i];
			    newrowski.transform.parent = availableadviserpane.transform;
			    GameObject col1 = Instantiate (colski);
			    col1.GetComponent<Text> ().text = String.Format("{0:C}", curadvisor.price);
			    col1.transform.parent = newrowski.transform;
			    GameObject col2 = Instantiate (colski);
			    col2.GetComponent<Text> ().text = String.Format("{0:C}", curadvisor.name);
			    col2.transform.parent = newrowski.transform;
			    GameObject col3 = Instantiate (colski);
                string type = "";
                for (int k = 0; k < curadvisor.type.Count; k++)
                {
                    Debug.Log(curadvisor.type[k]);
                    Debug.Log(curadvisor.tier[k]);
                    type = type + curadvisor.type[k] + "(" + curadvisor.tier[k] + ") ";
                }
			    col3.GetComponent<Text> ().text = String.Format("{0:C}", type);
			    col3.transform.parent = newrowski.transform;
			    GameObject add = Instantiate (addadvisorbtn);
			    add.GetComponent<AddAdvisorScript> ().curadvisor = curadvisor;
			    add.GetComponent<AddAdvisorScript> ().advisorpanel = advisorpanel;
			    add.transform.parent = newrowski.transform;
                col1.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
                col2.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
                col3.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
                add.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;

		    }
        }
	}
}
