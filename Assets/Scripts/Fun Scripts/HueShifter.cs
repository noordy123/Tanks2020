using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShifter : MonoBehaviour
{
    public float Speed = 2;
    public Material shift;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        shift.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
    }
}
