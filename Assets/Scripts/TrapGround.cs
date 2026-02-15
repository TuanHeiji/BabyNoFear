using UnityEngine;

public class TrapGround : MonoBehaviour
{
    // ================= ENUM XÁC ĐỊNH LOẠI TRAP =================
    public enum TrapType
    {
        Moving,    // Ground di chuyển từ posA sang posB
        FallAndHide    // Ground rớt xuống rồi biến mất
        
    }

    [Header("Trap Type")]
    public TrapType trapType;

    // ================= THIẾT LẬP CHUNG =================
    [Header("Common")]
    [SerializeField] private Transform ground;   // Platform thật sự
    [SerializeField] private float delay = 0.1f; // Delay trước khi trap chạy

    private bool activated = false;               // Trap chỉ kích hoạt 1 lần

    // ================= MOVE TRAP =================
    [Header("Move Settings")]
    [SerializeField] private Transform posA;      // Vị trí ban đầu
    [SerializeField] private Transform posB;      // Vị trí đích
    [SerializeField] public float speed = 25f;   // Tốc độ di chuyển
    

    // ================= FALL TRAP =================
    [Header("Fall Settings")]
    [SerializeField] private float fallSpeed = 3f;    // Tốc độ rơi
    [SerializeField] private float hideDelay = 0.2f;  // Thời gian chờ trước khi biến mất

    private bool isFalling = false;                // Cờ rơi cho Fall trap

    // ================= START =================
    void Start()
    {
        // Đảm bảo ground bắt đầu ở posA (rõ ràng, tránh lệch vị trí)
        if (trapType == TrapType.Moving && posA != null)
        {
            ground.position = posA.position;
        }
    }

    // ================= KHI PLAYER CHẠM TRIGGER =================
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Chỉ kích hoạt nếu là Player và trap chưa chạy
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            Invoke(nameof(ActivateTrap), delay);
        }
    }

    // ================= KÍCH HOẠT TRAP =================
    void ActivateTrap()
    {
        switch (trapType)
        {
            case TrapType.Moving:
                break;

            case TrapType.FallAndHide:
                StartFalling();
                break;
        }
    }

    // ================= UPDATE =================
    void Update()
    {
        if (!activated) return;

        // ===== MOVE TRAP =====
        if (trapType == TrapType.Moving)
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

        // ===== FALL TRAP =====
        if (trapType == TrapType.FallAndHide && isFalling)
        {
            ground.position += Vector3.down * fallSpeed * Time.deltaTime;
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

    // ================= FALL LOGIC =================
    void StartFalling()
    {
        isFalling = true;

        // Sau một khoảng thời gian thì biến mất
        Invoke(nameof(HideGround), hideDelay);
    }

    void HideGround()
    {
        // Tắt collider trước để player không đứng được nữa
        Collider2D col = ground.GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        // Ẩn ground
        ground.gameObject.SetActive(false);
    }

    //// ================= PLAYER ĐỨNG TRÊN GROUND =================
    //// Chỉ áp dụng cho Move trap (platform di chuyển)
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (trapType != TrapType.MoveToPosB) return;

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // Gán player làm con của ground
    //        collision.transform.SetParent(ground);
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (trapType != TrapType.MoveToPosB) return;

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // Khi rời ground thì bỏ parent
    //        collision.transform.SetParent(null);
    //    }
    //}
}
