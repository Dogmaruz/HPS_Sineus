using UnityEngine;
using Zenject;

public class KillZoneController : MonoBehaviour
{
    [SerializeField] private int m_damage = 1;
    [SerializeField] private float m_hitRate = 1;
    private PlayerHP _playerHP;
    private bool _isInZone;

    private float _timer;

    [Inject]
    public void Construct(PlayerHP playerHP)
    {
        _playerHP = playerHP;
    }

    private void Update()
    {
        if (_isInZone == true) return;

        _timer += Time.deltaTime;

        if (_timer >= m_hitRate)
        {
            _playerHP.RemoveHealth(m_damage);
            _timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var killZone = other.transform.GetComponent<KillZone>();

        if (killZone != null)
        {
            _isInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var killZone = other.transform.GetComponent<KillZone>();

        if (killZone != null)
        {
            _isInZone = false;
        }
    }
}
