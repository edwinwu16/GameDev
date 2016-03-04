using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Globalization;

public class GeneralSummaryScript : MonoBehaviour {
	public int daysuntilelection = 10;
	public Text daysuntilelectiontext;
	public Text dollarstext;
	public Text votestext;
	public Text moneyearnedlosttext;
	public Text votesearnedlosttext;
	public Slider votesslider;
	public Slider moneyslider;
	public GameObject popup;
	public GameObject daysleftobj;

	public Text votesslidertext;

	public int votestowin;

	private float moneydiff;
	private float votesdiff;
	private List<float> moneylist = new List<float> ();
	private List<int> voteslist = new List<int> ();
	// Use this for initialization
	void Start () {
		moneylist = popup.GetComponent<PopupScript>().moneyovertime;
		voteslist = popup.GetComponent<PopupScript>().votesovertime;
		votestowin = popup.GetComponent<PopupScript>().votestowin;
	}
	
	// Update is called once per frame
	void Update () {
		votesslidertext.GetComponent<Text> ().text = String.Format("{0}", voteslist [voteslist.Count - 1]);

		daysuntilelectiontext.GetComponent<Text>().text = (daysleftobj.GetComponent<DaysUntilElectionScript>().daysLeft + 1) + " Days Until Election";
		Debug.Log (moneylist.Count);

		CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
		culture.NumberFormat.CurrencyNegativePattern = 1;
		if (moneylist.Count != 0) {
			if (moneylist.Count == 1)
				moneydiff = moneylist [0];
			else {
				Debug.Log ("ELASE");
				moneydiff = moneylist [moneylist.Count - 1] - moneylist [moneylist.Count - 2];
			}
			if (moneydiff >= 0) {
				moneyearnedlosttext.GetComponent<Text> ().text = "Earned";
				moneyearnedlosttext.color = Color.green;
				dollarstext.GetComponent<Text> ().text = String.Format (culture, "{0:C}", moneydiff);
			} else {
				moneyearnedlosttext.GetComponent<Text> ().text = "Spent";
				moneyearnedlosttext.color = Color.red;
				dollarstext.GetComponent<Text>().text = String.Format(culture, "{0:C}", moneydiff).Substring(1);
			}
		}

		if (voteslist.Count != 0) {
			if (voteslist.Count == 1)
				votesdiff = voteslist [0];
			else {
				votesdiff = voteslist [moneylist.Count - 1] - voteslist [moneylist.Count - 2];
			}
			if (votesdiff >= 0) {
				votesearnedlosttext.GetComponent<Text> ().text = "Votes Earned";
				votesearnedlosttext.color = Color.green;
				votestext.GetComponent<Text> ().text = String.Format("{0:n0}", votesdiff);

			} else {
				votesearnedlosttext.GetComponent<Text> ().text = "Votes Lost";
				votesearnedlosttext.color = Color.red;
				dollarstext.GetComponent<Text>().text = String.Format("{0:n0}", votesdiff);
			}
		}
		if (voteslist.Count != 0)
			votesslider.value = voteslist [voteslist.Count - 1]/(float)votestowin;
	}
}
