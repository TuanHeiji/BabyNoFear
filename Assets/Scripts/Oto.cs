using UnityEngine;

public class Oto : MonoBehaviour
{
    [SerializeField] private Transform oto;

    [Header("Move Points")]
    [SerializeField] private Transform posA;   // Điểm xuất phát
    [SerializeField] private Transform posB;   // Điểm kết thúc

    [Header("Settings")]
    [SerializeField] private float speed = 5f;

    private bool active = false;

    void Start()
    {
        // Đặt oto về vị trí ban đầu và ĐỨNG YÊN
        oto.position = posA.position;
    }

    // Được gọi từ GroundNotifier (UnityEvent)
    public void ActivateCar()
    {
        active = true;
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
