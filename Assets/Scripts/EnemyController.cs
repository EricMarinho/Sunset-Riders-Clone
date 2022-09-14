using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject projectilePrefab;
    public ParticleSystem explosion;
    GameObject player;
    float shootTime = 2f;
    float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("WalPlayer");
    }

    // Update is called once per frame
    void Update()
    {

        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            Launch();
            shootTimer = 2f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet") != null){

            Instantiate(explosion, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            Destroy(gameObject);

        }

    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(player.transform.position - transform.position, 50);

    }

}
