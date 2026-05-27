using UnityEngine;

public class Oto : MonoBehaviour
{
    [SerializeField] private Transform oto;

    [SerializeField] private Transform posA;   // Điểm xuất phát
    [SerializeField] private Transform posB;   // Điểm kết thúc

    [SerializeField] private float speed = 5f;

    private bool active = false;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Start()
    {
        // Đặt oto về vị trí ban đầu và ĐỨNG YÊN
        oto.position = posA.position;
    }

    public void ActivateCar()
    {
        active = true;
        audioManager.PlayCarSound();
    }

    void Update()
    {
        if (!active) return;   // ⛔ chưa kích hoạt thì khỏi chạy
        MoveCar();
    }

    private void MoveCar()
    {
        oto.position = Vector3.MoveTowards(
            oto.position,
            posB.position,
            speed * Time.deltaTime
        );
    }
}
