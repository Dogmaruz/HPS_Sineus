using UnityEngine;
using UnityEngine.Events;

public class MarkToFinishPoint : MonoBehaviour
{
    public UnityAction eventMarkBeacon;
    //private UnityEvent playerInZone;
    [SerializeField] private Transform player; // Получаем как то трансформу нашего жука а лучше его скрипт, смотря кто будет евент делать о финальном этапе забега
    [SerializeField] private GameObject beaconFinish;

    private bool isFinished;

    void Start()
    {
        beaconFinish.SetActive(false);
        //Подписаться на событие завершения сбора мусора    += StartFinishStage()
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
            isFinished = true; // Ну или в скрипт плаера отправить инфу. 
        }
    }


    private void OnDestroy()
    {
        //Отписаться на событие завершения сбора мусора
    }

    public void StartFinishStage()
    {
        beaconFinish.SetActive(true);
        eventMarkBeacon?.Invoke();
    }
}
