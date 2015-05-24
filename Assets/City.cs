using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class City : MonoBehaviour {

	public GameObject labelPrefab;
	public GameObject uiPrefab;
	public GameObject cityPrefab;

	// Use this for initialization
	void Start () {
		//generateResource ();

		//forestPrefab = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generateResource()
	{
		int newFood = Random.Range(0,3);
		if (newFood > 0)
		{
			GameObject label = Instantiate (labelPrefab, (cityPrefab.transform.position + new Vector3(0,1.2f,0)), cityPrefab.transform.rotation) as GameObject;
		label.transform.SetParent(uiPrefab.transform);
			label.GetComponent<Text> ().text = "Food: +" + newFood;
		GameStateManager.campFood += newFood;
		}
	}
}
