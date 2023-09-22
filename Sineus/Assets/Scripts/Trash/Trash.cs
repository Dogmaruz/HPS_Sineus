using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Trash : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_trashPrafabes;

    [SerializeField] private GameObject m_organicPrafabe;

    [SerializeField] private Transform m_parentTransform;

    private SphereCollider _sphereCollider;

    [Inject]
    public void Construct()
    {
        
    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();

        var rnd = Random.Range(0, m_trashPrafabes.Count);

        Instantiate(m_trashPrafabes[rnd], transform.position, Quaternion.identity, m_parentTransform);
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.attachedRigidbody.GetComponent<CharacterMovement>();

        if (character != null)
        {
            _sphereCollider.enabled = false;

            Instantiate(m_organicPrafabe, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
