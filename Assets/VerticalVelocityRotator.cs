using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalVelocityRotator : MonoBehaviour
{
    private Flappy _player;

    private float currentY;
    private float lastY;

    public float velocity = 0f;
    
    // Update is called once per frame
    void Start()
    {
        _player = transform.parent.GetComponent<Flappy>();
        currentY = lastY = transform.parent.position.y;
    }

    private void FixedUpdate()
    {
        if (_player == null)
            return;

        currentY = _player.transform.position.y;

        velocity = currentY - lastY;
        velocity *= 10f;
        velocity = Mathf.Clamp(velocity, -1, 1);
        velocity = Unity.Mathematics.math.remap(-1, 1, 0, 1, velocity);
        
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0,0,-20f), Quaternion.Euler(0,0,60f), velocity   );
        
        lastY = _player.transform.position.y;
        
    }
}
