using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupScript : MonoBehaviour {
	public string string1;
    public GameObject maincamera;
    public GameObject popupregion;
    public int totalmoney;
    public int totalpop;
	public GameObject USA;
    private string clickedregion;
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
    }

	public void IncreasePopularity(int amount) {
		regions [clickedregion].popularity += amount;
		Debug.Log (regions [clickedregion].popularity);
	}

	public void IncreaseMoney(int amount) {
		USA.GetComponent<USAScript>().money += amount;
	}

	public int getTotalPopularity() {
		int popularity = 0;
		foreach(KeyValuePair<string, Region> entry in regions) {
			popularity += entry.Value.popularity;
		}
		return popularity;
	}

	public int getTotalMoney() {
		return USA.GetComponent<USAScript>().money;
	}

	public void SetClickedRegion(string region) {
		clickedregion = region;
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