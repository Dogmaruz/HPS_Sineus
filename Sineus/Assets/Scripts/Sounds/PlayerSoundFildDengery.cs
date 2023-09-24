using UnityEngine;
using Zenject;

public class PlayerSoundFildDengery : MonoBehaviour
{
    [SerializeField] private AudioClip _clipPlayerFieldDanger;

    [SerializeField] private float m_volume = 1;

    [SerializeField] private float distSoundFieldDanger;

   [SerializeField] private KillZoneController m_controllerKillZone;
    
    private KillZone _killZone;

    private BackgroundSoundPlayer _soundPlayer;

    [Inject]
    public void Construct(BackgroundSoundPlayer soundPlayer, KillZone killZone)
    {
        _soundPlayer = soundPlayer;
        _killZone = killZone;
    }

    private void Update()
    {
        OnSoundPlay();
    }

    private void OnSoundPlay()
    {

        m_controllerKillZone.GetKillZone();
        if (m_controllerKillZone != null)
        {
           var colliderMesh = _killZone.GetComponent<CapsuleCollider>();

             
            var size = colliderMesh.bounds.center;
            var distR = Vector3.Distance(_killZone.radiusPoint.transform.position, size);
            //print(Vector3.Distance(transform.position, size));
            print(distR);
            var asdf = distR - distSoundFieldDanger;
            print(asdf);
            if (Vector3.Distance(transform.position, size) > distR - distSoundFieldDanger)
            {
                _soundPlayer.Play(_clipPlayerFieldDanger, m_volume);
               print("Yeaap");
            }           
        }
        if (m_controllerKillZone.IsInZone == false)
        {
            _soundPlayer.Play(_clipPlayerFieldDanger, m_volume);
            print(_soundPlayer);
        } else
            _soundPlayer.Stop();


    }
}
