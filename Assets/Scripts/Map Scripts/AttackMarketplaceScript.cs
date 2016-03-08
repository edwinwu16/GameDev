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
			new Attack("I support gun control!", 15.0F, 95, 1000000, 7),
			new Attack("I don't support gun control!", 20.0F, 90, 50000, 4),
			new Attack("Cater to popular opinion", 12.0F, 97, 90000, 5)
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
		GameObject costcol = Instantiate (colski);
		costcol.GetComponent<Text> ().text = String.Format("{0}", "Cost");
		costcol.transform.parent = firstrowski.transform;

		namecol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
		dmgcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
		acccol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
		costcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;

		for (int i = 0; i < attacksowned.Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Attack curattack = attacksowned [i];
			Debug.Log (curattack.name);
			newrowski.transform.parent = activeattackstbl.transform;
			namecol = Instantiate (colski);
			namecol.GetComponent<Text> ().text = String.Format ("{0}", curattack.name);
			namecol.transform.parent = newrowski.transform;
			dmgcol = Instantiate (colski);
			dmgcol.GetComponent<Text> ().text = String.Format("{0}", curattack.dmg);
			dmgcol.transform.parent = newrowski.transform;
			acccol = Instantiate (colski);
			acccol.GetComponent<Text> ().text = String.Format("{0}", curattack.acc);
			acccol.transform.parent = newrowski.transform;
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
			costcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
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
            costcol = Instantiate(colski);
            costcol.GetComponent<Text>().text = String.Format("{0}", "Cost");
            costcol.transform.parent = firstrowski1.transform;

            GameObject lastcol = Instantiate(colski);
            lastcol.transform.parent = firstrowski1.transform;
            lastcol.GetComponent<Text>().text = "";
            namecol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
            dmgcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
            acccol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
            costcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
            lastcol.GetComponent<LayoutElement>().preferredWidth = fifthrowwidth;
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
                costcol.GetComponent<LayoutElement>().preferredWidth = fourthrowwidth;
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


