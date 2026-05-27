using UnityEngine;


public class FallTrap : MonoBehaviour
{
    [SerializeField] private Transform ground;   
    [SerializeField] private float delay = 0.1f; 
    [SerializeField] private float fallSpeed = 5f;    
    [SerializeField] private float hideDelay = 0.2f;  
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



}
