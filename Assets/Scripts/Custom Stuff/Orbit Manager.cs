using System;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    [SerializeField] private List<PhysicsObject> objects;
    [SerializeField] private PhysicsObject PrimaryStar;

    private const float GravitationalConstant = 1f;
    private void FixedUpdate()
    {
        foreach (PhysicsObject physicsObject in objects)
        {
            foreach (PhysicsObject physicsObject2 in objects)
            {
                if (physicsObject == physicsObject2) { continue; }
                physicsObject.acceleration += SFMathsCore.CalculateGravityFor2Objects(physicsObject,physicsObject2, GravitationalConstant);
            }
            physicsObject.acceleration += SFMathsCore.CalculateGravityFor2Objects(physicsObject,PrimaryStar, GravitationalConstant);
            
            physicsObject.currentVelocity += physicsObject.acceleration * Time.fixedDeltaTime;
            
            physicsObject.CustomTransformComponent.Position += physicsObject.currentVelocity/physicsObject.mass * Time.fixedDeltaTime;
        }
        
        
        
        //Debug.Log(transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
        //objects[1]. acceleration = SFMathsCore.CalculateGravityFor2Objects(objects[1], PrimaryStar, GravitationalConstant);
        //objects[1].currentVelocity += objects[1].acceleration * Time.fixedDeltaTime;
        //objects[1].CustomTransformComponent.Position += objects[1].currentVelocity/objects[1].mass * Time.fixedDeltaTime;
    }
}
