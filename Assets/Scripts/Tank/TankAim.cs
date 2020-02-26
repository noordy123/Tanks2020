using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{
    LayerMask m_LayerMask;
    
    public void Awake()
    {
        m_LayerMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_LayerMask))
        {
            transform.LookAt(hit.point);

            // zero the rotation around x and z
            transform.eulerAngles = Vector3.up * transform.eulerAngles.y;

        }
    }

}
