using UnityEngine;
using UnityEngine.UI;
namespace GGJ2020
{
    public class PrincessStats : MonoBehaviour
    {
        [SerializeField] private int damage;

        public int Damage
        {
            get
            {
                return damage;
            }
            
            set
            {
                damage = value;
            }
        }
        
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Knight")
            {
                Debug.Log("Hit by the knight!");
                Damage += 1; 
            }
        }
    }
}
