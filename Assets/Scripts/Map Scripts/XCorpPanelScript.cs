using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class XCorpPanelScript : MonoBehaviour {
		public Button xButton;
		public GameObject corppanel;

		// Use this for initialization
		void Start () {
			xButton.onClick.AddListener(() => sendClick());
		}

		// Update is called once per frame
		void Update () {

		}
		private void sendClick() {
		corppanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(3000f, 3000f, 0);
		}

}
