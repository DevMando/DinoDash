using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Dino.Scripts
{
    internal class Player
    {
        public enum ANIMATION_STATES
        {
            Idle = 0,
            Walk = 1,
            FastRun = 2,
            Hurt = 3,
            Jump = 4
        };

        const float RUN_SPEED = 15f;
        const float NO_SPEED = 0f;
        const string ANIMATOR_STATE_PARAMETER_LABEL = "AnimationState";

        public GameObject dino { get; set; }
        public SpriteRenderer spriteRenderer { get; set; }
        public Animator animator { get; set; }
        public Rigidbody2D rigidBody { get; set; }

        public Player(GameObject dinoGameObject) 
        {
            // Get GameObject Components.
            dino = dinoGameObject;
            spriteRenderer = dino.GetComponent<SpriteRenderer>();
            animator = dino.GetComponent<Animator>();
            rigidBody = dino.GetComponent<Rigidbody2D>();

            // Set Initial Animation State.
            UpdateAnimationState(ANIMATION_STATES.Idle);
        }

        public void UpdateAnimationState(ANIMATION_STATES animationState)
        {
            animator.SetInteger(ANIMATOR_STATE_PARAMETER_LABEL, (int)animationState);
            Move(animationState);
        }

        public void Move(ANIMATION_STATES animationState)
        {
            switch(animationState)
            {
                case ANIMATION_STATES.FastRun: FastRun(); 
                    break;
                default: DescendRun();
                    break;
            }
        }

        protected void FastRun()
        {
            rigidBody.AddForce(new Vector2(RUN_SPEED, NO_SPEED));
        }

        protected void DescendRun()
        {
            rigidBody.AddForce(new Vector2(-(RUN_SPEED / 2), NO_SPEED));
        } 

    }
}
