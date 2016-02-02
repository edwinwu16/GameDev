using UnityEngine;
using System.Collections;

public class ClickTest: MonoBehaviour {
    


	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed left click.");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if(hit.collider != null)
            {
                Debug.Log("object clicked: "+hit.collider.name);
                checkWindow0 = true;
            }
            if(hit.collider == null)
            {
                Debug.Log("null");
                checkWindow0 = false;
            }
        }
	
	}

    public bool checkWindow0 = false;

    void OnGUI()
    {
        if (checkWindow0)
            GUI.Window(0, new Rect(110, 10, 310, 60), DoWindow0, "Basic Window");
    }

    void DoWindow0(int windowID)
    {
        GUI.Button(new Rect(10, 30, 150, 20), "Increase Popularity");
        GUI.Button(new Rect(160, 30, 150, 20), "Increase Money");
    }



   
}
