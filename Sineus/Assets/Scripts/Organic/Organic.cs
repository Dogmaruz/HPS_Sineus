using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Organic : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_organicPrafabes;

    [SerializeField] private Transform m_parentTransform;

    [SerializeField] private GameObject m_ImpactEffect;

    private SphereCollider _sphereCollider;

    private IEntityFactory _factory;

    [Inject]
    public void Construct(IEntityFactory entityFactory)
    {
        _factory = entityFactory;
    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();

        var rnd = Random.Range(0, m_organicPrafabes.Count);

        _factory.Create(m_organicPrafabes[rnd], transform.position, Quaternion.identity, m_parentTransform);
    }

    private void OnTriggerEnter(Collider other)
    {
        var killZone = other.transform.root.GetComponent<KillZone>();

        if (killZone != null)
        {
            _sphereCollider.enabled = false;

            killZone.StopMove();

            if (m_ImpactEffect != null)
            {
                _factory.Create(m_ImpactEffect, transform.position, Quaternion.identity, null);
            }
        }
    }
}
