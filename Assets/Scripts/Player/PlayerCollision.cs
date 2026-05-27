using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            audioManager.PlayGameOverSound();
            gameManager.GameOver();
        }

        else if (collision.CompareTag("Key"))
        {
            audioManager.PlayGameWinSound();
            gameManager.GameWin();
        }

    }


}
