using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healing : MonoBehaviour {

    public Image healthBar;
    public bool hasCollided = false;
    string keyPrompt = "";

    public GameObject teddyBear;

    public AudioClip healSound;

    private AudioSource source2;

    void Start()
    {
        healthBar = transform.FindChild("PlayerCanvas").FindChild("HealthBar").FindChild("Health").GetComponent<Image>();
    }

    void Awake()
    {
        source2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hasCollided && Input.GetKeyDown(KeyCode.E)
                && this.GetComponent<TakeDamage>().currentHealth < this.GetComponent<TakeDamage>().totalHealth)
        {
            print("Huggy");  // debug
            this.GetComponent<TakeDamage>().currentHealth = this.GetComponent<TakeDamage>().totalHealth;
            healthBar.fillAmount = (float)this.GetComponent<TakeDamage>().totalHealth;
            hasCollided = false;
            source2.PlayOneShot(healSound, 1);
        }
        float distance = Vector3.Distance(transform.position, teddyBear.transform.position);
        if (distance <= 3)
        {
            if (this.GetComponent<TakeDamage>().currentHealth < this.GetComponent<TakeDamage>().totalHealth)
            {
                keyPrompt = "Press E to heal";
                hasCollided = true;
            }
            else if (this.GetComponent<TakeDamage>().currentHealth == this.GetComponent<TakeDamage>().totalHealth)
            {
                keyPrompt = "Daaawww, a teddy bear!";
                hasCollided = true;
            }
        }
        else
        {
            hasCollided = false;
        }
    }

    void OnGUI()
    {
        if (hasCollided)
        {
            GUI.Box(new Rect(140, Screen.height - 50, Screen.width - 300, 120), (keyPrompt));
        }
    }

    void OnCollisionEnter(UnityEngine.Collision col)
    {

    }
}
