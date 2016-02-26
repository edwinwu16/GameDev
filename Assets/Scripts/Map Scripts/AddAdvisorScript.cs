using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR 
    using UnityEditor;
#endif


public class AddAdvisorScript : MonoBehaviour {

	public int index;
	public GameObject advisorpanel;
    public GameObject popup;

	public Button self;
	// Use this for initialization
	void Start () {
        popup = GameObject.Find("PopupRegion");
		advisorpanel = GameObject.Find ("Adviser Panel");
		self.onClick.AddListener(() => { onClickAdd(index);}); 
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(int i) {
		Debug.Log ("CLICKY Add");
        if (popup.GetComponent<PopupScript>().getTotalMoney() < advisorpanel.GetComponent<AdvisorScript>().availableAdvisors[i].price)
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Too Little Money", "Yo you broke son", "Okay");
#endif
        }
        else
        {
            advisorpanel.GetComponent<AdvisorScript>().AddAdvisor(i);
        }
	}
}