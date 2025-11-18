using Content.Shared.EntityEffects;
using Robust.Shared.Audio;
using Robust.Shared.Prototypes;

namespace Content.Shared.Exodus.EntityEffects.Effects.Transform;

/// <inheritdoc cref="EntityEffect"/>
/// <seealso cref="RandomTeleportEffect">
public sealed partial class RandomTeleportEffect : EntityEffectBase<RandomTeleportEffect>
{
    [DataField]
    public float Range = 10f;

    [DataField]
    public bool SpaceAllowed = true;

    [DataField]
    public SoundSpecifier TeleportSound = new SoundPathSpecifier("/Audio/Effects/teleport_arrival.ogg");

    public override string EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("entity-effect-guidebook-random-teleport", ("range", Range), ("chance", Probability));
}
