using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColliderLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            ActionWithAliveObject(FindObjectOfType<Score>().CharacterScore++);
        }
        else if (collision.tag == "Character")
        {
            ActionWithAliveObject(FindObjectOfType<Score>().EnemyScore++);
        }
        else if (collision.tag == "Encounter")
        {
            gameObject.transform.up = -gameObject.transform.up;
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * FindObjectOfType<BulletSpawnSystem>().BulletSpeed;
        }
        else if (collision.tag == "Border")
        {
            Destroy(gameObject, 3);
        }
    }

    private void ActionWithAliveObject(int Score)
    {
        Score++;
        Destroy(gameObject);
        foreach (var Prefab in FindObjectOfType<BulletSpawnSystem>().UselessPrefabs)
        {
            try
            {
                Destroy(Prefab);
            }
            catch { }
        }
        FindObjectOfType<SpawnSystem>().Spawn();
    }
}
