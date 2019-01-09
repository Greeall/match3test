using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field  {

	const int pointsForStandardLine = 5;
	const int pointsFor4Combo = 15;
	const int pointsFor5Combo = 30;
	public int []column;
	const int emptyCell = -1;
	public int fieldSize;

	int ballTypes;

	public Element [,] grid;

	public Field(int size, int _ballTypes)
	{
		fieldSize = size;
		grid = new Element[size,size];
		ballTypes = _ballTypes;
	}

	public int Swap(int x1, int y1, int x2, int y2)
	{
		if(AreCellsNearby(x1,y1,x2,y2))
		{
			Field fieldCopy = new Field(fieldSize, ballTypes);
			fieldCopy.grid = grid.Clone() as Element[,];

			Element bufferEl = fieldCopy.grid[x1,y1];
			fieldCopy.grid[x1,y1] = fieldCopy.grid[x2,y2];
			fieldCopy.grid[x2,y2] = bufferEl;

			fieldCopy.CheckCoincedence();

			if(fieldCopy.IsAnyLineExist())
			{
				bufferEl = grid[x1,y1];
				grid[x1,y1] = grid[x2,y2];
				grid[x2,y2] = bufferEl;
			}

			int points = CheckCoincedence();
			FallElements();	
			points += FillUpByBalls();

			CheckDeadLock();
			return points;
		}
		return 0;
	}

	public bool AreCellsNearby(int x1, int y1, int x2, int y2)
	{
		return ((x1 == x2 && (y1+1 == y2 || y1-1 == y2)) || y1 == y2 && (x1+1 == x2 || x1-1 == x2));
	}

	public bool IsAnyLineExist()
	{
		for(int i = 0; i < fieldSize; i++)
			for(int j = 0; j < fieldSize; j++)
				if(grid[i,j].type == emptyCell)
					return true;
		return false;
	}

	public int CheckCoincedence()
	{
		return 	CheckFiveComboType() +
		CheckFourHorizontalLine() +
		CheckFourVerticalLine() +
		CheckStandardHorizontalLine() +
		CheckStandartVerticalLine();
	}

	public int CheckFiveComboType()
	{
		return CheckFiveHorizontalLine() +
		CheckFiveVerticalLine() +
		CheckFiveCombo1Type() +
		CheckFiveCombo2Type() +
		CheckFiveCombo3Type() +
		CheckFiveCombo4Type() +
		CheckFiveCombo5Type() +
		CheckFiveCombo6Type() +
		CheckFiveCombo7Type() +
		CheckFiveCombo8Type() +
		CheckFiveCombo9Type();
	}

	public int CheckFiveCombo1Type()
	{
		int points = 0;
		for(int i = 0; i < fieldSize - 2; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i+1,j] && grid[i,j] == grid[i+2,j])
						{
							DeleteAllElements(grid[i,j]);
							points += pointsFor5Combo;
						}	
		return points;
	}

	public int CheckFiveCombo2Type()
	{
		int points = 0;
		for(int i = 0; i < fieldSize - 2; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i+1,j+1] && grid[i,j+1] == grid[i+2,j+1])
						{	
							points += pointsFor5Combo;
							DeleteAllElements(grid[i,j]);	
						}
		return points;
	}

	public int CheckFiveCombo3Type()
	{
		int points = 0;
		for(int i = 0; i < fieldSize - 2; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i+1,j+2] && grid[i,j] == grid[i+2,j+2])
						{
							DeleteAllElements(grid[i,j]);
							points += pointsFor5Combo;
						}	
		return points;
	}

	public int CheckFiveCombo4Type()
	{
		int points = 0;
		for(int i = 1; i < fieldSize - 1; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i-1,j] && grid[i,j] == grid[i+1,j])
						{
							DeleteAllElements(grid[i,j]);
							points += pointsFor5Combo;	
						}
		return points;
	}

	public int CheckFiveCombo5Type()
	{
		int points = 0;
		for(int i = 1; i < fieldSize - 1; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i+1,j+1] && grid[i,j] == grid[i-1,j+1])
						{
							DeleteAllElements(grid[i,j]);	
							points += pointsFor5Combo;
						}
		return points;
	}

	public int CheckFiveCombo6Type()
	{
		int points = 0;
		for(int i = 1; i < fieldSize - 1; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i+1,j+2] && grid[i,j] == grid[i-1,j+2])
						{
							DeleteAllElements(grid[i,j]);	
							points += pointsFor5Combo;
						}
		return points;
	}

	public int CheckFiveCombo7Type()
	{
		int points = 0;
		for(int i = 2; i < fieldSize; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i-1,j+2] && grid[i,j] == grid[i-2,j+2])
						{
							DeleteAllElements(grid[i,j]);	
							points += pointsFor5Combo;
						}
		return points;
	}

	public int CheckFiveCombo8Type()
	{
		int points = 0;
		for(int i = 2; i < fieldSize; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i-1,j+1] && grid[i,j] == grid[i-2,j+1])
						{
							DeleteAllElements(grid[i,j]);	
							points += pointsFor5Combo;
						}
		return points;
	}

	public int CheckFiveCombo9Type()
	{
		int points = 0;
		for(int i = 2; i < fieldSize; i ++)
			for(int j = 0; j < fieldSize - 2; j++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
						if(grid[i,j] == grid[i-1,j] && grid[i,j] == grid[i-2,j])
						{
							DeleteAllElements(grid[i,j]);	
							points += pointsFor5Combo;
						}
		return points;
	}

	public int CheckFiveHorizontalLine()
	{
		int points = 0;
		if(fieldSize >= 5)
		{
		for(int i = 0; i < fieldSize; i ++)
			for(int j = 0; j < fieldSize - 4; j ++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2] && grid[i,j] == grid[i,j+3] && grid[i,j] == grid[i,j+4])
					{	
						DeleteAllElements(grid[i,j]);
						points += pointsFor5Combo;
					}
		}
		return points;
	}


	int CheckFiveVerticalLine()
	{
		int points = 0;
		if(fieldSize >= 5)
		{
		for(int i = 0; i < fieldSize - 4; i ++)
			for(int j = 0; j < fieldSize; j ++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i+1,j] && grid[i,j] == grid[i+2,j] && grid[i,j] == grid[i+3,j] && grid[i,j] == grid[i+4,j])
					{	
						DeleteAllElements(grid[i,j]);
						points = pointsFor5Combo;
					}
		}
		return points;
	}
	public int CheckStandardHorizontalLine()
	{
		int points = 0;
		for(int i = 0; i < fieldSize; i ++)
			for(int j = 0; j < fieldSize - 2; j ++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2])
					{
						DeleteHorizontal(i, j, j+1, j+2);
						points += pointsForStandardLine;
					}
		return points;
					
	}

	

	int CheckStandartVerticalLine()
	{
		int points = 0;
		for(int i = 0; i < fieldSize - 2; i ++)
			for(int j = 0; j < fieldSize; j ++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i+1,j] && grid[i,j] == grid[i+2,j])
					{
						DeleteVertical(i,j,i+1,i+2);
						points += pointsForStandardLine;
					}
		return points;
	}

	int CheckFourHorizontalLine()
	{
		int points = 0;
		if(fieldSize >= 4)
		{
		for(int i = 0; i < fieldSize; i ++)
			for(int j = 0; j < fieldSize - 3; j ++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i,j+1] && grid[i,j] == grid[i,j+2] && grid[i,j] == grid[i,j+3])
					{	
						DeleteHorizontalLine(i);
						points += pointsFor4Combo;
					}
		}
		return points;
	}

	int CheckFourVerticalLine()
	{
		int points = 0;
		if(fieldSize >= 4)
		{
		for(int i = 0; i < fieldSize - 3; i ++)
			for(int j = 0; j < fieldSize; j ++)
				if(grid[i,j].type != emptyCell)
					if(grid[i,j] == grid[i+1,j] && grid[i,j] == grid[i+2,j] && grid[i,j] == grid[i+3,j])
					{	
						DeleteVerticalLine(j);
						points += pointsFor4Combo;
					}
		}
		return points;
	}

	void DeleteHorizontal(int i, int j, int j1, int j2)
	{
		grid[i,j] = new Element(emptyCell);
		grid[i, j1] = new Element(emptyCell);
		grid[i, j2] = new Element(emptyCell);
	}

	void DeleteVertical(int k, int j, int k1, int k2)
	{
		grid[k, j] = new Element(emptyCell);
		grid[k1, j] = new Element(emptyCell);
		grid[k2, j] = new Element(emptyCell);
	}

	void DeleteHorizontalLine(int i)
	{
		for(int k = 0; k < fieldSize; k++)
			grid[i,k] = new Element(emptyCell);
	}

	void DeleteVerticalLine(int i)
	{
		for(int k = 0; k < fieldSize; k++)
			grid[k,i] = new Element(emptyCell);
	}

	void DeleteAllElements(Element elementType)
	{
		for(int i = 0; i < fieldSize; i++)
			for(int j = 0; j < fieldSize; j++)
				if(grid[i,j] == elementType)
					grid[i,j] = new Element(emptyCell);
	}

	public void FallElements()
	{
		for(int columnNumber = 0; columnNumber < fieldSize; columnNumber ++)
		{
			column = new int[fieldSize];
			for(int i = 0; i < fieldSize; i++)
				column[i] = grid[i,columnNumber].type;

			for(int j = 0; j < fieldSize; j++)
			{
				for(int k = 1; k < fieldSize; k++)
				{
					if(column[k] == emptyCell && column[k-1] != emptyCell)
					{
						int buffer = column[k];
						column[k] = column[k-1];
						column[k-1] = buffer;
					}
				}
			}
			int z = 0;
			for(int i = 0; i < fieldSize; i++)
			{
				grid[z,columnNumber].type = column[i]; 
				z++;
			}
		}

	}

	public int FillUpByBalls()
	{
		int points = 0;
		bool isAnyNewBall = false;
		for(int i = 0; i < fieldSize; i++)
		{
			for(int j = 0; j < fieldSize; j++)
			{
				if(grid[i,j].type == emptyCell)
				{
					isAnyNewBall = true;
					int elementType = Random.Range(0,ballTypes);
					grid[i,j] = new Element(elementType);
				}
			}
		}
		if(isAnyNewBall)
		{
			points = CheckCoincedence();
			FallElements();	
			FillUpByBalls();
		}
		return points;
	}

	public bool IsTurnPossible()
	{
		for(int i = 0; i < fieldSize - 1; i ++)
		{
			for(int j = 0; j < fieldSize - 1; j++)
			{
				int a = 1;
				if(i == fieldSize - 1) a = -a;
				if(TrySwap(j, i, j, i + a) || TrySwap(i,j,i + a,j)) return true; 
			}
		}
		return false;
	}

	bool TrySwap(int x1, int y1, int x2, int y2)
	{
		Field fieldCopy = new Field(fieldSize, ballTypes);
		fieldCopy.grid = grid.Clone() as Element[,];
		Element bufferEl = fieldCopy.grid[x1,y1];
		fieldCopy.grid[x1,y1] = fieldCopy.grid[x2,y2];
		fieldCopy.grid[x2,y2] = bufferEl;
		fieldCopy.CheckCoincedence();
		return fieldCopy.IsAnyLineExist();
	}

	public void CheckDeadLock()
	{
		if(!IsTurnPossible())
			{
				GenerationBallsAfterDeadLock();
				CheckCoincedence();
				FallElements();	
				FillUpByBalls();
				CheckDeadLock();
			}
	}
	public void GenerationBallsAfterDeadLock()
	{
		do
		{
			for(int i = 0; i < fieldSize; i++)
				for(int j = 0; j < fieldSize; j++)
					grid[i,j].type = Random.Range(0, ballTypes);
		}
		while(!IsTurnPossible());
	}

}
