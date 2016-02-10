using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
//using System;

public class BattleScript : MonoBehaviour {
	public GameObject trump;
	public GameObject hilary;
//	private bool _textisavailable = true;
	private Dictionary<GameObject, List<Attack>> movelist = new Dictionary<GameObject,  List<Attack>>();
	private bool _myturn;
	public Text poketext;
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
		List<Attack> hilaryattacks = new List<Attack> ();
		hilaryattacks.Add(new Attack ("rawr", 0.1f));
		hilaryattacks.Add(new Attack ("boom!", 0.2f));
		hilaryattacks.Add(new Attack ("heyoo", 0.18f));
		hilaryattacks.Add(new Attack ("eat that!", 0.1f));
		movelist.Add(hilary, hilaryattacks);

		List<Attack> trumpattacks = new List<Attack> ();
		trumpattacks.Add(new Attack ("booo", 0.1f));
		trumpattacks.Add(new Attack ("go catz!", 0.2f));
		trumpattacks.Add(new Attack ("eat me", 0.18f));
		trumpattacks.Add(new Attack ("hiyaaa!", 0.21f));
		movelist.Add(trump, trumpattacks);

		BeginMyTurn ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_myturn) {
			if (Input.GetKeyDown (KeyCode.A)) {
				GenerateMyAttack (0, trump, hilary);
				EndMyTurn ();
				GenerateOpponentAttack (trump);
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				GenerateMyAttack (1, trump, hilary);
				EndMyTurn ();
				GenerateOpponentAttack (trump);
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				GenerateMyAttack (2, trump, hilary);
				EndMyTurn ();
				GenerateOpponentAttack (trump);
			}
			if (Input.GetKeyDown (KeyCode.F)) {
				GenerateMyAttack (3, trump, hilary);
				EndMyTurn ();
				GenerateOpponentAttack (trump);
			}
		}
	}
	void BeginMyTurn() {
		_myturn = true;
	}
	void EndMyTurn() {
		_myturn = false;
	}
	void GenerateOpponentAttack(GameObject opponent) {
//		Debug.Log (Random.value);
//		yield return new WaitForSeconds(1);
		float randf = Random.value * movelist [opponent].Count;
		int randi = (int) randf;
		Debug.Log (randi);
		Attack randattack = movelist [opponent] [randi];
		hilary.GetComponent<FighterScript> ().health -= randattack.dmg;
		string opponentname = opponent.GetComponent<FighterScript> ().name;
		StartCoroutine(AnimateText(opponentname + " used " + randattack.name));
		BeginMyTurn ();
	}

	void GenerateMyAttack(int attackindex, GameObject opponent, GameObject me) {
		Attack attack = movelist [me] [attackindex];
		opponent.GetComponent<FighterScript> ().health -= attack.dmg;
//		while (!_textisavailable) {
//		}
		StartCoroutine(AnimateText("You used " + attack.name));
	}

	IEnumerator AnimateText(string strComplete){
//		_textisavailable = false;
		int i = 0;
		string str = "";
		while( i < strComplete.Length ){
			str += strComplete[i++];
			poketext.GetComponent<Text> ().text = str;
			yield return new WaitForSeconds(0.03F);
		}
//		_textisavailable = true;
	}
}