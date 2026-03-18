using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
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
[System.Serializable]
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

    public MyVector3(MyVector2 v, float z = 0f)
    {
        x = v.x;
        y = v.y;
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
        result.z = a.z - b.y;
        return result;
    }

    public static MyVector3 operator *(MyVector3 v, float s)
    {
        return new MyVector3(v.x * s, v.y * s, v.z * s);
    }

    public static MyVector3 operator *(MyVector3 v, MyVector3 s)
    {
        return new MyVector3(v.x * s.x, v.y * s.y, v.z * s.z);
    }

    public static MyVector3 operator /(MyVector3 v, float s)
    {
        if (s == 0) { return new MyVector3(0f, 0f, 0f); }

        return new MyVector3(v.x / s, v.y / s, v.z / s);
    }

    public static MyVector3 zero
    {
        get
        {
            return new MyVector3(0f, 0f, 0f);
        }
    }
    public static MyVector3 forward
    {
        get
        {
            return new MyVector3(0f, 0f, 1f);
        }
    }
    public static MyVector3 up
    {
        get
        {
            return new MyVector3(0f, 1f, 0f);
        }
    }
    public static MyVector3 right
    {
        get
        {
            return new MyVector3(1f, 0f, 0f);
        }
    }
   

}
[System.Serializable]
public class MyVector4
{
    public float x;
    public float y;
    public float z;
    public float w;

    public MyVector4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public MyVector4(MyVector3 v, float w = 1f)
    {
        x = v.x;
        y = v.y;
        z = v.z;
        this.w = w;
    }

    public static MyVector4 operator +(MyVector4 a, MyVector4 b)
    {
        MyVector4 result = new MyVector4(0f, 0f, 0f, 0f);
        result.x = a.x + b.x;
        result.y = a.y + b.y;
        result.z = a.z + b.z;
        result.w = a.w + b.w;
        return result;
    }

    public static MyVector4 operator -(MyVector4 a, MyVector4 b)
    {
        MyVector4 result = new MyVector4(0f, 0f, 0f, 0f);
        result.x = a.x - b.x;
        result.y = a.y - b.y;
        result.z = a.z - b.z;
        result.w = a.w - b.w;
        return result;
    }
}
[System.Serializable]
public class Matrix4by4
{ 

    public MyVector4 row0;
    public MyVector4 row1; 
    public MyVector4 row2;
    public MyVector4 row3;

    public Matrix4by4(MyVector4 column1, MyVector4 column2, MyVector4 column3, MyVector4 column4)
    {
        row0 = new MyVector4(column1.x, column2.x, column3.x, column4.x);
        row1 = new MyVector4(column1.y, column2.y, column3.y, column4.y);
        row2 = new MyVector4(column1.z, column2.z, column3.z, column4.z);
        row3 = new MyVector4(column1.w, column2.w, column3.w, column4.w);
    }

    public Matrix4by4(MyVector3 R, MyVector3 U, MyVector3 F, MyVector3 P)
    {
        row0 = new MyVector4(R.x, U.x, F.x, P.x);
        row1 = new MyVector4(R.y, U.y, F.y, P.y);
        row2 = new MyVector4(R.z, U.z, F.z, P.z);
        row3 = new MyVector4(0f, 0f, 0f, 1f);
    }

    public static MyVector4 operator *(Matrix4by4 M, MyVector4 v)
    {
        return M.Multiply(v);

        /*
        float x = M.values[0, 0] * v.x + M.values[0, 1] * v.y + M.values[0, 2] * v.z + M.values[0, 3] * v.w;
        float y = M.values[1, 0] * v.x + M.values[1, 1] * v.y + M.values[1, 2] * v.z + M.values[1, 3] * v.w;
        float z = M.values[2, 0] * v.x + M.values[2, 1] * v.y + M.values[2, 2] * v.z + M.values[2, 3] * v.w;
        float w = M.values[3, 0] * v.x + M.values[3, 1] * v.y + M.values[3, 2] * v.z + M.values[3, 3] * v.w;
        return new MyVector4 (x, y, z, w);
        */
    }

