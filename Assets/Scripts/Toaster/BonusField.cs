using UnityEngine;

public class BonusField : MonoBehaviour
{
    short dir;
    bool work = false;
    float current;
    float speed;

    float range = 12;
    float difficulty = 0;
    int speedMultiply = 2;

    FloatingTextsManager floatingTexts;

    private void Awake()
    {
        floatingTexts = GameObject.FindGameObjectWithTag("FloatingTextsCanvas").GetComponent<FloatingTextsManager>();
    }

    private void Start()
    {
        GameManager.instance.SwitchingToToastFrying.AddListener(StartHeating);
        GameManager.instance.SwitchingToButterChoice.AddListener(StopHeating);
        TapToaster.instance.tapEvent.AddListener(Tap);
        GetComponent<Renderer>().material.SetFloat("_Range", range * Mathf.Deg2Rad);
        StartHeating();
        if (!LevelManager.instance.currentLevel.bonus) { gameObject.SetActive(false); }
    }
    private void Update()
    {
        if (work)
        {
            current += dir * speed * Time.deltaTime;
            if (current < -302.0f) { current = -302.0f; dir = 1; }
            if (current >= 0.0f) { current = 0.0f; dir = -1; }
            transform.rotation = Quaternion.Euler(current, 0, 0);
        }
    }

    void Tap()
    {
        if (LevelManager.instance.currentLevel.bonus)
        {
            if (TapToaster.instance.correct)
            {
                float angle = TapToaster.instance.GetCurrentAngle();
                if (Mathf.Abs(angle - current) < range)
                {
                    GetComponent<StateSounds>().PlayStateSound();
                    PointsHolder.instance.points += 200;

                    //Debug.Log("AAAA URWA BONUS!"); 
                    floatingTexts.InstantateBonus();
                }
                else
                {
                    GetComponent<PlayOnTap>().PlayGoodTap();
                }
            } 
            else
            {
                GetComponent<PlayOnTap>().PlayBadTap();
            }
            
            current = Offset();
        } 
        else
        {
            if(TapToaster.instance.correct)
            {
                GetComponent<PlayOnTap>().PlayGoodTap();
            }
            else
            {
                GetComponent<PlayOnTap>().PlayBadTap();
            }
        } 
    }

    public void StartHeating()
    {
        gameObject.SetActive(LevelManager.instance.currentLevel.bonus);
        if (!LevelManager.instance.currentLevel.bonus) { return; }

        range = LevelManager.instance.currentLevel.bonusRange;
        difficulty = LevelManager.instance.currentLevel.difficulty;
        speedMultiply = LevelManager.instance.currentLevel.bonusSpeedMiltipler;
        work = true;
        current = Offset();
    }

    public void StopHeating()
    {
        work = false;
    }


    float Offset()
    {
        if (TapToaster.instance.GetStage() >= LevelManager.instance.currentLevel.indexOfColorInOrder.Length)
        { return 0; }

        int mul = speedMultiply;
        speed = mul * TapToaster.instance.arrowSpeed;
        int[] possible = new int[LevelManager.instance.currentLevel.section];
        Color currentTarget = LevelManager.instance.currentLevel.paletteOfColours[LevelManager.instance.currentLevel.indexOfColorInOrder[TapToaster.instance.GetStage()]];
        int a = 0;
        for (int i = 0; i < TapToaster.instance.colorList.Length * 0.5f; i++)
        {
            if (TapToaster.instance.colorList[i] == currentTarget)
            {
                possible[a] = i;
                a++;
                if (a == possible.Length) { break; }
            }
        }
        int ourTarget = possible[Random.Range(0, LevelManager.instance.currentLevel.section)];
        float ourTargetPos = ((float)ourTarget+difficulty) * TapToaster.instance.colorRange;
        float betha = (mul-1) * ourTargetPos;

        float fx = Calculate(speed, TapToaster.instance.GetTrajectoryTime(), betha, 302.0f);
        float fxb = Calculate(speed, TapToaster.instance.GetTrajectoryTime() + Time.deltaTime, betha, 302.0f);
        dir =(short)Mathf.Sign(fxb - fx);
        return fx;
    }

    float Calculate(float bonusSpeed, float x, float betha, float max)
    {
        float y = ((bonusSpeed * x + betha) % (2 * max)) - (2 * ((Mathf.FloorToInt((bonusSpeed * x + betha) / max) % 2) * (bonusSpeed * x + betha) % max));
        return -y;
    }

}