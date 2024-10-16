using System.Collections;
using System.Collections.Generic;
using Cf.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using Auc.InputAct;
    
namespace Auc.Net
{
    public class NetPlayer : Cf.Net.NetPlayer
    {
        private bool _isPressed;
        
        private AucInputModule _module;
    
        private void Awake()
        {
            _module = new AucInputModule();
            _module.Player.Enable();
        }

        private void OnEnable()
        {
            _module.Player.Move.performed += MoveOnPerformed;
        }

        private void OnDisable()
        {
            _module.Player.Move.performed -= MoveOnPerformed;
        }

        private void MoveOnPerformed(InputAction.CallbackContext context)
        {
            _isPressed = context.ReadValue<float>() > 0;
        }
    }
}
