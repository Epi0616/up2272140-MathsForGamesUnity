using UnityEngine;
using System.Collections.Generic;
using System;

public class testing : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    private float w;
    private MyVector3 A = new MyVector3( 1.2f, -2f, 7f);
    private MyVector3 B = new MyVector3( 0f, 1.5f, 0.5f);
    private MyVector3 C = new MyVector3( -0.5f, 0f, 2f);
    private MyVector3 R;
    private MyVector3 U;
    private MyVector3 F;
    private MyVector4 Q;
    private MyVector4 E;
    private Matrix4by4 M;
    
    

    void start()
    {
       

        

    }
    
    private void Update()
    {
        MyQuaternion q = new MyQuaternion(SFMathsCore.DegreesToRadians(60f), new MyVector3(0.2673f, 0.5345f, 0.8018f));
        Debug.Log(q.w + " Vector: " + q.x + " , " + q.y + " , " + q.z);
    }

    private float easeOutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }
}
