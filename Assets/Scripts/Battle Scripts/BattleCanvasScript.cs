using UnityEngine;
using System.Collections;

public class BattleCanvasScript : MonoBehaviour {
	public GameObject battlepanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void movePanel(){
		battlepanel.transform.localPosition = new Vector3 (0.0F, 0.0F, 0.0F);
	}
}
