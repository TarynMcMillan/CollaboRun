using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform healthBarFilledRect;
    private float healthBarWidth;

    private void Start()
    {
        healthBarWidth = healthBar.rect.width;
        SubscribeToPlayerEvents();
    }

    private void SubscribeToPlayerEvents()
    {
        PlayerMovement player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        player.PlayerHealthChange += UpdateHealthBar;
    }

    private void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        //modify the right value to decrease the filled area
        var offsetMax = healthBarFilledRect.offsetMax;
        var diffPercentage = (float) currentHealth / maxHealth * 100;
        var right = healthBarWidth - ((diffPercentage / 100) * healthBarWidth);
        healthBarFilledRect.offsetMax = new Vector2(-right, offsetMax.y);
    }
}