using UnityEngine;
using UnityEngine.Events;

public class MarkToFinishPoint : MonoBehaviour
{
    public UnityAction eventMarkBeacon;
    //private UnityEvent playerInZone;
    [SerializeField] private Transform player; // �������� ��� �� ���������� ������ ���� � ����� ��� ������, ������ ��� ����� ����� ������ � ��������� ����� ������
    [SerializeField] private GameObject beaconFinish;

    private bool isFinished;

    void Start()
    {
        beaconFinish.SetActive(false);
        //����������� �� ������� ���������� ����� ������    += StartFinishStage()
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            StartFinishStage();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.TryGetComponent(out Transform player))
        {
            isFinished = true; // �� ��� � ������ ������ ��������� ����. 
        }
    }


    private void OnDestroy()
    {
        //���������� �� ������� ���������� ����� ������
    }

    public void StartFinishStage()
    {
        beaconFinish.SetActive(true);
        eventMarkBeacon?.Invoke();
    }
}
