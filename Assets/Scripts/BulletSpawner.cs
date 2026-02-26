using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour

{

    [Header("Prefab")]

    public GameObject bulletPrefab;

    public MyVector3 muzzleLocalOffset = new MyVector3(0f, 0f, 1.2f);


    private bool firePressedThisFrame;


    // If you have PlayerInput (Send Messages) with a "Fire" action (you should after W3)

    public void OnFire(InputValue value)
    {
        Debug.Log("weaw");
        if (value.isPressed)
        {
            Debug.Log("Fired");
            firePressedThisFrame = true;
        }
    }


    private void Update()

    {

        // 1) Basis vectors of the capsule (world space)

        MyVector3 R = SFMathsCore.Vector3ToMyVector3(transform.right);

        MyVector3 U = SFMathsCore.Vector3ToMyVector3(transform.up);

        MyVector3 F = SFMathsCore.Vector3ToMyVector3(transform.forward);


        // 2) Capsule position

        MyVector3 P = SFMathsCore.Vector3ToMyVector3(transform.position);


        // 3) Spawn position (local point -> world point)

        // TODO (C): Use the correct Part A function to convert muzzleLocalOffset into a world point.

        MyVector3 spawnPos = SFMathsCore.LocalPointToWorldPoint(P, muzzleLocalOffset, R, U, F);


        // 4) Fire direction (local direction -> world direction)

        // Local forward is (0,0,1)

        MyVector3 localForward = new MyVector3(0f, 0f, 1f);


        // TODO (C): Use the correct Part A function to convert localForward into a world direction and normalise it.

        MyVector3 fireDir = 


        // 5) Spawn bullet (rotation is optional for movement)

        // TODO (C): GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);


        // 6) Pass direction to the bullet (Part D will implement BulletMover.Init)

        // TODO (C): bullet.GetComponent<Bullet>().Init(fireDir);

    }

}