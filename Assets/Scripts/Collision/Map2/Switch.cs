using UnityEngine;
using static UnityEditor.Progress;

public class Switch : MonoBehaviour
{
    
    [SerializeField] private GameObject switch1;
    [SerializeField] private GameObject switch2;

    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;

    [SerializeField] private float delay = 0.2f;
    private bool activated = false;
    void Start()
    {
        switch2.SetActive(false);
        item2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated) return;
        AppearItem();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Bullet"))
        {
            activated = true;
            Invoke(nameof(AppearItem), delay);
            
        }
    }

    private void AppearItem()
    {
        activated = false;
        item2.SetActive(true);
        switch2.SetActive(true);

        item1.SetActive(false);
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
