using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BulletSpawnSystem : MonoBehaviour
{
    [Header("Bullet Prefab")]
    [SerializeField] public float BulletSpeed = 1.2f;
    [SerializeField] GameObject BulletPrefab;

    Rigidbody2D RigidBody2d;

    public List<GameObject> UselessPrefabs = new List<GameObject>();

    public void BulletRun(Transform GameObjectCaller)
    {
        GameObject Bullet = Instantiate(BulletPrefab, new Vector3(GameObjectCaller.GetComponent<BoxCollider2D>().transform.position.x, GameObjectCaller.GetComponent<BoxCollider2D>().transform.position.y), GameObjectCaller.GetComponent<BoxCollider2D>().transform.rotation);

        UselessPrefabs.Add(Bullet);

        RigidBody2d = Bullet.GetComponent<Rigidbody2D>();
        RigidBody2d.velocity = BulletSpeed * GameObjectCaller.transform.up;
    }
}
    

