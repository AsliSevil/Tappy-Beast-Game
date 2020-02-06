using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("MovePipe", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePipe()
    {
        verticalSpeed = -verticalSpeed;
        rb.velocity = new Vector2(-horizontalSpeed, verticalSpeed);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PipeRemover")
        {
            Destroy(gameObject);
        }
    }
}
