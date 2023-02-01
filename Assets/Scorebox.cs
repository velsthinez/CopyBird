using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorebox : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private Flappy _player;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _player = FindObjectOfType<Flappy>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_player != null && _player.IsDead) return;
        
        if (!col.gameObject.CompareTag("Player"))
            return;

        if (_scoreManager != null)
            _scoreManager.AddScore();
        
        if(_audioSource != null)
            _audioSource.Play();
    }
}
