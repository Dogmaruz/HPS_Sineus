using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private float contractionRate = 1;
    private Transform _transform;
    private bool isStopped = false;

    private float timer;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            isStopped = false;
        }

        if (_transform.localScale.x >= 0 && isStopped == false)
        {
            float size = Time.deltaTime * contractionRate;
            _transform.localScale -= new Vector3(size, size, 0);
        }
    }

    public void StopMove(float time)
    {
        isStopped = true;
        timer = time;
    }
}
