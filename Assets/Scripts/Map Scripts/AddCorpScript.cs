using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AddCorpScript : MonoBehaviour
{
    public Corporation curcorp;
    public GameObject corppanel;
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
        if (popup.GetComponent<PopupScript>().getTotalMoney() < curcorp.costtobuy)
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Too Little Money", "Yo you broke son", "Okay");
#endif
        }
       
        else
        {
            if (corppanel.GetComponent<CorpScript>().corporationsowned.Count >= 5)
            {
#if UNITY_EDITOR
                EditorUtility.DisplayDialog("Too Many Corporations", "Maximum of Five Corprations. You're trying to run a Campaign, not a Conglomerate", "Okay");
#endif
            }
            else
            {
            }
            corppanel.GetComponent<CorpScript>().AddCorporation(curcorp);
            self.interactable = false;

        }
        Debug.Log("CLICKY Add");
    }
}
