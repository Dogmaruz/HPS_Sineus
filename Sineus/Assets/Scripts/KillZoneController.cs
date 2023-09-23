using UnityEngine;
using Zenject;

public class KillZoneController : MonoBehaviour
{
    private PlayerHP _playerHP;

    [Inject]
    public void Construct(PlayerHP playerHP)
    {
        _playerHP = playerHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        var killZone = other.transform.GetComponent<KillZone>();

        if (killZone != null)
        {
            _playerHP.RemoveHealth(killZone.Damage);
        }
    }
}
