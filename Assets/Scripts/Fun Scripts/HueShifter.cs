using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HueShifter : MonoBehaviour
{
    public float Speed = 2;
    public Material shift;
    public Text[] warning;
    
    public Outline[] textOutline;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shift.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));

        for(int i = 0; i < warning.Length; i++)
        warning[i].color = shift.color;

        for (int j = 0; j < textOutline.Length; j++)
        {
            textOutline[j].effectColor = shift.color;
        }
    }
}
