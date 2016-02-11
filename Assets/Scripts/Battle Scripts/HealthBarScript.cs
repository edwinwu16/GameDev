using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour {

	public Slider healthBarSlider;
	public GameObject fighter;
	// Use this for initialization
	void Start () {
	
	}
	
//	 Update is called once per frame
	void Update () {
		healthBarSlider.value = fighter.GetComponent<FighterScript> ().health / fighter.GetComponent<FighterScript>().maxhealth;
	}
}