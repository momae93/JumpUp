using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAI : MonoBehaviour
{
    Animator anim;

    public float moveSpeed;
    public float jumpHeight;

    public GameObject player;
    private Transform playerTransform;

    Vector3 posA;
    Vector3 posB;
    Vector3 nextPos;



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTransform = player.transform;

        posA = transform.localPosition;
        posB = transform.localPosition;
        posB.y = transform.position.y - 5;
        posA.y = transform.position.y + 5;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void OnCollisionEnter(Collision col)
    {
        nextPos = nextPos != posA ? posA : posB;
    }
    void Movement()
    {
        if (transform.position.x > playerTransform.position.x)
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        if (transform.position.x < playerTransform.position.x)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, moveSpeed * Time.deltaTime);
        Debug.Log(Vector3.Distance(transform.position, nextPos));
        if (Vector3.Distance(transform.position, nextPos) <= 1)
            nextPos = nextPos != posA ? posA : posB;

        if (transform.position.y <= (playerTransform.position.y + 1) || transform.position.y <= (playerTransform.position.y))
            anim.SetBool("attack", true);
        else
            anim.SetBool("attack", false);
    }
}
