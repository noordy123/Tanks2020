﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;

    public Transform m_FireTransform;

    public float m_LaunchForce = 30f;

    public float m_ShootDelay = 1f;

    bool m_CanShoot;
    float m_ShootTimer;

    private void Awake()
    {
        m_CanShoot = false;
        m_ShootTimer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CanShoot == true)
        {
            m_ShootTimer -= Time.deltaTime;
            if(m_ShootTimer <= 0)
            {
                m_ShootTimer = m_ShootDelay;
                
            }
        }
    }

    void Fire()
    {
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_CanShoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            m_CanShoot = false;
        }
    }
}
