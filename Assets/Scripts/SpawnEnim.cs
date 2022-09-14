using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnim : MonoBehaviour
{
    float range = 10f;
    float distance;
    bool isSpawned = true;
    public GameObject enemyPrefab;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("WalPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs(transform.position.x - player.transform.position.x);

        if (distance < range && isSpawned)
        {
            isSpawned = false;
            Spawn();
        }
    }

    public void Spawn()
    {
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
