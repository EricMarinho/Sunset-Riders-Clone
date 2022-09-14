using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlataform : MonoBehaviour
{
    [SerializeField] float turningDelay = 2.0f;
    float delayTimer = 0;
    [SerializeField] int direction;
    [SerializeField] bool isHorizontal = true;
    [SerializeField] float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {


 
        Vector2 position = transform.position;

        if (isHorizontal)
        {
            position.x = position.x + (speed * direction * Time.deltaTime);
        }
        else
        {
            position.y = position.y + (speed * direction * Time.deltaTime);
        }
        transform.position = position;

        delayTimer -= Time.deltaTime;
        if (delayTimer <= 0)
        {
            delayTimer = turningDelay;
            direction *= -1;
        }
    }
}
