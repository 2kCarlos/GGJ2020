using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace GGJ2020
{
    public class PrincessStats : MonoBehaviour
    {
        public static bool allKeyFrags;

        [SerializeField] private AudioClip Hurtclip;
        [SerializeField] private AudioClip Pedestalclip;
        [SerializeField] private AudioClip Doorclip2;
        [SerializeField] private AudioSource source;
        //[SerializeField] private 
        [SerializeField] private int damage;
        [SerializeField] private GameObject[] keyFrags;
        //[SerializeField] private GameRuntime gameRuntime;
        bool contact;
        
        int num = 0;

        private void Start()
        {
            //ILevelSystem levelSys = gameRuntime.Locator.Resolve<ILevelSystem>();
            //levelSys.OnLevelChanged.RegisterListener()
            keyFrags = GameObject.FindGameObjectsWithTag("KeyFrags");
            for(int i = 0; i < keyFrags.Length; i++)
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
            //keyFrags = GameObject.FindGameObjectsWithTag("KeyFrags");
            
            print(keyFrags.Length);
            if (keyFrags[0] != null && keyFrags[1] != null && keyFrags[2] != null)
            {
                if (keyFrags[0].activeInHierarchy && keyFrags[1].activeInHierarchy && keyFrags[2].activeInHierarchy)
                {
                    print("All active in Hierarchy!");
                    allKeyFrags = true;

                }
                else
                {
                    //Start();
                    allKeyFrags = false;
                }
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Knight")
            {
                Debug.Log("Hit by the knight!");
                AudioSource.PlayClipAtPoint(Hurtclip, transform.position);
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
                    AudioSource.PlayClipAtPoint(Pedestalclip, transform.position);
                    if(num == 3)
                    {
                        print("Resetting num! ");
                        num = 0;
                    }
                    PrincessInventory.keyFragments -= 1;
                }

            }
        }
        public void Restart()
        {
            if (SceneManager.GetActiveScene().isLoaded)
            {
                print("It has been loaded! Restart!!");
                keyFrags = GameObject.FindGameObjectsWithTag("KeyFrags");
                for (int i = 0; i < keyFrags.Length; i++)
                {
                    keyFrags[i].SetActive(false);
                }
            }
        }

        #region Public Inspector Methods
        public void InspectorRestart()
        {
            AudioSource.PlayClipAtPoint(Hurtclip, transform.position);
            Restart();
        }
        #endregion

    }
}
