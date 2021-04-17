using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var torque = -touch.deltaPosition.x * _rotateSpeed * Time.deltaTime;
                _rigidbody.AddTorque(Vector3.up * torque);
            }
        }
        else
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
