using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TuttyScript : MonoBehaviour {
	private int stepintut = 0;
	public Text tuttext;
	public GameObject votestutarrow;
	public GameObject daystutarrow;
	public GameObject southtutarrow;
	public GameObject westtutarrow;
	public GameObject netutarrow;
	public GameObject midwesttutarrow;
	public GameObject managecorpsarrow;
	public GameObject moneyarrow;
	public GameObject adviserarrow;

	private string thingtoproceed;
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
			new TutorialThing(null, "There are four types of voters: \n Hippies, \n Immigrants, \n Geriatrics, \n and Businessmen",null),
			new TutorialThing(null, "There are four regions",null),
			new TutorialThing(southtutarrow, "South,",null),
			new TutorialThing(westtutarrow, "West,",null),
			new TutorialThing(midwesttutarrow, "Midwest,",null),
			new TutorialThing(netutarrow, "and New England,",null),
			new TutorialThing(null, "You can run up to 3 campaigns in a region. Each campaign has a category: \n Environmental, \n Immigration, \n Healthcare, \n and Finance.",null),
			new TutorialThing(null, "Specific campaigns help you get certain types of voters: \n Environmental - Hippies, \n Immigration - Immigrants, \n Healthcare - Geriatrics, \n Finance - Businessmen.",null),
			new TutorialThing(null, "Go ahead, click on the West to see what campaigns you can add.","west"),
			new TutorialThing(null, "Campaigns will only charge you on a daily basis, not upfront. The prices and votes listed are a daily average, however they fluctuate for various reasons.",null),
			new TutorialThing(null, "Go ahead and flier at the library.", "addcampaign"),
			new TutorialThing(null, "Let's go back to the main screen.","popupx"),
			new TutorialThing(null, "The way to make money in a campaign, of course, is to have control over corporations that anonymously give you money since corporations are people.",null),
			new TutorialThing(managecorpsarrow, "Anyway, let's check out the manage corporations pane.","managecorps"),
			new TutorialThing(null, "Adding corporations will charge you right away. But they will give you money every day.", null),
			new TutorialThing(moneyarrow, "By the way, the money you have is shown here", null),
			new TutorialThing(null, "Let's go back to the main screen.", "corpx"),
			new TutorialThing(adviserarrow, "Now let's check out the advisers available.", "manageadvisers"),
			new TutorialThing(null, "Advisers enhance the effectiveness of your campaigns. They also open up certain campaigns. If you buy an environmental adviser, more environmental campaigns will be available. Also, environmental campaigns will earn you more hippie voters.", null),
			new TutorialThing(daystutarrow, "You have 100 days",null),
		};
		refreshTut ();
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
	void refreshTut() {
		List<GameObject> arrows = new List<GameObject> ();
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
		}
	}

	public void ThingClicked(string thing) {
		Debug.Log (thing);
		Debug.Log ("ttproc" + thingtoproceed);
		if (thing == thingtoproceed) {
			thingtoproceed = null;
		}
	}
}
