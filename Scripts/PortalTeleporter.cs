using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject new_book;
     
    public Collider stair_collider;
    public bool playerIsOverlapping = false;

    public bool clueBook = false;
    // public bool cluebook = false; 
    void Start()
    {
        // Destroy(new_book);
        
        new_book.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if(book != null)
        {
            clueBook = ClueBookPresent();
            // Debug.Log("Book: "+clueBook);
        }

        // isgrabbed = book.GetComponent<>;
        // if (playerIsOverlapping)
        
            // Vector3 portalToPlayer = player.position - transform.position;
            // float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // if(dotProduct < 0f)
            // {
            //     // Teleport Player
            //     float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
            //     rotationDiff += 180;
            //     player.Rotate(Vector3.up, rotationDiff);

            //     Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            //     player.position = receiver.position + positionOffset;

            //     playerIsOverlapping = false;
            // }
    }
    bool ClueBookPresent()
    {
        bool cluePresent = stair_collider.bounds.Contains(book.transform.position);
        return cluePresent;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsOverlapping = true;
            
        }

        if(ClueBookPresent() && playerIsOverlapping)
        {
            Debug.Log("Collider book");
            Destroy(book); 
            // Instantiate(new_book);
            new_book.SetActive(true);
            player.position = receiver.position;
        }
        // else if(!ClueBookPresent() && playerIsOverlapping)
        // {
        //     player.position = receiver.position;
        // }

    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsOverlapping = false;
        }
    }
}
