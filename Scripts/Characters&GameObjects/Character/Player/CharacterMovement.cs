using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float Speed = 13;
     
    private Rigidbody2D Movement;
    private Vector3 Direction;

    private float KeyHor, KeyVer;

    void Start()
    {
        Movement = GetComponent<Rigidbody2D>();
        Movement.drag = 7;
    }

    void Update()
    {

        KeyHor = Input.GetAxisRaw("Horizontal");
        KeyVer = Input.GetAxisRaw("Vertical");

        Direction = Input.mousePosition;
        Direction = Camera.main.ScreenToWorldPoint(Direction);

        Vector2 FinalDirection = new Vector2(Direction.x - transform.position.x, Direction.y - transform.position.y);
        transform.up = FinalDirection;

        Movement.velocity += Speed * new Vector2(KeyHor *Time.deltaTime, KeyVer * Time.deltaTime);
    }
}