using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    Rigidbody body;
    public bool inAir = true;
    
    [SerializeField]
    Vector3 velocity;

    [SerializeField, Range(0.01f, 50f)]
    float stepSize;

    [SerializeField, Range(1f, 30f)]
    float bounciness = 15f;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Start()
    {
        body.velocity = new Vector3(0f, 15f, 0f);
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 position = body.position;
        float newPositionX = position.x + inputX * stepSize * Time.deltaTime;
        body.MovePosition(new Vector3(newPositionX, position.y, 0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if(Vector3.Dot(contact.normal, Vector3.up) == 1) {
            velocity.y = bounciness;
        }
        velocity.x = 0;
        velocity.z = 0;
        body.velocity = velocity;
        inAir = false;
    }

    void OnCollisionExit()
    {
        inAir = true;
    }
}
