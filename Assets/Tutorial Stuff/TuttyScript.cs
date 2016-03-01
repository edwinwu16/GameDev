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
			daystutarrow};
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
