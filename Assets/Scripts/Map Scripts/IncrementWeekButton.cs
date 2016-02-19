using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IncrementWeekButton : MonoBehaviour {
    public Button self;
    public GameObject popup;
	// Use this for initialization
	void Start () {
        self.onClick.AddListener(() => { onClickAdd(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClickAdd()
    {
        popup.GetComponent<PopupScript>().decrementDaysLeft();
    }
}
