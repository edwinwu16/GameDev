﻿using UnityEngine;
using System.Collections;

public class ClickTest: MonoBehaviour {
    

	public string lastClick;
	public GameObject popupregion;
	private bool _popupisup;
	// Use this for initialization
	void Start () {
		popupregion = GameObject.Find("PopupRegion");
		popupregion.SetActive (true);
		popupregion.transform.localPosition = new Vector3 (500.0F, 500.0F, 0.0F);
		_popupisup = false;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed left click.");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
			if(hit.collider != null && !_popupisup)
            {
                Debug.Log("object clicked: "+hit.collider.name);
				lastClick = hit.collider.name;
				Debug.Log ("LastClick " + lastClick);
                popupregion.transform.localPosition = new Vector3(0, 0, 0);
				_popupisup = true;
            }
            if(hit.collider == null)
            {
                Debug.Log("null");
				_popupisup = false;
                popupregion.transform.localPosition = new Vector3(500, 500, 0);
            }
        }
	
	}
}
