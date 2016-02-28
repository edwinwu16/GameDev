using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class AttackMarketplaceScript : MonoBehaviour {
	public GameObject rowski;
	public GameObject colski;
	public GameObject activeattackstbl;
//	public GameObject availablecorpstbl;
//	public GameObject removecorpbtn;
//	public GameObject addcorpbtn;
	public GameObject attackapnel;
//	public GameObject popupregion;
	public GameObject hilary;
	public GameObject battleobj;
//	public List<Attack> attacksowned = new List<Attack>();
	public List<Corporation> attackstobuy = new List<Corporation>();
	public float preferredwidth1 = 0.3F;
	public float preferredwidth2 = 0.3F;
	public float preferredwidth3 = 0.2F;
	public float preferredwidth4 = 0.2F;


	// Use this for initialization
	void Start () {
//		attacksowned = battleobj.GetComponent<BattleScript> ().movedict[hilary.GetComponent<FighterScript>().fightername];
//		Corporation exxon = new Corporation (1000000, 300000, "Environment", "Exxon");
//		corporationsowned.Add (exxon);
//		Corporation goldman = new Corporation (2000000, 350000, "Finance", "Goldman Sachs");
//		corporationsowned.Add (goldman);
//		Corporation fencecorp = new Corporation (100000, 75000, "Immigration", "FenceCorp");
//		corporationstobuy.Add (fencecorp);
//		Corporation jp = new Corporation (2000000, 80000, "Finance", "JP Morgan");
//		corporationstobuy.Add (jp);
		makeRows ();
	}

	// Update is called once per frame
	void Update () {
		//		makeToBuyRows ();
	}

	void makeRows () {
		float totalscreenwidth = RectTransformExtensions.GetWidth(activeattackstbl.GetComponent<RectTransform>());
		float firstrowwidth = totalscreenwidth * preferredwidth1;
		float secondrowwidth = totalscreenwidth * preferredwidth2;
		float thirdrowwidth = totalscreenwidth * preferredwidth3;
		float fourthrowwidth = totalscreenwidth * preferredwidth4;
		var children = new List<GameObject>();
		foreach (Transform child in activeattackstbl.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
//
//		for (int i = 0; i < attacksowned.Count; i++) {
//			GameObject newrowski = Instantiate (rowski);
//			Attack curattack = attacksowned [i];
//			Debug.Log (curattack.name);
//			newrowski.transform.parent = activeattackstbl.transform;
//			GameObject namecol = Instantiate (colski);
//			namecol.GetComponent<Text> ().text = String.Format("{0:C}", curattack.name);
//			namecol.transform.parent = newrowski.transform;
//			GameObject dmgcol = Instantiate (colski);
//			dmgcol.GetComponent<Text> ().text = String.Format("{0:C}", curattack.dmg);
//			dmgcol.transform.parent = newrowski.transform;
//			GameObject acccol = Instantiate (colski);
//			acccol.GetComponent<Text> ().text = String.Format("{0:C}", curattack.acc);
//			acccol.transform.parent = newrowski.transform;
////			GameObject remove = Instantiate (removecorpbtn);
////			remove.GetComponent<RemoveScript> ().index = i;
////			remove.GetComponent<RemoveScript> ().corppanel = corppanel;
////			remove.transform.parent = newrowski.transform;
//			namecol.GetComponent<LayoutElement>().preferredWidth = firstrowwidth;
//			dmgcol.GetComponent<LayoutElement>().preferredWidth = secondrowwidth;
//			acccol.GetComponent<LayoutElement>().preferredWidth = thirdrowwidth;
//
//		}
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
//	public void AddCorporation (int i) {
//		Corporation corptomove = corporationstobuy [i];
//		corporationstobuy.RemoveAt (i);
//		popupregion.GetComponent<PopupScript> ().IncreaseMoney (-corptomove.costtobuy);
//		corporationsowned.Add (corptomove);
//		makeRows ();
//	}
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


