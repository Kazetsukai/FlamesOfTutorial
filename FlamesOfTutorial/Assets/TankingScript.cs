using UnityEngine;
using System.Collections;

public class TankingScript : MonoBehaviour, ISelectable, IMovable {

    private bool _selected = false;
	
    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_selected)
            renderer.material.color = Color.red;
        else
            renderer.material.color = Color.white;
	}

    public void Select()
    {
        _selected = true;
    }

    public void Deselect()
    {
        _selected = false;
    }
	
	public bool IsSelected
	{
		get 
		{
			return _selected;
		}
	}

    public void Move(Vector3 destination)
    {
        rigidbody.AddForce((destination - transform.position + Vector3.up * 10) * 20);
        Debug.Log("Move!");
    }
}
