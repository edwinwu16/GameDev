using UnityEngine;
using System.Collections;

public class ClickTest: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

//    void ClickSelect()
//    {
//        //Converting Mouse Pos to 2D (vector2) World Pos
//        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        //Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
//        //RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

//        //if (hit)
//        //{
//        //    Debug.Log(hit.transform.name);
//        //    return hit.transform.gameObject;
//        //}
//        //else return null;

//        RaycastHit2D hitInfo = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);
//        if(hitInfo != null
//        {
//    Debug.Log( hitInfo.rigidbody.gameObject.name );
//}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed left click.");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if(hit.collider != null)
            {
                Debug.Log("object clicked: "+hit.collider.name);
            }
            if(hit.collider == null)
            {
                Debug.Log("null");
            }
        }
	
	}


}
