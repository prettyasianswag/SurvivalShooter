using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 10.0f;
        public float rotationSpeed = 10.0f;
        public float jumpHeight = 2.0f;
        private bool isGrounded = false;
        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move(float h, float v, float mv, float mh)
        {
            Vector3 position = rigid.position;
            Quaternion rotation = rigid.rotation;
            Quaternion currentRotation = rigid.rotation;
            float camRotationLimit = 30f;
            float camRotationX = 0f;

            position += transform.forward * mv * movementSpeed * Time.deltaTime;
          
            rotation *= Quaternion.AngleAxis(rotationSpeed * h, Vector3.up);

            currentRotation *= Quaternion.AngleAxis(rotationSpeed * v, Vector3.left);
            currentRotation = Mathf.Clamp(currentRotation, -camRotationLimit, camRotationLimit);

            position += transform.right * mh * movementSpeed * Time.deltaTime;
            
            rigid.MovePosition(position);
            rigid.MoveRotation(rotation);
            rigid.MoveRotation(currentRotation);
        }

        public void Jump()
        {
            if (isGrounded)
            {
                rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        void OnCollisionEnter (Collision col)
        {
            isGrounded = true;
        }
    }
}

