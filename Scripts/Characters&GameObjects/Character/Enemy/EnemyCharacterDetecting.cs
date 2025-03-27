using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyCharacterDetecting : MonoBehaviour
{
    public GameObject Gun, Enemy;
    public bool ShootPermission, IsInstanceRunning = false;
    public Coroutine Instance;


    private void Update()
    {
        if (ShootPermission && IsInstanceRunning)
        {
           Instance = StartCoroutine(SimpleShoot());
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Character")
        {
            IsInstanceRunning = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Encounter")
            ShootPermission = false;
        if (collision.tag != "Encounter" && collision.tag == "Character" && !FindObjectOfType<EnemyDetecting>().Encounter)
            ShootPermission = true;
    }

    public IEnumerator SimpleShoot()
    {
        IsInstanceRunning = false;
        Enemy.GetComponent<Rigidbody2D>().drag = 10000;
        FindObjectOfType<BulletSpawnSystem>().BulletRun(Gun.GetComponent<Transform>());
        Enemy.GetComponent<Rigidbody2D>().drag = 7;

        yield return new WaitForSecondsRealtime(1);
        IsInstanceRunning = true;
    }
}
