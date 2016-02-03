using UnityEngine;
using System.Collections;

public class RegionalEventButtonScript : MonoBehaviour {
    public GameObject maincamera;
    public GameObject popupregion;
    public int moneyinc;
    public int popinc;
    private string currentregion;
	// Use this for initialization
	void Start () {
        currentregion = maincamera.GetComponent<ClickTest>().lastClick;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ButtonClicked()
    {
        Debug.Log("clicked button");
        GameObject.Find(currentregion).GetComponent<RegionScript>().moneyValue += moneyinc;
        GameObject.Find(currentregion).GetComponent<RegionScript>().popularityValue += popinc;
        popupregion.transform.localPosition = new Vector3(300, 300, 0);
    }
}
