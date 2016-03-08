using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class AttackMarketplaceScript : MonoBehaviour {
	public Attack curattacktoadd;
	public GameObject dropdownpanel;
	public Dropdown dropdown;
	public GameObject rowski;
	public GameObject colski;
	public GameObject activeattackstbl;
	public GameObject availableattackstbl;
    public bool _newday = true;
//	public GameObject removecorpbtn;
//	public GameObject addcorpbtn;
	public GameObject attackapnel;
	public GameObject xButton;
	public GameObject popupregion;
	public GameObject addattackbutton;
	public GameObject hilary;
	public GameObject battleobj;
	public List<Attack> attacksowned = new List<Attack>();
	public List<Attack> attackstobuy = new List<Attack>();
	public float preferredwidth1 = 0.2F;
	public float preferredwidth2 = 0.2F;
	public float preferredwidth3 = 0.2F;
	public float preferredwidth4 = 0.2F;
	public float preferredwidth5 = 0.2F;
	public float preferredwidth6 = 0.2F;

	// Use this for initialization
	void Start () {
//		Debug.Log (battleobj.GetComponent<BattleScript> ().movedict);
//		attacksowned = battleobj.GetComponent<BattleScript> ().movedict[hilary];
//		Corporation exxon = new Corporation (1000000, 300000, "Environment", "Exxon");
//		corporationsowned.Add (exxon);
//		Corporation goldman = new Corporation (2000000, 350000, "Finance", "Goldman Sachs");
//		corporationsowned.Add (goldman);
//		Corporation fencecorp = new Corporation (100000, 75000, "Immigration", "FenceCorp");
//		corporationstobuy.Add (fencecorp);
//		Corporation jp = new Corporation (2000000, 80000, "Finance", "JP Morgan");
//		corporationstobuy.Add (jp);
		attackstobuy = new List<Attack>() {
			new Attack("What Died on Trumps Head", 10.0F, 95, 100000, 10),
			new Attack("Trump = Oompa Loompa", 20.0F, 90, 400000, 5),
			new Attack("Chapter 11 is my fav", 40.0F, 80, 750000, 5),
            new Attack("9/11", 25.0F, 75, 750000, 10),
            new Attack("Donald Drumpf", 15.0F, 85, 100000, 7),
            new Attack("Donald Duck Would Be Better ):", 10.0F, 95, 100000, 10),
            new Attack("Treason", 100.0F, 20, 750000, 3),
            new Attack("New Tax on Tanning Salons", 25.0F, 85, 400000, 5),
            new Attack("Isn't Your Wife an Immigrant?", 15.0F, 95, 400000, 8),
            new Attack("Isn't This a Donald Glover Concert?", 8.0F, 100, 100000, 15),
            new Attack("Donald Driver, TD?", 10.0F, 95, 100000, 10),
            new Attack("Thought This Was a Scrubs Q&A", 15.0F, 85, 100000, 7),
            new Attack("'Damnit Donald!' - Manning", 10.0F, 100, 400000, 10),
            new Attack("You're Fired", 30.0F, 75, 750000, 5),
            new Attack("Trump's Super Tuesday is at a Ruby Tuesday", 20.0F, 60, 100000, 4),
            new Attack("Word is the Longest Word Trump Knows", 18.0F, 100, 750000, 8),
            new Attack("Miss USA is Creepy", 25.0F, 95, 750000, 7),
            new Attack("America is Already Great", 25.0F, 55, 100000, 4),
            new Attack("No Taxes For Anyone", 30.0F, 90, 750000, 5),
            new Attack("Free Healthcare For Everyone", 50.0F, 40, 750000, 3),
            new Attack("Make Marijuana Legal", 30.0F, 75, 400000, 4),
            new Attack("Free College", 30.0F, 50, 100000, 4),
            new Attack("Capitalism is Dumb", 15.0F, 90, 100000, 7),
            new Attack("It's Not Socialism, It's Communism", 10.0F, 95, 100000, 4)
		};
		dropdownpanel.SetActive (false);
//		makeRows ();
	}

	// Update is called once per frame
	void Update () {
		dropdownpanel.transform.SetAsLastSibling ();
		Debug.Log ("ATTACKSOWNED" + attacksowned.Count);
//		makeRows 	();
		//		makeToBuyRows ();
	}

	public void makeRows () {
		attacksowned = battleobj.GetComponent<BattleScript> ().GimmeMyAttacks();
		float totalscreenwidth = RectTransformExtensions.GetWidth(activeattackstbl.GetComponent<RectTransform>());
		float firstrowwidth = totalscreenwidth * preferredwidth1;
		float secondrowwidth = totalscreenwidth * preferredwidth2;
		float thirdrowwidth = totalscreenwidth * preferredwidth3;
		float fourthrowwidth = totalscreenwidth * preferredwidth4;
		float fifthrowwidth = totalscreenwidth * preferredwidth5;
		float sixthrowwidth = totalscreenwidth * preferredwidth6;
		var children = new List<GameObject>();
		foreach (Transform child in activeattackstbl.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
//
//		IN THIS PART, WE MAKE THE CURRENT ATTACKS

		GameObject firstrowski = Instantiate (rowski);
//		Attack curattack = attacksowned [i];
//		Debug.Log (curattack.name);
		firstrowski.transform.parent = activeattackstbl.transform;
		GameObject namecol = Instantiate (colski);
		namecol.GetComponent<Text> ().text = String.Format ("{0}", "Attack");
		namecol.transform.parent = firstrowski.transform;
		GameObject dmgcol = Instantiate (colski);
		dmgcol.GetComponent<Text> ().text = String.Format("{0}", "Damage");
		dmgcol.transform.parent = firstrowski.transform;
		GameObject acccol = Instantiate (colski);
		acccol.GetComponent<Text> ().text = String.Format("{0}", "Accuracy");
		acccol.transform.parent = firstrowski.transform;
		GameObject ppcol = Instantiate (colski);
		ppcol.GetComponent<Text> ().text = String.Format("{0}", "PP");
		ppcol.transform.parent = firstrowski.transform;
		GameObject costcol = Instantiate (colski);
		costcol.GetComponent<Text> ().text = String.Format("{0}", "Cost");
		costcol.transform.parent = firstrowski.transform;

		namecol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
		dmgcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
		acccol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
		ppcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
		costcol.GetComponent<LayoutElement>().preferredWidth = fifthrowwidth;

		for (int i = 0; i < attacksowned.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Attack curattack = attacksowned [i];
			Debug.Log (curattack.name);
			newrowski.transform.parent = activeattackstbl.transform;
			namecol = Instantiate (colski);
			namecol.GetComponent<Text> ().text = String.Format ("{0}", curattack.name);
			namecol.transform.parent = newrowski.transform;
			dmgcol = Instantiate (colski);
			dmgcol.GetComponent<Text> ().text = String.Format("{0}/{1}", (int)curattack.dmg, curattack.basedmg);
			dmgcol.transform.parent = newrowski.transform;
			acccol = Instantiate (colski);
			acccol.GetComponent<Text> ().text = String.Format("{0}", curattack.acc);
			acccol.transform.parent = newrowski.transform;
			ppcol = Instantiate (colski);
			ppcol.GetComponent<Text> ().text = String.Format("{0}/{1}", curattack.pp, curattack.basepp);
			ppcol.transform.parent = newrowski.transform;
			costcol = Instantiate (colski);
			costcol.GetComponent<Text> ().text = String.Format("{0:C0}", curattack.cost);
			costcol.transform.parent = newrowski.transform;
//			GameObject remove = Instantiate (removecorpbtn);
//			remove.GetComponent<RemoveScript> ().index = i;
//			remove.GetComponent<RemoveScript> ().corppanel = corppanel;
//			remove.transform.parent = newrowski.transform;
			namecol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
			dmgcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
			acccol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
			ppcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
			costcol.GetComponent<LayoutElement>().preferredWidth = fifthrowwidth;
		}


		//		IN THIS PART, WE MAKE THE ATTACKS TO BUY
        if (_newday)
        {
            _newday = false;
            var children2 = new List<GameObject>();
            foreach (Transform child in availableattackstbl.transform) children2.Add(child.gameObject);
            children2.ForEach(child => Destroy(child));

            GameObject firstrowski1 = Instantiate(rowski);
            //		Attack curattack = attacksowned [i];
            //		Debug.Log (curattack.name);
            firstrowski1.transform.parent = availableattackstbl.transform;
            namecol = Instantiate(colski);
            namecol.GetComponent<Text>().text = String.Format("{0}", "Attack");
            namecol.transform.parent = firstrowski1.transform;
            dmgcol = Instantiate(colski);
            dmgcol.GetComponent<Text>().text = String.Format("{0}", "Damage");
            dmgcol.transform.parent = firstrowski1.transform;
            acccol = Instantiate(colski);
            acccol.GetComponent<Text>().text = String.Format("{0}", "Accuracy");
            acccol.transform.parent = firstrowski1.transform;
			ppcol = Instantiate(colski);
			ppcol.GetComponent<Text>().text = String.Format("{0}", "PP");
			ppcol.transform.parent = firstrowski1.transform;
            costcol = Instantiate(colski);
            costcol.GetComponent<Text>().text = String.Format("{0}", "Cost");
            costcol.transform.parent = firstrowski1.transform;

            GameObject lastcol = Instantiate(colski);
            lastcol.transform.parent = firstrowski1.transform;
            lastcol.GetComponent<Text>().text = "";
            namecol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
            dmgcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
            acccol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
			ppcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
			costcol.GetComponent<LayoutElement>().preferredWidth = fifthrowwidth;
			lastcol.GetComponent<LayoutElement>().preferredWidth = sixthrowwidth;
            List<int> b = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                int j = UnityEngine.Random.Range(0, attackstobuy.Count);
                while (b.Contains(j))
                {
                    j = UnityEngine.Random.Range(0, attackstobuy.Count);
                }
                b.Add(j);
                GameObject newrowski = Instantiate(rowski);
                Attack curattack = attackstobuy[j];
                Debug.Log(curattack.name);
                newrowski.transform.parent = availableattackstbl.transform;
                namecol = Instantiate(colski);
                namecol.GetComponent<Text>().text = String.Format("{0}", curattack.name);
                namecol.transform.parent = newrowski.transform;
                dmgcol = Instantiate(colski);
                dmgcol.GetComponent<Text>().text = String.Format("{0}", curattack.dmg);
                dmgcol.transform.parent = newrowski.transform;
                acccol = Instantiate(colski);
                acccol.GetComponent<Text>().text = String.Format("{0}", curattack.acc);
                acccol.transform.parent = newrowski.transform;
				ppcol = Instantiate(colski);
				ppcol.GetComponent<Text>().text = String.Format("{0}", curattack.pp);
				ppcol.transform.parent = newrowski.transform;
                costcol = Instantiate(colski);
                costcol.GetComponent<Text>().text = String.Format("{0:C0}", curattack.cost);
                costcol.transform.parent = newrowski.transform;

                GameObject addy = Instantiate(addattackbutton);
                addy.GetComponent<AddAttackScript>().index = curattack;
                //			remove.GetComponent<RemoveScript> ().corppanel = corppanel;
                addy.transform.parent = newrowski.transform;
                namecol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
                dmgcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
                acccol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
				ppcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
				costcol.GetComponent<LayoutElement>().preferredWidth = fifthrowwidth;
                addy.GetComponent<LayoutElement>().preferredWidth = fifthrowwidth;
            }
        }

		



////		GameObject blankrowski = Instantiate (rowski);
//		totalscreenwidth = RectTransformExtensions.GetWidth(availablecorpstbl.GetComponent<RectTransform>());
//		firstrowwidth = totalscreenwidth * preferredwidth1;
//		secondrowwidth = totalscreenwidth * preferredwidth2;
//		thirdrowwidth = totalscreenwidth * preferredwidth3;
//		fourthrowwidth = totalscreenwidth * preferredwidth4;
//
//		if (_newday)
//		{
//			for (int i = 0; i < corporationstobuy.Count; i++)
//			{
//				foreach (Transform child in availablecorpstbl.transform) children.Add(child.gameObject);
//				children.ForEach(child => Destroy(child));
//
//				GameObject newrowski = Instantiate(rowski);
//				Corporation curcorp = corporationstobuy[i];
//				newrowski.transform.parent = availablecorpstbl.transform;
//				GameObject cost2buycol = Instantiate(colski);
//				cost2buycol.GetComponent<Text>().text = String.Format("{0:C}", curcorp.costtobuy);
//				cost2buycol.transform.parent = newrowski.transform;
//				GameObject namecol = Instantiate(colski);
//				namecol.GetComponent<Text>().text = String.Format("{0:C}", curcorp.name);
//				namecol.transform.parent = newrowski.transform;
//				GameObject typecol = Instantiate(colski);
//				typecol.GetComponent<Text>().text = String.Format("{0:C}", curcorp.type);
//				typecol.transform.parent = newrowski.transform;
//				GameObject add = Instantiate(addcorpbtn);
//				add.GetComponent<AddCorpScript>().index = i;
//				add.GetComponent<AddCorpScript>().corppanel = corppanel;
//				add.transform.parent = newrowski.transform;
//				cost2buycol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
//				namecol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
//				typecol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
//
//			}
//		}
	}
//
//	public void RemoveAttack (int i) {
////		Corporation corptomove = corporationsowned [i];
////		corporationsowned.RemoveAt (i);
////		corporationstobuy.Add (corptomove);
//		makeRows ();
//	}
	public void ShowDropdown(Attack i) {
		Attack attacktoadd = i;
		Debug.Log("to add: " + i.name);
		curattacktoadd = attacktoadd;
		dropdown.ClearOptions ();
		for (var j = 0; j < attacksowned.Count; j++) {
			dropdown.AddOptions(new List<string>(){attacksowned[j].name});
		}
		//corpbuts[k].transform.parent.gameObject
		dropdownpanel.SetActive (true);
		xButton.SetActive (false);
	}
	public void AddAttack (Attack i) {
//		popupregion.GetComponent<PopupScript> ().IncreaseMoney (-corptomove.costtobuy);
//		corporationsowned.Add (corptomove);
        GameObject[] attackbut = GameObject.FindGameObjectsWithTag("AttBut");
        for (int j = 0; j < attackbut.Length; j++)
        {
            Debug.Log("Attacki" + i.name);
            Debug.Log("Attack:" + attackbut[j].GetComponent<AddAttackScript>().index.name);
            if (attackbut[j].GetComponent<AddAttackScript>().index == i)
            {
                Debug.Log("WHATTT");
                Destroy(attackbut[j].transform.parent.gameObject);

            }
        }
        attackstobuy.Remove(i);

		battleobj.GetComponent<BattleScript>().SwapMyAttack(dropdown.value, curattacktoadd);
		popupregion.GetComponent<PopupScript> ().IncreaseMoney (-curattacktoadd.cost);
		makeRows ();
		dropdownpanel.SetActive (false);
		xButton.SetActive (true);
	}
//
//	public float GetWeeklyMoneyFromCorporations() {
//		float totalmoney=0.0F;
//		for (var i = 0; i < corporationsowned.Count; i++) {
//			Corporation corptogetfundsfrom = corporationsowned [i];
//			double multiplier = GenerateFromGaussian (1f, .2f);
//			float moneytoget = corptogetfundsfrom.moneyperweek * (float)multiplier;
//			totalmoney += moneytoget;
//			corporationsowned [i].moneylastweek = moneytoget;
//			corporationsowned [i].weeklymonies.Add(moneytoget);
//		}
//		return totalmoney;
//	}
}


