using UnityEngine;
using UnityEngine.UI;
namespace GGJ2020
{
    public class PrincessStats : MonoBehaviour
    {
        [SerializeField] private int damage;
        GameObject[] keyFrags;
        bool contact;
        int num = 0;

        private void Start()
        {
            keyFrags = GameObject.FindGameObjectsWithTag("KeyFrags");
            for(int i = 0; i< keyFrags.Length; i++)
            {
                keyFrags[i].SetActive(false);
            }
        }
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
            

            if(collision.gameObject.tag == "Pedestal")
            {
                contact = true;
                //OnFire();
            }
            else
            {
                contact = false;
            }
        }
        //Using input system
        private void OnFire()
        {
            if(contact)
            {
                print("Collided with the pedestal and pressed fire button.");
                if(PrincessInventory.keyFragments >= 1)
                {
                    print("placing a keyFrag");
                    num++;
                    for(int i = 0; i< num; i++)
                    {
                        keyFrags[i].SetActive(true);
                    }
                    PrincessInventory.keyFragments -= 1;
                }

            }
        }
    }
}
