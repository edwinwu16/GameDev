using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddCorpScript : MonoBehaviour
{
    public Corporation curcorp;
    public GameObject corppanel;
    public GameObject dialoguecanvas;
    public GameObject dialoguepanel;

    public GameObject popup;
    public Button self;
    // Use this for initialization
    void Start()
    {
        popup = GameObject.Find("PopupRegion");

        corppanel = GameObject.Find("Corp Panel");
        self.onClick.AddListener(() => { onClickAdd(curcorp); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickAdd(Corporation curcorp)
    {
        dialoguecanvas = popup.GetComponent<PopupScript>().dialoguecanvas;
        dialoguepanel = popup.GetComponent<PopupScript>().dialoguepanel;


        if (popup.GetComponent<PopupScript>().getTotalMoney() < curcorp.costtobuy)
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
            if (corppanel.GetComponent<CorpScript>().corporationsowned.Count >= 5)
            {
                dialoguecanvas.SetActive(true);
                dialoguepanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0F, 0.0F);
                dialoguepanel.GetComponent<DisplayDialogScript>().title.text = "Too Many Corporations";
                dialoguepanel.GetComponent<DisplayDialogScript>().message.text = "Maximum of Five Corprations. You're trying to run a Campaign, not a Conglomerate.";
                dialoguepanel.GetComponent<DisplayDialogScript>().falsebutton.gameObject.SetActive(false);
                dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.GetComponentInChildren<Text>().text = "Continue";
                dialoguepanel.GetComponent<DisplayDialogScript>().truebutton.onClick.AddListener(delegate { dialoguecanvas.SetActive(false); });

            }
            else
            {
                corppanel.GetComponent<CorpScript>().AddCorporation(curcorp);
                self.interactable = false;

            }

        }
        Debug.Log("CLICKY Add");
    }
}
