using UnityEngine;

public class CharacterCapabilityRollingAir : CharacterCapability {
    public CharacterCapabilityRollingAir(Character character) : base(character) { }

    public override void Init() {
        name = "rollingAir";
        character.AddStateGroup("airCollision", "rollingAir");
        character.AddStateGroup("harmful", "rollingAir");
        character.AddStateGroup("air", "rollingAir");
        character.AddStateGroup("rolling", "rollingAir");
    }

    public override void StateInit(string stateName, string prevStateName) {
        if (!character.InStateGroup("air") || !character.InStateGroup("rolling")) return;
        character.modeGroupCurrent = character.rollingAirModeGroup;
        character.spriteAnimator.speed = 1 + ((Mathf.Abs(character.groundSpeed) / character.topSpeedNormal) * 2F);
    }

    public override void Update(float deltaTime) {
        if (!character.InStateGroup("air") || !character.InStateGroup("rolling")) return;
        character.eulerAngles = Vector3.zero;
    }
}