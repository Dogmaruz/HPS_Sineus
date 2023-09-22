using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Trash : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_trashPrafabes;

    [SerializeField] private GameObject m_organicPrafabe;

    [SerializeField] private Transform m_parentTransform;

    private SphereCollider _sphereCollider;

    private IEntityFactory _factory;

    private GameManager _gameManager;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager)
    {
        _factory = entityFactory;

        _gameManager = gameManager;
    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();

        var rnd = Random.Range(0, m_trashPrafabes.Count);

        _factory.Create(m_trashPrafabes[rnd], transform.position, Quaternion.identity, m_parentTransform);
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.transform.root.GetComponent<CharacterMovement>();

        if (character != null)
        {
            _sphereCollider.enabled = false;

            _gameManager.ReworkedTrash();

            _factory.Create(m_organicPrafabe, transform.position, Quaternion.identity, null);

            Destroy(gameObject);
        }
    }
}
