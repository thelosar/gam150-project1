using UnityEngine;
using System.Collections;

public class EmitBubble : MonoBehaviour {

    public GameObject bubble;
    public float bubbleDelay = 0.25f;
    public bool emitting = true;

    // Use this for initialization
    void Start () {
        StartCoroutine("BubbleEmitter");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator BubbleEmitter()
    {
        while (emitting)
        {
            yield return new WaitForSeconds(bubbleDelay);
            GameObjectUtil.Instantiate(bubble, transform.position);
        }
    }
}
