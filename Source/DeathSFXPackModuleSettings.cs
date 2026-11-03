using System;

namespace Celeste.Mod.DeathSFXPack;

public class DeathSFXPackModuleSettings : EverestModuleSettings
{
    private TextMenu.Slider DeathSoundEffectEntry;
    public int DeathSoundEffect { get; set; } = (int)DeathSFXPackModule.DeathSounds.Default;
    public void CreateDeathSoundEffectEntry(TextMenu menu, bool inGame)
    {
        Array enumValues = Enum.GetValues(typeof(DeathSFXPackModule.DeathSounds));
        Array.Sort((int[])enumValues);
        menu.Add(DeathSoundEffectEntry = new TextMenu.Slider(
            Dialog.Clean("MODSETTING_DEATHSOUNDEFFECT"),
            (int i) => Dialog.Clean($"MODSETTING_DEATHSOUNDEFFECT_{enumValues.GetValue(i)}".ToUpper()),
            0,
            enumValues.Length - 1,
            DeathSoundEffect
        ));
        DeathSoundEffectEntry.Change(sound => DeathSoundEffect = sound);
    }

    private TextMenu.Slider GoldenDeathSoundEffectEntry;
    public int GoldenDeathSoundEffect { get; set; } = (int)DeathSFXPackModule.DeathSounds.Default;
    public void CreateGoldenDeathSoundEffectEntry(TextMenu menu, bool inGame)
    {
        Array enumValues = Enum.GetValues(typeof(DeathSFXPackModule.DeathSounds));
        Array.Sort((int[])enumValues);
        menu.Add(GoldenDeathSoundEffectEntry = new TextMenu.Slider(
            Dialog.Clean("MODSETTING_GOLDENDEATHSOUNDEFFECT"),
            (int i) => Dialog.Clean($"MODSETTING_DEATHSOUNDEFFECT_{enumValues.GetValue(i)}".ToUpper()),
            0,
            enumValues.Length - 1,
            GoldenDeathSoundEffect
        ));
        GoldenDeathSoundEffectEntry.Change(sound => GoldenDeathSoundEffect = sound);
    }

    [SettingName("MODSETTING_DEATHIN")]
    [SettingSubText("MODSETTING_DEATHIN_CONTEXT")]
    public bool DeathIn { get; set; } = true;

    [SettingName("MODSETTING_RESPAWN")]
    public bool Respawn { get; set; } = true;
}