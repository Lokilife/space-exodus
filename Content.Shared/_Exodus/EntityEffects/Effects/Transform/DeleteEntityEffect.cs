using Content.Shared.EntityEffects;
using Robust.Shared.Prototypes;

namespace Content.Shared.Exodus.EntityEffects.Effects.Transform;

/// <inheritdoc cref="EntityEffect"/>
/// <seealso cref="DeleteEntityEffect">
public sealed partial class DeleteEntityEffect : EntityEffectBase<DeleteEntityEffect>
{
    public override string EntityEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("entity-effect-guidebook-delete", ("chance", Probability));
}
