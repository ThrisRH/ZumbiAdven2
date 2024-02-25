using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterPatrol : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rigidbody2;
    private Animator animator;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rigidbody2.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigidbody2.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;

        }
    }
}
