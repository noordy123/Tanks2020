using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
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

        if(targetRigidbody != null)
        {
            targetRigidbody.AddExplosionForce(m_ExplosionForce,
                            transform.position, m_ExplosionRadius);

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

            if(targetHealth != null)
            {
                float damage = CalculateDamage(targetRigidbody.position);

                targetHealth.TakeDamage(damage);
            }
        }

        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = 
            (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        float damage = relativeDistance * m_MaxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }

}
