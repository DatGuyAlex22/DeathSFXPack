using FMOD.Studio;
using Microsoft.Xna.Framework;
using System;

namespace Celeste.Mod.DeathSFXPack;

public class DeathSFXPackModule : EverestModule
{
    public static DeathSFXPackModule Instance { get; private set; }

    public override Type SettingsType => typeof(DeathSFXPackModuleSettings);
    public static DeathSFXPackModuleSettings Settings => (DeathSFXPackModuleSettings)Instance._Settings;

    public DeathSFXPackModule()
    {
        Instance = this;
    }

    public override void Load()
    {
        On.Celeste.Audio.CreateInstance += PlayCustomSound;
    }

    public override void Unload()
    {
        On.Celeste.Audio.CreateInstance -= PlayCustomSound;
    }

    public enum DeathSounds
    {
        Default,
        Oof,
        Pipe,
        Explosion,
        Bell,
        Kirby,
        Yippee,
        Yaaay,
        Laugh,
        Wii,
        Gun,
        ThatsNot,
        HaHaHa,
        Secret
    }

    public static EventInstance PlayCustomSound(On.Celeste.Audio.orig_CreateInstance orig, string path, Vector2? position)
    {
        if ((Settings.DeathSoundEffect != (int)DeathSounds.Default) && (path == "event:/char/madeline/death"))
        {
            return orig($"event:/DatGuyAlex_DeathSFXPack/sfx_{Enum.GetName(typeof(DeathSounds), Settings.DeathSoundEffect).ToLower()}", position);
        }
        if ((Settings.GoldenDeathSoundEffect != (int)DeathSounds.Default) && (path == "event:/new_content/char/madeline/death_golden"))
        {
            return orig($"event:/DatGuyAlex_DeathSFXPack/sfx_{Enum.GetName(typeof(DeathSounds), Settings.GoldenDeathSoundEffect).ToLower()}", position);
        }
        if ((path == "event:/char/madeline/predeath") && !Settings.DeathIn)
        {
            return orig("event:/none", position);
        }
        else if ((path == "event:/char/madeline/revive") && !Settings.Respawn)
        {
            return orig("event:/none", position);
        }
        return orig(path, position);
    }
}