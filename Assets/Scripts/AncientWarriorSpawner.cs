using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientWarriorSpawner : MonoBehaviour
{
    //IObjectPool<Enemy> _pool;
    //void Awake() => _pool = new IObjectPool<Test>(CreateTest, OnTakeTestFromPool, OnReturnBallToPool);
    [SerializeField] private GameObject _enemyToSpawn;
    [SerializeField] private float _spawnTime, _nextSpawn = 10;


    void Update()
    {
        if (SpawnSwitch())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        _spawnTime = Time.time + _nextSpawn;
        Instantiate(_enemyToSpawn, transform.position, transform.rotation);
    }

    private bool SpawnSwitch()
    {
        return Time.time >= _spawnTime;
    }
}
