using UnityEngine;


public class GroundNotifier : MonoBehaviour
{
    [Header("Hidden Blocks Above")]
    [SerializeField] private HiddenGround[] hiddenBlocks;

    
       // 🔥 event khi player rớt xuống

    private bool triggered = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        triggered = true;

        // Cho phép hidden block hoạt động
        foreach (var block in hiddenBlocks)
        {
            block.AllowExist();
        }

    }
}
