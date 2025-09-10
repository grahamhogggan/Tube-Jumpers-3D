using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyantObject : MonoBehaviour
{
    public float floatStrength = 10f;   // upward force when submerged
    public float waterDrag = 1f;        // drag in water
    public float waterAngularDrag = 1f;
    public FluctuatingPlane fluctuatingPlane;
    public float offset = 0.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get water height at this object's X,Z
        float waterHeight =    fluctuatingPlane.GetWaveHeight(transform.position);

        float objectY = transform.position.y;

        if (objectY < waterHeight) // object is under the surface
        {
            float displacement = waterHeight - objectY + offset;
            Vector3 buoyancy = Vector3.up * floatStrength * displacement;
            rb.AddForce(buoyancy, ForceMode.Acceleration);

            rb.drag = waterDrag;
            rb.angularDrag = waterAngularDrag;
        }
        else
        {
            rb.drag = 0f;
            rb.angularDrag = 0.05f;
        }
    }
}