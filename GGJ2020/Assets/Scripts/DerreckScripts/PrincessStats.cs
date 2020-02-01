using UnityEngine;
namespace GGJ2020
{
    public class PrincessStats : MonoBehaviour
    {
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Knight")
            {
                Debug.Log("Hit by the knight!");
            }
        }
    }
}
