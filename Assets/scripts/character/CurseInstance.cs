using data.ScriptableObjects;
using UnityEngine;

public class CurseInstance : MonoBehaviour
{
    [SerializeField] private CurseData curseData;
    private Stats _snapshotStats;
    private int _runtimeHp;
    private int _runtimeExp;
    private int _runtimeLevel = 1;
    private const int MaxLevel = 100;  

    // Properties
    public string CurseName => curseData.curseName;
    public int MaxHp => _snapshotStats.hp;
    public int RuntimeHp => _runtimeHp;
    public CurseType Type => curseData.primaryType;
    public int RuntimeLevel => _runtimeLevel;
    public int RuntimeExp => _runtimeExp;

    private void Awake()
    {
        Debug.Log("CurseInstance Awake called");
        InitializeCurse();
    }

    private void InitializeCurse()
    {
        if (curseData != null)
        {
            _snapshotStats = curseData.baseStats.SnapShot();
            _runtimeHp = _snapshotStats.hp;
        }
        else
        {
            Debug.LogWarning("No CurseData assigned please try again");
        }
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Max(0, damage);
        _runtimeHp = Mathf.Max(0, _runtimeHp - damage);

        if (IsDead())
        {
            Debug.Log($"{CurseName} is defeated!");
        }
    }

    public void Heal(int heal)
    {
        heal = Mathf.Max(0, heal);
        _runtimeHp = Mathf.Min(MaxHp, _runtimeHp + heal);
    }

    public bool IsDead()
    {
        return _runtimeHp <= 0;
    }

    public float GetHealthPercentage()
    {
        return (float)_runtimeHp / MaxHp;
    }

    // Level System
    public void HandleExperience(int exp)  // Made public so other systems can give exp
    {
        if (_runtimeLevel >= MaxLevel) return;  // Don't process exp at max level

        _runtimeExp += exp;
        
        while (_runtimeExp >= GetRequiredExpForNextLevel() && _runtimeLevel < MaxLevel)
        {
            LevelUp();
        }
    }

    private int GetRequiredExpForNextLevel()
    {
        return 100 * (_runtimeLevel * _runtimeLevel);  // Your exp curve
    }

    private void LevelUp()
    {
        _runtimeLevel++;
        
        float increaseRate = 0.1f;  // 10% increase per level
        _snapshotStats.hp += Mathf.FloorToInt(_snapshotStats.hp * increaseRate);
        _snapshotStats.attack += Mathf.FloorToInt(_snapshotStats.attack * increaseRate);
        _snapshotStats.defense += Mathf.FloorToInt(_snapshotStats.defense * increaseRate);
        _snapshotStats.speed += Mathf.FloorToInt(_snapshotStats.speed * increaseRate);
        
        // Heal to full on level up
        _runtimeHp = MaxHp;
        
        // Reset exp for next level
        _runtimeExp = 0;
        
        Debug.Log($"{CurseName} leveled up to {_runtimeLevel}!");
    }

    // Testing Options
    public void FullHeal()
    {
        _runtimeHp = MaxHp;
    }

    public void InstantKill()
    {
        _runtimeHp = 0;
    }

    public void InstantLevelUp()
    {
        LevelUp();
    }
    // For debugging
    public string GetStatus()
    {
        return $"Curse: {CurseName} (Lvl {_runtimeLevel})\n" +
               $"Type: {Type}\n" +
               $"HP: {RuntimeHp}/{MaxHp}\n" +
               $"Exp: {_runtimeExp}/{GetRequiredExpForNextLevel()}";  // Added exp requirement
    }
}