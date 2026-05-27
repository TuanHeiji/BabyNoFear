using UnityEngine;

public class HiddenTrap : MonoBehaviour
{

    [SerializeField] private GameObject switch1;
    [SerializeField] private GameObject switch2;

    [SerializeField] private GameObject trap;

    [SerializeField] private float delay = 0.2f;
    private bool activated = false;
    void Start()
    {
        switch2.SetActive(false);
        trap.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated) return;
        Hidden();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Bullet"))
        {
            activated = true;
            Invoke(nameof(Hidden), delay);

        }
    }

    private void Hidden()
    {
        activated = false;
        trap.SetActive(false);
        switch2.SetActive(true);

        switch1.SetActive(false);
        OnGroundFinished();
    }

    void OnGroundFinished()
    {
        Collider2D col = switch1.GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = false;
        }
    }
}
