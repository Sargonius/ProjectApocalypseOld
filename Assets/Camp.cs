using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Camp : MonoBehaviour {

	public GameObject upgradePanel;
	public Button upgradeButton;
	public Slider upgradeSlider;
	public Text campLevelLabel;
	public GameStateManager gameManager;

	public int campLevel = 1;
	public int upgradeCost = 10;

	public int campStatus = 1; //1 - normal, 2 - upgrading

	public float campUpgradeTime = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if (campStatus == 1)
		{
		upgradePanel.SetActive(true);
		if (upgradeCost > GameStateManager.campWood)
			{
				upgradeButton.interactable = false;
			} else upgradeButton.interactable = true;

		GameStateManager.gameState = 2;
		}

	}

	public void hideUpgradePanel()
	{
		upgradePanel.SetActive(false);
		GameStateManager.gameState = 1;
		gameManager.countTime();
	}

	public void upgradeCamp()
	{
		if (campStatus == 1 && upgradeCost <= GameStateManager.campWood)
		{
			hideUpgradePanel();
			Debug.Log("Upgrading camp");
			upgradeSlider.gameObject.SetActive(true);
			campLevelLabel.gameObject.SetActive(false);
			GameStateManager.campWood -= upgradeCost;
			campUpgradeTime = campUpgradeTime * campLevel;
			StartCoroutine(upgradeCampTimer(campUpgradeTime));
		}

	}

	IEnumerator upgradeCampTimer(float waitTime)
		{
		Debug.Log("Camp is upgrading. Time before upgrade: " + waitTime);
		upgradeSlider.value = 0;
		upgradeSlider.DOValue(1, waitTime,false);
		campStatus = 2;
		yield return new WaitForSeconds(waitTime);
		campLevel++;
		upgradeCost += upgradeCost * campLevel;
		upgradeSlider.gameObject.SetActive(false);
		campLevelLabel.gameObject.SetActive(true);
		campStatus = 1;
		}
}
