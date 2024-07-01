using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject _fireBall;
    private ParticleSystem _fireBallParticleSystem;
    private List<ParticleCollisionEvent> collisionEvents;

    public float damageAmount = 10f; // Урон от каждой частицы

    private void Start()
    {
        _fireBallParticleSystem = _fireBall.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ThrowFireball();
        }
        else
        {
            
        }
    }

    private void ThrowFireball()
    {
        _fireBall.SetActive(true);
        _fireBallParticleSystem.Play();
    }

    private void StopThrowingFireball()
    {
        if (!_fireBallParticleSystem.isPlaying)
        {
            _fireBallParticleSystem.Stop();
            _fireBall.SetActive(false);
        }
    }
}
