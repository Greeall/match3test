using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypesOfBalls : MonoBehaviour {

	public Sprite [] typesOfBalls;

	public static TypesOfBalls I;

	void Start()
	{
		I = this;
	}
}
