using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Animations : MonoBehaviour {
	const int animationSteps = 20;
	const float animationTime = 0.5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwapAnimation(GameObject ball1, GameObject ball2, Action nextAnimation) {
		Vector3 pos1 = ball1.transform.position;
		Vector3 pos2 = ball2.transform.position;
		CountdownAction bothAnimations = new CountdownAction(2, nextAnimation);
		StartCoroutine(MoveToPosition(ball1, pos2, () => bothAnimations.DecreaseAndAct()));
		StartCoroutine(MoveToPosition(ball2, pos1, () => bothAnimations.DecreaseAndAct()));
	}

	public void SwapAnimation(GameObject ball1, GameObject ball2) {
		Vector3 pos1 = ball1.transform.position;
		Vector3 pos2 = ball2.transform.position;
		StartCoroutine(MoveToPosition(ball1, pos2, () => {}));
		StartCoroutine(MoveToPosition(ball2, pos1, () => {}));
	}

	IEnumerator MoveToPosition(GameObject obj, Vector3 position, Action act) {
		Vector3 initPos = obj.transform.position;
		for(int x=0; x < animationSteps; x++) {
			obj.transform.position = Vector3.Lerp(initPos, position, (float)x / animationSteps);
			yield return new WaitForSeconds(animationTime / animationSteps);
		}
		obj.transform.position = position;
		act();
	}
	
	void SemaphorAction(int count, Action act) {
		if(count <= 0) {
			act();
		}
	}
}
