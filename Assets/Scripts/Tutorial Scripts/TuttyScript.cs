using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Timers;

public class TutorialThing {
	public GameObject arrow;
	public string text;
	public string thingtoproceed;

	public TutorialThing (GameObject tutorialarrow, string tutorialtext, string thingtoproc) {
		arrow = tutorialarrow;
		text = tutorialtext;
		thingtoproceed = thingtoproc;
	}
}
public class TuttyScript : MonoBehaviour {
	private int stepintut = 0;
	public Text tuttext;
	public GameObject continuebtn;
	public GameObject votestutarrow;
	public GameObject daystutarrow;
	public GameObject southtutarrow;
	public GameObject westtutarrow;
	public GameObject netutarrow;
	public GameObject midwesttutarrow;
	public GameObject managecorpsarrow;
	public GameObject moneyarrow;
	public GameObject adviserarrow;
	public GameObject addcampaignarrow;
	public GameObject activecampaignsarrow;
	public GameObject xcamparrow;
	public GameObject votetutarrow;
	public GameObject atkarrow;
	public GameObject self;
	public GameObject mapcanvas;
	public GameObject battlecanvas;
    public GameObject battleobject;
	public GameObject gainlosstext;

	public GameObject popup;

	public AudioSource mysource;
	public AudioClip mysound;

	private string thingtoproceed;

