using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Timer = System.Threading.Timer;

public class Scroller : MonoBehaviour
{
    public float Speed = 2f;
    SpriteRenderer _spriteRenderer;
    private Flappy _player;
    private GameManager _gameManager;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        
        Vector2 offset = new Vector2(Time.time * Speed, 0);
        
        _spriteRenderer.material.mainTextureOffset = offset;
    }
}
