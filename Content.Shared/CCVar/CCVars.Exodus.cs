using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

public sealed partial class CCVars
{
    /// <summary>
    ///     If enabled automatically creates preset and map votes when round restarts
    /// </summary>
    public static readonly CVarDef<bool> VoteAutoVoteEnabled =
        CVarDef.Create("vote.auto_vote_enabled", false, CVar.SERVERONLY);
}
