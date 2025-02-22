using Unity.VisualScripting;
using UnityEngine;

namespace data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewCurse", menuName = "ScriptableObjects/CurseData", order = 1)]
    public class CurseData : ScriptableObject
    {
        [Header("Basic Info")]
        public int id;
        public string curseName;
        public string description;
        public Sprite curseSprite;
        
        [Header("Stats")]
        public CurseType primaryType;
        public Stats baseStats;

        [Header("Misc")]
        public int catchRate;
        public int fleeRate;
        public int baseExpYield;
        public int baseMoneyYield;
    }
    [System.Serializable]
    public class Stats
    {
        public int hp;
        public int attack;
        public int defense;
        public int speed;
        
        public Stats(int hp, int attack, int defense, int speed)
        {
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
        }

        public Stats SnapShot()
        {
            return new Stats(hp, attack, defense, speed);
        }

    }

    public enum CurseType
    {
        Fire,
        Water,
        Earth,
        Electric,
        Light,
        Dark
    }
    
}