using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextActorValue : MonoBehaviour
{
	public Value TrackValue;
	public Actor Actor;

	void UpdateText()
	{
		string stat_string = Actor.statList.GetText(TrackValue);
		GetComponent<TextMeshProUGUI>().text = stat_string;
	}

    // Start is called before the first frame update
    void Start()
    {
        Actor.statList.Subscribe(UpdateText, TrackValue);
		UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
