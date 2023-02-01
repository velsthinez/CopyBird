using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public float SpawnInterval = 1f;
    private float _timer = 0f;

    private Flappy _player;
    private GameManager _gameManager;

    private void Start()
    {
        _timer = SpawnInterval;
        _player = FindObjectOfType<Flappy>();
        _gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.GameProgress != GameManager.GameStatus.InProgress)
            return;
        
        if (_player != null && _player.IsDead)
            return;
        
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
            return;
        }
        
        _timer = SpawnInterval;
        int random = Random.Range(0, ObstaclePrefabs.Length);

        GameObject.Instantiate(ObstaclePrefabs[random], transform.position, Quaternion.identity);
    }
}
