using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class USAScript : MonoBehaviour {
	public int money;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getMoney() {
		return money;
	}
	void increaseMoney(int amount) {
		money += amount;
	}
}
