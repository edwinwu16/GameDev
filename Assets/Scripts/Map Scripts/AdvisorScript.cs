using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Advisor{
	public string name;
	public string type;
	public float price;
	//public float weeklycost;
	public bool hired;


	public Advisor(string n, string typ, float pr, bool isHired) {
		name = n;
		type = typ;
		price = pr;
		//weeklycost = wkcost;
		hired = isHired;
	}
}

public class AdvisorScript : MonoBehaviour {
	

	public List<Advisor> myAdvisors = new List<Advisor> ();
	private List<Advisor> availableAdvisors = new List<Advisor> ();

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
		myAdvisors.Add(new Advisor("Charmander", "Environment", 1000, false));
		myAdvisors.Add(new Advisor("Squirtle", "Finance", 1500, false));
		myAdvisors.Add(new Advisor("Bulbasaur", "Healthcare", 2000, false));
		myAdvisors.Add(new Advisor("Pikachu", "Immigration", 3000, false));
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
			col3.GetComponent<Text> ().text = String.Format("{0:C}", curadvisor.type);
			col3.transform.parent = newrowski.transform;
			GameObject remove = Instantiate (removeadvisorbtn);
			remove.GetComponent<RemoveAdvisorScript> ().index = i;
			remove.GetComponent<RemoveAdvisorScript> ().advisorpanel = advisorpanel;
			remove.transform.parent = newrowski.transform;
		}
		GameObject blankrowski = Instantiate (rowski);
		blankrowski.transform.parent = tableski.transform;
		for (int i = 0; i < availableAdvisors.Count; i++) {
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
			col3.GetComponent<Text> ().text = String.Format("{0:C}", curadvisor.type);
			col3.transform.parent = newrowski.transform;
			GameObject add = Instantiate (addadvisorbtn);
			add.GetComponent<AddAdvisorScript> ().index = i;
			add.GetComponent<AddAdvisorScript> ().advisorpanel = advisorpanel;
			add.transform.parent = newrowski.transform;
		}
	}
}
