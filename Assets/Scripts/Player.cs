using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float currentForwardSpeed = 5f;
	public float maxForwardSpeed = 30f;
	public float automaticAcceleration = 0.5f;
	public float altitudeSpeed = 1f;
    public float manualAcceleration = 5f;
    public GameObject restartText;
    public string direction = "right";
    public bool isStationary = false;

    private PlayerController controller;
	private float prevXPos = -20f;
	private int destroyed = 1;
	private Explode exploder;
    private Animator animator;
    private Rigidbody2D playerBody;

	void Start() {
		controller = GetComponent<PlayerController> ();
		exploder = GetComponent<Explode> ();
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

	void Update () {
        AnimateShip();

        PlayerMovement();

        Accelerate ();
	}

	void Accelerate(){
		if (currentForwardSpeed < maxForwardSpeed){
			currentForwardSpeed += automaticAcceleration * Time.deltaTime;
		}
	}

    private void AnimateShip()
    {
        animator.SetInteger("Direction", (int)controller.moving.y);
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "EnemyBullet")
        {
			restartText.SetActive(true);

			exploder.OnExplode();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "EnemyBullet")
        {
            restartText.SetActive(true);

            exploder.OnExplode();
        }
    }

    public void StopPlayer()
    {
        currentForwardSpeed = 0;
        manualAcceleration = 0;
        altitudeSpeed = 0;
        automaticAcceleration = 0;
        PlayerMovement();
        isStationary = true;
    }

    private void PlayerMovement ()
    {
        if (direction.ToLower() == "right")
        {
            if (controller.moving.x >= 0)
                playerBody.velocity = new Vector2(currentForwardSpeed + (manualAcceleration * controller.moving.x), altitudeSpeed * controller.moving.y);
            else
                playerBody.velocity = new Vector2(currentForwardSpeed + (2 * manualAcceleration * controller.moving.x), altitudeSpeed * controller.moving.y);
        }
        else if (direction.ToLower() == "left")
        {
            if (controller.moving.x <= 0)
                playerBody.velocity = new Vector2(-currentForwardSpeed + manualAcceleration * controller.moving.x, altitudeSpeed * controller.moving.y);
            else
                playerBody.velocity = new Vector2(-currentForwardSpeed + 2 * manualAcceleration * controller.moving.x, altitudeSpeed * controller.moving.y);
        }
        else if (direction.ToLower() == "up")
        {
            if (controller.moving.y >= 0)
                playerBody.velocity = new Vector2(altitudeSpeed * controller.moving.x, currentForwardSpeed + manualAcceleration * controller.moving.y);
            else
                playerBody.velocity = new Vector2(altitudeSpeed * controller.moving.x, currentForwardSpeed + manualAcceleration * controller.moving.y * 2);
        }
        else if (direction.ToLower() == "down")
        {
            if (controller.moving.y >= 0)
                playerBody.velocity = new Vector2(altitudeSpeed * controller.moving.x, -currentForwardSpeed + manualAcceleration * controller.moving.y);
            else
                playerBody.velocity = new Vector2(altitudeSpeed * controller.moving.x, -currentForwardSpeed + manualAcceleration * controller.moving.y * 2);
        }
    }
}
