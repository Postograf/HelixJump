using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _range = 5f;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _minimalBallPosition;
    
    // Start is called before the first frame update
    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();
        _minimalBallPosition = _ball.transform.position;
        
        TrackBall();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_ball.transform.position.y < _minimalBallPosition.y)
        {
            _minimalBallPosition = _ball.transform.position;
            TrackBall();
        }
    }

    private void TrackBall()
    {
        var cameraPosition = _minimalBallPosition;
        var beamPosition = _beam.transform.position;
        beamPosition.y = _minimalBallPosition.y;
        var direction = (beamPosition - _minimalBallPosition).normalized + _directionOffset;
        cameraPosition -= direction * _range;
        transform.position = cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
