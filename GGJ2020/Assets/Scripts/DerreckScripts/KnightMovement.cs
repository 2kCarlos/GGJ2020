using UnityEngine;
namespace GGJ2020
{
    public class KnightMovement : MonoBehaviour
    {
        [SerializeField] private int movementSpeed;

        GameObject Player;
        void Start()
        {
            Player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(Player.transform);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        
    }
}
