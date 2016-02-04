using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupScript : MonoBehaviour {
    public GameObject maincamera;
    public GameObject popupregion;
    public int totalmoney;
    public int totalpop;
    private string currentregion;
	public Region west = new Region(0, 0, "West");
	public Region south = new Region(0, 0, "South");
	public Dictionary<string, Region> regions = new Dictionary<string, Region> (); 
	// Use this for initialization
	void Start () {
		var index = 10; 
		south.popularity = 15;
		regions.Add ("West", west);
		regions.Add ("South", south);
		Debug.Log (regions ["South"].popularity);

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void onClick()
    {
        Debug.Log("clicked button");
//        GameObject.Find(currentregion).GetComponent<RegionScript>().moneyValue += moneyinc;
//        GameObject.Find(currentregion).GetComponent<RegionScript>().popularityValue += popinc;
//        popupregion.transform.localPosition = new Vector3(300, 300, 0);
    }

	public void IncreasePopularity(int amount) {
		currentregion = maincamera.GetComponent<ClickTest>().lastClick;
		Debug.Log (currentregion);
		regions [currentregion].popularity += amount;
		Debug.Log (currentregion + regions [currentregion].popularity);
	}

	public int getTotalPopularity() {
		return 0;
	}
}
	
public class Region {
	public int popularity;
	public int money;
	public string name;
	public Region()
	{
		popularity = 0;
		money = 0;
	}
	public Region(int p, int m, string s) {
		popularity = p;
		money = m;
		name = s;
	}
}