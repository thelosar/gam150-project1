using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

    public float secondsToDisappear = 1f;

    private Player player;
    private float velocity = 5f;
    private Rigidbody2D bubbleBody;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        bubbleBody = GetComponent<Rigidbody2D>();
    }

	void OnEnable()
    {
        StartCoroutine("Disappear");
    }
	
	// Update is called once per frame
	void Update () {
        if (player.direction == "up")
            bubbleBody.velocity = new Vector2(0, -velocity);
        else if (player.direction == "down")
            bubbleBody.velocity = new Vector2(0, velocity);
        else if (player.direction == "right")
        {
            if (player.isStationary)
                bubbleBody.velocity = new Vector2(-velocity, 0);
        }
        else if (player.direction == "left")
        {
            if (player.isStationary)
                bubbleBody.velocity = new Vector2(velocity, 0);
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(secondsToDisappear);
        GameObjectUtil.Destroy(gameObject);
    }
}
