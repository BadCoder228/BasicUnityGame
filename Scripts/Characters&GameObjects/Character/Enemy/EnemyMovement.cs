using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float Speed = 25;
    private float YDirection, XDirection = 1f;

    private Rigidbody2D Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.drag = 7;
        Rigidbody.velocity = Vector2.zero;
    }

    private void Update()
    {
        Vector3 EDirection = Player.GetComponent<Transform>().position - transform.position;
        float EADirection = Mathf.Atan2(EDirection.y, EDirection.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, EADirection), Time.deltaTime * 5);
        if (FindObjectOfType<EnemyDetecting>().Bullet)
        {
            transform.position -= new Vector3(-FindObjectOfType<EnemyDetecting>().BulletPos.x * Speed * Time.deltaTime, -FindObjectOfType<EnemyDetecting>().BulletPos.y * Speed * Time.deltaTime, 0);
            FindObjectOfType<EnemyDetecting>().BulletPos = Vector2.zero;
        }
        else
        {
            if (transform.position.y >= Player.GetComponent<Transform>().position.y)
            {
                YDirection = -0.2f;
            }
            else if (transform.position.y <= Player.GetComponent<Transform>().position.y)
            {
                YDirection = 0.2f;
            }

            if (transform.position.x >= Player.GetComponent<Transform>().position.x)
            {
                XDirection = -0.2f;
            }
            else if (transform.position.x <= Player.GetComponent<Transform>().position.x)
            {
                XDirection = 0.2f;
            }
            transform.position += new Vector3(2 * XDirection * Time.deltaTime, 2 * YDirection * Time.deltaTime, 0);
        }

    }
}
