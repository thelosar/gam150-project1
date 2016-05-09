using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int enemyHP = 1;
    public int numberOfDamageBits = 2;
    public GameObject bits;
    public bool destroyOnKill = true;

    private Explode explode;

	// Use this for initialization
	void Start () {
        explode = GetComponent<Explode>();
	}
	
	void OnCollisionEnter2D(Collision2D target)
    {
        CheckForDamage(target.gameObject.tag);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        CheckForDamage(target.gameObject.tag);
    }

    private void CheckForDamage(string target)
    {
        if (target == "Bullet")
        {
            enemyHP--;

            if (enemyHP <= 0)
            {
                if (destroyOnKill)
                    explode.OnExplode();
                else
                    explode.OnExplodeLite();
            }
            else
            {
                for (int i = 0; i < numberOfDamageBits; i++)
                {
                    //clones the bits
                    GameObjectUtil.Instantiate(bits, transform.position);
                }
            }
        }
    }
}
