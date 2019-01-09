using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CountdownAction {
	int counter;
	Action act;

	public CountdownAction(int _counter, Action _act) {
		counter = _counter;
		act = _act;
	}

	public void DecreaseAndAct() {
		counter--;
		if(counter <= 0) {
			act();
		}
	}
}
