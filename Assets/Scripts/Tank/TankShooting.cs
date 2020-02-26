using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;

    public Transform m_FireTransform;

    public float m_LaunchForce = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }
    
    public void Fire()
    {
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }
}
