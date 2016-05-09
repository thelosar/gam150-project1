using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour {

	public GameObject bits;
	public int totalBits = 5;
    
    private bool active = true;

    

	public void OnExplode() {
        //destroys object
        GameObjectUtil.Destroy(gameObject);

        ScatterBits();
	}

    public void OnExplodeLite()
    {
        gameObject.SetActive(false);
        ScatterBits();
        active = false;
    }

    public void OnRespawn()
    {
        gameObject.SetActive(true);
        ScatterBits();
        active = true;
    }

    private void ScatterBits()
    {
        var t = transform;

        //creates bits when object explodes
        for (int i = 0; i < totalBits; i++)
        {
            //parts start outside of the player's area
            t.TransformPoint(0, -100, 0);
            //clones the bits
            GameObjectUtil.Instantiate(bits, t.position);
        }
    }

    public bool IsActive()
    {
        return active;
    }
}
