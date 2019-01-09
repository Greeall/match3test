using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClass {

	public int score;
	int scoreForWin;
	int turns;
	public int currentStep;

	public int fieldSize;

	public Field field;

	public LevelClass(int _winScore, int _turns, int _fieldSize, int ballTypes)
	{
		scoreForWin = _winScore;
		score = 0;
		//turns = _turns;
		currentStep = _turns;
		fieldSize = _fieldSize;
		field = FieldGenerator.InitialFieldGeneration(fieldSize, ballTypes);
	}
	
	public int MakeTurn(int x1, int y1, int x2, int y2)
	{
		int possiblePoints = field.Swap(x1,y1,x2,y2);
		if(possiblePoints > 0)
		{
			score += possiblePoints;
			currentStep -= 1;
		}
		return possiblePoints;
	}

	public bool CheckFinish()
	{
		return currentStep == 0 || score >= scoreForWin;
	}

	public bool CheckWin() {
		return score >= scoreForWin;
	}
}
