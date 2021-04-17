using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    public void Bounce(float force, Vector3 center, float radius)
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(force, center, radius);
    }
}
