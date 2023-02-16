using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{

    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        // Spawn a random prop at every spawn point
        foreach(GameObject spawnProp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[rand], spawnProp.transform.position, Quaternion.identity);

            prop.transform.parent = spawnProp.transform;
        }
    }
}
