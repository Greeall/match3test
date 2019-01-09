using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator {

	public static Field InitialFieldGeneration(int size, int ballTypes)
	{
		
		Field field = new Field(size, ballTypes);

		for(int i = 0; i < size; i++)
		{
			for(int j = 0; j < size; j++)
			{
				int elementType = Random.Range(0, ballTypes);
				field.grid[i,j] = new Element(elementType);
			}
		}

		field.CheckCoincedence();
		field.FallElements();
		field.FillUpByBalls();

		field.CheckDeadLock();
		return field;
	}
}
