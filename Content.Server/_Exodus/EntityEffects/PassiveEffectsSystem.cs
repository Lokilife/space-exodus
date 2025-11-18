using Content.Shared.EntityEffects;

namespace Content.Server.Exodus.EntityEffects;

public sealed partial class PassiveEffectsSystem : EntitySystem
{
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    public override void Update(float frameTime)
    {
        var query = EntityQueryEnumerator<PassiveEffectsComponent>();

        while (query.MoveNext(out var uid, out var comp))
        {
            comp.Accumulator += frameTime;

            if (comp.Accumulator < comp.Rate)
                continue;

            comp.Accumulator = 0;

            foreach (var effect in comp.Effects)
            {
                _entityEffects.TryApplyEffect(uid, effect);
            }
        }
    }
}
