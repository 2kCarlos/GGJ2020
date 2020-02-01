using UnityEngine;
namespace GGJ2020
{
    public class KnightMovement : MonoBehaviour
    {
        GameObject Player;
        void Start()
        {
            Player = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(Player.transform);

        }
        
    }
}
