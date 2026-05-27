using UnityEngine;

public class RoteGearTrap : MonoBehaviour
{
   
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;

    [SerializeField] private float speed = 1f;
    [SerializeField] public float rotateSpeed = 180f;
 
    private Vector3 target;
    void Start()
    {
          target = posA.position;
    }

    void Update()
    {
        roteGearTrap();
        movingGearTrap();
    }

    private void roteGearTrap()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    private void movingGearTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == posA.position)
            {
                target = posB.position;
            }
            else
            {
                target = posA.position;
            }
        }
    }


}
