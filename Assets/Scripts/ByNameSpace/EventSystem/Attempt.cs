using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OpenWorld.EventSystem
{
    public class Attempt
    {
        Func<bool> Tryer;
        public UnityEvent AttemptSucceeded = new UnityEvent();

        public bool Try()
        {
            bool canTry = Tryer != null && Tryer();
            if (canTry)
                AttemptSucceeded.Invoke();
            return canTry;
        }

        public void SetTryer(Func<bool> tryer)
        {
            Tryer = tryer;
        }
        
        public void AddListener(UnityAction listener)
        {
            AttemptSucceeded.AddListener(listener);
        }

        public void RemoveListener(UnityAction listener)
        {
            AttemptSucceeded.RemoveListener(listener);
        }
    }
}
