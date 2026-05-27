using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeDestoy = 1f;

    private Rigidbody2D rb;

    private int direction = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, 0f);

        // Lật hình viên đạn theo hướng bay
        transform.localScale = new Vector3(direction, 1, 1);

        Destroy(gameObject, timeDestoy);
    }

    public void SetDirection(int dir)
    {
        direction = dir;
    }
}
