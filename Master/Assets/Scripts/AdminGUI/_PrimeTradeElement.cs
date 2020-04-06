﻿using CoreGame;
using UnityEngine;
using UnityEngine.UI;

namespace AdminGUI
{
    //Parent Class, not to be used directly
    public abstract class _PrimeTradeElement : MonoBehaviour
    {
        public GameObject FirstChoice;
        
        [SerializeField] protected bool firstChoiceActive;
        
        protected PlayerController _playerController;

        protected virtual void Start()
        {
            GUIEvents.current.OnButtonHit += GUIButtonPressed;
        }

        protected abstract void GUIButtonPressed(Button button);
        
        protected void SetFirstChoiceActive()
        {
            LeanTween.moveLocalX(FirstChoice, 0, 0.5f).setEase(LeanTweenType.easeOutExpo).setEase(LeanTweenType.easeOutExpo);
            firstChoiceActive = true;
        }
        
        protected void SetFirstChoiceInactive()
        {
            LeanTween.moveLocalX(FirstChoice, 264, 0.5f).setEase(LeanTweenType.easeOutExpo).setEase(LeanTweenType.easeOutExpo);
            firstChoiceActive = false;
        }
    }
}