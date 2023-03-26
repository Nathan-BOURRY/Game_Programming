using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D;
        float startRadius = 0.1f;
        float endRadius = 1f;
        bool isLight = false;
      
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light2D.pointLightOuterRadius = startRadius;
    }

    // Update is called once per frame
    void Update()
    {
            
            if(!isLight){
                
                Invoke("plusRadius", 1f);
               
              
            } else {
                 Invoke("minusRadius", 1f);
            }

            if(light2D.pointLightOuterRadius >= 0.5){
                isLight = true;
            } else if(light2D.pointLightOuterRadius <= 0.1) {
                isLight = false;
            }
            

    
    
    }

    void plusRadius (){
        light2D.pointLightOuterRadius = light2D.pointLightOuterRadius + 0.05f;

    }

    void minusRadius (){

         light2D.pointLightOuterRadius = light2D.pointLightOuterRadius - 0.05f;
    }
}
