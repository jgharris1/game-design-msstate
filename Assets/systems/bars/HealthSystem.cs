using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	public static HealthSystem Instance;

	public Image currentHealthBar;
	public Text healthText;
	public float hitPoint = 100f;
	public float maxHitPoint = 100f;

	public Image currentManaBar;
	public Text manaText;
	public float manaPoint = 100f;
	public float maxManaPoint = 100f;

	void Awake()
	{
		Instance = this;
	}
	
  	void Start()
	{
		UpdateGraphics();
	}

	private void UpdateHealthBar()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
		healthText.text = hitPoint.ToString ("0") + "/" + maxHitPoint.ToString ("0");
	}

	private void UpdateManaBar()
	{
		float ratio = manaPoint / maxManaPoint;
		currentManaBar.rectTransform.localPosition = new Vector3(currentManaBar.rectTransform.rect.width * ratio - currentManaBar.rectTransform.rect.width, 0, 0);
		manaText.text = manaPoint.ToString("0") + "/" + maxManaPoint.ToString("0");
	}

	public void SetHealth(float health)
	{
		hitPoint = health;
		UpdateGraphics();
	}

	public void SetMaxHealth(float max)
	{
		maxHitPoint = (int)(max);
		UpdateGraphics();
	}


	public void SetMana(float Mana)
	{
		manaPoint = Mana;
		UpdateGraphics();
	}

	public void SetMaxMana(float max)
	{
		maxManaPoint = (int)(max);
		UpdateGraphics();
	}



	private void UpdateGraphics()
	{
		UpdateHealthBar();
		UpdateManaBar();
	}
}
