using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAirship : MonoBehaviour
{
    bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            Vector2 position = transform.position;
            position.x = position.x + 4f * Time.deltaTime;
            transform.position = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            isMove = true;
        }
    }
}
