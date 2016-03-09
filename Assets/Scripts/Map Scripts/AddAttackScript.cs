using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AddAttackScript: MonoBehaviour {
	public Attack index;
	public GameObject attackpanel;
	public GameObject popup;
	public Button self;
    public GameObject dialoguecanvas;
    public GameObject dialoguepanel;

	// Use this for initialization
	void Start () {
		popup = GameObject.Find("PopupRegion");

		attackpanel = GameObject.Find ("AttackMarketplacePanel");
		self.onClick.AddListener(() => { onClickAdd(index);});
//		self.onClick.AddListener(() => { self.interactable = false; });
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(Attack i) {
        dialoguecanvas = popup.GetComponent<PopupScript>().dialoguecanvas;
        dialoguepanel = popup.GetComponent<PopupScript>().dialoguepanel;

        if (i.cost > popup.GetComponent<PopupScript>().getTotalMoney())
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
            Debug.Log("ONCLICKADD" + i);
            //			attackpanel.GetComponent<AttackMarketplaceScript>().AddAttack(i);
            attackpanel.GetComponent<AttackMarketplaceScript>().ShowDropdown(i);

        }
	}
}
