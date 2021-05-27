using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stone : MonoBehaviour
{

    private Rigidbody2D rb;
    public Joystick joystick;
    public float force = 5f;
    private Vector2 vector;
    public Trajectory trajectory;
    static public EventTrigger.Entry InventoryEntry;
    private Pickup pickup;
    public float direction = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        trajectory = GameObject.Find("Trajectory").GetComponent<Trajectory>();

        InventoryEntry = new EventTrigger.Entry();
        InventoryEntry.eventID = EventTriggerType.PointerDown;
        InventoryEntry.callback.AddListener((data) => {
            
            Player player = GameObject.Find("Player").GetComponent<Player>();
            
            if (player.interactObj != null) return;
            
            Vector2 pos = GameObject.Find("ActiveObject").transform.position;
            GameObject stone = Instantiate(pickup.Prefab);
            Stone stoneCode = stone.GetComponent<Stone>();

            if (player.flip) stoneCode.direction = -1;
            else stoneCode.direction = 1;

            player.GetComponent<Inventory>().remove(pickup.Name);
            Destroy(stone.GetComponent<Pickup>());
            stone.transform.position = pos;
            stone.transform.SetParent(player.transform);
            stoneCode.trajectory.Show();
            stoneCode.joystick = player.joystick;
            player.moveAllowed = false;
            player.flipAllowed = false;
            player.jumpAllowed = false;
            GameObject.Find("Player").GetComponent<Player>().interactObj = stone;       

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((data) => {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                Stone stone = player.interactObj.GetComponent<Stone>();

                stone.trajectory.Hide();
                stone.Push();
                stone.joystick = null;
                player.interactObj = null;
                player.moveAllowed = true;
                player.flipAllowed = true;
                player.jumpAllowed = true;

            });
            
            GameObject active = GameObject.Find("Active");
            active.GetComponent<EventTrigger>().triggers.Add(entry);

        });

        pickup = GetComponent<Pickup>();
        pickup.entry =  InventoryEntry;
    }

    private void Update()
    {
        if (joystick)
        {
            vector.x = Mathf.Abs(joystick.Horizontal) * direction;
            vector.y = Mathf.Abs(joystick.Vertical);
        }
        trajectory.UpdateDots(transform.position, vector*force);

    }
    public void Push()
    {
        transform.SetParent(null);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(vector * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            rb.drag = 2;
        }
    }

}
