using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyTankMovement : MonoBehaviour
{
    public float m_CloseDistance = 8f; // may be too big
    public Transform m_Turret;

    private GameObject m_Player;

    private NavMeshAgent m_NavAgent;

    private Rigidbody m_Rigidbody;

    public AudioSource pirates;
    public AudioSource panthers;

    private bool m_Follow;
    // Start is called before the first frame update

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Follow == false)
            return;

        float distance = (m_Player.transform.position - transform.position).magnitude;

        if(distance > m_CloseDistance)
        {
            m_NavAgent.SetDestination(m_Player.transform.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            m_NavAgent.isStopped = true;
        }
        if(m_Turret != null)
        {
           m_Turret.LookAt(m_Player.transform);
        }
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = true;
            pirates.Play();
            panthers.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = false;
            pirates.Stop();
            panthers.Play();
        }
    }
}
