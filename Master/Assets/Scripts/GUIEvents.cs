﻿using System;
using System.Security.Cryptography;
using CoreGame;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// ReSharper disable UseNullPropagation

namespace AdminGUI
{
    public class GUIEvents : MonoBehaviour
    {
        public static GUIEvents current;

        private PlayerTags _currentChosenPlayerTag;
        
        private void Awake()
        {
            current = this;
        }

        public event Action<Button> OnButtonHit;
        public event Action<PlayerTags> onPlayerChange;
        public event Action<Button, TradeActions, Direction> OnTradeAction;
        public event Action OnManualOverride;
        public event Action OnGameStart;
        
        /*
         * GAME BUTTONS
         */
        //Start game
        public void StartGame()
        {
            GameHandler.current.StartGame();
            if (OnGameStart != null) OnGameStart();
        }

        public void BtnHit(Button b)
        {
            NotifyButtonHit(b);
        }

        public void SetGameTag(PlayerTags playerTag)
        {
            _currentChosenPlayerTag = playerTag;
        }
        
        /*
         * ADMIN GUI BUTTONS
         */
        //Manual Control Button
        public void OnManualControl()
        {
            OnPlayerChange();
            ManualEnabledNotify();
        }
        
        //Notify Methods
        public void TradeActionNotify(Button b, TradeActions action, Direction counterOffer)
        {
            if (OnTradeAction != null) OnTradeAction(b, action, counterOffer);
        }

        private void ManualEnabledNotify()
        {
            if (OnManualOverride != null) OnManualOverride();
        }

        private void NotifyButtonHit()
        {
            GameObject go = new GameObject("FakeGameObject");
            Button b = go.AddComponent<Button>();
            
            Destroy(go,1);
            
            NotifyButtonHit(b);
        }
        private void NotifyButtonHit(Button button)
        {
            if (OnButtonHit != null) OnButtonHit(button);
        }

        private void OnPlayerChange()
        {
            if (onPlayerChange != null) onPlayerChange(_currentChosenPlayerTag);
        }
    }
}