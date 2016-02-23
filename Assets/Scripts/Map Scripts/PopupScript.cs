using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PopupScript : MonoBehaviour {
	public GameObject maincamera;
	public GameObject popupregion;
	public GameObject USA;
	public GameObject maincanvas;
	public Text daysuntilelection;
	public GameObject gameoverpopup;
	private bool initializedalready = false;
	public GameObject battlecanvas;
	private string clickedregion;
	public List<GameObject> createdCampaigns = new List<GameObject>();
	public List<GameObject> purchaseCampaigns = new List<GameObject>();
	public GameObject rowski;
	public GameObject colski;
	public GameObject activecampaignstable;
	public GameObject purchasecampaignstable;
	public Button genericbutton;
	public GameObject adviserspanel;
	public GameObject corporatepanel;
	private List<Corporation> activecorporations;
	private List<Advisor> activeadvisers;
	public float financeboost;
	public float environmentboost;
	public float generalboost;
	public float immigrationboost;
	public float healthcarecampaign;
    public List<float> moneyovertime = new List<float>();
    public List<int> votesovertime = new List<int>();
    public int votestowin = 300000000;
    public Player Hilary;

	public Region west = new Region(0.0F, "West", 100000);
	public Region south = new Region(0.0F, "South", 100000);
	public Region midwest = new Region (0.0F, "Midwest", 100000);
	public Region newengland = new Region (0.0F, "NewEngland", 100000);
	public Dictionary<string, Region> regions = new Dictionary<string, Region> ();
	public Dictionary<string, List<Campaign>> activecampaigns = new Dictionary<string, List<Campaign>>();
	public Dictionary<string, List<Campaign>> allcampaigns = new Dictionary<string, List<Campaign>>();
	private Dictionary<string, bool> newday = new Dictionary<string, bool>();

	private List<Campaign> generalcampaigns = new List<Campaign>(){
		new Campaign("Television", 200, 25, 150, 20, "General"),
		new Campaign("Radio", 200, 25, 150, 20, "General"),
		new Campaign("Social Media", 200, 25, 150, 20, "General"),
		new Campaign("Newspaper", 200, 25, 150, 20, "General"),
		new Campaign("Grassroots", 200, 25, 150, 20, "General"),
		new Campaign("College Tour", 200, 25, 150, 20, "General"),
		new Campaign("Book Tour", 1500, 25, 150, 20, "General")
	};
    private List<Campaign> environmentcampaigns = new List<Campaign>(){
		new Campaign("Park Preservation", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Water", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Air", 200, 25, 150, 20, "Environment"),
		new Campaign("Save Animals", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment")
	};
    private List<Campaign> environmentcampaigns1 = new List<Campaign>(){
		new Campaign("Park Preservation", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Water", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Air", 200, 25, 150, 20, "Environment"),
		new Campaign("Save Animals", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment")
	};
    private List<Campaign> financecampaigns = new List<Campaign>(){
		new Campaign("1% Movement", 200, 25, 150, 20, "Finance"),
		new Campaign("Microloan Program", 200, 25, 150, 20, "Finance"),
		new Campaign("Support Local Business", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance")
	};
    private List<Campaign> financecampaigns1 = new List<Campaign>(){
		new Campaign("1% Movement", 200, 25, 150, 20, "Finance"),
		new Campaign("Microloan Program", 200, 25, 150, 20, "Finance"),
		new Campaign("Support Local Business", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance")
	};
    private List<Campaign> immigrationcampaigns = new List<Campaign>(){
		new Campaign("Learn Spanish", 200, 25, 150, 20, "Immigration"),
		new Campaign("Kick Down Walls", 200, 25, 150, 20, "Immigration"),
		new Campaign("Sponsor Ethnic Minorities", 200, 25, 150, 20, "Immigration"),
		new Campaign("Grassroots in Hispanic comm.", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration")
	};
    private List<Campaign> immigrationcampaigns1 = new List<Campaign>(){
		new Campaign("Learn Spanish", 200, 25, 150, 20, "Immigration"),
		new Campaign("Kick Down Walls", 200, 25, 150, 20, "Immigration"),
		new Campaign("Sponsor Ethnic Minorities", 200, 25, 150, 20, "Immigration"),
		new Campaign("Grassroots in Hispanic comm.", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration")
	};
    private List<Campaign> healthcarecampaigns = new List<Campaign>(){
		new Campaign("Open Enrollment Help", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor Nursing School", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor 10k", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Hold Blood Clinics", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare")
	};
    private List<Campaign> healthcarecampaigns1 = new List<Campaign>(){
		new Campaign("Open Enrollment Help", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor Nursing School", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor 10k", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Hold Blood Clinics", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare")
	};
    private List<Campaign> environmentcampaigns2 = new List<Campaign>(){
		new Campaign("Park Preservation", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Water", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Air", 200, 25, 150, 20, "Environment"),
		new Campaign("Save Animals", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment")
	};
    private List<Campaign> environmentcampaigns3 = new List<Campaign>(){
		new Campaign("Park Preservation", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Water", 200, 25, 150, 20, "Environment"),
		new Campaign("Clean Air", 200, 25, 150, 20, "Environment"),
		new Campaign("Save Animals", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment"),
		new Campaign("Television", 200, 25, 150, 20, "Environment")
	};
    private List<Campaign> financecampaigns2 = new List<Campaign>(){
		new Campaign("1% Movement", 200, 25, 150, 20, "Finance"),
		new Campaign("Microloan Program", 200, 25, 150, 20, "Finance"),
		new Campaign("Support Local Business", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance")
	};
    private List<Campaign> financecampaigns3 = new List<Campaign>(){
		new Campaign("1% Movement", 200, 25, 150, 20, "Finance"),
		new Campaign("Microloan Program", 200, 25, 150, 20, "Finance"),
		new Campaign("Support Local Business", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance"),
		new Campaign("Television", 200, 25, 150, 20, "Finance")
	};
    private List<Campaign> immigrationcampaigns2 = new List<Campaign>(){
		new Campaign("Learn Spanish", 200, 25, 150, 20, "Immigration"),
		new Campaign("Kick Down Walls", 200, 25, 150, 20, "Immigration"),
		new Campaign("Sponsor Ethnic Minorities", 200, 25, 150, 20, "Immigration"),
		new Campaign("Grassroots in Hispanic comm.", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration")
	};
    private List<Campaign> immigrationcampaigns3 = new List<Campaign>(){
		new Campaign("Learn Spanish", 200, 25, 150, 20, "Immigration"),
		new Campaign("Kick Down Walls", 200, 25, 150, 20, "Immigration"),
		new Campaign("Sponsor Ethnic Minorities", 200, 25, 150, 20, "Immigration"),
		new Campaign("Grassroots in Hispanic comm.", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration"),
		new Campaign("Television", 200, 25, 150, 20, "Immigration")
	};
    private List<Campaign> healthcarecampaigns2 = new List<Campaign>(){
		new Campaign("Open Enrollment Help", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor Nursing School", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor 10k", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Hold Blood Clinics", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare")
	};
    private List<Campaign> healthcarecampaigns3 = new List<Campaign>(){
		new Campaign("Open Enrollment Help", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor Nursing School", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Sponsor 10k", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Hold Blood Clinics", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare"),
		new Campaign("Television", 200, 25, 150, 20, "Healthcare")
	};


	// Use this for initialization

	void Start () {
		if (!initializedalready) {
			InitializeShit ();
			InitializeCampaigns();
			initializedalready = true;
            Hilary = new Player();
		}

	}

	// Update is called once per frame
	void Update () {
		activecorporations =  corporatepanel.GetComponent<CorpScript> ().corporationsowned;
		activeadvisers = adviserspanel.GetComponent<AdvisorScript> ().myAdvisors;
	}


	void deleteCreated(){
		var children = new List<GameObject>();
		foreach (Transform child in activecampaignstable.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
	}

	void deletePurchased(){
		var children = new List<GameObject>();
		foreach (Transform child in purchasecampaignstable.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
	}

	void InitializeCampaigns(){	
		foreach (string region in regions.Keys){
			allcampaigns[region].AddRange(generalcampaigns);
			allcampaigns[region].AddRange(financecampaigns);
			allcampaigns[region].AddRange(environmentcampaigns);
			allcampaigns[region].AddRange(immigrationcampaigns);
			allcampaigns[region].AddRange(healthcarecampaigns);
			Debug.Log(allcampaigns[region].Count);
		}


	}


	void makeRowsActive(string region) {
		var children = new List<GameObject>();
		foreach (Transform child in activecampaignstable.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		GameObject firstrow = Instantiate (rowski);
		firstrow.transform.parent = activecampaignstable.transform;
		GameObject firstcol = Instantiate (colski);
		firstcol.GetComponent<Text> ().text = "Name";
		firstcol.transform.parent = firstrow.transform;
		GameObject secondcol = Instantiate (colski);
		secondcol.GetComponent<Text> ().text = "Campaign Type";
		secondcol.transform.parent = firstrow.transform;
		GameObject thirdcol = Instantiate (colski);
		thirdcol.GetComponent<Text> ().text = "Avg Cost/W";
		thirdcol.transform.parent = firstrow.transform;
		GameObject fourthcol = Instantiate (colski);
		fourthcol.GetComponent<Text>().text = "Avg Votes/W";
		fourthcol.transform.parent = firstrow.transform;
		GameObject fifthcol = Instantiate (colski);
		fifthcol.GetComponent<Text>().text = "";
		fifthcol.transform.parent = firstrow.transform;
		for (int i = 0; i < activecampaigns[region].Count; i++) {
			GameObject newrowski = Instantiate (rowski);
			Campaign campaign =  activecampaigns[region][i];
			newrowski.transform.parent = activecampaignstable.transform;
			GameObject namecol = Instantiate (colski);
			namecol.GetComponent<Text> ().text = String.Format("{0}", campaign.name);
			namecol.transform.parent = newrowski.transform;
			GameObject typecol = Instantiate (colski);
			typecol.GetComponent<Text> ().text = String.Format("{0}", campaign.type);
			typecol.transform.parent = newrowski.transform;
			GameObject cost2buycol = Instantiate (colski);
			cost2buycol.GetComponent<Text> ().text = String.Format("{0:C}", campaign.averagecost*1000.0F);
			cost2buycol.transform.parent = newrowski.transform;
			GameObject averagevotesw = Instantiate (colski);
			averagevotesw.GetComponent<Text> ().text = String.Format("{0}", campaign.avgvotes*1000.0F);
			averagevotesw.transform.parent = newrowski.transform;
			Button addbutton = Instantiate (genericbutton);
			addbutton.transform.parent = newrowski.transform;
			addbutton.onClick.AddListener(delegate{suspendClick(region, campaign);});
            addbutton.onClick.AddListener(delegate { addbutton.interactable = false; });
			addbutton.GetComponentInChildren<Text> ().text = "Suspend";
		}
	}


	void makeRowsPurchase(string region) {
		var children = new List<GameObject>();
		foreach (Transform child in purchasecampaignstable.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		GameObject firstrow = Instantiate (rowski);
		firstrow.transform.parent = purchasecampaignstable.transform;
		GameObject firstcol = Instantiate (colski);
		firstcol.GetComponent<Text> ().text = "Name";
		firstcol.transform.parent = firstrow.transform;
		GameObject secondcol = Instantiate (colski);
		secondcol.GetComponent<Text> ().text = "Campaign Type";
		secondcol.transform.parent = firstrow.transform;
		GameObject thirdcol = Instantiate (colski);
		thirdcol.GetComponent<Text> ().text = "Avg Cost/W";
		thirdcol.transform.parent = firstrow.transform;
		GameObject fourthcol = Instantiate (colski);
		fourthcol.GetComponent<Text>().text = "Avg Votes/W";
		fourthcol.transform.parent = firstrow.transform;
		GameObject fifthcol = Instantiate (colski);
		fifthcol.GetComponent<Text>().text = "";
		fifthcol.transform.parent = firstrow.transform;
		for (int i = 0; i < 4; i++) {
			int campaignnum = UnityEngine.Random.Range(0, allcampaigns[region].Count);
            
			GameObject newrowski = Instantiate (rowski);
			Campaign campaign =  allcampaigns[region][campaignnum];
			newrowski.transform.parent = purchasecampaignstable.transform;
			GameObject namecol = Instantiate (colski);
			namecol.GetComponent<Text> ().text = String.Format("{0}", campaign.name);
			namecol.transform.parent = newrowski.transform;
			GameObject typecol = Instantiate (colski);
			typecol.GetComponent<Text> ().text = String.Format("{0}", campaign.type);
			typecol.transform.parent = newrowski.transform;
			GameObject cost2buycol = Instantiate (colski);
			cost2buycol.GetComponent<Text> ().text = String.Format("{0:C}", campaign.averagecost * 1000.0F);
			cost2buycol.transform.parent = newrowski.transform;
			GameObject averagevotesw = Instantiate (colski);
			averagevotesw.GetComponent<Text> ().text = String.Format("{0}", campaign.avgvotes * 1000.0F);
			averagevotesw.transform.parent = newrowski.transform;
			Button addbutton = Instantiate (genericbutton);
			addbutton.transform.parent = newrowski.transform;
			addbutton.onClick.AddListener(delegate{startClick(region, campaign);});
            addbutton.onClick.AddListener(delegate { addbutton.interactable = false; });
		}
	}


	void InitializeShit() {
		USA.GetComponent<USAScript>().money = 1000000.0F;
		regions.Add ("West", west);
		regions.Add ("South", south);
		regions.Add ("Midwest", midwest);
		regions.Add ("NewEngland", newengland);
		activecampaigns.Add("West", new List<Campaign>());
		activecampaigns.Add("Midwest", new List<Campaign>());
		activecampaigns.Add("South", new List<Campaign>());
		activecampaigns.Add("NewEngland", new List<Campaign>());
		allcampaigns.Add("West", new List<Campaign>());
		allcampaigns.Add("Midwest", new List<Campaign>());
		allcampaigns.Add("South", new List<Campaign>());
		allcampaigns.Add("NewEngland", new List<Campaign>());
		newday.Add("West", true);
		newday.Add("Midwest", true);
		newday.Add("South", true);
		newday.Add("NewEngland", true);
        moneyovertime.Add(getTotalMoney());
        votesovertime.Add(getTotalPopularity());
	}

	private void suspendClick(string region, Campaign campaign){
		Debug.Log("insuspend");
		Debug.Log(campaign.name);
		activecampaigns[region].Remove(campaign);
		allcampaigns[region].Add(campaign);
		deleteCreated();
		makeRowsActive(region);
	}			

	private void startClick(string region, Campaign campaign){
		allcampaigns[region].Remove(campaign);
		activecampaigns[region].Add(campaign);
		deleteCreated();
		makeRowsActive(region);
        
    }

	public void onClick()
	{
		Debug.Log("clicked button");
	}

	public void IncreasePopularity(float amount, string region) {
		regions[region].popularity += amount;
	}

	public void IncreasePopularityGeneral(float amount){
		foreach (string key in regions.Keys) {
			regions [key].popularity += amount / 4.0F;
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

	public float getTotalMoney() {
		return USA.GetComponent<USAScript>().money;
	}

	public void SetClickedRegion(string region) {
		clickedregion = region;
		makeRowsActive(region);
		makeRowsPurchase(region);
		newday[region] = false;
	}


	/*public void newButtons()
	{
		int incpopoption = Random.Range(0, buttons_general_incpop.Count);
		int incmonoption = Random.Range(0, buttons_general_incmon.Count);


		incpopbutton.GetComponentInChildren<Text>().text = buttons_general_incpop[incpopoption].Key;
		incpopbutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreaseMoney = buttons_general_incpop[incpopoption].Value[0];
		incpopbutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreasePop = buttons_general_incpop[incpopoption].Value[1];
		incmoneybutton.GetComponentInChildren<Text>().text = buttons_general_incmon[incmonoption].Key;
		incmoneybutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreaseMoney = buttons_general_incmon[incmonoption].Value[0];
		incmoneybutton.GetComponent<IncreasePopularityorMoneyScript>().amounttoIncreasePop = buttons_general_incmon[incmonoption].Value[1];
	}*/

    void generateBoosters(){
        

        foreach (Advisor advisor in adviserspanel.GetComponent<AdvisorScript>().myAdvisors)
        {
            
        }
        foreach (Corporation corporation in corporatepanel.GetComponent<CorpScript>().corporationsowned)
        {
            Hilary.campaignboosts[corporation.type] -= 0.15F;
        }
    }

	public void decrementDaysLeft()
	{

		daysuntilelection.GetComponent<DaysUntilElectionScript>().daysLeft -= 1;
        float ttlmoneytoincrement = 0.0F;
        float ttlvotestoincrement = 0.0F;
        generateBoosters();


		foreach (Region region in regions.Values){
			foreach (Campaign campaign in activecampaigns[region.name])
			{
				float cost = -GenerateFromGaussian(campaign.averagecost*1000.0F, campaign.volcost*1000.0F);
                campaign.costovertimecamp.Add(campaign.costovertimecamp[campaign.costovertimecamp.Count - 1] + cost);
                ttlmoneytoincrement += cost;
                float votes = GenerateFromGaussian(campaign.avgvotes*1000.0F, campaign.volvotes*1000.0F);
                if (campaign.type !="General")
				    votes = (1.0F + Hilary.campaignboosts[campaign.type]) *votes;
                
                campaign.costovertimecamp.Add(campaign.votesovertimecamp[campaign.votesovertimecamp.Count - 1] + votes);
                IncreasePopularity(votes, region.name);
                ttlvotestoincrement += votes;
			}
		}
        ttlmoneytoincrement += corporatepanel.GetComponent<CorpScript>().GetWeeklyMoneyFromCorporations();
        ttlmoneytoincrement += -adviserspanel.GetComponent<AdvisorScript>().GetTotalAdvisorCost();


        IncreaseMoney(ttlmoneytoincrement);
        moneyovertime.Add(getTotalMoney());
        votesovertime.Add(getTotalPopularity());
        foreach (float value in moneyovertime)
            Debug.Log(value);
        foreach (float value in votesovertime)
            Debug.Log(value);
        foreach (Campaign campaign in activecampaigns["West"])
        {
            Debug.Log(campaign.votesovertimecamp);
            Debug.Log(campaign.costovertimecamp);
        }


	}

	public float GenerateFromGaussian(float mean, float stdDev)
	{
		System.Random rand = new System.Random(); //reuse this if you are generating many
		double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
		double u2 = rand.NextDouble();
		double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
			Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
		double randNormal =
			mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
		return (float)randNormal;
	}

	public void gameOver()
	{
		gameoverpopup.GetComponent<GameOverPopupScript>().gameOver(getTotalPopularity());
	}
	public void switchtoBattleScene()
	{
		battlecanvas.SetActive (true);
		battlecanvas.GetComponent<BattleCanvasScript> ().movePanel ();
		maincanvas.SetActive (false);
		//maincanvas.SetActive (false);
	}

}

public class Region {
	public float popularity;
	public float population;
	public string name;
	public Region()
	{
		popularity = 0;
	}
	public Region(float p, string s, float totalpop) {
		popularity = p;
		name = s;
		population = totalpop;
	}
}

public class Player
{
    public Dictionary<String, float> campaignboosts = new Dictionary<String, float>();
    public Dictionary<String, float> corporateboosts = new Dictionary<String, float>();
    public string firstname;
    public string lastname;
    public Player()
    {
        firstname = "Hilary";
        lastname = "Clinton";
        campaignboosts["Environment"] = 0.0F;
        campaignboosts["Finance"] = 0.0F;
        campaignboosts["Immigration"] = 0.0F;
        campaignboosts["Healthcare"] = 0.0F;
        corporateboosts["Environment"] = 0.0F;
        corporateboosts["Finance"] = 0.0F;
        corporateboosts["Immigration"] = 0.0F;
        corporateboosts["Healthcare"] = 0.0F;
    }

}

public class Campaign {
	public string name;
	public string type;
	public int averagecost;
	public int volcost;
	public int avgvotes;
	public int volvotes;
	public string region;
	public bool active;
    public List<float> costovertimecamp = new List<float>();
    public List<float> votesovertimecamp = new List<float>();

	public Campaign()
	{
		name = "hello";
		averagecost = 20;
		volcost = 15;
		region = "West";

	}

	public Campaign(string s, int cost, int vcost, int a, int vvotes, string t){
		name = s;
		averagecost = cost;
		volcost = vcost;
		avgvotes = a;
		volvotes = vvotes;
		type = t;
        costovertimecamp.Add(0.0F);
        votesovertimecamp.Add(0.0F);

	}


}


public static class RectTransformExtensions
{
	public static void SetDefaultScale(this RectTransform trans) {
		trans.localScale = new Vector3(1, 1, 1);
	}
	public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec) {
		trans.pivot = aVec;
		trans.anchorMin = aVec;
		trans.anchorMax = aVec;
	}

	public static Vector2 GetSize(this RectTransform trans) {
		return trans.rect.size;
	}
	public static float GetWidth(this RectTransform trans) {
		return trans.rect.width;
	}
	public static float GetHeight(this RectTransform trans) {
		return trans.rect.height;
	}

	public static void SetPositionOfPivot(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x, newPos.y, trans.localPosition.z);
	}

	public static void SetLeftBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetLeftTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}

	public static void SetSize(this RectTransform trans, Vector2 newSize) {
		Vector2 oldSize = trans.rect.size;
		Vector2 deltaSize = newSize - oldSize;
		trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
	}
	public static void SetWidth(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(newSize, trans.rect.size.y));
	}
	public static void SetHeight(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(trans.rect.size.x, newSize));
	}
}
	