using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PopupScript : MonoBehaviour {
	public GameObject maincamera;
	public GameObject popupregion;
	public int totalmoney;
	public int totalpop;
	public GameObject USA;
	private string clickedregion;
	public Button incpopbutton;
	public Button incmoneybutton;
	public Region west = new Region(0.0F, "West");
	public Region south = new Region(0.0F, "South");
	public Dictionary<string, Region> regions = new Dictionary<string, Region> ();
	private List<KeyValuePair<string, float[]>> buttons_general_incpop = new List<KeyValuePair<string, float[]>>()
	{
		new KeyValuePair<string, float[]>("Social Media Campaign", new float [] {-100.0F, 40F}),
		new KeyValuePair<string, float[]>("Radio Campaign", new float[] {-150.0F, 50F}),
		new KeyValuePair<string, float[]>("Television Campaign", new float[] {-150.0F, 40F}),
		new KeyValuePair<string, float[]>("Print Campaign", new float[]{-200.0F, 50F}),
		new KeyValuePair<string, float[]>("General Uplifting Talk at School", new float []{-10, 150F}),
		new KeyValuePair<string, float[]>("Environmental Talk", new float []{-150.0F, .20F})
	};

	private List<KeyValuePair<string, float[]>> buttons_general_incmon = new List<KeyValuePair<string, float[]>>(){
		new KeyValuePair<string, float[]>("Private Donors Dinner", new float[]{100.0F, -100F}),
		new KeyValuePair<string, float[]>("Talk to Oil Industry", new float[]{200.0F, -50F}),
		new KeyValuePair<string, float[]>("Talk to Big Banks", new float[]{500.0F, -10F}),
		new KeyValuePair<string, float[]>("Run Local Fundraiser - Bernie Style", new float[]{50.0F, -200F}),
		new KeyValuePair<string, float[]>("Send Emails Soliciting Donations", new float[]{10.0F, -300F})

	};

	private Dictionary<string, float[]> buttons_environmental = new Dictionary<string, float[]>(){
		{"Environmental Talk at School", new float []{-10.0F, 100F}},

	};



	// Use this for initialization
	void Start () {
		var index = 10; 
		south.popularity = 15.0F;
		regions.Add ("West", west);
		regions.Add ("South", south);
		Debug.Log (regions ["South"].popularity);

		int incpopoption = Random.Range(0, buttons_general_incpop.Count);
		int incmonoption = Random.Range(0, buttons_general_incmon.Count);


		incpopbutton.GetComponentInChildren<Text>().text = buttons_general_incpop[incpopoption].Key;
		incpopbutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreaseMoney = buttons_general_incpop[incpopoption].Value[0];
		incpopbutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreasePop = buttons_general_incpop[incpopoption].Value[1];
		incmoneybutton.GetComponentInChildren<Text>().text = buttons_general_incmon[incmonoption].Key;
		incmoneybutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreaseMoney = buttons_general_incmon[incmonoption].Value[0];
		incmoneybutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreasePop = buttons_general_incmon[incmonoption].Value[1];


	}

	// Update is called once per frame
	void Update () {

	}

	public void onClick()
	{
		Debug.Log("clicked button");
	}

	public void IncreasePopularity(float amount) {
		if (amount > 0) { 
			regions [clickedregion].popularity = (100-regions[clickedregion].popularity)/amount + regions[clickedregion].popularity;
		}
		else
		{
			regions[clickedregion].popularity = (regions[clickedregion].popularity-0) / amount + regions[clickedregion].popularity;
		}
	}

	public void IncreaseMoney(float amount) {
		USA.GetComponent<USAScript>().money += (int)amount;
	}

	public int getTotalPopularity() {
		float popularity = 0.0F;
		foreach(KeyValuePair<string, Region> entry in regions) {
			popularity += entry.Value.popularity;
		}
		return (int)popularity;
	}

	public int getTotalMoney() {
		return USA.GetComponent<USAScript>().money;
	}

	public void SetClickedRegion(string region) {
		clickedregion = region;
	}

}

public class Region {
	public float popularity;
	public string name;
	public Region()
	{
		popularity = 0;
	}
	public Region(float p, string s) {
		popularity = p;
		name = s;
	}
}