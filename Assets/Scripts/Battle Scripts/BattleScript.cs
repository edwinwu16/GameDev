using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Attack{
	public string name;
	public float dmg;
	public int acc; // range 0-100
	public float cost;
	public int pp;
	public int basepp;
	public float basedmg;

	public Attack(string n, float damage, int accuracy, float cst, int peep) {
		name = n;
		dmg = damage;
		acc = accuracy;
		cost = cst;
		pp = peep;
		basedmg = damage;
		basepp = peep;
	}
	public Attack(string n, float damage, int accuracy) {
		name = n;
		dmg = damage;
		acc = accuracy;
		basedmg = damage;
	}

	public void DecrementPP(){
		pp -= 1;
	}
	public void ResetAttack(){
		pp = basepp;
		dmg = basedmg;
	}
	public void DecrementDmg() {
		dmg = ((float)pp / (float)basepp) * (float)0.5 * basedmg + (float)0.5 * basedmg;
	}
}

public class BattleScript : MonoBehaviour {
	public bool inbattle = false;
	public bool playerWon;
	public GameObject trump;
	public GameObject hilary;
	public GameObject popupscript;
//	private bool _textisavailable = true;
	public Dictionary<GameObject, List<Attack>> movedict = new Dictionary<GameObject,  List<Attack>>();
	private bool _myturn;
	public Text poketext;
	public GameObject poketextobject;
	public Text hilaryHealthText;
	public Text trumpHealthText;
	private bool _pausestate = false;
	public bool _gameover = false;
    private bool _firsttime = true;

	public Text attack1text;
	public Text attack2text;
	public Text attack3text;
	public Text attack4text;
	public Text attackDescription;
	public bool attackHit;

	public GameObject attackmenu;
	public GameObject attackselector;

	public GameObject tutorial;


	private Vector3 attack1textselectionlocation = new Vector3(-156f, 47f, 0f);
	private Vector3 attack2textselectionlocation = new Vector3(-156f, 26f, 0f);
	private Vector3 attack3textselectionlocation = new Vector3(-156f, 5f, 0f);
	private Vector3 attack4textselectionlocation = new Vector3(-156f, -16f, 0f);

	public int currentattackselectorchoice = 0;
	public GameObject finishbattlepanel;
	public GameObject welcomebattlepanel;


	public List<Vector3> attacktextselectionlocations = new List<Vector3>();



