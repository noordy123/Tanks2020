using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpin : MonoBehaviour
{
    public float rotationSpeed = 2f;
    Vector3 currentEulerAngles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentEulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed;

        transform.eulerAngles = currentEulerAngles;
    }
}
