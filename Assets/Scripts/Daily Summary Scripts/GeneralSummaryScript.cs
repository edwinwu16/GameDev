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
	public List<int> moneylist = new List<int>();
	public List<int> voteslist = new List<int>();

	private int moneydiff;
	private int votesdiff;
	// Use this for initialization
	void Start () {
		moneylist.Add (1000000);
		moneylist.Add (1230000);
		voteslist.Add (123);
		voteslist.Add (143000);
		daysuntilelectiontext.GetComponent<Text>().text = daysuntilelection + " Days Until Election";
		Debug.Log (moneylist.Count);

		CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
		culture.NumberFormat.CurrencyNegativePattern = 1;

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
			moneyearnedlosttext.GetComponent<Text> ().text = "Lost";
			moneyearnedlosttext.color = Color.red;
			dollarstext.GetComponent<Text>().text = String.Format(culture, "{0:C}", moneydiff).Substring(1);
		}

		if (voteslist.Count == 1)
			votesdiff = voteslist [0];
		else {
			votesdiff = voteslist [moneylist.Count - 1] - voteslist [moneylist.Count - 2];
		}
		if (votesdiff >= 0) {
			votesearnedlosttext.GetComponent<Text> ().text = "Votes Earned";
			votesearnedlosttext.color = Color.green;
			votestext.GetComponent<Text> ().text = String.Format("{0}", votesdiff);
		} else {
			votesearnedlosttext.GetComponent<Text> ().text = "Votes Lost";
			votesearnedlosttext.color = Color.red;
			dollarstext.GetComponent<Text>().text = String.Format("{0}", votesdiff);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
