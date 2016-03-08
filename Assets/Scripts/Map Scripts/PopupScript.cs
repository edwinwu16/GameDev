using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
//using UnityEngine.Behaviour;
using UnityEngine.UI;
using System;

public class PopupScript : MonoBehaviour {
	public GameObject maincamera;
	public GameObject popupregion;
	public GameObject USA;
	public GameObject maincanvas;
    public GameObject attackcanvas;
	public Text daysuntilelection;
	public GameObject gameoverpopup;
	private bool initializedalready = false;
    public GameObject tutorial;
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
	public GameObject dailysummarypanel;
	public GameObject corporatepanel;
	public GameObject battleobject;
	public GameObject welcomebattlepanel;
	public GameObject trump;
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
	public int daystostartwith = 100;
    public GameObject voterpanel;
    public Player Hilary;
    public bool _tutorial = true;
    public bool _newday = true;
    public Dictionary<string, List<Campaign>> storedcampaigns = new Dictionary<string, List<Campaign>>();
    public int belowzero = 0;

    public float preferredwidth1;
    public float preferredwidth2;
    public float preferredwidth3;
    public float preferredwidth4;
    public float preferredwidth5;
	public Region west = new Region(0.0F, "West", 100000);
	public Region south = new Region(0.0F, "South", 100000);
	public Region midwest = new Region (0.0F, "Midwest", 100000);
	public Region newengland = new Region (0.0F, "NewEngland", 100000);
	public Dictionary<string, Region> regions = new Dictionary<string, Region> ();
	public Dictionary<string, List<Campaign>> activecampaigns = new Dictionary<string, List<Campaign>>();
	public Dictionary<string, List<Campaign>> allcampaigns = new Dictionary<string, List<Campaign>>();
	private Dictionary<string, bool> newday = new Dictionary<string, bool>();
    public Dictionary<string, List<List<Campaign>>> specialcampaigns = new Dictionary <string, List<List<Campaign>>>();
    public Campaign tutorialcampaign = new Campaign("Flier at the Library", 10, 5, 10, 5, "General");

	private List<Campaign> generalcampaigns = new List<Campaign>(){
		new Campaign("Television", 200, 25, 50, 20, "General"),
		new Campaign("Radio", 150, 15, 35, 10, "General"),
		new Campaign("Social Media", 300, 25, 75, 20, "General"),
		new Campaign("Newspaper", 300, 	25, 70, 20, "General"),
		new Campaign("Grassroots", 250, 25, 60, 20, "General"),
		new Campaign("College Tour", 300, 25, 75, 20, "General"),
		new Campaign("Book Tour", 1500, 25, 200, 20, "General")
	};
    private List<Campaign> environmentcampaigns = new List<Campaign>(){
		new Campaign("Park Preservation", 200, 25, 50, 20, "Environment"),
		new Campaign("Clean Water", 200, 25, 40, 20, "Environment"),
		new Campaign("Clean Air", 150, 25, 36, 20, "Environment"),
		new Campaign("Save Animals", 300, 25, 70, 20, "Environment")
	};

    private List<Campaign> financecampaigns = new List<Campaign>(){
		new Campaign("1% Movement", 200, 25, 50, 20, "Finance"),
		new Campaign("Support Local Business", 150, 37, 0, 10, "Finance"),
		new Campaign("Microloan Program", 300, 25, 75, 20, "Finance"),
		new Campaign("Blue Collar Tour", 300, 25, 70, 20, "Finance"),
		new Campaign("Open a Soup Kitchen", 250, 25, 62, 20, "Finance"),
	};

    private List<Campaign> immigrationcampaigns = new List<Campaign>(){
		new Campaign("Learn Spanish", 200, 25, 50, 20, "Immigration"),
		new Campaign("Kick Down Walls", 150, 15, 37, 10, "Immigration"),
		new Campaign("Sponsor Ethnic Minorities", 300, 25, 70, 20, "Immigration"),
		new Campaign("Hispanic Grassroots", 300, 	25, 75, 20, "Immigration"),
		new Campaign("Book Tour", 1500, 25, 200, 20, "Immigration")

	};

    private List<Campaign> healthcarecampaigns = new List<Campaign>(){
		new Campaign("Open Enrollment Help", 200, 25, 50, 20, "Healthcare"),
		new Campaign("Sponsor Nursing School", 200, 25, 40, 20, "Healthcare"),
		new Campaign("Sponsor 10k", 250, 25, 62, 20, "Healthcare"),
		new Campaign("Hold Blood Clinics", 300, 25, 75, 20, "Healthcare"),
		new Campaign("ACA Enrollment Clinic", 300, 25, 70, 20, "Healthcare"),
		new Campaign("Open Free Clinic", 1000, 15, 260, 10, "Healthcare")
	};

