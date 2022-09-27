using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpeed : MonoBehaviour
{
    public float speed;
    float rotation = 0;
    float intensity;
    public static string timeState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = this.transform.localEulerAngles.x;

        this.transform.Rotate(speed * Time.deltaTime, 0, 0);

        if(rotation >= 360)
        {
            rotation = 0f;
        }
        else
        {
            rotation += speed * Time.deltaTime;
            //print(rotation);
        }
        // 10 PM
        if(rotation >= 330)
        {
            intensity = 0.25f;
        }
        // 6 PM
        else if(rotation >= 270)
        {
            intensity = 0.75f;
        }
        // 2 PM
        else if (rotation >= 210)
        {
            intensity = 1f;
        }
        // 11 AM
        else if (rotation >= 165)
        {
            intensity = 1.5f;
        }
        // 6 AM
        else if (rotation >= 90)
        {
            intensity = 0.75f;
        }
        // 0 AM
        else if (rotation >= 0)
        {
            intensity = 0.25f;
        }
        
        this.gameObject.GetComponent<Light>().intensity = intensity;
    }
}
