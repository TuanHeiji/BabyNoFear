using UnityEngine;


public class FallTrap : MonoBehaviour
{
    [SerializeField] private Transform ground;   // Platform thật sự trong game
    [SerializeField] private float delay = 0.1f; // Delay trước khi trap chạy
    [SerializeField] private float fallSpeed = 5f;    // Tốc độ rơi
    [SerializeField] private float hideDelay = 0.5f;  // Thời gian chờ trước khi biến mất
    [SerializeField] private Transform posA; 

    private bool activated = false;


   
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (!activated) return;
        fallTrap();
    }

    // ================= KHI PLAYER CHẠM TRIGGER =================
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Chỉ kích hoạt nếu là Player và trap chưa chạy
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            Invoke(nameof(fallTrap), delay);
        }
    }

    // ================= FALL TRAP =================
    private void fallTrap()
    {
        if (activated)
        {
        ground.position = Vector3.MoveTowards(
                ground.position,
                posA.position,
                fallSpeed * Time.deltaTime
            );
        
        HideGround();

        }
         
    }
    
    // ================= FALL LOGIC =================
     
    private void HideGround()
    {
        Collider2D col = ground.GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = false;
        }

        Destroy(ground.gameObject, hideDelay);
    }

    //// ================= PLAYER ĐỨNG TRÊN GROUND =================
    // Chỉ áp dụng cho Move trap (platform di chuyển)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            // Gán player làm con của ground
            collision.transform.SetParent(ground);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            // Khi rời ground thì bỏ parent
            collision.transform.SetParent(null);
        }
    }

}
