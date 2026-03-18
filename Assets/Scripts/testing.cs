using UnityEngine;
using System.Collections.Generic;
using System;

public class testing : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    private float w;
    private MyVector3 A = new MyVector3( 1f, 1f, 1f);
    private MyVector3 B = new MyVector3( 1f, 1f, 1f);
    private MyVector3 C = new MyVector3( 1f, 1f, 1f);
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
        

    }

    private float easeOutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }
}