	// Use this for initialization
	void Start () {
		initAttackLocations ();

		_myturn = false;
		List<GameObject> opponents = new List<GameObject> ();
		opponents.Add (trump);

		// move call to popupscript
		welcomebattlepanel.transform.localPosition = new Vector3 (0.0F, 0.0F, 0.0F);
		welcomebattlepanel.GetComponent<WelcomeBattleScript> ().challenger = trump.GetComponent<FighterScript> ().fightername;

//		Start opoponent move import
		//ImportMe();
		ImportOpponents(opponents);

		BeginMyTurn ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inbattle) {
			HealthUpdate (hilary, hilaryHealthText);
			HealthUpdate (trump, trumpHealthText);
			if (!_gameover) {
				if (_pausestate) {
					if (Input.GetKeyDown (KeyCode.Return)) {
						Debug.Log ("space");
						_pausestate = false;
						// you LOSE
						if (hilary.GetComponent<FighterScript> ().health <= 0) {
							StartCoroutine (AnimateText (hilary.GetComponent<FighterScript> ().fightername + " loses!"));
							playerWon = false;
							IncOrDecPopularity (playerWon);
							_gameover = true;
                            if (!_firsttime)
                            {
                                finishbattlepanel.SetActive(true);
                                finishbattlepanel.transform.localPosition = new Vector3(0.0F, 0.0F, 0.0F);
                                finishbattlepanel.GetComponent<FinishBattleScript>().winner = trump.GetComponent<FighterScript>().fightername;
                                tutorial.GetComponent<TuttyScript>().mysource.Stop();
                            }
                            else
                            {
                                tutorial.SendMessage("ThingClicked", "spclick");
                                _firsttime = false;
                            }
						// you WIN
						} else if (trump.GetComponent<FighterScript> ().health <= 0) {
							StartCoroutine (AnimateText (trump.GetComponent<FighterScript> ().fightername + " loses!"));
							playerWon = true;
							IncOrDecPopularity (playerWon);
							_gameover = true;
							Debug.Log ("you win");
                            if (!_firsttime)
                            {
                                finishbattlepanel.SetActive(true);
                                finishbattlepanel.transform.localPosition = new Vector3(0.0F, 0.0F, 0.0F);
                                finishbattlepanel.GetComponent<FinishBattleScript>().winner = hilary.GetComponent<FighterScript>().fightername;
                                tutorial.GetComponent<TuttyScript>().mysource.Stop();
                            }
                            else
                            {
                                tutorial.SendMessage("ThingClicked", "spclick");
                                _firsttime = false;
                            }
						} else {
							if (_myturn) {
								EndMyTurn ();
								GenerateOpponentAttack (trump);
							} else {
								BeginMyTurn ();
							}
						}
					}

					//			StartCoroutine (BlinkArrow ());
				} else {
					if (_myturn) {
						if (Input.GetKeyDown (KeyCode.UpArrow)) {
							tutorial.SendMessage ("ThingClicked", "udclick");
							NavigateMoveMenu (KeyCode.UpArrow);
							updateAttackDescription (currentattackselectorchoice);
						}
						if (Input.GetKeyDown (KeyCode.DownArrow)) {
							tutorial.SendMessage ("ThingClicked", "udclick");
							NavigateMoveMenu (KeyCode.DownArrow);
							updateAttackDescription (currentattackselectorchoice);
						}
						if (Input.GetKeyDown (KeyCode.Return)) {
							updateAttackDescription (currentattackselectorchoice);
							NavigateMoveMenu (KeyCode.Return);
						}
					}
				}
			}
		}
		}
	void BeginMyTurn() {
		_myturn = true;
		ShowMoveMenu ();
		HidePokeText ();
	}
	void EndMyTurn() {
//		StartCoroutine (WaiterBoy ());
		_myturn = false;
		HideMoveMenu ();
		ShowPokeText ();
	}
	void GenerateOpponentAttack(GameObject opponent) {
		_pausestate = true;
		float randf = UnityEngine.Random.value * movedict [opponent].Count;
		int randi = (int) randf;
		Debug.Log (randi);
		Attack randattack = movedict [opponent] [randi];
		attackHit = determineAttackHit (randattack);
		if (attackHit == true) {
			float atkDmg = (float)Math.Round (GenerateFromGaussian (randattack.dmg, 3), 0);
			hilary.GetComponent<FighterScript> ().health -= atkDmg;
			Debug.Log ("Trump dealt " + atkDmg + " damage.");
			string opponentname = opponent.GetComponent<FighterScript> ().fightername;
			StartCoroutine (AnimateText (opponentname + " used " + randattack.name + "\u25BC"));
			StartCoroutine (AnimateSprite (hilary, 8));
		} else {
			Debug.Log ("attack missed");
			StartCoroutine (AnimateText (randattack.name + " missed! " + "\u25BC"));
		}
	}

	void GenerateMyAttack(int attackindex, GameObject opponent, GameObject me) {
		Attack attack = movedict [me] [attackindex];
		if (attack.pp <= 0) {
			StartCoroutine (AnimateText ("Cannot use " + attack.name + " - out of PP! Swap in a new attack in Attack Marketplace." + "\u25BC"));
		} else {
			attackHit = determineAttackHit (attack);
			if (attackHit == true) {
				float atkDmg = (float)Math.Round (GenerateFromGaussian (attack.dmg, 3), 0);
				opponent.GetComponent<FighterScript> ().health -= atkDmg;
				attack.DecrementPP ();
				attack.DecrementDmg ();
				updateAttackDescription (attackindex);
				Debug.Log ("You dealt " + atkDmg + " damage.");
				StartCoroutine (AnimateText (hilary.GetComponent<FighterScript>().fightername + " used " + attack.name + "\u25BC"));
				StartCoroutine (AnimateSprite (opponent, 8));
			} else {
				Debug.Log ("attack missed");
				StartCoroutine (AnimateText (attack.name + " missed! " + "\u25BC"));
			}
		}
		_pausestate = true;
	}


	IEnumerator AnimateText(string strComplete){
		int i = 0;
		string str = "";
		while( i < strComplete.Length ){
			str += strComplete[i++];
			poketext.GetComponent<Text> ().text = str;
			yield return new WaitForSeconds(0.03F);
		}
	}

	void HealthUpdate(GameObject fighter, Text fightertext){
		if (fighter.GetComponent<FighterScript> ().health <= 0)
			fighter.GetComponent<FighterScript> ().health = 0;
		fightertext.GetComponent<Text> ().text = fighter.GetComponent<FighterScript> ().health + "/" + fighter.GetComponent<FighterScript> ().maxhealth;
	}
	IEnumerator AnimateSprite(GameObject fighter, int i){
		int vibecount = 0;
		bool lastright = true;
		while (vibecount < i) {
			if (lastright) {
				fighter.transform.Translate (20, 0, 0);
				lastright = false;
				yield return new WaitForSeconds(0.1f);

			}
			else {
				fighter.transform.Translate (-20, 0, 0);
				lastright = true;
				yield return new WaitForSeconds(0.05f);
			}
					vibecount += 1;
		}
	}
	void NavigateMoveMenu(KeyCode key){
//		Debug.Log ("CURKEY" + key);
//		Debug.Log ("CURRATACKSELECTOR" + currentattackselectorchoice);
		if (key == KeyCode.DownArrow) {
			currentattackselectorchoice += 1;
			if (currentattackselectorchoice == 4) {
				currentattackselectorchoice = 3;
			}
		}
		if (key == KeyCode.UpArrow) {
			currentattackselectorchoice -= 1;
			if (currentattackselectorchoice == -1) {
				currentattackselectorchoice = 0;
			}
		}
		attackselector.transform.localPosition = attacktextselectionlocations [currentattackselectorchoice];
		if (key == KeyCode.Return) {
			GenerateMyAttack (currentattackselectorchoice, trump, hilary);
//			Debug.Log ("HIT RETURN YO");
			HideMoveMenu ();
			ShowPokeText ();
            tutorial.SendMessage("ThingClicked", "rtclick");

		}
	}
	void HideMoveMenu(){
		attackmenu.SetActive (false);
	}
	void ShowMoveMenu(){
		attackmenu.SetActive (true);
	}

	void ShowPokeText(){
		poketextobject.SetActive (true);
	}
	void HidePokeText(){
		poketextobject.SetActive (false);
	}
	void ImportOpponents(List<GameObject> opponents) {
		for (int i = 0; i < opponents.Count; i++) {
			GameObject curopponent = opponents [i];
			List<Attack> opponentattacks = new List<Attack> ();

//			string attack1name = curopponent.GetComponent<FighterScript>().attack1name;
//			string attack2name = curopponent.GetComponent<FighterScript>().attack2name;
//			string attack3name = curopponent.GetComponent<FighterScript>().attack3name;
//			string attack4name = curopponent.GetComponent<FighterScript>().attack4name;
//
//			float attack1damage = curopponent.GetComponent<FighterScript>().attack1damage;
//			float attack2damage = curopponent.GetComponent<FighterScript>().attack2damage;
//			float attack3damage = curopponent.GetComponent<FighterScript>().attack3damage;
//			float attack4damage = curopponent.GetComponent<FighterScript>().attack4damage;
//
//			int attack1accuracy = curopponent.GetComponent<FighterScript>().attack1accuracy;
//			int attack2accuracy = curopponent.GetComponent<FighterScript>().attack2accuracy;
//			int attack3accuracy = curopponent.GetComponent<FighterScript>().attack3accuracy;
//			int attack4accuracy = curopponent.GetComponent<FighterScript>().attack4accuracy;

			opponentattacks.Add(new Attack ("Build Wall", 42, 12));
			opponentattacks.Add(new Attack ("China! China! China!", 51, 15));
			opponentattacks.Add(new Attack ("You Know What They Say About Big Hands...", 40, 20));
			opponentattacks.Add(new Attack ("I Know Words", 23, 40));
			movedict.Add(curopponent, opponentattacks);
		}
	}
	public void ImportMe() {
		List<Attack> myattacks = new List<Attack> ();
//		string attack1name = hilary.GetComponent<FighterScript>().attack1name;
//		string attack2name = hilary.GetComponent<FighterScript>().attack2name;
//		string attack3name = hilary.GetComponent<FighterScript>().attack3name;
//		string attack4name = hilary.GetComponent<FighterScript>().attack4name;
//
//		float attack1damage = hilary.GetComponent<FighterScript>().attack1damage;
//		float attack2damage = hilary.GetComponent<FighterScript>().attack2damage;
//		float attack3damage = hilary.GetComponent<FighterScript>().attack3damage;
//		float attack4damage = hilary.GetComponent<FighterScript>().attack4damage;
//
//		int attack1accuracy = hilary.GetComponent<FighterScript>().attack1accuracy;
//		int attack2accuracy = hilary.GetComponent<FighterScript>().attack2accuracy;
//		int attack3accuracy = hilary.GetComponent<FighterScript>().attack3accuracy;
//		int attack4accuracy = hilary.GetComponent<FighterScript>().attack4accuracy;
		string name = hilary.GetComponent<FighterScript>().fightername;
		Debug.Log ("fighter name is: " + name);
		if (name == "Hillary") {
			myattacks.Add (new Attack ("Send Classified Private Email", 12, 75, 100000, 6));
			myattacks.Add (new Attack ("Three Way Bill Monica Kiss", 20, 55, 1000000, 4));
			myattacks.Add (new Attack ("Beep Boop Beep Boop", 14, 65, 500000, 6));
			myattacks.Add (new Attack ("Take Things Away From You", 22, 50, 100000, 8));
		}else if (name == "Bernie"){
			myattacks.Add (new Attack ("Education is a Right", 12, 75, 10000, 6));
			myattacks.Add (new Attack ("F#$@ Wall Street!", 20, 55, 100000, 4));
			myattacks.Add (new Attack ("I Smoked Marijuana Twice", 14, 70, 50000, 6));
			myattacks.Add (new Attack ("Finger Wag", 22, 50, 10000, 8));
		}
		movedict[hilary] = myattacks;
		initAttackText();
		updateAttackDescription (currentattackselectorchoice);

	}

	void initAttackLocations(){
		attacktextselectionlocations.Add(attack1textselectionlocation);
		attacktextselectionlocations.Add(attack2textselectionlocation);
		attacktextselectionlocations.Add(attack3textselectionlocation);
		attacktextselectionlocations.Add(attack4textselectionlocation);

		attackselector.transform.localPosition = attacktextselectionlocations [currentattackselectorchoice];

	}
	void initAttackText(){
		attack1text.GetComponent<Text>().text = movedict [hilary][0].name;
		attack2text.GetComponent<Text>().text = movedict [hilary][1].name;
		attack3text.GetComponent<Text>().text = movedict [hilary][2].name;
		attack4text.GetComponent<Text>().text = movedict [hilary][3].name;
	}


	public void resetBattle(){
		trump.GetComponent<FighterScript> ().health = trump.GetComponent<FighterScript> ().maxhealth;
		hilary.GetComponent<FighterScript> ().health = hilary.GetComponent<FighterScript> ().maxhealth;
		_gameover = false;

		BeginMyTurn ();
	}

	// battle scene sometimes exits out... I think its because of this function but idk why
	void updateAttackDescription(int i){
		string bp = String.Format ("{0:N0}", movedict [hilary] [currentattackselectorchoice].dmg);
		attackDescription.GetComponent<Text> ().text = "Power: " + bp 
		+ "\nAccuracy: " + movedict [hilary] [currentattackselectorchoice].acc
			+ "\nPP: " + movedict[hilary][currentattackselectorchoice].pp + "/" + movedict[hilary][currentattackselectorchoice].basepp;
	}

	bool determineAttackHit(Attack att){
		var random = new System.Random ();
		int attackAcc = att.acc;
		if (random.Next (0, 100) < attackAcc)
			return true;
		else
			return false;
	}

	public void IncOrDecPopularity(bool playerWon){
		Debug.Log("Inc/Dec worked");
		int currentPopularity = popupscript.GetComponent<PopupScript> ().getTotalPopularity ();
		int popularityChange = (int)((float)currentPopularity * 0.10f);
		if (playerWon == true) {
			popupscript.GetComponent<PopupScript> ().regions ["West"].popularity += popularityChange;
			Debug.Log ("popularity increasd by:  " + popularityChange);
		} else{
			popupscript.GetComponent<PopupScript> ().regions ["West"].popularity -= popularityChange;
			Debug.Log ("popularity decreased by:  " + popularityChange);
		}
	}
//	public void LoserRekt(){
//		int currentPopularity = popupscript.GetComponent<PopupScript> ().getTotalPopularity ();
//		int popularityDecrement = (int)((float)currentPopularity * 0.10f);
//		popupscript.GetComponent<PopupScript>().regions["West"].popularity -= popularityDecrement;
//		Debug.Log("popularity decreased by:  " + popularityDecrement);
//	}

	public List<Attack> GimmeMyAttacks() {
		return movedict [hilary];
	}

	public void SwapMyAttack(int index, Attack newattack) {
		movedict [hilary] [index] = newattack;

		attack1text.GetComponent<Text>().text = movedict [hilary][0].name;
		attack2text.GetComponent<Text>().text = movedict [hilary][1].name;
		attack3text.GetComponent<Text>().text = movedict [hilary][2].name;
		attack4text.GetComponent<Text>().text = movedict [hilary][3].name;
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
}