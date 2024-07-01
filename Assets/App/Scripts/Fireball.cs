using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private ParticleSystem _fireBallParticleSystem;
    private List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        _fireBallParticleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = _fireBallParticleSystem.GetCollisionEvents(other, collisionEvents);
        Debug.Log(numCollisionEvents);

        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(10);
        }
    }
}
