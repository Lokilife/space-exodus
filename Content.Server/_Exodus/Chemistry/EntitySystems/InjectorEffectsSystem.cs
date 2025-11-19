using Content.Server.Exodus.Chemistry.Components;
using Content.Shared.Chemistry.Components;
using Content.Shared.EntityEffects;

namespace Content.Server.Exodus.Chemistry.EntitySystems;

public sealed partial class InjectorEffectsSystem : EntitySystem
{
    [Dependency] private readonly SharedEntityEffectsSystem _entityEffects = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<InjectorEffectsComponent, InjectionStartedEvent>(InjectionStarted);
        SubscribeLocalEvent<InjectorEffectsComponent, AfterInjectorUseEvent>(AfterInjectorUse);
    }

    private void InjectionStarted(EntityUid uid, InjectorEffectsComponent comp, ref InjectionStartedEvent ev)
    {
        foreach (var effect in comp.InjectionStarted)
        {
            _entityEffects.TryApplyEffect(ev.Target, effect, user: ev.User);
        }
    }

    private void AfterInjectorUse(EntityUid uid, InjectorEffectsComponent comp, ref AfterInjectorUseEvent ev)
    {
        foreach (var effect in comp.InjectionStarted)
        {
            _entityEffects.TryApplyEffect(ev.Target, effect, user: ev.User);
        }
    }
}
