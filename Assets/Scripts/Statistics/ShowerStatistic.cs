using UnityEngine;
using UnityEngine.UI;

public class ShowerStatistic : MonoBehaviour
{
    [SerializeField] private Text _shootPlayerText;
    [SerializeField] private Text _pickUpBuffText;
    [SerializeField] private Text _pickedBuffDamageText;
    [SerializeField] private Text _pickUpBuffArmorText;
    [SerializeField] private Text _pickUpBuffSpeedText;
    [SerializeField] private Text _pickUpBuffWeaponText;
    [SerializeField] private Text _killMobsText;
    [SerializeField] private Text _killSmallMobText;
    [SerializeField] private Text _killMiddleMobText;
    [SerializeField] private Text _killBigEnemyText;
    [SerializeField] private Text _pointsPlayerText;


    private void OnEnable()
    {
        StatisticCollector.onShootDone += ShowCountPlayerShoot;
        StatisticCollector.onPickedBuff += ShowPickUpBuffs;
        StatisticCollector.onPickedBuffDamage += ShowPickUpBuffDamage;
        StatisticCollector.onPickedBuffArmor += ShowPickUpBuffArmor;
        StatisticCollector.onPickedBuffSpeed += ShowPickUpBuffSpeed;
        StatisticCollector.onPickedBuffWeapon += ShowPickUpBuffWeapon;
        StatisticCollector.onKilledMobs += ShowKilledMobs;
        StatisticCollector.onKilledSmallMobs += ShowKilledSmallMob;
        StatisticCollector.onKilledMiddleMobs += ShowKilledMiddleMob;
        StatisticCollector.onKilledBigMobs += ShowKilledBigMob;
        StatisticCollector.onPointedPlayerChanged += ShowPointPlayer;
    }

    private void OnDisable()
    {
        StatisticCollector.onShootDone -= ShowCountPlayerShoot;
        StatisticCollector.onPickedBuff -= ShowPickUpBuffs;
        StatisticCollector.onPickedBuffDamage -= ShowPickUpBuffDamage;
        StatisticCollector.onPickedBuffArmor -= ShowPickUpBuffArmor;
        StatisticCollector.onPickedBuffSpeed -= ShowPickUpBuffSpeed;
        StatisticCollector.onPickedBuffWeapon -= ShowPickUpBuffWeapon;
        StatisticCollector.onKilledMobs -= ShowKilledMobs;
        StatisticCollector.onKilledSmallMobs -= ShowKilledSmallMob;
        StatisticCollector.onKilledMiddleMobs -= ShowKilledMiddleMob;
        StatisticCollector.onKilledBigMobs -= ShowKilledBigMob;
        StatisticCollector.onPointedPlayerChanged -= ShowPointPlayer;
    }

    private void ShowCountPlayerShoot(int count)
    {
        _shootPlayerText.text = "Сделано выстрeлов: " + count.ToString();
    }

    private void ShowPickUpBuffs(int count)
    {
        _pickUpBuffText.text = "Подобрано усилений: " + count.ToString();
    }

    private void ShowPickUpBuffDamage(int count)
    {
        _pickedBuffDamageText.text = "Подобрано усилений урона: " + count.ToString();
    }

    private void ShowPickUpBuffArmor(int count)
    {
        _pickUpBuffArmorText.text = "Подобрано усилений защиты: " + count.ToString();
    }

    private void ShowPickUpBuffSpeed(int count)
    {
        _pickUpBuffSpeedText.text = "Подобрано усилений скорости: " + count.ToString();
    }

    private void ShowPickUpBuffWeapon(int count)
    {
        _pickUpBuffWeaponText.text = "Подобрано усилений оружия: " + count.ToString();
    }

    private void ShowKilledMobs(int count)
    {
        _killMobsText.text = "Уничтожено противников: " + count.ToString();
    }

    private void ShowKilledSmallMob(int count)
    {
        _killSmallMobText.text = "Уничтожено легких противников: " + count.ToString();
    }

    private void ShowKilledMiddleMob(int count)
    {
        _killMiddleMobText.text = "Уничтожено средних противников: " + count.ToString();
    }

    private void ShowKilledBigMob(int count)
    {
        _killBigEnemyText.text = "Уничтожено сильных противников: " + count.ToString();
    }

    private void ShowPointPlayer(int count)
    {
        _pointsPlayerText.text = "Набрано очков: " + count.ToString();
    }

}