    public MyVector4 Multiply(MyVector4 v)
    {
        float x = SFMathsCore.DotProduct(row0, v);
        float y = SFMathsCore.DotProduct(row1, v);
        float z = SFMathsCore.DotProduct(row2, v);
        float w = SFMathsCore.DotProduct(row3, v);

        return new MyVector4(x, y, z, w);
    }

    public static Matrix4by4 Identity
    {
        get
        {
            return new Matrix4by4(
                new MyVector4(1, 0, 0, 0),
                new MyVector4(0, 1, 0, 0),
                new MyVector4(0, 0, 1, 0),
                new MyVector4(0, 0, 0, 1));
            
        }
    }
}



public static class SFMathsCore
{
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
    public static float DotProduct(MyVector4 a, MyVector4 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
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

    public static MyVector3 CalculateGravityFor2Objects(PhysicsObject obj1, PhysicsObject obj2, float G)
    {
        
        MyVector3 distanceVector = obj1.CustomTransformComponent.Position - obj2.CustomTransformComponent.Position;
        float distanceValue = Length(distanceVector);
        distanceValue = Mathf.Clamp(distanceValue, 11f, 10000f);
        MyVector3 distanceNormalised = Normalize(distanceVector);
        if (distanceValue == 0)
        {
            Debug.LogError("Distance is Zero");
            return MyVector3.zero;
        }
        float force = (G * obj1.mass * obj2.mass) / Mathf.Pow(distanceValue, 2);
        return (distanceNormalised * -force);
        
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

    public static MyVector3 ForwardFromYawPitchUnity(float yawRadians, float pitchRadians)
    {
        float Fx = Mathf.Sin(yawRadians) * Mathf.Cos(pitchRadians);
        float Fy = -Mathf.Sin(pitchRadians);
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

    public static void BuildBasisFromForward(MyVector3 forward, out MyVector3 R, out MyVector3 U, out MyVector3 F)
    {
        F = Normalize(forward);
        U = MyVector3.up;
        R = Normalize(CrossProduct(U, F));
        U = CrossProduct(F, R);
    }

    public static MyVector3 LocalPointToWorldPoint(MyVector3 P, MyVector3 localPoint, MyVector3 R, MyVector3 U, MyVector3 F)
    {
        return P + DirectionFromBasis(localPoint, R, U, F);
    }

    public static MyVector3 Lerp(MyVector3 a, MyVector3 b, float t)
    {
        return a + Scale((b - a), t); 
    }
    public static float Lerp(float a, float b, float t)
    {
        return a + (b - a) * t;
    }

    public static MyVector3 NonUniformScaleLocalToWorld(MyVector3 P, MyVector3 localP, MyVector3 scaleV, MyVector3 R, MyVector3 U, MyVector3 F)
    {
        MyVector3 scaled = NonUniformScale(localP, scaleV);
        return P + Scale(R, scaled.x) + Scale(U, scaled.y) + Scale (F, scaled.z);
    }

    public static MyVector3 TransformPoint(Matrix4by4 M, MyVector3 P)
    {
        MyVector4 v = new MyVector4(P.x, P.y, P.z, 1f);
        MyVector4 result = M.Multiply(v);
        return new MyVector3(result.x, result.y, result.z);
    }

    public static MyVector3 TransformDirection(Matrix4by4 M, MyVector3 D)
    {
        MyVector4 v = new MyVector4(D.x, D.y, D.z, 0f);
        MyVector4 result = M.Multiply(v);
        return new MyVector3(result.x, result.y, result.z);
    }

    public static Matrix4by4 BuildTRS(MyVector3 P, MyVector3 R, MyVector3 U, MyVector3 F, MyVector3 scale)
    {
        MyVector3 Rs = R * scale.x;
        MyVector3 Us = U * scale.y;
        MyVector3 Fs = F * scale.z;

        return new Matrix4by4(Rs, Us, Fs, P);
    }
}
