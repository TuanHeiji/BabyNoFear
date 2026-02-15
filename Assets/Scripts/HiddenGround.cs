using UnityEngine;
using UnityEngine.Events;


public class HiddenGround : MonoBehaviour
{
    public UnityEvent onPlayerFall;

    private SpriteRenderer sr;
    private BoxCollider2D col;

    private bool canExist = false;   // đã được phép kích hoạt chưa
    private bool revealed = false;   // đã hiện chưa

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();

        // Ẩn hoàn toàn lúc đầu
        sr.enabled = false;
        col.enabled = false;
    }

    // ===== GỌI KHI PLAYER RỚT XUỐNG GROUND DƯỚI =====
    public void AllowExist()
    {
        canExist = true;

        // bật collider trigger để bắt va chạm từ dưới
        col.enabled = true;
        col.isTrigger = true;

        
    }

    // ===== PLAYER NHẢY LÊN CHẠM =====
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canExist || revealed) return;
        if (!other.CompareTag("Player")) return;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        // CHỈ khi player đang bay lên
        if (rb.linearVelocity.y > 0)
        {
            Reveal();
        }
       
    }

    void Reveal()
    {
        revealed = true;

        // hiện ground
        sr.enabled = true;

        // biến trigger thành collider thật để chặn đầu
        col.isTrigger = false;
        onPlayerFall?.Invoke();
    }
}
