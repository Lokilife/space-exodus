using Content.Server.Exodus.RandomTeleport;
using Content.Shared.EntityEffects;
using Content.Shared.Exodus.EntityEffects.Effects.Transform;
using Robust.Shared.Audio.Systems;

namespace Content.Server.Exodus.EntityEffects.Effects.Transform;

/// <inheritdoc cref="EntityEffectSystem{T,TEffect}"/>
public sealed partial class RandomTeleportEffectSystem : EntityEffectSystem<TransformComponent, RandomTeleportEffect>
{
    [Dependency] private readonly SharedTransformSystem _transform = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly RandomTeleportSystem _randomTeleport = default!;

    protected override void Effect(Entity<TransformComponent> entity, ref EntityEffectEvent<RandomTeleportEffect> args)
    {
        var targetCoordinates = _randomTeleport.GetRandomCoordinates(entity, args.Effect.Range, args.Effect.SpaceAllowed);

        if (targetCoordinates.HasValue)
        {
            _transform.SetCoordinates(entity, targetCoordinates.Value);
            _audio.PlayPvs(args.Effect.TeleportSound, entity);
        }
    }
}
