using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayDialogScript : MonoBehaviour {
    public Text title;
    public Text message;
    public Button truebutton;
    public Button falsebutton;
    public GameObject displaycanvas;
    public bool buttonclicked = false;
    public bool buttonvalue = true;
    public int tempvalue;
	// Use this for initialization
	void Start () {
        displaycanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
