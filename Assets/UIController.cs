using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject pauseButton;
	public Text pauseButtonText;

	public Text foodLabel;
	public Text woodLabel;
    public Text survivorsLabel;

	public Camp campReference;
	public Text campUpgradeCost;
	public Text campCurrentLevel;
	//public Text campUpgradeButtonLabel;

	// Use this for initialization
	void Start () {

		//pauseButtonText = pauseButton.GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		foodLabel.text = "Food: " + GameStateManager.campFood;
		woodLabel.text = "Wood: " + GameStateManager.campWood;
        survivorsLabel.text = "Survivors: " + GameStateManager.campSurvivors;
        campUpgradeCost.text = "Cost: " + campReference.upgradeCost + " wood";
		campCurrentLevel.text = "Camp level: " + campReference.campLevel;


		switch (GameStateManager.gameState) {
		case 1:
			{
				pauseButtonText.text = "Pause";
				break;
			}
		case 2:
			{
				pauseButtonText.text = "Continue";
				break;
			}
		default:
			{
				break;
			}
		}
	
	}
	
}
