using UnityEngine;
using System.Collections;

public class EscapeFire : MonoBehaviour {

    public float currentSpeed = .1f;
    public float acceleration = .1f;
    public float maxSpeed = 15f;
    public float fireStopDelay = 3f;

    private Rigidbody2D fireBody;

	// Use this for initialization
	void Start () {
        fireBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Player player = (Player)FindObjectOfType(typeof(Player));
        if (!player)
            StartCoroutine("StopFire");

        fireBody.velocity = new Vector2(currentSpeed, 0);

        Accelerate();
	}

    private void Accelerate()
    {
        if (currentSpeed <= maxSpeed)
            currentSpeed += acceleration * Time.deltaTime;
    }

    IEnumerator StopFire()
    {
        yield return new WaitForSeconds(fireStopDelay);
        currentSpeed = 0;
        acceleration = 0;
    }
}
