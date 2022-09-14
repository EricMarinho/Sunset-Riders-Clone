using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject playerPrefab;
    Rigidbody2D playerRb;
    [SerializeField] float speed = 4.0f;
    float force = 8.0f;
    Animator playerAnim;
    bool lookDirection = true;
    int jump = 2;
    Vector2 lookDirections = new Vector2(1, 0);
    float time = 1f;
    float timer = 10f;
    bool isDead = false;

    public ParticleSystem explosion;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            Vector2 move = new Vector2(horizontal, vertical);

            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirections.Set(move.x, move.y);
                lookDirections.Normalize();
            }

            Vector2 position = playerRb.transform.position;
            position.x = position.x + horizontal * speed * Time.deltaTime;
            playerRb.transform.position = position;

            if (Input.GetKeyDown(KeyCode.C))
            {
                Launch();
                playerAnim.SetTrigger("Launch");
            }

            if (Input.GetKeyDown(KeyCode.Space) && jump <= 1)
            {
                jump = jump + 1;
                playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                playerAnim.SetInteger("Jump", jump);
            }
            Flip(horizontal);
            playerAnim.SetFloat("Speed", Mathf.Abs(horizontal));

        }
        else
        {
            Vector2 position2 = transform.position;
            position2.y = 3.3f;
            transform.position = position2;
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                isDead = false;
            }
        }
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") != null)
            {
                jump = 0;
                playerAnim.SetInteger("Jump", jump);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnm") == true)
        {
            Vector2 respawnPos = playerRb.transform.position;
            timer = time;
            Instantiate(explosion, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            isDead = true;
        }
    }

    void Flip(float horizontal)
    {
        if((horizontal > 0 && !lookDirection) || (horizontal<0 && lookDirection))
        {
            lookDirection = !lookDirection;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, playerRb.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirections, 600);

    }

}
