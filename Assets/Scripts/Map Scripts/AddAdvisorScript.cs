using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class AddAdvisorScript : MonoBehaviour {

	public Advisor curadvisor;
	public GameObject advisorpanel;
    public GameObject popup;
    public GameObject dialoguecanvas;
    public GameObject dialoguepanel;

	public Button self;
	// Use this for initialization
	void Start () {
        popup = GameObject.Find("PopupRegion");
		advisorpanel = GameObject.Find ("Adviser Panel");
		self.onClick.AddListener(() => { onClickAdd(curadvisor);});
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(Advisor curadvisor) {
        dialoguecanvas = popup.GetComponent<PopupScript>().dialoguecanvas;
        dialoguepanel = popup.GetComponent<PopupScript>().dialoguepanel;

		Debug.Log ("CLICKY Add");
        
        if (popup.GetComponent<PopupScript>().getTotalMoney() < curadvisor.price)
        {
            dialoguecanvas.SetActive(true);
            dialoguepanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0F, 0.0F);
            dialoguepanel.GetComponent<DisplayDialogScript>().title.text = "Too Little Money";
            dialoguepanel.GetComponent<DisplayDialogScript>().message.text = "Yo, You Broke Son.";
            dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.gameObject.SetActive(false);
            dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.GetComponentInChildren<Text>().text = "Continue";
            dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.onClick.AddListener(delegate { dialoguecanvas.SetActive(false); });

        }
        else
        {
            if (advisorpanel.GetComponent<AdvisorScript>().myAdvisors.Count >= 5)
            {
                dialoguecanvas.SetActive(true);
                dialoguepanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0F, 0.0F);
                dialoguepanel.GetComponent<DisplayDialogScript>().title.text = "Too Many Advisors";
                dialoguepanel.GetComponent<DisplayDialogScript>().message.text = "Maximum of Five Advisors. Go All 'The Apprentice' on Somebody.";
                dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.gameObject.SetActive(false);
                dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.GetComponentInChildren<Text>().text = "Continue";
                dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.onClick.AddListener(delegate { dialoguecanvas.SetActive(false); });



            }
            else
            {
                advisorpanel.GetComponent<AdvisorScript>().AddAdvisor(curadvisor);
                self.interactable = false;

            }
        }
	}
}