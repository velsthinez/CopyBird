using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float MoveSpeed = 100f;

    private Flappy _player;

    private void Start()
    {
        _player = FindObjectOfType<Flappy>();
        
        if(_player == null)
            Debug.LogError("NO PLAYER");
    }

    private void FixedUpdate()
    {
        if (_player != null && _player.IsDead)
            return;
        
        if(transform.position.x <= -12)
            Destroy(gameObject);
        
        Vector2 targetMovePos = transform.position;
        targetMovePos.x -= MoveSpeed*Time.deltaTime;

        transform.position = targetMovePos;
    }
}
