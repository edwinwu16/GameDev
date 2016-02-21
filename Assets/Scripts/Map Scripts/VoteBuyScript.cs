using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoteBuyScript: MonoBehaviour {
	public int index;
	public int amount;
	public GameObject votespanel;
	public Button self;
	// Use this for initialization
	void Start () {
		votespanel = GameObject.Find ("Vote Panel");
		self.onClick.AddListener(() => { onClickVote(index, amount);}); 
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickVote(int i, int a) {
		Debug.Log ("CLICKY buyvote");
		votespanel.GetComponent<VoteScript> ().buyVotes(i, a);
	}
}