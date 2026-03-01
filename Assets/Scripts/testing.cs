using UnityEngine;
using System.Collections.Generic;
using System;

public class testing : MonoBehaviour
{
    private float x;
    private float y;
    private MyVector3 a = new MyVector3(2f, -1f, 5f);
    private MyVector3 ab = new MyVector3(-6f, 3f, 9f);
    private MyVector3 b = new MyVector3(0.6634f, 0.5000f, 0.5567f);

    void start()
    {
        float radians = SFMathsCore.DegreesToRadians(210);
        y = Mathf.Sin(radians);
        x = Mathf.Cos(radians);

        //Debug.Log(x + " , " + y);

    }
    
    private void Update()
    {
        //MyVector3 lerpResult = SFMathsCore.VecLerp(a, ab, 0.25f);
        //float v = SFMathsCore.FLerp(0f, 90f, easeOutQuad(1.5f));
        //float t = 1 - ((1 - 1.5f) * (1 - 1.5f));
        //MyVector3 lerpResult = SFMathsCore.NonUniformScaleLocalToWorld(new MyVector3(10f, 2f, -4f), new MyVector3(1.5f, 2f, -0.5f), new MyVector3(2f, 0.5f, 3f), new MyVector3(0.8f, 0f, -0.6f), new MyVector3(0f, 1f, 0f), new MyVector3(0.6f, 0f, 0.8f));
        //Debug.Log("x: " + lerpResult.x + ", y: " + lerpResult.y + " z: " + lerpResult.z);
        //Debug.Log(v);
         MyVector3 R = SFMathsCore.Normalize(SFMathsCore.CrossProduct(MyVector3.up(), b));
        Debug.Log("x: " + R.x + ", y: " + R.y + " z: " + R.z);
         MyVector3 Up = SFMathsCore.CrossProduct(b, R);
        Debug.Log("x: " + Up.x + ", y: " + Up.y + " z: " + Up.z);

    }

    private float easeOutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }
}
