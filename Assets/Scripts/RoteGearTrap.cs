using UnityEngine;

public class RoteGearTrap : MonoBehaviour
{
    [SerializeField] public float rotateSpeed = 180f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        roteGearTrap();
    }

    private void roteGearTrap()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
