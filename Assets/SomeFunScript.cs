using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SomeFunScript : MonoBehaviour {

	public Text clickLabel;

	// Use this for initialization
	void Start () {

		clickLabel.text = "Waiting...";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clicked()
	{
		clickLabel.text = "Clicked!";
	}
}
