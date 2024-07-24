using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Dino.Scripts
{
    internal static class UserInput
    {
        public static Player.ANIMATION_STATES GetAnimationState()
        {
            return GetKeyboardInput();
        }

        private static Player.ANIMATION_STATES GetKeyboardInput()
        {
            if (Input.GetKey(KeyCode.D))
            {
                return Player.ANIMATION_STATES.FastRun;
            }
            else
            {
                return Player.ANIMATION_STATES.Walk;
            }
        }
    }
}
