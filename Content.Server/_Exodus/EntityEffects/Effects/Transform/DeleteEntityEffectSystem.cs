using Content.Shared.EntityEffects;
using Content.Shared.Exodus.EntityEffects.Effects.Transform;

namespace Content.Server.Exodus.EntityEffects.Effects.Transform;

/// <inheritdoc cref="EntityEffectSystem{T,TEffect}"/>
public sealed partial class DeleteEntityEffectSystem : EntityEffectSystem<TransformComponent, DeleteEntityEffect>
{
    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<DeleteEntityEffect> args)
    {
        QueueDel(entity);
    }
}
