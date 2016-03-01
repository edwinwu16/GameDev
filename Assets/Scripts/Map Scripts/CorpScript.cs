﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class CorpScript : MonoBehaviour {
	public GameObject rowski;
	public GameObject colski;
	public GameObject activecorpstbl;
    public GameObject availablecorpstbl;
	public GameObject removecorpbtn;
	public GameObject addcorpbtn;
	public GameObject corppanel;
	public GameObject popupregion;
	public List<Corporation> corporationsowned = new List<Corporation>();
	public List<Corporation> corporationstobuy = new List<Corporation>(){
        new Corporation(1000000, 300000, "Environment", "BP"),
        new Corporation(2000000, 800000, "Environment", "Exxon"),
        new Corporation(600000, 30000, "Environment", "Cicero"),
        new Corporation(600000, 90000, "Environment", "Petrobas"),
        new Corporation(8000000, 200000, "Environment", "Saudi Aramco"),
        new Corporation(3000000, 300000, "Environment", "PetroChina"),
        new Corporation(1000000, 300000, "Environment", "Chevron"),
        new Corporation(80000, 20000, "Immigration", "LittleFenceCo"),
        new Corporation(160000, 80000, "Immigration", "BiggerFenceCo"),
        new Corporation (800000, 100000, "Immigration", "BigFenceCo"),
        new Corporation(1500000, 700000, "Immigration", "TrumpFenceCo"),
        new Corporation(5000000, 1100000, "Finance", "Citigroup"),
        new Corporation(3000000, 800000, "Finance", "Barclays"),
        new Corporation(500000, 100000, "Finance", "First Bank of Boston"),
        new Corporation(2000000, 800000, "Finance", "Morgan Stanley"),
        new Corporation(2000000, 800000, "Finance", "Credit Suisse"),
        new Corporation(2000000, 800000, "Finance", "Deutsche Bank"),
        new Corporation(1000000, 300000, "Healthcare", "Aetna"),
        new Corporation(2000000, 800000, "Healthcare", "Anthem"),
        new Corporation(600000, 30000, "Healthcare", "Blue Cross"),
        new Corporation(600000, 90000, "Healthcare", "Kaiser"),
        new Corporation(8000000, 200000, "Healthcare", "Cigna"),
        new Corporation(3000000, 300000, "Healthcare", "Centene"),
        new Corporation(1000000, 300000, "Healthcare", "United"),

    }


        
        ;
    public float preferredwidth1 = 0.3F;
    public float preferredwidth2 = 0.3F;
    public float preferredwidth3 = 0.2F;
    public float preferredwidth4 = 0.2F;
    public bool _newday = true;


	// Use this for initialization
	void Start () {
		Corporation goldman = new Corporation (3000000, 700000, "Finance", "Goldman Sachs");
		corporationsowned.Add (goldman);
		makeRows ();
	}
	
	// Update is called once per frame
	void Update () {
//		makeToBuyRows ();
	}

	void makeRows () {
        float totalscreenwidth = RectTransformExtensions.GetWidth(activecorpstbl.GetComponent<RectTransform>());
        float firstrowwidth = totalscreenwidth * preferredwidth1;
        float secondrowwidth = totalscreenwidth * preferredwidth2;
        float thirdrowwidth = totalscreenwidth * preferredwidth3;
        float fourthrowwidth = totalscreenwidth * preferredwidth4;
		var children = new List<GameObject>();
		foreach (Transform child in activecorpstbl.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		for (int i = 0; i < corporationsowned.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Corporation curcorp = corporationsowned [i];
			newrowski.transform.parent = activecorpstbl.transform;
			GameObject cost2buycol = Instantiate (colski);
			cost2buycol.GetComponent<Text> ().text = String.Format("{0:C}", curcorp.costtobuy);
			cost2buycol.transform.parent = newrowski.transform;
            GameObject moneyperweek = Instantiate(colski);
            moneyperweek.GetComponent<Text>().text = String.Format("{0:C}", curcorp.moneyperweek);
            moneyperweek.transform.parent = newrowski.transform;
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
            cost2buycol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
            namecol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
            typecol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;

		}
		GameObject blankrowski = Instantiate (rowski);
        totalscreenwidth = RectTransformExtensions.GetWidth(availablecorpstbl.GetComponent<RectTransform>());
        firstrowwidth = totalscreenwidth * preferredwidth1;
        secondrowwidth = totalscreenwidth * preferredwidth2;
        thirdrowwidth = totalscreenwidth * preferredwidth3;
        fourthrowwidth = totalscreenwidth * preferredwidth4;

        if (_newday)
        {
            _newday = false;
            foreach (Transform child in availablecorpstbl.transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));

            for (int i = 0; i < 5; i++)
            {
                int k = (int) UnityEngine.Random.RandomRange(0.0F, corporationstobuy.Count);
                Debug.Log(String.Format("k value = {0}", k));
                GameObject newrowski = Instantiate(rowski);
                Corporation curcorp = corporationstobuy[k];
                newrowski.transform.parent = availablecorpstbl.transform;
                GameObject cost2buycol = Instantiate(colski);
                cost2buycol.GetComponent<Text>().text = String.Format("{0:C}", curcorp.costtobuy);
                cost2buycol.transform.parent = newrowski.transform;
                GameObject moneyperweek = Instantiate(colski);
                moneyperweek.GetComponent<Text>().text = String.Format("{0:C}", curcorp.moneyperweek);
                moneyperweek.transform.parent = newrowski.transform;
                GameObject namecol = Instantiate(colski);
                namecol.GetComponent<Text>().text = String.Format("{0:C}", curcorp.name);
                namecol.transform.parent = newrowski.transform;
                GameObject typecol = Instantiate(colski);
                typecol.GetComponent<Text>().text = String.Format("{0:C}", curcorp.type);
                typecol.transform.parent = newrowski.transform;
                GameObject add = Instantiate(addcorpbtn);
                add.GetComponent<AddCorpScript>().index = k;
                add.GetComponent<AddCorpScript>().corppanel = corppanel;
                add.transform.parent = newrowski.transform;
                cost2buycol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
                namecol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
                typecol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;

            }
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


