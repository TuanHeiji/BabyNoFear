using UnityEditor.UIElements;
using UnityEngine;

public class AppearItem : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject safe;
    [SerializeField] private float delay = 0.2f;
    private bool activated = false;

    void Start()
    {
        item.SetActive(false);
        safe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated) return;
        Appear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            Invoke(nameof(Appear), delay);
            MovingNailTrap();
        }
    }

    private void Appear()
    {
        activated = false;
        item.SetActive(true);
        safe.SetActive(true);
        OnGroundFinished();
    }

    void OnGroundFinished()
    {
        Collider2D col = ground.GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = false;
        }
    }

    void MovingNailTrap()
    {
        MovingNailTrap movingNailTrap = FindAnyObjectByType<MovingNailTrap>();
        movingNailTrap.SetActivated(activated);
    }
}
