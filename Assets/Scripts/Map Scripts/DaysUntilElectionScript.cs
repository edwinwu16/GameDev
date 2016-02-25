using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class DaysUntilElectionScript : MonoBehaviour {

    public GameObject popup;
	public int daysstartwith = 100;
    public int daysLeft;
    private bool _gameovercalled;
    private bool _scenenotswitched;

	// Use this for initialization
	void Start () {
		daysLeft = daysstartwith;
        updateDaysLeftText();
        _gameovercalled = false;
        _scenenotswitched = true;
	}
	
	// Update is called once per frame
	void Update () {
        updateDaysLeftText();
        if (daysLeft == 0 & !_gameovercalled)
        {
            _gameovercalled = true;
            popup.GetComponent<PopupScript>().gameOver();
        }
        else if (daysLeft % 10 != 0 & _scenenotswitched)
        {
            _scenenotswitched = false;
        }
        else if (daysLeft % 10 ==0 & !_scenenotswitched)
        {
            _scenenotswitched = true;
            popup.GetComponent<PopupScript>().switchtoBattleScene();
        }
	
	}

    public void updateDaysLeftText()
    {
        GameObject scoreTextObject = this.gameObject;
        Text textComponent = scoreTextObject.GetComponent<Text>();
        textComponent.text = string.Format("Days Until Election: {0}", daysLeft);
    }
}
