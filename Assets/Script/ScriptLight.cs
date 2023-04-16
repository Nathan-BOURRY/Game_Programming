using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D;
    float startRadius = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light2D.pointLightOuterRadius = startRadius;
    }

    // Update is called once per frame
    void Update()
    {


        float t = Mathf.Sin(Time.time * 0.5f * Mathf.PI);
        light2D.pointLightOuterRadius = startRadius * (5.0f + t);




    }

    void plusRadius()
    {
        light2D.pointLightOuterRadius = light2D.pointLightOuterRadius + 0.05f;

    }

    void minusRadius()
    {

        light2D.pointLightOuterRadius = light2D.pointLightOuterRadius - 0.05f;
    }
}
