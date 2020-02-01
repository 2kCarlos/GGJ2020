using UnityEngine;

namespace GGJ2020
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private int moveSpeed;
        [SerializeField] private ParticleSystem ps;
        Transform pos;
        
        private void Update()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            StartCoroutine(DestroyBullet());
        }
        System.Collections.IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Knight")
            {
                
                Destroy(collision.gameObject);
                Instantiate(ps, collision.transform.position, collision.transform.rotation);
                
                Destroy(gameObject);
            }
        }
    }
}

