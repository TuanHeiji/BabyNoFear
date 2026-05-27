using System;
using UnityEngine;

public class MovingNailTrap : MonoBehaviour
{
    [SerializeField] private Transform trap;
    [SerializeField] private GameObject check;

    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;

    [SerializeField] private float speed = 25f;

    private Collider2D col;

    private bool Activated = false;
    private bool isRunning = false;

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
        if (isRunning)
        {
            MoveTrap();
        }
    }

    private void PrepTrap()
    {
        if (col != null)
        {
            col.enabled = false;
            col.isTrigger = false;
        }

        Debug.Log("Ban đầu đã tắt collider check");
    }

    public void SetActivated(bool value)
    {
        Activated = value;
        if (Activated)
        {
            col.enabled = true;
            col.isTrigger = true;
            Debug.Log("Đã bật collider check, chờ Player chạm");
        }
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
        isRunning = true;
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
            isRunning = false; 
            Activated = false;
            col.enabled = false;
            col.isTrigger = false;
            
        }    
    }
}