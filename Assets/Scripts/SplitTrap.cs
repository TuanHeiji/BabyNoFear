using UnityEngine;

public class SplitTrap : MonoBehaviour
{
    // =========================
    // TRẠNG THÁI CỦA TRAP
    // =========================
    private enum TrapState
    {
        Idle,        // Chưa kích hoạt, đang hợp nhất
        Splitting,   // Đang tách ra
        Waiting,     // Đang chờ (player rơi / đi qua)
        Merging,     // Đang hợp lại
        Finished     // Đã xong, trở thành ground thường
    }

    private TrapState state = TrapState.Idle;

    // =========================
    // CÁC MẢNH TRAP
    // =========================
    [Header("Trap Parts")]
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;

    // =========================
    // VỊ TRÍ
    // =========================
    [Header("Positions")]
    [SerializeField] private Transform leftSplitPos;
    [SerializeField] private Transform rightSplitPos;

    private Vector3 leftOriginPos;
    private Vector3 rightOriginPos;

    // =========================
    // CÀI ĐẶT
    // =========================
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float waitTime = 0.6f;

    private float waitTimer;

    // =========================
    // COLLIDER
    // =========================
    private BoxCollider2D triggerCollider;

    void Awake()
    {
        // Lưu vị trí ban đầu (khi trap đang hợp nhất)
        leftOriginPos = leftPart.position;
        rightOriginPos = rightPart.position;

        // Lấy collider trigger ở trap cha
        triggerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        switch (state)
        {
            case TrapState.Splitting:
                SplitMove();
                break;

            case TrapState.Waiting:
                WaitBeforeMerge();
                break;

            case TrapState.Merging:
                MergeMove();
                break;
        }
    }

    // =========================
    // KHI PLAYER CHẠM TRIGGER
    // =========================
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (state != TrapState.Idle) return;

        state = TrapState.Splitting;
    }

    // =========================
    // TÁCH TRAP RA
    // =========================
    void SplitMove()
    {
        leftPart.position = Vector3.MoveTowards(
            leftPart.position,
            leftSplitPos.position,
            moveSpeed * Time.deltaTime
        );

        rightPart.position = Vector3.MoveTowards(
            rightPart.position,
            rightSplitPos.position,
            moveSpeed * Time.deltaTime
        );

        // Khi cả 2 mảnh đã đến vị trí tách
        if (Reached(leftPart.position, leftSplitPos.position) &&
            Reached(rightPart.position, rightSplitPos.position))
        {
            state = TrapState.Waiting;
            waitTimer = 0f;
        }
    }

    // =========================
    // ĐỢI MỘT CHÚT
    // =========================
    void WaitBeforeMerge()
    {
        waitTimer += Time.deltaTime;

        if (waitTimer >= waitTime)
        {
            state = TrapState.Merging;
        }
    }

    // =========================
    // HỢP TRAP LẠI
    // =========================
    void MergeMove()
    {
        leftPart.position = Vector3.MoveTowards(
            leftPart.position,
            leftOriginPos,
            moveSpeed * Time.deltaTime
        );

        rightPart.position = Vector3.MoveTowards(
            rightPart.position,
            rightOriginPos,
            moveSpeed * Time.deltaTime
        );

        // Khi đã hợp xong
        if (Reached(leftPart.position, leftOriginPos) &&
            Reached(rightPart.position, rightOriginPos))
        {
            FinishTrap();
        }
    }

    // =========================
    // KẾT THÚC TRAP
    // =========================
    void FinishTrap()
    {
        state = TrapState.Finished;

        // Tắt trigger → trap trở thành ground bình thường
        triggerCollider.isTrigger = false;

    }

    // =========================
    // HÀM HỖ TRỢ SO SÁNH VỊ TRÍ
    // =========================
    bool Reached(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b) < 0.01f;
    }
}
