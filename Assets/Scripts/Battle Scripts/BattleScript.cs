using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Attack{
	public string name;
	public float dmg;
	public int acc; // range 0-100

	public Attack(string n, float damage, int accuracy) {
		name = n;
		dmg = damage;
		acc = accuracy;
	}
}

public class BattleScript : MonoBehaviour {
	public GameObject trump;
	public GameObject hilary;
//	private bool _textisavailable = true;
	private Dictionary<GameObject, List<Attack>> movedict = new Dictionary<GameObject,  List<Attack>>();
	private bool _myturn;
	public Text poketext;
	public GameObject poketextobject;
	public Text hilaryHealthText;
	public Text trumpHealthText;
	private bool _pausestate = false;
	public bool _gameover = false;

	public Text attack1text;
	public Text attack2text;
	public Text attack3text;
	public Text attack4text;
	public Text attackDescription;
	public bool attackHit;

	public GameObject attackmenu;

	public GameObject attackselector;

	private Vector3 attack1textselectionlocation = new Vector3(-83f, -135f, 0f);
	private Vector3 attack2textselectionlocation = new Vector3(-83f, -156f, 0f);
	private Vector3 attack3textselectionlocation = new Vector3(-83f, -177f, 0f);
	private Vector3 attack4textselectionlocation = new Vector3(-83f, -198f, 0f);

	public int currentattackselectorchoice = 0;
	public GameObject finishbattlepanel;
	public GameObject welcomebattlepanel;


	public List<Vector3> attacktextselectionlocations = new List<Vector3>();



	// Use this for initialization
	void Start () {
		// initAttackLocations()
		attacktextselectionlocations.Add(attack1textselectionlocation);
		attacktextselectionlocations.Add(attack2textselectionlocation);
		attacktextselectionlocations.Add(attack3textselectionlocation);
		attacktextselectionlocations.Add(attack4textselectionlocation);

		attackselector.transform.localPosition = attacktextselectionlocations [currentattackselectorchoice];

		_myturn = false;
		List<GameObject> opponents = new List<GameObject> ();
		opponents.Add (trump);

		// move call to popupscript
		welcomebattlepanel.transform.localPosition = new Vector3 (0.0F, 0.0F, 0.0F);
		welcomebattlepanel.GetComponent<WelcomeBattleScript> ().challenger = trump.GetComponent<FighterScript> ().fightername;

//		Start opoponent move import
		ImportMe();
		ImportOpponents(opponents);

		//initAttackText();
		attack1text.GetComponent<Text>().text = movedict [hilary][0].name;
		attack2text.GetComponent<Text>().text = movedict [hilary][1].name;
		attack3text.GetComponent<Text>().text = movedict [hilary][2].name;
		attack4text.GetComponent<Text>().text = movedict [hilary][3].name;

		attackDescription.GetComponent<Text> ().text = "Base Power: " + movedict [hilary] [currentattackselectorchoice].dmg
			+ "\nAccuracy: " + movedict [hilary] [currentattackselectorchoice].acc;
		BeginMyTurn ();
	}
	
