using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GGJ2020
{
    public class UIUpdate : MonoBehaviour
    {
        [SerializeField] private Text damage;
        //PrincessStats p = new PrincessStats();
        [SerializeField] PrincessStats princess;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            
            damage.text = "Damage: " + princess.Damage;
        }
    }
}
