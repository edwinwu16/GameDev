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

	private string thingtoproceed;

	private List<GameObject> arrows = new List<GameObject>();
	private List<string> textlist = new List<string> () { "Welcome to our game!", 
		"In this game, you are running for President of the United States of America (POTUS).",
		"You need 150,000,000 votes to win.",
		"The number of votes you currently have is here.",
		"There are four types of voters: \n Hippies, \n Immigrants, \n Geriatrics, \n and Businessmen",
		"There are four regions",
		"South,",
		"West,",
		"Midwest,",
		"and New England,",
		"You can run up to 3 campaigns in a region. Each campaign has a category: \n Environmental, \n Immigration, \n Healthcare, \n and Finance.",
		"Specific campaigns help you get certain types of voters: \n Environmental - Hippies, \n Immigration - Immigrants, \n Healthcare - Geriatrics, \n Finance - Businessmen.",
		"Go ahead, click on the West to see what campaigns you can add.",
		"Add a campaign if you'd like. Campaigns will only charge you on a daily basis, not upfront. The prices and votes listed are a daily average, however they fluctuate for various reasons.",
		"Let's go back to the main page.",
		"The way to make money in a campaign, of course, is to have control over corporations that anonymously give you money since corporations are people.",
		"Anyway, let's check out the manage corporations pane.",
		"You have 100 days",
		};

	private List<string> thingstoproceed = new List<string> () { null, 
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		"west",
		null,
		"popupx",
		null,
		"managecorps",
		null,
	};
//	Vector2 goodby = ;
	// Use this for initialization
	void Start () {
		arrows = new List<GameObject>() {null,
			null,
			null,
			votestutarrow,
			null,
			null,
			southtutarrow,
			westtutarrow,
			midwesttutarrow,
			netutarrow,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			daystutarrow};
		Debug.Assert ((arrows.Count == thingstoproceed.Count) & (thingstoproceed.Count == textlist.Count));
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
		foreach (GameObject arr in arrows) {
			if (arr != null) {
				arr.SetActive (false);
			}
		}

		if (stepintut == textlist.Count) { 
			gameObject.SetActive (false);
		} else {
			tuttext.GetComponent<Text> ().text = textlist [stepintut];
			if (arrows [stepintut] != null) {
				arrows [stepintut].SetActive (true);
			}
			thingtoproceed = thingstoproceed [stepintut];
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
