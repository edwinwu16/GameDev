using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AddAttackScript: MonoBehaviour {
	public Attack index;
	public GameObject attackpanel;
	public GameObject popup;
	public Button self;
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
        if (i.cost > popup.GetComponent<PopupScript>().getTotalMoney())
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Too Little Money", "Yo you broke son", "Okay");
#endif
        }
        else
        {
            Debug.Log("ONCLICKADD" + i);
            //			attackpanel.GetComponent<AttackMarketplaceScript>().AddAttack(i);
            attackpanel.GetComponent<AttackMarketplaceScript>().ShowDropdown(i);

        }
	}
}
