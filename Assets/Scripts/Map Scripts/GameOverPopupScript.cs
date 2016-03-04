using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPopupScript : MonoBehaviour {
    private Vector3 _hidelocation = new Vector3(800.0F, 800.0F, 0.0F);
    public GameObject self;

	// Use this for initialization
	void Start () {
        self = this.gameObject;
        self.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void gameOver(int popularity)
    {
        self.SetActive(true);
        self.transform.localPosition = new Vector3(0, 0, 0);
        if (popularity > 150000000)
        {
            self.GetComponentInChildren<Text>().text = "You beat Trump";
        }
        else
        {
            self.GetComponentInChildren<Text>().text = "100 Years of Darkness: Trump wins";
        }
        //open back to splash menu.

    }

   
}
