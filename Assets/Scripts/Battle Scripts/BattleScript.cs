using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
//using System;

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

	public GameObject attackmenu;

	public GameObject attackselector;


	public class Attack{
		public string name;
		public float dmg;

		public Attack(string n, float damage) {
			name = n;
			dmg = damage;
		}
	}
	// Use this for initialization
	void Start () {
		_myturn = false;
		List<GameObject> opponents = new List<GameObject> ();
		opponents.Add (trump);

//		Start opoponent move import
		ImportMe();
		ImportOpponents(opponents);

		attack1text.GetComponent<Text>().text = movedict [hilary][0].name;
		attack2text.GetComponent<Text>().text = movedict [hilary][1].name;
		attack3text.GetComponent<Text>().text = movedict [hilary][2].name;
		attack4text.GetComponent<Text>().text = movedict [hilary][3].name;

		BeginMyTurn ();
	}
	
	// Update is called once per frame
	void Update () {
		HealthUpdate (hilary, hilaryHealthText);
		HealthUpdate (trump, trumpHealthText);
		if (!_gameover) {
			if (_pausestate) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					Debug.Log ("SPACEY");
					_pausestate = false;
					if (hilary.GetComponent<FighterScript> ().health <= 0) {
						StartCoroutine (AnimateText (hilary.GetComponent<FighterScript> ().fightername + " loses!"));
						Debug.Log ("someone lost");
						_gameover = true;
					} else if (trump.GetComponent<FighterScript> ().health <= 0) {
						StartCoroutine (AnimateText (trump.GetComponent<FighterScript> ().fightername + " loses!"));
						_gameover = true;
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
//					if (Input.GetKeyDown (KeyCode.UpArrow))
//						NavigateMoveMenu (KeyCode.UpArrow);
//					if (Input.GetKeyDown (KeyCode.DownArrow))
//						NavigateMoveMenu (KeyCode.DownArrow);
//					if (Input.GetKeyDown (KeyCode.Return))
//						NavigateMoveMenu (KeyCode.Return);
//					EndMyTurn ();
//					GenerateOpponentAttack (trump);

					if (Input.GetKeyDown (KeyCode.S)) {
						GenerateMyAttack (1, trump, hilary);
						HideMoveMenu ();
						ShowPokeText ();
//					EndMyTurn ();
//					GenerateOpponentAttack (trump);
					}
					if (Input.GetKeyDown (KeyCode.D)) {
						GenerateMyAttack (2, trump, hilary);
						HideMoveMenu ();
						ShowPokeText ();
//					EndMyTurn ();
//					GenerateOpponentAttack (trump);
					}
					if (Input.GetKeyDown (KeyCode.F)) {
						GenerateMyAttack (3, trump, hilary);
						HideMoveMenu ();
						ShowPokeText ();
//					EndMyTurn ();
//					GenerateOpponentAttack (trump);
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
		float randf = Random.value * movedict [opponent].Count;
		int randi = (int) randf;
		Debug.Log (randi);
		Attack randattack = movedict [opponent] [randi];
		hilary.GetComponent<FighterScript> ().health -= randattack.dmg;
		string opponentname = opponent.GetComponent<FighterScript> ().fightername;
		StartCoroutine(AnimateText(opponentname + " used " + randattack.name + "\u25BC"));
		StartCoroutine(AnimateSprite (hilary));
	}

	void GenerateMyAttack(int attackindex, GameObject opponent, GameObject me) {
		Attack attack = movedict [me] [attackindex];
		opponent.GetComponent<FighterScript> ().health -= attack.dmg;
		StartCoroutine(AnimateText("You used " + attack.name + "\u25BC"));
		StartCoroutine(AnimateSprite (opponent));
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
	IEnumerator AnimateSprite(GameObject fighter){
		int vibecount = 0;
		bool lastright = true;
		while (vibecount < 8) {
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
		Debug.Log (key);
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

			opponentattacks.Add(new Attack (attack1name, attack1damage));
			opponentattacks.Add(new Attack (attack2name, attack2damage));
			opponentattacks.Add(new Attack (attack3name, attack3damage));
			opponentattacks.Add(new Attack (attack4name, attack4damage));
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

		myattacks.Add(new Attack (attack1name, attack1damage));
		myattacks.Add(new Attack (attack2name, attack2damage));
		myattacks.Add(new Attack (attack3name, attack3damage));
		myattacks.Add(new Attack (attack4name, attack4damage));
		movedict.Add(hilary, myattacks);
	}
}