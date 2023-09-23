using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Beacon : MonoBehaviour
{
    [SerializeField] private MarkToFinishPoint finishPoint;
    [SerializeField] private bool isFinishStage;
    [SerializeField] private float leftAngle = 40;
    [SerializeField] private float rightAngle = -40;

    [SerializeField] private Image leftArrow;
    [SerializeField] private Image rightArrow;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private float angle;

    private Timer timer;
    [SerializeField] private float timeDurationOfFinish;
    void Start()
    {
        finishPoint.eventMarkBeacon += StartFinishStage;
    }

    void Update()
    {

        if (isFinishStage == true)
            MarkBeacon();
    }

    private void OnDestroy()
    {
        finishPoint.eventMarkBeacon -= StartFinishStage;
    }

    private void MarkBeacon()
    {
        Vector3 targetDir = finishPoint.transform.position - transform.position;
        angle = Vector3.SignedAngle(targetDir, transform.forward,Vector3.up);
        if (angle > leftAngle)
        {
            leftArrow.enabled = true;
            rightArrow.enabled = false;
        }
        else if (angle < rightAngle)
        {
            leftArrow.enabled = false;
            rightArrow.enabled = true;
        }
        else 
        {
            leftArrow.enabled = false;
            rightArrow.enabled = false;
        }

        timerText.text = StringTime.SecondToTimeString(timer.CurrentTime);
        if (timer.CurrentTime < 20)
        {
            timerText.color = Color.red;
        }
    }

    private void StartFinishStage()
    {
        isFinishStage = true;
        timer = Timer.CreateTimer(timeDurationOfFinish, false);
        timer.OnTimeRanOut += TimeOver;
    }

    private void TimeOver()
    {
        isFinishStage = false;
        timer.OnTimeRanOut -= TimeOver;
    }
}
