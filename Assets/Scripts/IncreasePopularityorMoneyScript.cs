using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IncreasePopularityorMoneyScript : MonoBehaviour {
	public Button btn;
	public int amounttoIncreasePop;
	public int amounttoIncreaseMoney;
	public GameObject popupregion;
	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(() => increasePopandMoney());
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	void increasePopandMoney() {
		Debug.Log ("clickyyyy");
		popupregion.SendMessage ("IncreasePopularity", amounttoIncreasePop);
		popupregion.SendMessage("IncreaseMoney", amounttoIncreaseMoney);
	}
}