    private List<Campaign> financecampaigns1 = new List<Campaign>(){
        new Campaign("Audit the Fed", 200, 25, 67, 20, "Finance"),
		new Campaign("Break Up the Banks", 150, 50, 0, 10, "Finance"),
		new Campaign("Rob the Rich", 300, 25, 90, 20, "Finance"),
		new Campaign("Occupy Movement", 300, 25, 100, 20, "Finance"),
		new Campaign("Occupy Wall Street", 250, 25, 70, 20, "Finance"),
	};

    private List<Campaign> immigrationcampaigns1 = new List<Campaign>(){
		new Campaign("Get the best from Mexico", 200, 25, 67, 20, "Immigration"),
		new Campaign("Promise not to ban Muslims", 150, 50, 0, 10, "Immigration"),
		new Campaign("Take Syrian Refuggees", 250, 25, 70, 20, "Immigration"),
		new Campaign("Visit the Pyramids", 250, 25, 70, 20, "Immigration"),


	};
    private List<Campaign> healthcarecampaigns1 = new List<Campaign>(){
		new Campaign("Sponsor Single Payer", 200, 25, 66, 20, "Healthcare"),
		new Campaign("Dedicate Hospital Wings", 200, 25, 67, 20, "Healthcare"),
		new Campaign("Sponsor Half-Marathon", 250, 25, 80, 20, "Healthcare"),
        new Campaign("Sponsor Marathon", 250, 25, 85, 20, "Healthcare"),

		new Campaign("ACA Enrollment Clinic", 300, 25, 100, 20, "Healthcare"),
		new Campaign("Open Free Clinic", 1000, 15, 320, 10, "Healthcare")


	};


    private List<Campaign> environmentcampaigns1 = new List<Campaign>()
    {
		new Campaign("Save the Swamps", 200, 25, 67, 20, "Environment"),
		new Campaign("Wash Oil off Seals", 200, 25, 60, 20, "Environment"),
		new Campaign("Pour a bunch of water on California", 250, 25, 85, 20, "Envrionment"),
        new Campaign("Go to Yellowstone", 250, 25, 80, 20, "Environment"),
		new Campaign("Spend a day with a Hippie", 300, 25, 100, 20, "Environment"),
		new Campaign("Reenact Woodstock", 1000, 15, 330, 10, "Enviroment")


    };

    private List<Campaign> financecampaigns2 = new List<Campaign>(){
        new Campaign("Stop Tax Inversions", 200, 25, 80, 20, "Finance"),
		new Campaign("Rob the Rich", 300, 25, 110, 20, "Finance"),
		new Campaign("Occupy Wall Street", 250, 25, 100, 20, "Finance"),
	};

    private List<Campaign> immigrationcampaigns2 = new List<Campaign>(){
		new Campaign("Make Fairtrade Campaign T-Shirts", 300, 25, 120, 20, "Immigration"),
		new Campaign("Build Ladders Next to Walls", 300, 25, 120, 20, "Immigration"),
		new Campaign("Take Syrian Refugees", 250, 25, 100, 20, "Immigration"),
		new Campaign("Visit the Pyramids", 250, 25, 90, 20, "Immigration"),


	};
    private List<Campaign> healthcarecampaigns2 = new List<Campaign>(){
		new Campaign("Sponsor Single Payer", 200, 25, 80, 20, "Healthcare"),
		new Campaign("Dedicate Hospital Wings", 200, 25, 75, 20, "Healthcare"),
		new Campaign("Sponsor Half-Marathon", 250, 25, 100, 20, "Healthcare"),
        new Campaign("Sponsor Marathon", 250, 25, 90, 20, "Healthcare"),

		new Campaign("ACA Enrollment Clinic", 300, 25, 100, 20, "Healthcare"),
		new Campaign("Open Free Clinic", 1000, 15, 410, 10, "Healthcare")


	};


    private List<Campaign> environmentcampaigns2 = new List<Campaign>()
    {
        new Campaign("Go Solar", 500, 25, 200, 20, "Environment"),
		new Campaign("Go Nuclear", 300, 25, 115, 20, "Environment"),
		new Campaign("Promise to Cover White House with Solar Panels", 1000, 15, 390, 10, "Enviroment")


    };

