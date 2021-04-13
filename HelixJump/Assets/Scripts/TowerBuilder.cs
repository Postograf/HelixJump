using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawn;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finish;
    
    private float _startAndFinishAdditionalScale = 0.5f;
    
    public Vector3 BeamScale =>
            new Vector3(1, (_levelCount + _additionalScale) / 2f + _startAndFinishAdditionalScale, 1);
    private void Start()
    {
        Build();
    }
    
    private void Build()
    {
        var beam = Instantiate(_beam, transform);
        beam.transform.localScale = BeamScale;
        
        var spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;
        
        var parent = beam.transform;
        
        SpawnPlatform(_spawn, ref spawnPosition, parent);
        
        for (int i = 0; i < _levelCount; i++)
        {
            var platform = _platforms[Random.Range(0, _platforms.Length)];
            
            SpawnPlatform(platform, ref spawnPosition, parent);
        }
        
        SpawnPlatform(_finish, ref spawnPosition, parent);
    }
    
    private void SpawnPlatform(
        Platform platform, 
        ref Vector3 spawnPosition,
        Transform parent
        )
    {
        var rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Instantiate(platform, spawnPosition, rotation, parent);
        spawnPosition.y--;
    }
}
