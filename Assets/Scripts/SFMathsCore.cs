using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class MyVector2
{
    public float x;
    public float y;

    public MyVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public static MyVector2 operator +(MyVector2 a, MyVector2 b)
    {
        MyVector2 result = new MyVector2(0f, 0f);
        result.x = a.x + b.x;
        result.y = a.y + b.y;
        return result;
    }

    public static MyVector2 operator -(MyVector2 a, MyVector2 b)
    {
        MyVector2 result = new MyVector2(0f, 0f);
        result.x = a.x - b.x;
        result.y = a.y - b.y;
        return result;
    }

}

public class MyVector3
{
    public float x;
    public float y;
    public float z;

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static MyVector3 operator +(MyVector3 a, MyVector3 b)
    {
        MyVector3 result = new MyVector3(0f, 0f, 0f);
        result.x = a.x + b.x;
        result.y = a.y + b.y;
        result.z = a.z + b.z;
        return result;
    }

    public static MyVector3 operator -(MyVector3 a, MyVector3 b)
    {
        MyVector3 result = new MyVector3(0f, 0f, 0f);
        result.x = a.x - b.x;
        result.y = a.y - b.y;
        result.z = a.z + b.y;
        return result;
    }

    public static MyVector3 zero()
    {
        return new MyVector3(0f, 0f, 0f);
    }
    public static MyVector3 forward()
    {
        return new MyVector3(0f, 0f, 1f);
    }
    public static MyVector3 up()
    {
        return new MyVector3(0f, 1f, 0f);
    }
    public static MyVector3 right()
    {
        return new MyVector3(1f, 0f, 0f);
    }

}



public static class SFMathsCore
{
    public static Vector2 AddVector(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }

    public static MyVector2 AddVector(MyVector2 a, MyVector2 b)
    {
        return new MyVector2(a.x + b.x, a.y + b.y);
    }

    public static MyVector3 AddVector(MyVector3 a, MyVector3 b)
    {
        return new MyVector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector2 SubtractVector(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x - b.x, a.y - b.y);
    }

    public static MyVector2 SubtractVector(MyVector2 a, MyVector2 b)
    {
        return new MyVector2(a.x - b.x, a.y - b.y);
    }

    public static MyVector3 SubtractVector(MyVector3 a, MyVector3 b)
    {
        return new MyVector3(a.x - b.x, a.y - b.y, a.z + b.z);
    }

    public static float Length(Vector2 v)
    {
        return Mathf.Sqrt(v.x * v.x + v.y * v.y);
    }

    public static float Length(MyVector2 v)
    {
        return Mathf.Sqrt(v.x * v.x + v.y * v.y);
    }

    public static float Length(MyVector3 v)
    {
        return Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
    }
    
    // ONLY USE LENGTHSQ / MAGNITUDESQ WHEN DOING COMPARISONS OR CHECKS CANNOT BE USED FOR MEASURING LENGTH IN SPACE
    public static float LengthSquared(Vector2 v)
    {
        return v.x * v.x + v.y * v.y;
    }
    
    public static float LengthSquared(MyVector2 v)
    {
        return v.x * v.x + v.y * v.y;
    }

    public static float LengthSquared(MyVector3 v)
    {
        return v.x * v.x + v.y * v.y + v.z * v.z;
    }

    public static Vector2 Normalize(Vector2 v)
    {
        float length = Length(v);
        if (length == 0) { return Vector2.zero; }

        return new Vector2(v.x / length, v.y / length);
    }

    public static MyVector2 Normalize(MyVector2 v)
    {
        float length = Length(v);
        if (length == 0) { return new MyVector2(0f, 0f); }

        return new MyVector2(v.x / length, v.y / length);
    }

    public static MyVector3 Normalize(MyVector3 v)
    {
        float length = Length(v);
        if (length == 0) { return new MyVector3(0f, 0f, 0f); }

        return new MyVector3(v.x / length, v.y / length, v.z / length);
    }

