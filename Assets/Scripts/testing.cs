using UnityEngine;
using System.Collections.Generic;
using System;

public class testing : MonoBehaviour
{
    private float x;
    private float y;

    void start()
    {
        float radians = SFMathsCore.DegreesToRadians(210);
        y = Mathf.Sin(radians);
        x = Mathf.Cos(radians);

        Debug.Log(x + " , " + y);
    }
    
    private void Update()
    {
        MyVector3 result = SFMathsCore.CrossProduct(MyVector3.up(), new MyVector3(0.6f, 0f, 0.8f));
        Debug.Log(result.x + " , " + result.y + " , " + result.z);
        float wewa = SFMathsCore.AngleFromVector2(new MyVector2(-3, 5));
        //Debug.Log(wewa);
    }
}
