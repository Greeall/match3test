using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameUI : MonoBehaviour {

	public CurrentLevel currentLevel; 
	public Text currentScoreText;
	public Text quantityTurn;

	public Text needScore;

	//public int typesBallsQuantity;
	public Dropdown ballTypesQuantity;

	int sizeField = 3;

	int scoreForWin = 0;
	public int ScoreForWin
	{     
		set
		{ 
			scoreForWin = value;
			needScore.text = "need score: " + scoreForWin.ToString(); 
		}
	}

	int turns = 0;


	public void ShowScore(int score) {
		currentScoreText.text = "score: " + score.ToString();
	} 

	public void ShowTurns(int turns) {
		quantityTurn.text = "turns left: " + turns.ToString();
	}

	public Dropdown sizeDrop;
	public InputField scoreInpt;
	public InputField turnsInpt;

	public GameObject startMenu;
	public GameObject levelMenu;

	public GameObject endGame;
	public Text endGameText;

	public void SetValueForTurns()
	{
		if (!Int32.TryParse(turnsInpt.text, out turns))
		{
   			turns = -1;
		}
	}

	public void SetValueForScore()
	{
		if (!Int32.TryParse(scoreInpt.text, out scoreForWin))
		{
   			ScoreForWin = -1;
		}
		else
		{
			ScoreForWin = scoreForWin;
		}
	}

	public void SetFieldSize()
	{
		sizeField = sizeDrop.value + 3;
	}
	public void StartGame()
	{
		if(turns > 0 && scoreForWin > 0 && sizeField >= 3)
		{
			currentLevel.Init(sizeField, scoreForWin, turns, ballTypesQuantity.value + 5);
			startMenu.SetActive(false);
			levelMenu.SetActive(true);
			ScoreForWin = scoreForWin;
			ShowScore(0);
			ShowTurns(turns);
		}
	}

	public void BackToMainMenu()
	{
		endGame.SetActive(false);
		startMenu.SetActive(true);
	}

	public void ShowEnd(bool win) {
		endGame.SetActive(true);
			levelMenu.SetActive(false);
		if(win)
			endGameText.text = "You win";
		else
			endGameText.text = "You lose";
	}
}
 