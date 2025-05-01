// © Space Exodus, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/space-exodus/space-station-14/master/CLA.txt

using System.Linq;
using Content.Shared.Exodus.Mining.Components;
using Robust.Shared.Timing;

namespace Content.Shared.Exodus.Mining;

public sealed partial class MiningScannerViewerSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _timing = default!;

    public void CreateScan(EntityUid uid, float range, TimeSpan delay, float animationDuration = 1.5f)
    {
        var xform = Transform(uid);

        var scan = new MiningScannerRecord()
        {
            AnimationDuration = TimeSpan.FromSeconds(animationDuration),
            ViewRange = range,
            CreatedAt = _timing.CurTime,
            PingLocation = xform.Coordinates,
            Delay = delay,
        };

        var viewer = EnsureComp<MiningScannerViewerComponent>(uid);
        viewer.Records.Add(scan);
        Dirty(uid, viewer);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        // when scanner records is out of date it would be better to clean redunant data
        // when we don't have any usefull data in component delete it fully

        var viewers = EntityQueryEnumerator<MiningScannerViewerComponent>();

        while (viewers.MoveNext(out var uid, out var viewer))
        {
            var records = viewer.Records.Where(record => record.CreatedAt + record.Delay + record.AnimationDuration > _timing.CurTime).ToList();

            if (records.Count == 0)
            {
                RemCompDeferred(uid, viewer);
                continue;
            }

            if (records.Count != viewer.Records.Count)
            {
                viewer.Records = records;
                Dirty(uid, viewer);
            }
        }
    }
}
