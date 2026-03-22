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
        //R = new MyVector3(0.6f, 0.0f, -0.8f);
        //U = new MyVector3(0.0f, 0.1f, 0.0f);
        //F = new MyVector3(0.8f, 0.0f, 0.6f);
        /*
        MyVector3 F = SFMathsCore.ForwardFromYawPitch(SFMathsCore.DegreesToRadians(30), SFMathsCore.DegreesToRadians(20));
        MyVector3 R = SFMathsCore.Normalize(SFMathsCore.CrossProduct(MyVector3.up, F));
        M = SFMathsCore.BuildTRS(A, R, MyVector3.up, F, B);
        MyVector3 worldP = SFMathsCore.TransformPoint(M, C);
        MyVector3 worldD = SFMathsCore.TransformDirection(M, C);
        Debug.Log("Forward is: " + F.x + " , " + F.y + " , " + F.z);
        Debug.Log("Right is: " + R.x + " , " + R.y + " , " + R.z);
        Debug.Log("world Point is: " + worldP.x + " , " + worldP.y + " , " + worldP.z);
        Debug.Log("world Direciton is: " + worldD.x + " , " + worldD.y + " , " + worldD.z);
        */
        M = new Matrix4by4(A, B, C, new MyVector3(6.0f, 0.0f, 0.0f));
        MyVector4 V = M.Multiply(new MyVector4(2.0f, 1.0f, -4.0f, 1.0f));
        Debug.Log(V.x);
    }

    private float easeOutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }
}
