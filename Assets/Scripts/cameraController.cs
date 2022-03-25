using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    public Transform Obstruction;

    float zoomSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Obstruction = target;
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset;
       // ViewObstructed();
    }
    // this monster detects objects that collide with the camera and then blinks them out until the camera moves outa there veiw... i think 
    // its really complicated and i had to use a tutorial for this. Its two camera scripts frankenstiened together
    void ViewObstructed()
    {
        RaycastHit hit;
        Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        if (Physics.Raycast(transform.position, target.position - transform.position, out hit, 4.5f))
        {

            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);

                }
            }
            else
            {
                Obstruction.gameObject.GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, target.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }

            }

        }

    }
}