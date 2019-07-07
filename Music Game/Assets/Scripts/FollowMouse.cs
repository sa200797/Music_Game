
// =================================	
// Namespaces.
// =================================

using System.Collections;
using UnityEngine;

// =================================	
// Define namespace.
// =================================



            // =================================	
            // Classes.
            // =================================

            //[ExecuteInEditMode]
            [System.Serializable]

            //[RequireComponent(typeof(TrailRenderer))]

            public  class FollowMouse : MonoBehaviour
            {
                // =================================	
                // Nested classes and structures.
                // =================================

                // ...

                // =================================	
                // Variables.
                // =================================

                // ...

                public float speed = 8.0f;
                public float distanceFromCamera = 5.0f;

                //private FollowMouse followMouse;

                // =================================	
                // Functions.
                // =================================

                // ...

                void Awake()
                {

                }

                // ...

                void Start()
                {
                    //followMouse = GetComponent<FollowMouse>();
                }

                // ...

                void Update()
                {

                  StartCoroutine(WaitandPlay());
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.8f,7.0f), Mathf.Clamp(transform.position.y, -3.8f, 3.8f), transform.position.z);
        }



                // ...
                IEnumerator WaitandPlay()
                {
                    yield return new  WaitForSeconds(2);
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = distanceFromCamera;

                    Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

                    Vector3 position = Vector3.Lerp(transform.position, mouseScreenToWorld, 1.0f - Mathf.Exp(-speed * Time.deltaTime));

                    transform.position = position;
                }

                

                void LateUpdate()
                {

                }

    





        // =================================	
        // End functions.
        // =================================

    }

            // =================================	
            // End namespace.
            // =================================


// =================================	
// --END-- //
// =================================
