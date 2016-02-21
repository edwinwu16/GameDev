using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class CorpScript : MonoBehaviour {
	public GameObject rowski;
	public GameObject colski;
	public GameObject corpstbl;
	public GameObject removecorpbtn;
	public GameObject addcorpbtn;
	public GameObject corppanel;
	public GameObject popupregion;
	public List<Corporation> corporationsowned = new List<Corporation>();
	public List<Corporation> corporationstobuy = new List<Corporation>();

	// Use this for initialization
	void Start () {
		Corporation exxon = new Corporation (1000000, 10000, "Environment", "Exxon");
		corporationsowned.Add (exxon);
		Corporation goldman = new Corporation (2700000, 10000, "Finance", "Goldman Sachs");
		corporationsowned.Add (goldman);
		Corporation fencecorp = new Corporation (50000000, 7500, "Immigration", "FenceCorp");
		corporationstobuy.Add (fencecorp);
		Corporation jp = new Corporation (27000000, 8000, "Finance", "JP Morgan");
		corporationstobuy.Add (jp);
		makeRows ();
	}
	
	// Update is called once per frame
	void Update () {
//		makeToBuyRows ();
	}

	void makeRows () {
		var children = new List<GameObject>();
		foreach (Transform child in corpstbl.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		for (int i = 0; i < corporationsowned.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Corporation curcorp = corporationsowned [i];
			newrowski.transform.parent = corpstbl.transform;
			GameObject cost2buycol = Instantiate (colski);
			cost2buycol.GetComponent<Text> ().text = String.Format("{0:C}", curcorp.costtobuy);
			cost2buycol.transform.parent = newrowski.transform;
			GameObject namecol = Instantiate (colski);
			namecol.GetComponent<Text> ().text = String.Format("{0:C}", curcorp.name);
			namecol.transform.parent = newrowski.transform;
			GameObject typecol = Instantiate (colski);
			typecol.GetComponent<Text> ().text = String.Format("{0:C}", curcorp.type);
			typecol.transform.parent = newrowski.transform;
			GameObject remove = Instantiate (removecorpbtn);
			remove.GetComponent<RemoveScript> ().index = i;
			remove.GetComponent<RemoveScript> ().corppanel = corppanel;
			remove.transform.parent = newrowski.transform;
		}
		GameObject blankrowski = Instantiate (rowski);
		blankrowski.transform.parent = corpstbl.transform;

		for (int i = 0; i < corporationstobuy.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Corporation curcorp = corporationstobuy [i];
			newrowski.transform.parent = corpstbl.transform;
			GameObject cost2buycol = Instantiate (colski);
			cost2buycol.GetComponent<Text> ().text = String.Format("{0:C}", curcorp.costtobuy);
			cost2buycol.transform.parent = newrowski.transform;
			GameObject namecol = Instantiate (colski);
			namecol.GetComponent<Text> ().text = String.Format("{0:C}", curcorp.name);
			namecol.transform.parent = newrowski.transform;
			GameObject typecol = Instantiate (colski);
			typecol.GetComponent<Text> ().text = String.Format("{0:C}", curcorp.type);
			typecol.transform.parent = newrowski.transform;
			GameObject add = Instantiate (addcorpbtn);
			add.GetComponent<AddCorpScript> ().index = i;
			add.GetComponent<AddCorpScript> ().corppanel = corppanel;
			add.transform.parent = newrowski.transform;
		}
	}

	public void RemoveCorporation (int i) {
		Corporation corptomove = corporationsowned [i];
		corporationsowned.RemoveAt (i);
		corporationstobuy.Add (corptomove);
		makeRows ();
	}
	public void AddCorporation (int i) {
		Corporation corptomove = corporationstobuy [i];
		corporationstobuy.RemoveAt (i);
		popupregion.GetComponent<PopupScript> ().IncreaseMoney (-corptomove.costtobuy);
		corporationsowned.Add (corptomove);
		makeRows ();
	}

	public float GetWeeklyMoneyFromCorporations() {
		float totalmoney=0.0F;
		for (var i = 0; i < corporationsowned.Count; i++) {
			Corporation corptogetfundsfrom = corporationsowned [i];
			double multiplier = GenerateFromGaussian (1f, .2f);
			float moneytoget = corptogetfundsfrom.moneyperweek * (float)multiplier;
			totalmoney += moneytoget;
			corporationsowned [i].moneylastweek = moneytoget;
			corporationsowned [i].weeklymonies.Add(moneytoget);
		}
		return totalmoney;
	}

	public double GenerateFromGaussian(float mean, float stdDev) {
		System.Random rand = new System.Random(); //reuse this if you are generating many
		double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
		double u2 = rand.NextDouble();
		double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
			Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
		double randNormal =
			mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
		return randNormal;
	}
}

public class Corporation {
	public int costtobuy;
	public int moneyperweek;
	public string type;
	public string name;
	public float moneylastweek;
	public List<float> weeklymonies = new List<float>();
	public Corporation(int cost, int weeklymoney, string t, string n) {
		costtobuy = cost;
		moneyperweek = weeklymoney;
		type = t;
		name = n;
	}
}


