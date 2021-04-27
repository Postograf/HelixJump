using System;
using UnityEngine;

public class FinishPlatform : Platform 
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            Debug.Log("Finish!!!");
        }
    }
}