    private List<Campaign> financecampaigns3 = new List<Campaign>(){
        new Campaign("Steal the Wall Street Bull", 1000, 100, 550, 55, "Finance"),
		new Campaign("Colonize the Cayman Islands", 300, 25, 150, 20, "Finance"),
		new Campaign("Rob Banks", 500, 25, 260, 20, "Finance"),
	};

    private List<Campaign> immigrationcampaigns3 = new List<Campaign>(){
		new Campaign("Pitch Plan to Make Greencard Access Easier", 200, 25, 100, 20, "Immigration"),
		new Campaign("Close Sweatshops", 300, 25, 150, 20, "Immigration"),
		new Campaign("Build Tunnels Under Walls", 250, 25, 120, 20, "Immigration"),
		new Campaign("Blow Up Trump Towers", 500, 25, 260, 20, "Immigration"),


	};
    private List<Campaign> healthcarecampaigns3 = new List<Campaign>(){
		new Campaign("Find the Fountain of Youth", 200, 25, 100, 20, "Healthcare"),
		new Campaign("Heal the Sick With Your Bare Hands", 300, 25, 150, 20, "Healthcare"),
		new Campaign("Universal Healthcare", 1000, 15, 510, 10, "Healthcare")


	};


    private List<Campaign> environmentcampaigns3 = new List<Campaign>()
    {
		new Campaign("Wash Birds Covered With Oil", 200, 25, 100, 20, "Environment"),
		new Campaign("Dedicate Hospital Wings", 200, 25, 89, 20, "Environment"),
        new Campaign("Sponsor Triathlon", 250, 25, 129, 20, "Environment"),
		new Campaign("Actually Make a Plan for a Productive FEMA", 1000, 15, 505, 10, "Enviroment")


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

    public float getCost()
    {
        float cost = 0.0F;
        foreach (KeyValuePair<string, List<Campaign>> values in activecampaigns)
        {
            foreach (Campaign campaign in values.Value){
                cost -=campaign.averagecost * 1000;
                Debug.Log(campaign.averagecost);
            }
        }
        foreach (Advisor advisor in adviserspanel.GetComponent<AdvisorScript>().myAdvisors)
        {
            cost -= advisor.price;
        }
        foreach (Corporation corporation in corporatepanel.GetComponent<CorpScript>().corporationsowned)
            cost += corporation.moneyperweek;
        return cost;
    }

	void InitializeCampaigns(){	
		foreach (string region in regions.Keys){
            allcampaigns[region].AddRange(generalcampaigns);
			Debug.Log(allcampaigns[region].Count);
		}


	}

    void updateCampaigns(Advisor advisorremoved, Advisor advisoradded)
    {
        foreach (string region in regions.Keys)
        {

        }
    }

 
    


	void makeRowsActive(string region) {
        float totalscreenwidth = RectTransformExtensions.GetWidth(activecampaignstable.GetComponent<RectTransform>());
        preferredwidth1 = totalscreenwidth * 0.3F;
        preferredwidth2 = totalscreenwidth * 0.2F;
        preferredwidth3 = totalscreenwidth * 0.2F;
        preferredwidth4 = totalscreenwidth * 0.2F;
        preferredwidth5 = totalscreenwidth * 0.1F;

        
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
		thirdcol.GetComponent<Text> ().text = "Avg Cost/Day";
		thirdcol.transform.parent = firstrow.transform;
		GameObject fourthcol = Instantiate (colski);
		fourthcol.GetComponent<Text>().text = "Avg Votes/Day";
		fourthcol.transform.parent = firstrow.transform;
		GameObject fifthcol = Instantiate (colski);
		fifthcol.GetComponent<Text>().text = "";
		fifthcol.transform.parent = firstrow.transform;
        firstcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
        secondcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
        thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
        fourthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;
        fifthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth5;





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
			averagevotesw.GetComponent<Text> ().text = String.Format("{0:n0}", campaign.avgvotes*5000.0F);
			averagevotesw.transform.parent = newrowski.transform;
			Button addbutton = Instantiate (genericbutton);
			addbutton.transform.parent = newrowski.transform;
			addbutton.onClick.AddListener(delegate{suspendClick(region, campaign);});
            addbutton.onClick.AddListener(delegate { addbutton.interactable = false; });
			addbutton.GetComponentInChildren<Text> ().text = "Suspend";
            namecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
            typecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
            cost2buycol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
            averagevotesw.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;

		}
	}

