using UnityEngine;
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


	public Advisor(string n, List<string> typ, float pr, List<int> ter) {
		name = n;
		type = typ;
		price = pr;
        tier = ter;
		//weeklycost = wkcost;
	}
}


public class AdvisorScript : MonoBehaviour {
	

	public List<Advisor> myAdvisors = new List<Advisor> ();
	public List<Advisor> availableAdvisors = new List<Advisor> ()
    {
        new Advisor("Charmander", new List<string>(){"Environment"}, 100090.0F, new List<int>(){1}),
        new Advisor("Bob", new List<string>(){"Finance"}, 100090.0F, new List<int>(){2}),
        new Advisor("James", new List<string>(){"Finance"}, 100090.0F, new List<int>(){3}),
        new Advisor("Charmander", new List<string>(){"Environment", "Finance"}, 100090.0F, new List<int>(){1, 2}),
        new Advisor("imm", new List<string>(){"Immigration"}, 100090.0F, new List<int>(){2}),
        new Advisor("John", new List<string>(){"Immigration"}, 100090.0F, new List<int>(){1}),
        new Advisor("Koch", new List<string>(){"Finance"}, 100090.0F, new List<int>(){1}),
        new Advisor("Oliver", new List<string>(){"Healthcare"}, 100090.0F, new List<int>(){1}),
        new Advisor("W.", new List<string>(){"Healthcare"}, 100090.0F, new List<int>(){1}),
        new Advisor("James Bond", new List<string>(){"Environment", "Healthcare"}, 100090.0F, new List<int>(){1, 1}),
        new Advisor("Robert", new List<string>(){"Healthcare", "Finance"}, 100090.0F, new List<int>(){1, 1}),
        new Advisor("asdf", new List<string>(){"Environment", "Immigration"}, 100090.0F, new List<int>(){1, 2}),
        new Advisor("Asshat", new List<string>(){"Finance"}, 100090.0F, new List<int>(){1}),
        new Advisor("Tomorrow", new List<string>(){"Environment"}, 100090.0F, new List<int>(){1}),
        new Advisor("Espn", new List<string>(){"Healthcare"}, 100090.0F, new List<int>(){2}),
        new Advisor("Fuego", new List<string>(){"Finance"}, 100090.0F, new List<int>(){3}),

    };

	public GameObject colski;
	public GameObject rowski;
	public GameObject tableski;
	public GameObject removeadvisorbtn;
	public GameObject addadvisorbtn;
	public GameObject advisorpanel;
	public GameObject popupregion;

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
	public void AddAdvisor (int i) {
		Advisor advisor = availableAdvisors [i];
		availableAdvisors.RemoveAt (i);
		popupregion.GetComponent<PopupScript> ().IncreaseMoney (-advisor.price);
		myAdvisors.Add (advisor);
		makeRows ();
	}


	void PopulateAdvisors(){
		}

	public float GetTotalAdvisorCost(){
		float cost = 0;
		foreach (Advisor advis in myAdvisors) 
			cost += advis.price;
		totalAdvisorCost = cost;
		return totalAdvisorCost;
	}

	void makeRows () {
		var children = new List<GameObject>();
		foreach (Transform child in tableski.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		for (int i = 0; i < myAdvisors.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Advisor curadvisor = myAdvisors [i];
			newrowski.transform.parent = tableski.transform;
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
		} 
		GameObject blankrowski = Instantiate (rowski);
		blankrowski.transform.parent = tableski.transform;
		for (int j = 0; j < 3; j++) {
            int i = UnityEngine.Random.Range(0, availableAdvisors.Count - 1);
			Debug.Log ("availableAdvisors: " + availableAdvisors.Count);
			GameObject newrowski = Instantiate (rowski);
			Advisor curadvisor = availableAdvisors [i];
			newrowski.transform.parent = tableski.transform;
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
			add.GetComponent<AddAdvisorScript> ().index = i;
			add.GetComponent<AddAdvisorScript> ().advisorpanel = advisorpanel;
			add.transform.parent = newrowski.transform;
		}
	}
}
