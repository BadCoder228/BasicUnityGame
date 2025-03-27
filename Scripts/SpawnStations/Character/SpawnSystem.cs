using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Header("character input vvv")]
    [SerializeField] private GameObject Character, Enemy, Hitbox, CharacterHitbox;
    [Header("spawner input vvv")]
    [SerializeField] private GameObject CSpawn, ESpawn;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Character.transform.position = new Vector3(CSpawn.transform.position.x, CSpawn.transform.position.y);
        Enemy.transform.position = new Vector3(ESpawn.transform.position.x, ESpawn.transform.position.y);
        try
        {
            StopCoroutine(FindObjectOfType<EnemyCharacterDetecting>().Instance);
            FindObjectOfType<EnemyCharacterDetecting>().ShootPermission = false;
            FindObjectOfType<EnemyCharacterDetecting>().IsInstanceRunning = true;
        }
        catch
        {

        }
    }

}
