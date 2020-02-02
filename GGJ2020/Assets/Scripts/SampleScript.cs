using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GGJ2020 {
	public class SampleScript : MonoBehaviour {

        delegate int incrInt(int j);
        //delegate int Plle();
		private void Start()
		{
            #region LamdaOp
            int[] a = { 1, 2, 3, 4 };
            
            //int doubleTheInt = 
            //var square = numbers.Select(x => x * x);

            #endregion
        }
        private string returnThis(string message)
        {
            return message;
        }
    }
}