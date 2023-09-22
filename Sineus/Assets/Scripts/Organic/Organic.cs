using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Organic : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_organicPrafabes;

    [SerializeField] private Transform m_parentTransform;

    [SerializeField] private GameObject m_ImpactEffect;

    private SphereCollider _sphereCollider;

    [Inject]
    public void Construct()
    {

    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();

        var rnd = Random.Range(0, m_organicPrafabes.Count);

        Instantiate(m_organicPrafabes[rnd], transform.position, Quaternion.identity, m_parentTransform);
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
                Instantiate(m_ImpactEffect, transform.position, Quaternion.identity);
            }
        }
    }
}
