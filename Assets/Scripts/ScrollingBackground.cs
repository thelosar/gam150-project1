using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

    public float scrollSpeed = 10f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, scrollSpeed, 0);
	}
}
