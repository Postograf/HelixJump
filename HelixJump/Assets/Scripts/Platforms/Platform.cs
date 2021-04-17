using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 50;
    [SerializeField] private float _bounceRadius = 50;

    public void Break()
    {
        var segments = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in segments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}
