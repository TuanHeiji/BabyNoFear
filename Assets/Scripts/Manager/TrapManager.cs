//using UnityEngine;

//public class TrapManager : MonoBehaviour
//{
//    [SerializeField] private MovingNailTrap[] traps;

//    private int currentTrapIndex = 0;

//    private void Start()
//    {
//        foreach (MovingNailTrap trap in traps)
//        {
//            trap.OnTrapFinished += HandleTrapFinished;
//        }

//        traps[0].StartMoveTrap();
//    }

//    private void HandleTrapFinished(MovingNailTrap finishedTrap)
//    {
//        currentTrapIndex++;

//        if (currentTrapIndex >= traps.Length)
//        {
//            Debug.Log("Tất cả trap đã chạy xong");
//            return;
//        }

//        traps[currentTrapIndex].StartMoveTrap();
//    }

//    private void OnDestroy()
//    {
//        foreach (MovingNailTrap trap in traps)
//        {
//            trap.OnTrapFinished -= HandleTrapFinished;
//        }
//    }
//}