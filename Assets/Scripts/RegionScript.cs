﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegionScript : MonoBehaviour {
	public int popularityValue;
	public int moneyValue;
	public Button region;
//	public GameObject maincamera;

	// Use this for initialization
	void Start () {
		popularityValue = 70;
		moneyValue = 69;
		region.onClick.AddListener(() => sendClick());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void sendClick() {
//		maincamera.SendMessage ("ShowBox");
		Debug.Log (region.name + "clicked");
	}
}
