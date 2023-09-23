using UnityEngine;
using Zenject;

public class KillZone : MonoBehaviour
{
    [SerializeField] private float m_contractionRate = 1;

    private LevelController _levelController;

    private Transform _transform;
    private Vector3 _startScale;

    private bool _isStopped = false;

    private float _timer;

    [Inject]
    public void Construct(LevelController levelController)
    {
        _levelController = levelController;
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _levelController.OnAllTrashCollected += DisableZone;
        _startScale = _transform.localScale;
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

        if (_transform.localScale.x < 1)
        {
            _isStopped = true;
            _transform.localScale = new Vector3(0, 0, 0);
        }

        if (_transform.localScale.x >= 0 && _isStopped == false)
        {
            float size = Time.deltaTime * m_contractionRate;
            _transform.localScale -= new Vector3(size, size, 0);
        }
    }

    public void StopMove(float time)
    {
        _isStopped = true;
        _timer = time;
    }

    private void DisableZone(bool _)
    {
        _transform.localScale = _startScale;

        StopMove(float.MaxValue);
    }
}