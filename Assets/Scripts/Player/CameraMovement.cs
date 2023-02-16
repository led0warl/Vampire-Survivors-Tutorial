using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire.unrefactor
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] Vector3 offset;

        // Update is called once per frame
        void Update()
        {
            transform.position = target.position + offset;
        }
    }
}