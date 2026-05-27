using UnityEngine;

public class MovingNailTrap3 : MonoBehaviour
{
    [SerializeField] private Transform trap;
    [SerializeField] private GameObject check;

    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;

    [SerializeField] private float speed = 25f;

    private Collider2D col;

    private bool Activated = false;
  

    private void Awake()
    {
        col = check.GetComponent<Collider2D>();
    }

    private void Start()
    {
        trap.position = posA.position;
        PrepTrap();
    }

    private void Update()
    {
        if (Activated)
        {
            MoveTrap();
        }
    }

    private void PrepTrap()
    {
        if (col != null)
        {
            col.enabled = true;
            col.isTrigger = true;
        }

        Debug.Log("Ban đầu bật collider check");
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player đã chạm check, trap chuẩn bị chạy");
            Invoke(nameof(StartMoveTrap), 0.1f);
        }
    }

    public void StartMoveTrap()
    {
        Activated = true;
    }

    private void MoveTrap()
    {
        trap.position = Vector3.MoveTowards(
            trap.position,
            posB.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(trap.position, posB.position) < 0.01f)
        {
            Activated = false;
            col.enabled = false;
            col.isTrigger = false;

        }
    }
}
