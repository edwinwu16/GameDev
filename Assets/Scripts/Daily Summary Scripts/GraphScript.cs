using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI.Extensions;

public class GraphScript : MonoBehaviour {
	public GameObject line;

	private int maxx = 110;
	private int maxy = 110;

	public GameObject daysleft;
	public GameObject popup;
	private List<int> voteslist = new List<int> ();
	// Use this for initialization
	void Start () {
//		voteslist = popup.GetComponent<PopupScript>().votesovertime;
		voteslist.Add(10000);
		voteslist.Add(100000);
		voteslist.Add(1000000);
		voteslist.Add(10000000);
		voteslist.Add(100000000);

		Debug.Log (voteslist[0]);
		int votestowin = popup.GetComponent<PopupScript> ().votestowin;
		int numdayscurrent = voteslist.Count;
		int maxdays = daysleft.GetComponent<DaysUntilElectionScript>().daysstartwith;
//		line.GetComponent<UILineRenderer>().Points[0] = (new Vector2(0, 23));
//		line.GetComponent<UILineRenderer>().Points[0] = (new Vector2(300, 300));
		float incrementx = maxx / (float)maxdays;
		float incrementy = maxy / (float)votestowin;
		Vector2[] newarr = new Vector2[numdayscurrent];
		for (int i = 0; i < voteslist.Count; i++) {
			float xval = i * incrementx;
			float yval = voteslist [i] * incrementy;
			newarr[i] = new Vector2(xval, yval);
		}
		line.GetComponent<UILineRenderer> ().Points = newarr;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
