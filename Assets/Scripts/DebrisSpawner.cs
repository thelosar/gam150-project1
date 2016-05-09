using UnityEngine;
using System.Collections;

public class DebrisSpawner : MonoBehaviour {

    public GameObject debris;
    public float spawnDelayMin = 1f;
    public float spawnDelayMax = 2f;

    private float spawnDelay = 1.5f;
    //private bool readyToSpawn = true;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine("SpawnTimer");
    }

    /*void Update () {

        if (readyToSpawn)
        {
            spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
            StartCoroutine("SpawnTimer");
            readyToSpawn = false;
        }
        


    }*/

    IEnumerator SpawnTimer()
    {
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
        yield return new WaitForSeconds(spawnDelay);

        GameObjectUtil.Instantiate(debris, transform.position);
        //Debris clone = Instantiate(debris, transform.position, Quaternion.identity) as Debris;

        StartCoroutine("SpawnTimer");
    }
}
