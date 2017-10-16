using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    [RequireComponent(typeof(Player))]
    public class LocalUser : MonoBehaviour
    {
        private Player player;

        // Use this for initialization
        void Start()
        {
            player = GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");
            float mv = Input.GetAxis("Vertical");
            float mh = Input.GetAxis("Horizontal");
            player.Move(h, v, mv, mh);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Jump();
            }
        }
    }
}