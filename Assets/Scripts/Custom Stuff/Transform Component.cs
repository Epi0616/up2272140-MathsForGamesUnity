using System;
using UnityEngine;

public class MyTransformComponent : MonoBehaviour
{
    [SerializeField] private MyVector3 position;
    [SerializeField] private MyVector3 rotation;
    [SerializeField] private MyVector3 scale;
    public MyVector3 Position
    {
        get { return position; }
        set { position = value; }
    }

    public MyVector3 Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }

    public MyVector3 Scale
    {
        get { return scale; }
        set { scale = value; }
    }

    private void Awake()
    {
        //Debug.Log(position.x + ", " + position.y + ", " + position.z);
    }
}
