﻿using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour {

	public Text highscoreText;
	public Text timerText;
	public Text moneyText;
	public Text specialBulletsText;

	public Color timerRecordColor;
	public Color zeroOfSomethingColor;


	private PlayerStats playerStats;

	void Start () {
		playerStats = PlayerStats.instance;
		highscoreText.text = string.Format ("{0:00.00}", PlayerPrefs.GetFloat ("highscore"));
	}

	void Update () {
		timerText.text = string.Format ("{0:00.00}", playerStats.TimeSurvived);

		moneyText.text = playerStats.money.ToString ();
		if (playerStats.TimeSurvived > PlayerPrefs.GetFloat ("highscore")) {
			timerText.color = timerRecordColor;
		}

		specialBulletsText.text = playerStats.specialBullets.ToString ();

		if (playerStats.money <= 0) {
			moneyText.color = zeroOfSomethingColor;
		}

		if (playerStats.specialBullets <= 0) {
			specialBulletsText.color = zeroOfSomethingColor;
		}

		if (playerStats.money > 0) {
			moneyText.color = Color.white;
		}

		if (playerStats.specialBullets > 0) {
			specialBulletsText.color = Color.white;
		}

	}


	public void PauseButton () {
		if (playerStats.isDead) {
			return;
		}
		Time.timeScale = 0f;
	}

	public void ContinueButton () {
		Time.timeScale = 1;
	}



}
