using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

namespace Networking
{
    [RequireComponent(typeof(Player))]
    public class NetworkUser : NetworkBehaviour
    {
        public Camera cam;
        public AudioListener aListener;
        private Player player;

        // Use this for initialization
        void Start()
        {
            player = GetComponent<Player>();
            if (!isLocalPlayer)
            {
                cam.enabled = false;
                aListener.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Check if current client has authority over this player
            if (isLocalPlayer)
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
}
