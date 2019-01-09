using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InteractiveSwap : MonoBehaviour {


	int x1 = -1;
	int y1 = -1;
	int x2 = -1 ;
	int y2 = -1;

	public CurrentLevel currentLevel;
	void Update () {

		if(Input.GetMouseButtonUp(0))
		{
			GraphicRaycaster m_Raycaster = GetComponent<GraphicRaycaster>();
    		PointerEventData m_PointerEventData;
			m_PointerEventData = new PointerEventData(EventSystem.current);
            m_PointerEventData.position = Input.mousePosition;
			List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(m_PointerEventData, results);

			if(results.Count > 0)
			{
				if(results[0].gameObject.GetComponent<BallScript>())
				{
					Debug.Log("x1 - " + results[0].gameObject.GetComponent<BallScript>().x + ", y1 - " +
										results[0].gameObject.GetComponent<BallScript>().y);
					x1 = results[0].gameObject.GetComponent<BallScript>().x;
					y1 = results[0].gameObject.GetComponent<BallScript>().y;
				}
			}
		}
		if(Input.GetMouseButtonDown(0))
		{
			GraphicRaycaster m_Raycaster = GetComponent<GraphicRaycaster>();
    		PointerEventData m_PointerEventData;
			m_PointerEventData = new PointerEventData(EventSystem.current);
            m_PointerEventData.position = Input.mousePosition;
			List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(m_PointerEventData, results);

			if(results.Count > 0)
			{
				if(results[0].gameObject.GetComponent<BallScript>())
				{
				//	Debug.Log("x2 - " + results[0].gameObject.GetComponent<BallScript>().x + ", y2 - " +
				//						results[0].gameObject.GetComponent<BallScript>().y);
					x2 = results[0].gameObject.GetComponent<BallScript>().x;
					y2 = results[0].gameObject.GetComponent<BallScript>().y;
				}
			}
		}

		if(x1 != -1 && x2 != -1)
		{
			currentLevel.MakeTurn(x1,y1,x2,y2);
			x1 = y1 = x2 = y1 = -1; 
		}

	}
}
