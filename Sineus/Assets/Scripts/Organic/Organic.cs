using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Organic : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_organicPrafabes;

    [SerializeField] private Transform m_parentTransform;

    [SerializeField] private ImpactEffect m_ImpactEffect;

    [SerializeField] private ShieldEffect m_ShieldEffect;

    [SerializeField] private float m_StopZoneTime = 1;

    private IEntityFactory _factory;

    [Inject]
    public void Construct(IEntityFactory entityFactory)
    {
        _factory = entityFactory;
    }

    private void Awake()
    {
        var rnd = Random.Range(0, m_organicPrafabes.Count);

        _factory.Create(m_organicPrafabes[rnd], transform.position, Quaternion.identity, m_parentTransform);

        if (m_ShieldEffect != null)
        {
            var shield = Instantiate(m_ShieldEffect, transform.position, Quaternion.identity);
            shield.SetLifeTime(m_StopZoneTime);
        }
    }
}
