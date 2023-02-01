using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flappy : MonoBehaviour
{
    public float FlapForce = 200f;

    public bool IsDead = false;

    public List<AudioClip> FlapSounds;
    public float MinPitch = 1f;
    public float MaxPitch = 1f;

    public List<AudioClip> DieSounds;
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;

    private GameManager _gameManager;

    private float _gravityStore;

    private bool gameStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = FindObjectOfType<GameManager>();

        _gravityStore = _rigidbody2D.gravityScale;
        _rigidbody2D.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager == null)
            return;

        if (_gameManager.GameProgress != GameManager.GameStatus.InProgress)
            return;

        if (!gameStarted)
            _rigidbody2D.gravityScale = _gravityStore;
        
        gameStarted = true;

        if (Input.GetKeyDown(KeyCode.Space))
            DoFlap();
    }

    private void DoFlap()
    {
        if (IsDead)
            return;
        
        if (_rigidbody2D == null)
            return;
        
        _rigidbody2D.velocity = Vector2.zero;
        
        _rigidbody2D.AddForce(Vector2.up * FlapForce  );

        if (_audioSource != null)
        {
            int random = Random.Range(0, FlapSounds.Count);
            float randomPitch = Random.Range(MinPitch , MaxPitch);
            _audioSource.pitch = randomPitch;
            _audioSource.PlayOneShot(FlapSounds[random]);
        }
    }

    public void Die()
    {
        if (IsDead)
            return;
        
        IsDead = true;
        
        _gameManager.GameEnded();
        
        if (_audioSource != null)
        {
            int random = Random.Range(0, DieSounds.Count);
            _audioSource.PlayOneShot(DieSounds[random]);
        }
        // Destroy(gameObject);
    }
}
