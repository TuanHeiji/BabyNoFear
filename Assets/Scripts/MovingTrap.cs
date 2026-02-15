using UnityEngine;
using static TrapGround;

public class MovingTrap : MonoBehaviour
{
    [SerializeField] private Transform ground;   // Platform thật sự
    [SerializeField] private float delay = 0.1f; // Delay trước khi trap chạy
    private bool activated = false;

    [SerializeField] private Transform posA;      // Vị trí ban đầu
    [SerializeField] private Transform posB;      // Vị trí đích
    [SerializeField] public float speed = 25f;   // Tốc độ di chuyển
    void Start()
    {
        ground.position = posA.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated) return;
        movingTrap();
    }

    // ================= KHI PLAYER CHẠM TRIGGER =================
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Chỉ kích hoạt nếu là Player và trap chưa chạy
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            Invoke(nameof(movingTrap), delay);
        }
    }

    private void movingTrap()
    {
        ground.position = Vector3.MoveTowards(
                ground.position,
                posB.position,
                speed * Time.deltaTime
            );

        if (Vector3.Distance(ground.position, posB.position) < 0.01f)
        {
            activated = false;     // Ngừng trap
            OnTrapFinished();
        }
    }

    void OnTrapFinished()
    {
        Collider2D col = ground.GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = false;
        }

    }
}
