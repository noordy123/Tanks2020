using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float m_MaxLifeTime = 2f;
    public float m_MaxDamage = 34f;
    public float m_ExplosionRadius = 5f;
    public float m_ExplosionForce = 100f;

    public ParticleSystem m_ExplosionParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        Destroy(gameObject);
    }
}
