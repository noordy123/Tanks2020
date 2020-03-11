using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform closestDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy();
    }

    public Vector3 closestEnemy()
    {
        // ensures that all tanks are checked
        float minDist = 10000000;

        // initialise the vector
        Vector3 closest = Vector3.zero;

        // for each tank
        for(int i = 1; i < GameManager.m_Tanks.Length; i++)
        {
            // find the distance between the enemy tank and player tank
            float dist = Vector3.Distance(GameManager.m_Tanks[i].transform.position, GameManager.m_Tanks[0].transform.position);

            // find the closest tank
            if (dist < minDist)
            {
                minDist = dist;
                closest = GameManager.m_Tanks[i].transform.position;
            }
        }

        return closest;
    }
}
