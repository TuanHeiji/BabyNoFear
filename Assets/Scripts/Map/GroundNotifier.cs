using UnityEngine;

public class GroundNotifier : MonoBehaviour
{
    [SerializeField] private HiddenGround[] hiddenBlocks;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        
        foreach (var block in hiddenBlocks)
        {
            if (block != null)
            {
                block.AllowExist();
            }
        }
    }
}