using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Dino.Scripts.Environment
{
    internal class Ground : MonoBehaviour
    {
        public GameObject scrollingObjectPrefab;  // The prefab to instantiate
        float speed = 7.0f;
        float resetPositionX = 20.0f;  // The X position to reset to (right side)
        float endPositionX = -30.0f;   // The X position at which to destroy the object (left side)

        private float objectWidth; // Width of the object
        private bool objectInstantiated = false;

        void Start()
        {
            // Calculate the width of the object
            BoxCollider2D renderer = GetComponent<BoxCollider2D>();

            if (renderer != null)
            {
                objectWidth = renderer.bounds.size.x;
            }
            else
            {
                // Default width if no boxCollider2D is found
                objectWidth = 1.0f;
            }
        }

        void Update()
        {
            // Move the object to the left
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Check if the object's left side is off the screen
            if (!objectInstantiated && (transform.position.x + objectWidth / 2)-10 < 10)
            {
                // Instantiate a new object at the reset position
                Instantiate(scrollingObjectPrefab, new Vector3(resetPositionX, transform.position.y, transform.position.z), Quaternion.identity);
                objectInstantiated = true;
            }

            // Check if the object has reached the end position
            if (transform.position.x < endPositionX)
            {
                // Destroy the current game object
                Destroy(gameObject);
            }
        }
    }
}
