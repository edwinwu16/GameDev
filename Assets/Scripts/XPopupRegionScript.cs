﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XPopupRegionScript : MonoBehaviour {
	public Button xButton;
	public GameObject maincamera;


	// Use this for initialization
	void Start () {
		xButton.onClick.AddListener(() => sendClick());

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void sendClick() {
		maincamera.SendMessage ("HideBox");
	}

}
