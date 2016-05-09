using UnityEngine;
using System.Collections;

public class Bits : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Scatter();
    }

    void OnEnable()
    {
        Scatter();
    }
	
	protected void Scatter()
    {
        //applies force to the objects in random direction left or right
        GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-50, 50));
        //applies force to the object random intensity upward
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 400));
    }
}
