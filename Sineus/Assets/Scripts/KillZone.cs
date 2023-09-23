using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private float m_ContractionRate = 1;

    [SerializeField] private int m_Damage;

    private Transform _transform;
    private bool _isStopped = false;

    private float _timer;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _isStopped = false;
        }

        if (_transform.localScale.x >= 0 && _isStopped == false)
        {
            float size = Time.deltaTime * m_ContractionRate;
            _transform.localScale -= new Vector3(size, size, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.transform.root.GetComponent<PlayerHP>();

        if (player != null)
        {
            player.RemoveHealth(m_Damage);
        }
    }

    public void StopMove(float time)
    {
        _isStopped = true;
        _timer = time;
    }
}