    public void addToAllCampaigns(Advisor adviser)
    {
        foreach (KeyValuePair<string, List<Campaign>> item in allcampaigns){
            allcampaigns[item.Key].AddRange((adviser.campaigns.Except(allcampaigns[item.Key])).ToList());
        }
    }

    public void removeFromAllCampaigns(Advisor adviser)
    {
        foreach (KeyValuePair<string, List<Campaign>> item in allcampaigns)
        {
            allcampaigns[item.Key] = allcampaigns[item.Key].Except(adviser.campaigns).ToList();
            List<Campaign> overlapping = activecampaigns[item.Key].Except(adviser.campaigns).ToList();
            foreach (Advisor adv in adviserspanel.GetComponent<AdvisorScript>().myAdvisors)
            {
                if (adv != adviser)
                {
                    overlapping.AddRange((adv.campaigns.Except(overlapping)).ToList());
                    addToAllCampaigns(adv);

                }
            }
            activecampaigns[item.Key] = overlapping;
        }
    }

	void makeRowsPurchase(string region) {
        
        if (newday[region] ){

            float totalscreenwidth = RectTransformExtensions.GetWidth(purchasecampaignstable.GetComponent<RectTransform>());
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
		    thirdcol.GetComponent<Text> ().text = "Avg Cost/Day";
		    thirdcol.transform.parent = firstrow.transform;
		    GameObject fourthcol = Instantiate (colski);
		    fourthcol.GetComponent<Text>().text = "Avg Votes/Day";
		    fourthcol.transform.parent = firstrow.transform;
		    GameObject fifthcol = Instantiate (colski);
		    fifthcol.GetComponent<Text>().text = "";
		    fifthcol.transform.parent = firstrow.transform;
            firstcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
            secondcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
            thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
            fourthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;
            fifthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth5;
            List<int> k = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if (_tutorial && i == 0 && region == "West")
                {
                    _tutorial = false;
                    GameObject newrowski = Instantiate(rowski);
                    Campaign campaign = tutorialcampaign;
                    storedcampaigns[region].Add(campaign);

                    newrowski.transform.parent = purchasecampaignstable.transform;
                    GameObject namecol = Instantiate(colski);
                    namecol.GetComponent<Text>().text = String.Format("{0}", campaign.name);
                    namecol.transform.parent = newrowski.transform;
                    GameObject typecol = Instantiate(colski);
                    typecol.GetComponent<Text>().text = String.Format("{0}", campaign.type);
                    typecol.transform.parent = newrowski.transform;
                    GameObject cost2buycol = Instantiate(colski);
                    cost2buycol.GetComponent<Text>().text = String.Format("{0:C}", campaign.averagecost * 1000.0F);
                    cost2buycol.transform.parent = newrowski.transform;
                    GameObject averagevotesw = Instantiate(colski);
                    averagevotesw.GetComponent<Text>().text = String.Format("{0:n0}", campaign.avgvotes * 5000.0F);
                    averagevotesw.transform.parent = newrowski.transform;
                    Button addbutton = Instantiate(genericbutton);
                    addbutton.transform.parent = newrowski.transform;
					addbutton.onClick.AddListener(delegate { startClick(region, campaign, addbutton); });
                    addbutton.onClick.AddListener(delegate { tutorial.SendMessage("ThingClicked", "addcampaign"); });
                    addbutton.onClick.AddListener(delegate { addbutton.interactable = false; });
                    namecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
                    typecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
                    cost2buycol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
                    averagevotesw.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;
                }
                else{
                    int campaignnum = UnityEngine.Random.Range(0, allcampaigns[region].Count);
                    while (k.Contains(campaignnum))
                    {
                        campaignnum = UnityEngine.Random.Range(0, allcampaigns[region].Count);
                    }
                    k.Add(campaignnum);
			        GameObject newrowski = Instantiate (rowski);
			        Campaign campaign =  allcampaigns[region][campaignnum];
                    storedcampaigns[region].Add(campaign);
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
			        averagevotesw.GetComponent<Text> ().text = String.Format("{0:n0}", campaign.avgvotes * 5000.0F);
			        averagevotesw.transform.parent = newrowski.transform;
			        Button addbutton = Instantiate (genericbutton);
			        addbutton.transform.parent = newrowski.transform;
					addbutton.onClick.AddListener(delegate{startClick(region, campaign, addbutton);});
                    addbutton.onClick.AddListener(delegate { addbutton.interactable = false; });
                    namecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
                    typecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
                    cost2buycol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
                    averagevotesw.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;
                }

			

		    }
        }
        else
        {
            float totalscreenwidth = RectTransformExtensions.GetWidth(purchasecampaignstable.GetComponent<RectTransform>());
            var children = new List<GameObject>();
            foreach (Transform child in purchasecampaignstable.transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
            GameObject firstrow = Instantiate(rowski);
            firstrow.transform.parent = purchasecampaignstable.transform;
            GameObject firstcol = Instantiate(colski);
            firstcol.GetComponent<Text>().text = "Name";
            firstcol.transform.parent = firstrow.transform;
            GameObject secondcol = Instantiate(colski);
            secondcol.GetComponent<Text>().text = "Campaign Type";
            secondcol.transform.parent = firstrow.transform;
            GameObject thirdcol = Instantiate(colski);
            thirdcol.GetComponent<Text>().text = "Avg Cost/Day";
            thirdcol.transform.parent = firstrow.transform;
            GameObject fourthcol = Instantiate(colski);
            fourthcol.GetComponent<Text>().text = "Avg Votes/Day";
            fourthcol.transform.parent = firstrow.transform;
            GameObject fifthcol = Instantiate(colski);
            fifthcol.GetComponent<Text>().text = "";
            fifthcol.transform.parent = firstrow.transform;
            firstcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
            secondcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
            thirdcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
            fourthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;
            fifthcol.GetComponent<LayoutElement>().preferredWidth = preferredwidth5;

            for (int i = 0; i < 4; i++)
            {
                

                GameObject newrowski = Instantiate(rowski);
                Campaign campaign = storedcampaigns[region][i];
                newrowski.transform.parent = purchasecampaignstable.transform;
                GameObject namecol = Instantiate(colski);
                namecol.GetComponent<Text>().text = String.Format("{0}", campaign.name);
                namecol.transform.parent = newrowski.transform;
                GameObject typecol = Instantiate(colski);
                typecol.GetComponent<Text>().text = String.Format("{0}", campaign.type);
                typecol.transform.parent = newrowski.transform;
                GameObject cost2buycol = Instantiate(colski);
                cost2buycol.GetComponent<Text>().text = String.Format("{0:C}", campaign.averagecost * 1000.0F);
                cost2buycol.transform.parent = newrowski.transform;
                GameObject averagevotesw = Instantiate(colski);
                averagevotesw.GetComponent<Text>().text = String.Format("{0:n0}", campaign.avgvotes * 5000.0F);
                averagevotesw.transform.parent = newrowski.transform;
                Button addbutton = Instantiate(genericbutton);
                addbutton.transform.parent = newrowski.transform;
				addbutton.onClick.AddListener(delegate { startClick(region, campaign, addbutton); });
                addbutton.onClick.AddListener(delegate { addbutton.interactable = false; });
                namecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth1;
                typecol.GetComponent<LayoutElement>().preferredWidth = preferredwidth2;
                cost2buycol.GetComponent<LayoutElement>().preferredWidth = preferredwidth3;
                averagevotesw.GetComponent<LayoutElement>().preferredWidth = preferredwidth4;
                



            }
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
        List<List<Campaign>> financecampaignslist = new List<List<Campaign>>()
        {
            financecampaigns,
            financecampaigns1,
            financecampaigns2,
            financecampaigns3

        };

        List<List<Campaign>> environmentcampaignslist = new List<List<Campaign>>()
        {
            environmentcampaigns,
            environmentcampaigns1,
            environmentcampaigns2,
            environmentcampaigns3

        };
        List<List<Campaign>> healthcarecampaignslist = new List<List<Campaign>>()
        {
            healthcarecampaigns,
            healthcarecampaigns1,
            healthcarecampaigns2,
            healthcarecampaigns3

        };

        List<List<Campaign>> immigrationcampaignslist = new List<List<Campaign>>(){
            immigrationcampaigns,
            immigrationcampaigns1,
            immigrationcampaigns2,
            immigrationcampaigns3
        };
        

        specialcampaigns.Add("Healthcare", healthcarecampaignslist);
        specialcampaigns.Add("Immigration", immigrationcampaignslist);
        specialcampaigns.Add("Finance", financecampaignslist);
        specialcampaigns.Add("Environment", environmentcampaignslist);
		newday.Add("West", true);
		newday.Add("Midwest", true);
		newday.Add("South", true);
		newday.Add("NewEngland", true);
        storedcampaigns.Add("West", new List<Campaign>());
        storedcampaigns.Add("Midwest", new List<Campaign>());
        storedcampaigns.Add("South", new List<Campaign>());
        storedcampaigns.Add("NewEngland", new List<Campaign>());
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

	private void startClick(string region, Campaign campaign, Button addbutton){
        if (activecampaigns[region].Count >= 3)
        {
            
#if UNITY_EDITOR
                EditorUtility.DisplayDialog("Too Many Campaigns", "You Can Only Have Three Campaigns in a Region", "Okay");
#endif
			addbutton.interactable = true;

        }
        else
        {
            allcampaigns[region].Remove(campaign);
			storedcampaigns [region].Remove (campaign);
            campaign.region = region;
            activecampaigns[region].Add(campaign);

            deleteCreated();
            makeRowsActive(region);
        }
        
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
            for (int i = 0; i < advisor.type.Count; i++)
            {
                Hilary.campaignboosts[advisor.type[i]] += 0.10F * advisor.tier[i];
                Hilary.corporateboosts[advisor.type[i]] += 0.10F * advisor.tier[i];
            }
        }
        foreach (Corporation corporation in corporatepanel.GetComponent<CorpScript>().corporationsowned)
        {
            Hilary.campaignboosts[corporation.type] -= 0.15F * corporation.costtobuy/1000000.0F;
            Debug.Log(Hilary.campaignboosts[corporation.type]);  
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
                float votes = GenerateFromGaussian (campaign.avgvotes*5000.0F, campaign.volvotes*5000.0F);
                if (campaign.type !="General")
				    votes = (1.0F + Hilary.campaignboosts[campaign.type]) *votes;
                Debug.Log(String.Format("Votes: {0}", votes));
                if (votes >= 0)
                {
                    IncreasePopularity(votes, region.name);
                    ttlvotestoincrement += votes;
                    campaign.votesovertimecamp.Add(campaign.votesovertimecamp[campaign.votesovertimecamp.Count - 1] + votes);


                }
                else
                {
                    campaign.votesovertimecamp.Add(0.0F);
                }
			}
		}
        ttlmoneytoincrement += corporatepanel.GetComponent<CorpScript>().GetWeeklyMoneyFromCorporations();
        ttlmoneytoincrement += -adviserspanel.GetComponent<AdvisorScript>().GetTotalAdvisorCost();


        IncreaseMoney(ttlmoneytoincrement);
        moneyovertime.Add(getTotalMoney());
        votesovertime.Add(getTotalPopularity());
		dailysummarypanel.transform.localPosition = new Vector3 (0.0F, 0.0F, 0.0F);
        adviserspanel.GetComponent<AdvisorScript>()._newday = true;
        corporatepanel.GetComponent<CorpScript>()._newday = true;
        voterpanel.GetComponent<VoteScript>()._newday = true;
        attackcanvas.GetComponent<AttackMarketplaceScript>()._newday = true;
        List<string> keys = newday.Keys.ToList();
        foreach (string key in keys)
        {
            newday[key] = true;
            storedcampaigns[key].Clear();
        }
        if (getTotalMoney() < 0.0F && belowzero < 3)
        {
            #if UNITY_EDITOR

                EditorUtility.DisplayDialog("Ran Out of Money", "Don't worry Goldman just extended you a loan for 1M! Just try not to forget about the little guys on Wall Street, aight?", "Okay");
            #endif
                IncreaseMoney(1000000.0F);

        }
        if (getTotalMoney() < 0.0F && belowzero >= 3)
        {
#if UNITY_EDITOR
            string str = String.Format("Ran Out of Money: {0:n0}", getTotalMoney());
            if (EditorUtility.DisplayDialog(str, "Goldman doesn't think you're worth it.", "Okay"))
            {
                gameOver();
            }
#endif
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
		// move call to popupscript
		welcomebattlepanel.transform.localPosition = new Vector3 (0.0F, 0.0F, 0.0F);
		welcomebattlepanel.GetComponent<WelcomeBattleScript> ().challenger = trump.GetComponent<FighterScript> ().fightername;
		battleobject.GetComponent<BattleScript> ().resetBattle ();
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
        corporateboosts["Environment"] = 0.1F;
        corporateboosts["Finance"] = 0.1F;
        corporateboosts["Immigration"] = 0.1F;
        corporateboosts["Healthcare"] = 0.1F;
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
	