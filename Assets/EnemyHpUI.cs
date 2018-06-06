using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    public EnemyMove EM;
    public Image HpBar;

    public float Amount;

	void Update ()
    {
        Amount = 1.0f * ((float)EM.CurHp / (float)EM.MaxHp);
        HpBar.fillAmount = Amount;
	}
}
