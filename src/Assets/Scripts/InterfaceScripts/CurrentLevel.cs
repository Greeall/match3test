using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CurrentLevel : MonoBehaviour {

	public GameUI ui;

	public Animations animations;
	public GameObject ballPrefab;

	public GameObject field;
	LevelClass level;

	GameObject[,] balls;

	// Use this for initialization
	public void Init(int sizeField, int scoreForWin, int turns, int ballTypes)
	{	
		level = new LevelClass(scoreForWin, turns, sizeField, ballTypes);
		balls = new GameObject[sizeField, sizeField];
		ShowLevel();
	}

	public void ShowLevel()
	{	
		DeleteOldBalls();

		float gridHeight = Screen.height;
		float ballSize = gridHeight / level.fieldSize;
		field.GetComponent<RectTransform>().sizeDelta = new Vector2(gridHeight, gridHeight);
		float x = 0;
		float y = 0;
		for(int i = 0; i < level.fieldSize ; i++)
		{
			for(int j = 0; j < level.fieldSize; j++)
			{
				GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation) as GameObject;
				balls[i,j] = ball;
				ball.GetComponent<RectTransform>().sizeDelta = new Vector2(ballSize, ballSize);
				ball.transform.SetParent(field.transform);
				ball.transform.localPosition = new Vector3(x,y);
				x += ballSize;
				ball.GetComponent<BallScript>().x = i;
				ball.GetComponent<BallScript>().y = j;
				ball.GetComponent<BallScript>().type = level.field.grid[i,j].type;
				ball.GetComponent<Image>().sprite = TypesOfBalls.I.typesOfBalls[ball.GetComponent<BallScript>().type];
			}
			x = 0;
			y -= ballSize;
		}
	}

	void DeleteOldBalls()
	{
		Transform [] balls = field.GetComponentsInChildren<Transform>();
		if(balls.Length > 1)
		{
			for(int i = 1; i < balls.Length; i++)
				Destroy(balls[i].transform.gameObject);
		}
	}

	public void MakeTurn(int x1, int y1, int x2, int y2) {
		if(level.MakeTurn(x1, y1, x2, y2) > 0) {
			GameObject ball1 = balls[x1,y1];
			GameObject ball2 = balls[x2,y2];
			animations.SwapAnimation(
				ball1, 
				ball2,
				() => AfterTurnAnimation()
			);
		} else if(level.field.AreCellsNearby(x1,y1,x2,y2)){
			GameObject ball1 = balls[x1,y1];
			GameObject ball2 = balls[x2,y2];
			animations.SwapAnimation(
				ball1, 
				ball2,
				(() => animations.SwapAnimation(
					ball1, 
					ball2,
					() => AfterTurnAnimation()
				))
			);
		}
	}

	void AfterTurnAnimation() {
		ui.ShowTurns(level.currentStep);
		ui.ShowScore(level.score);
		if (level.CheckFinish())
			ui.ShowEnd(level.CheckWin());
		ShowLevel();
	}

}
