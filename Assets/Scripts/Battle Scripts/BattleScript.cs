using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleScript : MonoBehaviour {
	public GameObject trump;
	public GameObject hilary;
	private Dictionary<GameObject, List<Attack>> movelist = new Dictionary<GameObject,  List<Attack>>();
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
		List<Attack> hilaryattacks = new List<Attack> ();
		hilaryattacks.Add(new Attack ("rawr", 0.1f));
		movelist.Add(hilary, hilaryattacks);
		Debug.Log (movelist [hilary][0].name);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			
			trump.GetComponent<FighterScript> ().health -= movelist[hilary][0].dmg;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Debug.Log ("S key was pressed");
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			Debug.Log ("D key was pressed");
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			Debug.Log ("space key was F");
		}
		
	}
}