using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AddCorpScript: MonoBehaviour {
	public int index;
	public GameObject corppanel;
    public GameObject popup;
	public Button self;
	// Use this for initialization
	void Start () {
        popup = GameObject.Find("PopupRegion");

		corppanel = GameObject.Find ("Corp Panel");
		self.onClick.AddListener(() => { onClickAdd(index);}); 
	}

	// Update is called once per frame
	void Update () {

	}

	public void onClickAdd(int i) {
        if (popup.GetComponent<PopupScript>().getTotalMoney() < corppanel.GetComponent<CorpScript>().corporationstobuy[i].costtobuy)
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Too Little Money", "Yo you broke son", "Okay");
#endif
        }
        else
        {
            corppanel.GetComponent<CorpScript>().AddCorporation(i);
        }
		Debug.Log ("CLICKY Add");
	}
}
