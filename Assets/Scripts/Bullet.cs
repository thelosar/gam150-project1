using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 100f;
    public bool horizontalShot = true;

    private float playerSpeed;
    private Rigidbody2D bulletBody;
    private string direction = "right";
    private Transform bulletTransform;
    private SpriteRenderer bulletSprite;
    private Vector2 bulletVelocity;
    private Player player;

	// Use this for initialization
	void Awake () {
        bulletBody = GetComponent<Rigidbody2D>();
        bulletTransform = GetComponent<Transform>();
        bulletSprite = GetComponent<SpriteRenderer>();
        player = (Player)FindObjectOfType(typeof(Player));

    }

    void OnEnable()
    {
        GetPlayerInfo();
    }
	
	// Update is called once per frame
	void Update ()
    {
        bulletBody.velocity = bulletVelocity;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
		if (target.gameObject.tag != "Player" && target.gameObject.tag != "Sensor" && target.gameObject.tag != "Bits" && target.gameObject.tag != "EnemyBullet")
            GameObjectUtil.Destroy(gameObject);
    }

    private void GetPlayerInfo()
    {
        playerSpeed = player.currentForwardSpeed;
        direction = player.direction.ToLower();
        if (player != null)
        {
            if (direction == "right")
            {
                SetBulletDirection(playerSpeed + bulletSpeed, 0, 0, false);
            }
            else if (direction == "up")
            {
                SetBulletDirection(0, playerSpeed + bulletSpeed, 90, false);
            }
            else if (direction == "left")
            {
                SetBulletDirection(-playerSpeed - bulletSpeed, 0, 180, true);
            }
            else
            {
                SetBulletDirection(0, -playerSpeed - bulletSpeed, -90, false);
            }
        }
        
    }

    private void SetBulletDirection(float velocityX, float velocityY, float rotation, bool flipY)
    {
        bulletVelocity = new Vector2(velocityX, velocityY);
        bulletTransform.rotation = Quaternion.Euler(0,0,rotation);
        bulletSprite.flipY = flipY;
    }
}
