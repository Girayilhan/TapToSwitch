using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TapToPlayScript : MonoBehaviour {
    public Text tapToPlay;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tapToPlay.color = new Color(tapToPlay.color.r, tapToPlay.color.g, tapToPlay.color.b, Mathf.Sin(Time.time * 3));

    }
    public void Pressed()
    {
        Application.LoadLevel(1);
    }
    
}
