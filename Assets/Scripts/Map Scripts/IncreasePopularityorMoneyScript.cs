using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IncreasePopularityorMoneyScript : MonoBehaviour {
	public Button btn;
	public float amounttoIncreasePop;
	public GameObject maincamera;
	public float amounttoIncreaseMoney;
	public GameObject popupregion;
	// Use this for initialization
	void Start () {
		btn.onClick.AddListener(() => increasePopandMoneyAfterClick());
	}

	// Update is called once per frame
	void Update () {

	}

	void increasePopandMoneyAfterClick() {
		Debug.Log ("clickyyyy");
		popupregion.SendMessage ("IncreasePopularity", amounttoIncreasePop);
		popupregion.SendMessage("IncreaseMoney", amounttoIncreaseMoney);
		maincamera.GetComponent<ClickTest>().ButtonClicked();
		popupregion.SendMessage("decrementDaysLeft");
		popupregion.SendMessage("newButtons");
	}
}