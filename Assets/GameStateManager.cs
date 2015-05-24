using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStateManager : MonoBehaviour {
	
	public static int gameState = 1;
	public static int hours = 0;
	public static int days = 1;
	public static float secondsPerHour = 0.01f;
	public Forest forest;
	public City city;

	public static int currentDay = 1;

	public static int campFood = 5;
	public static int campWood = 5;
	public static int campSupply = 5;

	public Text dayCounter;
	public Text hoursCounter;


	//debug
	public int eventsCounter = 0;

	//
	// Use this for initialization
	void Start () {

		Debug.Log ("Game initialised. Current state = " + gameState);
		GameManager();


	
	}
	
	// Update is called once per frame
	void Update () {

		dayCounter.text = "Day " + days;
		//GameManager ();
		if (hours < 10) hoursCounter.text = "0" + hours + ":00";
		else hoursCounter.text = "" + hours + ":00";
	
	}

	public void GameManager()
	{
		switch (gameState) {
		case 1:
			Debug.Log ("Game started");
			countTime();
			break;
		case 2:
			Debug.Log ("Window opened, waiting for input");
			Time.timeScale = 0;
			break;
		case 3:
			Debug.Log ("Upgrade window");
			Time.timeScale = 0;
			break;
		case 0:
			Debug.Log ("Main menu, waiting for start");
			break;
		default:
			Debug.Log ("Some error state");
			break;
		}

	}

	public void startGame()
	{
		GameStateManager.gameState = 1;
	}

	public void pauseGame()
	{
		switch (GameStateManager.gameState) {
		case 1: 
			{
				GameStateManager.gameState = 2;
				Debug.Log ("Game paused");
				Time.timeScale = 0;
				break;
			}
		case 2:
			{
				GameStateManager.gameState = 1;
				Debug.Log ("Game unpaused");
				countTime();
				break;
			}
		default:
			break;
		}

		//StopCoroutine (waitFor);
	}

	public void countTime()
	{
		Debug.Log ("CountTime() called");
		Time.timeScale = 1;
		//while (GameStateManager.hours <24) {
		StartCoroutine (waitFor (secondsPerHour));
		//}
	}

	private IEnumerator waitFor(float waitTime)
	{
		//debug
		/*if (hours > 500) {
			Debug.Log ("Total events: " + eventsCounter);
			GameStateManager.gameState = 3;
		}*/
		//
		yield return new WaitForSeconds(waitTime);
		if (GameStateManager.gameState == 1) {
			GameStateManager.hours += 1;
			if (GameStateManager.hours % 24 == 0)
			{
				GameStateManager.days++;
				hours = 0;
			}
			//Debug.Log ("Hours passed: " + GameStateManager.hours);
			float randomEventCheck = Random.Range(0f,1f);
			//Debug.Log ("RandomEventCheck = " + randomEventCheck);
			if (randomEventCheck > 0.75f)
			{
				foundSomething();
			}
			StartCoroutine (waitFor (secondsPerHour));
		}
	}

	private void foundSomething()
	{
		int eventType = 0;
		eventsCounter++;

		eventType = Random.Range (0, 5);

		switch (eventType) {
		case 0:
			{
				//Debug.Log ("Event 0. Nothing.");
				break;
			}
		case 1:
			{
				//Debug.Log ("Event 1. +2 resources, game cycle goes on.");
				forest.generateResource();
				break;
			}
		case 2:
		{
			forest.generateResource();
			break;
		}
		case 3:
			{
				//Debug.Log ("Event 2. Something happened. Game cycle paused until response");
				//GameStateManager.gameState = 2;
				//initRandomEvent();
				forest.generateResource();
				break;
			}
		case 4:
			{
				//Debug.Log ("Event 4. Another resource found. Game cycle goes on");
				city.generateResource();
				break;
			}
		case 5:
		{
			//Debug.Log("Another event with pause");
			//GameStateManager.gameState = 2;
			city.generateResource();
			break;
		}
		default: 
			{
				Debug.Log ("Some error state in foundSomething() function - please check");
				break;
			}
		}

	}
}
