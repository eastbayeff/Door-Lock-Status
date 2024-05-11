using UnityEditor;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Button : MonoBehaviour, IInteractable
{
    public int Id = 0;

    [SerializeField] private GameObject toggleTarget;

    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float interactionCooldown = 0.5f;
    private float interactionTimer;

    [SerializeField] private AudioClip interactionSound;

    private bool isOn = false;

    public bool Status
    {
        get
        {
            return isOn;
        }

        set
        {
            isOn = value;
        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        GameManager.Instance.AddButton(this);
        interactionTimer = interactionCooldown;
        spriteRenderer.color = isOn ? onColor : offColor;
    }

    void Update()
    {
        interactionTimer += Time.deltaTime;
    }

    public void Interact()
    {
        if (interactionTimer < interactionCooldown)
            return;

        isOn = !isOn;
        spriteRenderer.color = isOn ? onColor : offColor;
        toggleTarget.SetActive(!isOn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteract player))
            player.SetCurrentInteractable(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerInteract player))
            player.SetCurrentInteractable(null);
    }
}
