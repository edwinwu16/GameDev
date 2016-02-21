using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class USAScript : MonoBehaviour {
	public float money;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getMoney() {
		return money;
	}
	void increaseMoney(int amount) {
		money += amount;
	}
}