    public static Vector2 Scale(Vector2 v, float s)
    {
        return new Vector2(v.x * s, v.y * s);
    }

    public static MyVector2 Scale(MyVector2 v, float s)
    {
        return new MyVector2(v.x * s, v.y * s);
    }
    
    public static MyVector3 Scale(MyVector3 v, float s)
    {
        return new MyVector3(v.x * s, v.y * s, v.z * s);
    }
    
    public static MyVector2 Divide(MyVector2 v, float s)
    {
        if (s == 0) { return new MyVector2(0f, 0f); }

        return new MyVector2(v.x / 2, v.y / 2);
    }

    public static MyVector3 Divide(MyVector3 v, float s)
    {
        if (s == 0) { return new MyVector3(0f, 0f, 0f); }

        return new MyVector3(v.x / 2, v.y / 2, v.z / 2);
    }

    public static float DotProduct(MyVector2 a, MyVector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    public static float DotProduct(Vector2 a, Vector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    public static MyVector2 MoveStep(MyVector2 direction, float speed)
    {
        MyVector2 dir = Normalize(direction);
        MyVector2 v = Scale(dir, speed);
        return Scale(v, Time.deltaTime);
    }
    
    public static MyVector3 MoveStep(MyVector3 direction, float speed)
    {
        MyVector3 dir = Normalize(direction);
        MyVector3 v = Scale(dir, speed);
        return Scale(v, Time.deltaTime);
    }

    public static MyVector2 ApplyGravity(MyVector2 v, MyVector2 gravity)
    {
        return v + Scale(gravity, Time.deltaTime);
    }
    
    public static MyVector3 ApplyGravity(MyVector3 v, MyVector3 gravity)
    {
        return v + Scale(gravity, Time.deltaTime);
    }

    public static Vector2 MyVectorToVector(MyVector2 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static MyVector2 Vector2ToMyVector2(Vector2 v)
    {
        return new MyVector2(v.x, v.y);
    }

    public static MyVector3 Vector3ToMyVector3(Vector3 v)
    {
        return new MyVector3(v.x, v.y, v.z);
    }

    public static Vector3 MyVector3ToVector3(MyVector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    public static float RadiansToDegrees(float radians)
    {
        return radians * (180 / Mathf.PI);
    }

    public static float DegreesToRadians(float degrees)
    {
        return degrees * (Mathf.PI / 180);
    }

    public static float AngleFromVector2(MyVector2 v)
    {
        return Mathf.Atan2(v.y, v.x);  
    }

    public static MyVector2 Vector2FromAngle(float radians)
    {
        return new MyVector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }

    public static MyVector3 ForwardFromYawPitch(float yawRadians, float pitchRadians)
    {
        float Fx = Mathf.Sin(yawRadians) * Mathf.Cos(pitchRadians);
        float Fy = Mathf.Sin(pitchRadians);
        float Fz = Mathf.Cos(yawRadians) * Mathf.Cos(pitchRadians);
        return new MyVector3(Fx, Fy, Fz);
    }
    
    public static MyVector3 CrossProduct(MyVector3 a, MyVector3 b)
    {
        float Cx = a.y * b.z - a.z * b.y;
        float Cy = a.z * b.x - a.x * b.z;
        float Cz = a.x * b.y - a.y * b.x;
        return new MyVector3(Cx, Cy, Cz);
    }

    public static MyVector3 NonUniformScale(MyVector3 v, MyVector3 s)
    {
        return new MyVector3(v.x * s.x, v.y * s.y, v.z * s.z);
    }

    public static MyVector3 DirectionFromBasis(MyVector3 localDir, MyVector3 R, MyVector3 U, MyVector3 F)
    {
        return Scale(R, localDir.x) + Scale(U, localDir.y) + Scale(F, localDir.y);
    }

    public static MyVector3 LocalPointToWorldPoint(MyVector3 P, MyVector3 localPoint, MyVector3 R, MyVector3 U, MyVector3 F)
    {
        return P + DirectionFromBasis(localPoint, R, U, F);
    }

}
