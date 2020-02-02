using UnityEngine;
namespace GGJ2020
{
    public class KeyFragmentSpawn : MonoBehaviour
    {
        //[SerializeField] private GameObject KeyFragment;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Bullet")
            {
                //Instantiate(KeyFragment, transform.position, transform.rotation);
                PrincessInventory.keyFragments += 1;
                print("Got a keyFrag");
            }
        }
    }
}
