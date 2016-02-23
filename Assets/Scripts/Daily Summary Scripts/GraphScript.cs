using UnityEngine;
using System.Collections;
using UnityEngine.UI.Extensions;

public class GraphScript : MonoBehaviour {
	public GameObject line;
	// Use this for initialization
	void Start () {
//		line.GetComponent<UILineRenderer>().Points[0] = (new Vector2(0, 23));
//		line.GetComponent<UILineRenderer>().Points[0] = (new Vector2(300, 300));
		Vector2[] newarr = new Vector2[4];
		newarr[0] = new Vector2(0, 23);
		newarr[1] = new Vector2(300, 230);
		newarr[3] = new Vector2(10, 238);
		line.GetComponent<UILineRenderer> ().Points = newarr;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
