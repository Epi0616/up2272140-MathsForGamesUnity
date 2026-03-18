using System;
using UnityEngine;

//[RequireComponent(typeof(MeshRenderer))]
public class PhysicsObject : MonoBehaviour
{
    private MyTransformComponent customTransformComponent;
    protected MeshRenderer myRenderer;
    
    public MyTransformComponent CustomTransformComponent
    {
        get { return customTransformComponent; }
        set { customTransformComponent = value; }
    }
    
    public MyVector3 currentVelocity;
    public MyVector3 acceleration;
    public float mass;

    private void Awake()
    {
        myRenderer = GetComponent<MeshRenderer>();
        customTransformComponent = GetComponent<MyTransformComponent>();
    }

    private void FixedUpdate()
    {
        if (isValid(customTransformComponent.Position))
        {
            transform.position = SFMathsCore.MyVector3ToVector3(customTransformComponent.Position);
            transform.localScale = SFMathsCore.MyVector3ToVector3(customTransformComponent.Scale);
            acceleration = MyVector3.zero;
        }
        else
        {
            Debug.LogError("Custom Transform is not valid");
        }
        
    }

    private bool isValid(MyVector3 vector)
    {
        return !float.IsNaN(vector.x) && !float.IsNaN(vector.y) && !float.IsNaN(vector.z);
    }
}
