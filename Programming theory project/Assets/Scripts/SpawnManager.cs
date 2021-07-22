using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject zombie;
    [SerializeField] int zombiesDead;
    Vector3 spawnPos;
    private void Start()
    {
        EventManager.OnDeath += EventManager_OnDeath;
        spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    //abstraction
    private void EventManager_OnDeath(int zD)
    {
        zombiesDead += zD;
        Debug.Log("kills" + zombiesDead);

        Instantiate(zombie,spawnPos,zombie.transform.rotation);

    }
}
