﻿using CoreGame;
using UnityEngine.UI;

namespace AdminGUI
{
    public class OutgoingTradeElement : _PrimeTradeElement
    {
        
        protected override void GUIButtonPressed(string key)
        {
            if (key.Equals(name))
            {
                if (!firstChoiceActive) 
                {
                       SetFirstChoiceActive();
                }
                else
                {
                    SetFirstChoiceInactive();
                }
            }else if (key.Equals("CancelBtn"))
            {
                if (firstChoiceActive)
                {
                    GUIEvents.current.TradeActionNotify(gameObject.GetComponent<Button>(),TradeActions.TradeCanceled,Direction.Blank);
                }
            }
            else
            {
                SetFirstChoiceInactive();
            }
        }
    }
}