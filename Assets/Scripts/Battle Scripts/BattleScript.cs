using UnityEngine;
using System.Collections;

public class BattleScript : MonoBehaviour {
	public GameObject trump;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			Debug.Log ("A key was pressed");
			trump.GetComponent<FighterScript> ().health -= .2f;
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