using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField]
    Transform holdPoint;

    GameObject Item;

    [SerializeField]
    float distance = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastChecking();
    }

    void RaycastChecking()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {

            GameObject clone = Instantiate(hit.collider.gameObject);
            if (Item == null)
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
                {
                    Item = hit.collider.gameObject;

                    clone.transform.SetPositionAndRotation(holdPoint.transform.position, holdPoint.transform.rotation);

                    clone.transform.SetParent(holdPoint);

                }

            }
            if (Item != null)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {

                    clone.transform.SetParent(null);
                    Rigidbody rb = clone.AddComponent<Rigidbody>();
                    rb.mass = 1f;
                    rb.useGravity = true;
                    rb.isKinematic = false;
                }
            }
        }


    }
}
