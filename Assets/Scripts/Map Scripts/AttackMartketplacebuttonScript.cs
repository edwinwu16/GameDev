using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AttackMartketplacebuttonScript : MonoBehaviour {
		public Button self;
		public GameObject attackpanel;
		// Use this for initialization
		void Start () {
			self.onClick.AddListener(() => { onClickAdviser(); });
		}

		// Update is called once per frame
		void Update () {

		}
		void onClickAdviser() {
		attackpanel.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0f, 0f);
		attackpanel.GetComponent<AttackMarketplaceScript> ().makeRows ();
			//		self.transform.localPosition (false);
		}
	}
