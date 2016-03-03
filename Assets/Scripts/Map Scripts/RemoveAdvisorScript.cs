using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;


public class RemoveAdvisorScript : MonoBehaviour {

	public int index;
	public GameObject advisorpanel;
	public Button self;

	// Use this for initialization
	void Start () {
		advisorpanel = GameObject.Find ("Adviser Panel");
		self.onClick.AddListener(() => { onClickAdd(index);}); 
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(int i) {
        string str ="";
        int count = 0;
        foreach(KeyValuePair<string, List<Campaign>> value in GameObject.Find("PopupRegion").GetComponent<PopupScript>().activecampaigns)
        {
            List<Campaign> overlapping = advisorpanel.GetComponent<AdvisorScript>().myAdvisors[i].campaigns.Intersect(value.Value).ToList();
            foreach (Campaign campaign in overlapping){
                if (count == 0)
                {
                    str = campaign.name + " in " + value.Key;
                    count ++;
                }
                else
                {
                    str = str + ", " + campaign.name + " in " + value.Key;
                }


            }
                
        }
#if UNITY_EDITOR
            if (EditorUtility.DisplayDialog("Will Get Rid Of", str, "Okay", "Cancel")){
                Debug.Log ("CLICKY Add");
		    advisorpanel.GetComponent<AdvisorScript> ().RemoveAdvisor (i);
            }
    
#endif
		
	}
}