using UnityEngine;

public class WriterStatisticUnit : MonoBehaviour, IDie
{
    [SerializeField] private TypeOfEnemy typeOfEnemy;
    public void OnDie()
    {
        switch (typeOfEnemy)
        {
            case TypeOfEnemy.Small:
            {
                StatisticCollector.instance.CountKillSmallMob++;
                break;
            }
            case TypeOfEnemy.Middle:
                {
                    StatisticCollector.instance.CountKillMiddleMob++;
                    break;
            }
            case TypeOfEnemy.Big:
                {
                    StatisticCollector.instance.CountKillBigMob++;
                    break;
            }
        }
    }
}
