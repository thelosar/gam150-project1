using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    public float speed = 5f;
    public float minXForce = 10f;
    public Vector2 trajectory = Vector2.zero;

    private Player player;
    private Rigidbody2D projectileBody;
    private bool playerToTheLeft;
    private bool playerAbove;
    private float distanceToBase = 0.3f;

	void Start()
    {
        projectileBody = GetComponent<Rigidbody2D>();
        AimAndFire();
    }
    void OnEnable()
    {
        AimAndFire();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag != "Turret" && target.gameObject.tag != "Sensor" && target.gameObject.tag != "EnemyBullet" && target.gameObject.tag != "Bullet")
            GameObjectUtil.Destroy(gameObject);
    }

    private void AimAndFire()
    {
        player = (Player)FindObjectOfType(typeof(Player));

        if (player != null)
        {
            if (player.transform.position.x < transform.position.x)
                playerToTheLeft = true;
            else
                playerToTheLeft = false;
            if (player.transform.position.y > transform.position.y - distanceToBase)
                playerAbove = true;
            else
                playerAbove = false;
        }
        
        
        if (!playerToTheLeft && playerAbove)
        {
            trajectory.x = Random.Range(minXForce, speed);
            trajectory.y = speed - trajectory.x;
        }
        else if (!playerToTheLeft && !playerAbove)
        {
            trajectory.x = Random.Range(minXForce, speed);
            trajectory.y = -1 * (speed - trajectory.x);
        }
        else if (playerToTheLeft && playerAbove)
        {
            trajectory.x = Random.Range(minXForce, speed) * -1;
            trajectory.y = speed + trajectory.x;
        }
        else
        {
            trajectory.x = Random.Range(minXForce, speed) * -1;
            trajectory.y = (-1 * speed) - trajectory.x;
        }

        if (projectileBody != null)
            projectileBody.velocity = trajectory;
    }
}

