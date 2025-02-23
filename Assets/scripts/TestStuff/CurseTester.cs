using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sCurseTester : MonoBehaviour
{
    [SerializeField] private CurseInstance curseInstance;
    [SerializeField] private TextMeshProUGUI statusText;
    
    // Test values
    private int testDamage = 10;
    private int testHeal = 20;
    private int testExp = 50;

    void Start()
    {
        PrintStatus("System initialized!");
    }

    void Update()
    {
        // Test Controls
        if (Input.GetKeyDown(KeyCode.D)) // Damage
        {
            int beforeHp = curseInstance.RuntimeHp;
            curseInstance.TakeDamage(testDamage);
            Debug.Log($"=== DAMAGE TEST ===\n" +
                     $"Curse: {curseInstance.CurseName}\n" +
                     $"HP Before: {beforeHp}\n" +
                     $"Damage Taken: {testDamage}\n" +
                     $"HP After: {curseInstance.RuntimeHp}\n" +
                     $"Status: {(curseInstance.IsDead() ? "DEFEATED!" : "Still fighting!")}\n" +
                     $"==================");
        }

        if (Input.GetKeyDown(KeyCode.H)) // Heal
        {
            int beforeHp = curseInstance.RuntimeHp;
            curseInstance.Heal(testHeal);
            Debug.Log($"=== HEAL TEST ===\n" +
                     $"Curse: {curseInstance.CurseName}\n" +
                     $"HP Before: {beforeHp}\n" +
                     $"Heal Amount: {testHeal}\n" +
                     $"HP After: {curseInstance.RuntimeHp}\n" +
                     $"==================");
        }

        if (Input.GetKeyDown(KeyCode.E)) // Experience
        {
            int beforeExp = curseInstance.RuntimeExp;
            int beforeLevel = curseInstance.RuntimeLevel;
            curseInstance.HandleExperience(testExp);
            Debug.Log($"=== EXPERIENCE TEST ===\n" +
                     $"Curse: {curseInstance.CurseName}\n" +
                     $"Before - Level: {beforeLevel}, Exp: {beforeExp}\n" +
                     $"Exp Gained: {testExp}\n" +
                     $"After - Level: {curseInstance.RuntimeLevel}, Exp: {curseInstance.RuntimeExp}\n" +
                     $"==================");
        }

        if (Input.GetKeyDown(KeyCode.K)) // Kill
        {
            int beforeHp = curseInstance.RuntimeHp;
            curseInstance.InstantKill();
            Debug.Log($"=== INSTANT KILL TEST ===\n" +
                     $"Curse: {curseInstance.CurseName}\n" +
                     $"HP Before: {beforeHp}\n" +
                     $"HP After: {curseInstance.RuntimeHp}\n" +
                     $"Status: DEFEATED!\n" +
                     $"==================");
        }

        if (Input.GetKeyDown(KeyCode.L)) // Level Up
        {
            int beforeLevel = curseInstance.RuntimeLevel;
            curseInstance.InstantLevelUp();
            Debug.Log($"=== LEVEL UP TEST ===\n" +
                     $"Curse: {curseInstance.CurseName}\n" +
                     $"Level Before: {beforeLevel}\n" +
                     $"Level After: {curseInstance.RuntimeLevel}\n" +
                     $"==================");
        }

        if (Input.GetKeyDown(KeyCode.F)) // Full Heal
        {
            int beforeHp = curseInstance.RuntimeHp;
            curseInstance.FullHeal();
            Debug.Log($"=== FULL HEAL TEST ===\n" +
                     $"Curse: {curseInstance.CurseName}\n" +
                     $"HP Before: {beforeHp}\n" +
                     $"HP After: {curseInstance.RuntimeHp}\n" +
                     $"==================");
        }

        // Print current status every frame if we have a UI text component
        if (statusText != null)
        {
            statusText.text = curseInstance.GetStatus();
        }
    }

    private void PrintStatus(string message)
    {
        Debug.Log($"=== STATUS UPDATE ===\n" +
                 $"Message: {message}\n" +
                 $"{curseInstance.GetStatus()}\n" +
                 $"==================");
    }
}