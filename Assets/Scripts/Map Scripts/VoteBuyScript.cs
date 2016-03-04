using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class VoteBuyScript : MonoBehaviour
{
    public Voter index;
    public int amount;
    public GameObject votespanel;
    public Button self;
    public GameObject popup;
    // Use this for initialization
    void Start()
    {
        popup = GameObject.Find("PopupRegion");

        votespanel = GameObject.Find("Vote Panel");
        self.onClick.AddListener(() => { onClickVote(index, amount); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickVote(Voter i, int a) {
        if (popup.GetComponent<PopupScript>().getTotalMoney() < i.costtobuy)
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Too Little Money", "Yo you broke son", "Okay");
#endif
        }
        else{		votespanel.GetComponent<VoteScript> ().buyVotes(i, a);
        self.interactable = false;
}
}
}