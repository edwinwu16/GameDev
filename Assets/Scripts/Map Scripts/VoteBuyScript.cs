using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoteBuyScript : MonoBehaviour
{
    public Voter index;
    public int amount;
    public GameObject votespanel;
    public Button self;
    public GameObject popup;
    public GameObject dialoguecanvas;
    public GameObject dialoguepanel;

    // Use this for initialization
    void Start()
    {
        popup = GameObject.Find("PopupRegion");

        votespanel = GameObject.Find("Vote Panel");
        self.onClick.AddListener(() => { onClickVote(index, amount); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickVote(Voter i, int a) {
        dialoguecanvas = popup.GetComponent<PopupScript>().dialoguecanvas;
        dialoguepanel = popup.GetComponent<PopupScript>().dialoguepanel;

        if (popup.GetComponent<PopupScript>().getTotalMoney() < i.costtobuy)
        {
            dialoguecanvas.SetActive(true);
            dialoguepanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0F, 0.0F);
            dialoguepanel.GetComponent<DisplayDialogScript>().title.text = "Too Little Money";
            dialoguepanel.GetComponent<DisplayDialogScript>().message.text = "Yo, You Broke Son.";
            dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.gameObject.SetActive(false);
            dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.GetComponentInChildren<Text>().text = "Continue";
            dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.onClick.AddListener(delegate { dialoguecanvas.SetActive(false); });
        }
        else{		votespanel.GetComponent<VoteScript> ().buyVotes(i, a);
        self.interactable = false;
}
}
}