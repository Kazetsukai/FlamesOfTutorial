using UnityEngine;
using System.Collections;
using System;

public class ScriptController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))
            {
                obj.SendMessage("Deselect", SendMessageOptions.DontRequireReceiver);
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var tank = hit.transform.gameObject;
                var script = tank.GetComponent(typeof(ISelectable)) as ISelectable;

                if (script != null)
                {
                    script.Select();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))
                {
					var unit = obj.GetComponent(typeof(ISelectable)) as ISelectable;
					
					if (unit != null && unit.IsSelected)
                    	obj.SendMessage("Move", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
	}
}
