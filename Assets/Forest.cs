using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Forest : MonoBehaviour {

	public GameObject labelPrefab;
	public GameObject uiPrefab;
	public GameObject forestPrefab;

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
		int newWood = Random.Range(0,3);
		if (newWood > 0)
		{
		GameObject label = Instantiate (labelPrefab, (forestPrefab.transform.position + new Vector3(0,1.2f,0)), forestPrefab.transform.rotation) as GameObject;
		label.transform.SetParent(uiPrefab.transform);
		label.GetComponent<Text> ().text = "Wood: +" + newWood;
		GameStateManager.campWood += newWood;
		}
	}
}
