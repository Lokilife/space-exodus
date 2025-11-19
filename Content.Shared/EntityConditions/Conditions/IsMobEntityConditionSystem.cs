// © Space Exodus, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/space-exodus/space-station-14/master/CLA.txt

using Content.Shared.Mobs.Components;
using Robust.Shared.Prototypes;

namespace Content.Shared.EntityConditions.Conditions;

/// <summary>
/// Returns true if this entity is a mob.
/// </summary>
/// <inheritdoc cref="EntityConditionSystem{T, TCondition}"/>
public sealed partial class IsMobEntityConditionSystem : EntityConditionSystem<MobStateComponent, IsMobCondition>
{
    protected override void Condition(Entity<MobStateComponent> entity, ref EntityConditionEvent<IsMobCondition> args)
    {
        // is entity has MobStateComponent then it is a mob
        args.Result = true;
    }
}

/// <inheritdoc cref="EntityCondition"/>
public sealed partial class IsMobCondition : EntityConditionBase<IsMobCondition>
{
    public override string EntityConditionGuidebookText(IPrototypeManager prototype) =>
        Loc.GetString("reagent-effect-condition-guidebook-is-mob", ("invert", Inverted));
}