	private List<GameObject> arrows = new List<GameObject>();
	public List<TutorialThing> tuttylist = new List<TutorialThing> ();

//	Vector2 goodby = ;
	// Use this for initialization
	void Start () {
		tuttylist = new List<TutorialThing> () {
			new TutorialThing(null, "Welcome to our game!",  null),
			new TutorialThing(null, "In this game, you are running for President of the United States of America (POTUS).",null),
			new TutorialThing(null, "You need 150,000,000 votes to win.",null),
			new TutorialThing(votestutarrow, "The number of votes you currently have is here.",null),
			new TutorialThing(null, "There are four types of voters: \n Hippies, \n Immigrants, \n Geriatrics, \n and The 99%", null),
			new TutorialThing(null, "There are four regions",null),
			new TutorialThing(southtutarrow, "South,",null),
			new TutorialThing(westtutarrow, "West,",null),
			new TutorialThing(midwesttutarrow, "Midwest,",null),
			new TutorialThing(netutarrow, "and New England.",null),
			new TutorialThing(null, "You can run up to 3 campaigns in a region. Each campaign has a category: \n Environmental, \n Immigration, \n Healthcare, \n and Finance.",null),
			new TutorialThing(null, "Specific campaigns help you get certain types of voters: \n Environmental - Hippies, \n Immigration - Immigrants, \n Healthcare - Geriatrics, \n Finance - The 99%.",null),
			new TutorialThing(westtutarrow, "Go ahead, click on the West to see what campaigns you can add.","west"),
			new TutorialThing(null, "Campaigns will only charge you on a daily basis, not upfront. The prices and votes listed are a daily average, however they fluctuate for various reasons.",null),
			new TutorialThing(addcampaignarrow, "Go ahead and flier at the library.", "addcampaign"),
			new TutorialThing(activecampaignsarrow, "You can click here to see that you are now running the fliering campaign.", "activecamps"),
			new TutorialThing(xcamparrow, "Let's go back to the main screen.","popupx"),
			new TutorialThing(null, "The way to make money in a campaign, of course, is to have control over corporations that anonymously give you money since corporations are people.",null),
			new TutorialThing(managecorpsarrow, "Anyway, let's check out the manage corporations pane.","managecorps"),
			new TutorialThing(null, "Adding corporations will charge you right away. But they will give you money every day.", null),
			new TutorialThing(null, "But beware, the bigger the corporation, the more they hurt your campaign.", null),
			new TutorialThing(null, "Owning Goldman Sachs makes your finance campaigns less effective.", null),
			new TutorialThing(null, "Owning Exxon makes your environmental campaigns less effective.", null),
			new TutorialThing(moneyarrow, "By the way, the money you have is shown here.", null),
			new TutorialThing(null, "Let's go back to the main screen.", "corpx"),
			new TutorialThing(adviserarrow, "Now let's check out the advisers available.", "manageadvisers"),
			new TutorialThing(null, "Advisers enhance the effectiveness of your campaigns. They also open up certain campaigns.", null),
			new TutorialThing(null, "Better (and costlier) advisers open up higher tiered campaigns. The higher the tier, the better the campaign", null),
			new TutorialThing(null, "If you buy an environmental adviser, more environmental campaigns will be available. Also, environmental campaigns will earn you more hippie voters.",null),
			new TutorialThing(null, "Let's go back to the main screen.","adviserx"),
			new TutorialThing(votetutarrow, "Let's go buy some votes!", "votemark"),
			new TutorialThing(null, "Gotcha! Votes are really expensive to buy, but save up! Remember, it takes 150,000,000 to win.", null),
			new TutorialThing(null, "Let's go back to the main screen.","votesx"),
			new TutorialThing(null, "Now is the moment you've been waiting for...", null),
			new TutorialThing(null, "...", null),
			new TutorialThing(null, "...", null),
			new TutorialThing(null, "!!!", null),
			new TutorialThing(null, "Trump Challenges YOU to a debate! Press Continue to start.", "startbat"),
			new TutorialThing(null, "Use the arrow keys to choose an attack.", "udclick"),
			new TutorialThing(null, "Use the Return key to use it.", "rtclick"),
            new TutorialThing(null, "Make sure you keep track of your PP. If it hits zero, then you cannot use the move anymore.", "rtclick"),
            new TutorialThing(null, "Also, everytime your move hits, its power decreases.", "rtclick"),
            new TutorialThing(null, "Go ahead finish the battle.", "spclick"),
			new TutorialThing(null, "Winning and losing debates significantly affects the amount of votes you have. You can lose votes in a debate.", null),
			new TutorialThing(atkarrow, "You can buy attacks in the marketplace. Let's check it out.", "atkclicked"),
			new TutorialThing(null, "You may only have 4 attacks at a time. Attacks lose their effectiveness as you use them more, so make sure to buy new ones.", null),
			new TutorialThing(null, "Let's go back to the main screen.", "atkx"),
			new TutorialThing(null, "That's all! Good luck!", null),
			new TutorialThing(daystutarrow, "You have 100 days.",null),
		};

		refreshTut();
//		self.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	}

	public void ContinueClicked() {
		if (thingtoproceed == null) {
			stepintut += 1;
		}
		refreshTut ();
	}
	public void CleanArrows() {
		Debug.Log ("CLEAAAAN" + tuttylist.Count);
		foreach (TutorialThing tutt in tuttylist) {
			GameObject arr = tutt.arrow;
			if (arr != null) {
				arr.SetActive (false);
			}
		}
	}

	void refreshTut() {
		foreach (TutorialThing tutt in tuttylist) {
			GameObject arr = tutt.arrow;
			if (arr != null) {
				arr.SetActive (false);
			}
		}
		if (stepintut == tuttylist.Count) { 
			gameObject.SetActive (false);
		} else {
			tuttext.GetComponent<Text> ().text = tuttylist [stepintut].text;
			if (tuttylist [stepintut].arrow != null) {
				tuttylist [stepintut].arrow.SetActive (true);
			}
			thingtoproceed = tuttylist [stepintut].thingtoproceed;
			if (thingtoproceed != null) {
				continuebtn.SetActive (false);
			} else {
				continuebtn.SetActive (true);
			}
		}
		if (tuttylist [stepintut].text == "Now is the moment you've been waiting for...") {
			mysource.clip = mysound;
			mysource.Play ();
		}
		if (tuttylist [stepintut].text == "Trump Challenges YOU to a debate! Press Continue to start.") {
			Debug.Log ("AH!");
			popup.GetComponent<PopupScript> ().switchtoBattleScene ();
		}
        if (tuttylist[stepintut].text == "Winning and losing debates significantly affects the amount of votes you have. You can lose votes in a debate.")
        {
            mysource.Stop();
            mapcanvas.SetActive(true);
            battlecanvas.SetActive(false);
            battleobject.GetComponent<BattleScript>().ImportMe();
            battleobject.SetActive(false);
			gainlosstext.SetActive (false);
        }
	}

	public void ThingClicked(string thing) {
		Debug.Log (thing);
		Debug.Log ("ttproc" + thingtoproceed);
		if (thing == thingtoproceed) {
			thingtoproceed = null;
			ContinueClicked ();
		}
	}
}