	// Update is called once per frame
	void Update () {
		HealthUpdate (hilary, hilaryHealthText);
		HealthUpdate (trump, trumpHealthText);
		if (!_gameover) {
			if (_pausestate) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					Debug.Log ("space");
					_pausestate = false;
					if (hilary.GetComponent<FighterScript> ().health <= 0) {
						StartCoroutine (AnimateText (hilary.GetComponent<FighterScript> ().fightername + " loses!"));
						Debug.Log ("someone lost");
						_gameover = true;
						finishbattlepanel.transform.localPosition = new Vector3 (0.0F, 0.0F, 0.0F);
						finishbattlepanel.GetComponent<FinishBattleScript> ().winner = trump.GetComponent<FighterScript> ().fightername;
					} else if (trump.GetComponent<FighterScript> ().health <= 0) {
						StartCoroutine (AnimateText (trump.GetComponent<FighterScript> ().fightername + " loses!"));
						_gameover = true;
						finishbattlepanel.transform.localPosition = new Vector3 (0.0F, 0.0F, 0.0F);
						finishbattlepanel.GetComponent<FinishBattleScript> ().winner = hilary.GetComponent<FighterScript> ().fightername;
						Debug.Log ("someone lost");
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
						NavigateMoveMenu (KeyCode.UpArrow);
						attackDescription.GetComponent<Text> ().text = "Base Power: " + movedict [hilary] [currentattackselectorchoice].dmg
							+ "\nAccuracy: " + movedict [hilary] [currentattackselectorchoice].acc;
					}
					if (Input.GetKeyDown (KeyCode.DownArrow)) {
						NavigateMoveMenu (KeyCode.DownArrow);
						attackDescription.GetComponent<Text> ().text = "Base Power: " + movedict [hilary] [currentattackselectorchoice].dmg
							+ "\nAccuracy: " + movedict [hilary] [currentattackselectorchoice].acc;
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						NavigateMoveMenu (KeyCode.Space);
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
		attackHit = determineAttackHit (attack);
		if (attackHit == true) {
			float atkDmg = (float)Math.Round (GenerateFromGaussian (attack.dmg, 3), 0);
			opponent.GetComponent<FighterScript> ().health -= atkDmg;
			Debug.Log ("You dealt " + atkDmg + " damage.");
			StartCoroutine (AnimateText (me.name + " used " + attack.name + "\u25BC"));
			StartCoroutine (AnimateSprite (opponent, 8));
		} else {
			Debug.Log ("attack missed");
			StartCoroutine (AnimateText (attack.name + " missed! " + "\u25BC"));
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
		if (key == KeyCode.Space) {
			GenerateMyAttack (currentattackselectorchoice, trump, hilary);
//			Debug.Log ("HIT RETURN YO");
			HideMoveMenu ();
			ShowPokeText ();
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

			string attack1name = curopponent.GetComponent<FighterScript>().attack1name;
			string attack2name = curopponent.GetComponent<FighterScript>().attack2name;
			string attack3name = curopponent.GetComponent<FighterScript>().attack3name;
			string attack4name = curopponent.GetComponent<FighterScript>().attack4name;

			float attack1damage = curopponent.GetComponent<FighterScript>().attack1damage;
			float attack2damage = curopponent.GetComponent<FighterScript>().attack2damage;
			float attack3damage = curopponent.GetComponent<FighterScript>().attack3damage;
			float attack4damage = curopponent.GetComponent<FighterScript>().attack4damage;

			int attack1accuracy = curopponent.GetComponent<FighterScript>().attack1accuracy;
			int attack2accuracy = curopponent.GetComponent<FighterScript>().attack2accuracy;
			int attack3accuracy = curopponent.GetComponent<FighterScript>().attack3accuracy;
			int attack4accuracy = curopponent.GetComponent<FighterScript>().attack4accuracy;

			opponentattacks.Add(new Attack (attack1name, attack1damage, attack1accuracy));
			opponentattacks.Add(new Attack (attack2name, attack2damage, attack2accuracy));
			opponentattacks.Add(new Attack (attack3name, attack3damage, attack3accuracy));
			opponentattacks.Add(new Attack (attack4name, attack4damage, attack4accuracy));
			movedict.Add(curopponent, opponentattacks);
		}
	}
	void ImportMe() {
		List<Attack> myattacks = new List<Attack> ();
		string attack1name = hilary.GetComponent<FighterScript>().attack1name;
		string attack2name = hilary.GetComponent<FighterScript>().attack2name;
		string attack3name = hilary.GetComponent<FighterScript>().attack3name;
		string attack4name = hilary.GetComponent<FighterScript>().attack4name;

		float attack1damage = hilary.GetComponent<FighterScript>().attack1damage;
		float attack2damage = hilary.GetComponent<FighterScript>().attack2damage;
		float attack3damage = hilary.GetComponent<FighterScript>().attack3damage;
		float attack4damage = hilary.GetComponent<FighterScript>().attack4damage;

		int attack1accuracy = hilary.GetComponent<FighterScript>().attack1accuracy;
		int attack2accuracy = hilary.GetComponent<FighterScript>().attack2accuracy;
		int attack3accuracy = hilary.GetComponent<FighterScript>().attack3accuracy;
		int attack4accuracy = hilary.GetComponent<FighterScript>().attack4accuracy;

		myattacks.Add(new Attack (attack1name, attack1damage, attack1accuracy));
		myattacks.Add(new Attack (attack2name, attack2damage, attack2accuracy));
		myattacks.Add(new Attack (attack3name, attack3damage, attack3accuracy));
		myattacks.Add(new Attack (attack4name, attack4damage, attack4accuracy));
		movedict.Add(hilary, myattacks);
	}

	void initAttackLocations(){
		attacktextselectionlocations.Add(attack1textselectionlocation);
		attacktextselectionlocations.Add(attack2textselectionlocation);
		attacktextselectionlocations.Add(attack3textselectionlocation);
		attacktextselectionlocations.Add(attack4textselectionlocation);

		attackselector.transform.localPosition = attacktextselectionlocations [currentattackselectorchoice];

	}
	void initAttackNames(){
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
		attackDescription.GetComponent<Text> ().text = "Base Power: " + movedict [hilary] [currentattackselectorchoice].dmg
		+ "\nAccuracy: " + movedict [hilary] [currentattackselectorchoice].acc;
	}

	bool determineAttackHit(Attack att){
		var random = new System.Random ();
		int attackAcc = att.acc;
		if (random.Next (0, 100) < attackAcc)
			return true;
		else
			return false;
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