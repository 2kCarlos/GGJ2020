using UnityEngine;

namespace GGJ2020
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private int moveSpeed;
        private void Update()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}

