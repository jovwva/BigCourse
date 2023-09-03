using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IHasProgress 
{
    public event EventHandler<OnProgressChangedEventErgs> OnProgressChanged;
    public class OnProgressChangedEventErgs : EventArgs
    {
        public float progressNormalized;
    }
}
