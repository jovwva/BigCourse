using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveWarningUI : MonoBehaviour
{
    private Animator animator;
    private const string BOOL_KEY = "IsFlashing";
    [SerializeField] private StoveCounter stoveCounter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    
        animator.SetBool(BOOL_KEY, false);
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventErgs e)
    {
        float burnShowProgress = 0.5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgress;
    
        animator.SetBool(BOOL_KEY, show);
    }
}
