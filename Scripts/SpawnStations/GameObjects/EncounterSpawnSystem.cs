using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSpawnSystem : MonoBehaviour
{
    [Header("Encounter Prefab")]
    [SerializeField] private GameObject Encounter;

    void Start()
    {
        int EncounterValue = Random.Range(2, 3);
        for (byte i = 0; i <= EncounterValue;  i++)
        {
            Instantiate(Encounter, new Vector3(Random.Range(-2.77f, 5.82f), Random.Range(-3.55f, 3.55f)), Quaternion.identity);
        }
    }
}
