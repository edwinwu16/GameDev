﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManageAdvisersButtonScript : MonoBehaviour {
	public Button self;
	public GameObject adviserpanel;
	public GameObject tutorial;
	// Use this for initialization
	void Start () {
		self.onClick.AddListener(() => { onClickAdviser(); });
	}

	// Update is called once per frame
	void Update () {

	}
	void onClickAdviser() {
		adviserpanel.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0f, 0f);
		adviserpanel.GetComponent<AdvisorScript> ().makeRows ();
		//		self.transform.localPosition (false);
		tutorial.SendMessage("ThingClicked", "manageadvisers");
	}
}
