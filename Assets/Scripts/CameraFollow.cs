using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float zOffset = -20f;

	private Transform player;

	void Awake(){
		//camera.orthographicSize = ((Screen.height / 2.0f) / 100f);
	}

	// Use this for initialization
	void Start () {
		player = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
			transform.position = new Vector3 (player.position.x + xOffset, transform.position.y + yOffset, zOffset);
	}
}
