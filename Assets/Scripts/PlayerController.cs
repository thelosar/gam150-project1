using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		moving.x = moving.y = 0;

		if (Input.GetKey ("right") || Input.GetKey("d"))
		{
			moving.x = 1;
		} 
		else if (Input.GetKey ("left") || Input.GetKey("a")) 
		{
			moving.x = -1;
		}

		if (Input.GetKey ("up") || Input.GetKey("w"))
		{
			moving.y = 1;
		} 
		else if (Input.GetKey ("down") || Input.GetKey("s")) 
		{
			moving.y = -1;
		}

	}
}
