using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TankMovement : MonoBehaviour
{
    public float m_Speed = 12f; // How fast the tank moves forward and back
    public float m_TurnSpeed = 180f; // How fast the tank turns in degrees per second

    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue; // The current value of the movement input
    private float m_TurnInputValue; // the current value of the turn input

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
       // GetComponent<Animation>().GetComponent<Animator>();
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;

        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
        
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
