using UnityEngine;

public class Turret : MonoBehaviour

{

    public Transform ship;

    public MyVector3 localOffset = new MyVector3(0f, -1f, 0f);


    private void LateUpdate()

    {

        // Get the ship basis vectors (these should be calculated and set in W3)

        MyVector3 R = SFMathsCore.Vector3ToMyVector3(ship.right);

        MyVector3 U = SFMathsCore.Vector3ToMyVector3(ship.up);

        MyVector3 F = SFMathsCore.Vector3ToMyVector3(ship.forward);


        //Get ship position

        MyVector3 P = SFMathsCore.Vector3ToMyVector3(ship.position);


        // TODO: Convert local offset -> world offset and apply to transform

        transform.position = SFMathsCore.MyVector3ToVector3(SFMathsCore.LocalPointToWorldPoint(P, localOffset, R, U, F));

        // Then copy rotation

        transform.rotation = ship.rotation;

    }

}
