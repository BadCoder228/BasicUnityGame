using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour 
{ 
    public Vector3 BulletPos = Vector3.zero;
    public bool Bullet, Encounter;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Bullet = true;
            BulletPos = collision.gameObject.GetComponent<Transform>().position; 
        }
        if (collision.tag == "Encounter")
        {
            Encounter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            Bullet = false;
        if (collision.tag == "Encounter")
            Encounter = false;
    }
}