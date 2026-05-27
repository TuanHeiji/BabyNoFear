using UnityEngine;
using UnityEngine.Events;

public class HiddenGround : MonoBehaviour
{
    public UnityEvent onPlayerFall;

    private Collider2D col;
    private SpriteRenderer sr;
    private Rigidbody2D playerRb;

    private bool canAppear = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        col.enabled = false; 
        sr.enabled = false;
    }

    public void AllowExist()
    {
        canAppear = true;
        col.enabled = true;
        col.isTrigger = true; // cho player xuyên lên
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canAppear) return;
        if (!other.CompareTag("Player")) return;

        playerRb = other.GetComponent<Rigidbody2D>();

        if (playerRb != null && playerRb.linearVelocity.y > 0)
        {
           
            sr.enabled = true;
            col.isTrigger = false; // bật collision lại để đứng lên được
            onPlayerFall?.Invoke();
        }
    }
}