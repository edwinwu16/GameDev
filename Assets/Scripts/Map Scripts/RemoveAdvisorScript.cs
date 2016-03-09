using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using System.Linq;

using System;


public class RemoveAdvisorScript : MonoBehaviour {

	public int index;
	public GameObject advisorpanel;
	public Button self;
    public GameObject dialoguepanel;
    public GameObject dialoguecanvas;
    public GameObject popup;


	// Use this for initialization
	void Start () {
        popup = GameObject.Find("PopupRegion");
		advisorpanel = GameObject.Find ("Adviser Panel");
        dialoguepanel = GameObject.Find("DisplayDialogPanel");
        dialoguecanvas = GameObject.Find("DisplayDialogCanvas");
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
            foreach (Advisor adv in advisorpanel.GetComponent<AdvisorScript>().myAdvisors)
            {
                if (adv != advisorpanel.GetComponent<AdvisorScript>().myAdvisors[i])
                {
                    overlapping = overlapping.Except(adv.campaigns).ToList();

                }
            }
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
        if (str.Length >= 2)
        {
            Debug.Log(String.Format("str length: {0}", str.Length));
            dialoguecanvas = popup.GetComponent<PopupScript>().dialoguecanvas;
            dialoguepanel = popup.GetComponent<PopupScript>().dialoguepanel;
            dialoguecanvas.SetActive(true);
            dialoguepanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0F, 0.0F);
            dialoguepanel.GetComponent<DisplayDialogScript>().title.text = "Will Remove Campaigns In These Regions";
            dialoguepanel.GetComponent<DisplayDialogScript>().message.text = str;
            dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.gameObject.SetActive(true);
            dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.GetComponentInChildren<Text>().text = "Continue";
            dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.GetComponentInChildren<Text>().text = "Cancel";

            dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.onClick.AddListener(delegate { dialoguecanvas.SetActive(false); });
            dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.onClick.AddListener(delegate { dialoguecanvas.SetActive(false); });
            dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.onClick.AddListener(delegate { settrueorFalse(i, true); });
            dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.onClick.AddListener(delegate { settrueorFalse(i, false); });
            dialoguepanel.GetComponent<DisplayDialogScript>().tempvalue = i;

            if (dialoguepanel.GetComponent<DisplayDialogScript>().buttonvalue)
            {
                dialoguepanel.GetComponent<DisplayDialogScript>().buttonclicked = false;
                advisorpanel.GetComponent<AdvisorScript>().RemoveAdvisor(i);
            }
        }
        else
        {
            advisorpanel.GetComponent<AdvisorScript>().RemoveAdvisor(i);

        }


		
	}

    public void settrueorFalse(int i, bool val)
    {
        if (val)
        {
            dialoguepanel.GetComponent<DisplayDialogScript>().buttonclicked = false;
            advisorpanel.GetComponent<AdvisorScript>().RemoveAdvisor(i);

        }
    }
}