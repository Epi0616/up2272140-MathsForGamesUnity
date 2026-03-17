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
        foreach (PhysicsObject physicsObject1 in objects)
        {
            foreach (PhysicsObject physicsObject2 in objects)
            {
                //physicsObject.acceleration += SFMathsCore.CalculateGravityFor2Objects(physicsObject1,PrimaryStar, GravitationalConstant);
                if (physicsObject1 == physicsObject2) { continue; }
                physicsObject1.acceleration += SFMathsCore.CalculateGravityFor2Objects(physicsObject1,physicsObject2, GravitationalConstant);
            }
            
            
            physicsObject1.currentVelocity += physicsObject1.acceleration * Time.fixedDeltaTime;
            
            physicsObject1.CustomTransformComponent.Position += physicsObject1.currentVelocity/physicsObject1.mass * Time.fixedDeltaTime;
        }
        
        //Debug.Log(transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
        //objects[1]. acceleration = SFMathsCore.CalculateGravityFor2Objects(objects[1], PrimaryStar, GravitationalConstant);
        //objects[1].currentVelocity += objects[1].acceleration * Time.fixedDeltaTime;
        //objects[1].CustomTransformComponent.Position += objects[1].currentVelocity/objects[1].mass * Time.fixedDeltaTime;
    }
}
