using PlayerRoles;
using PluginAPI.Core;
using UnityEngine;

namespace BetterEscape
{
    public class EnteryEscape : MonoBehaviour
    {
        public void OnTriggerEnter(Collider col)
        {
            Player ply = Player.Get(col.gameObject);

            if (ply == null)
                return;

            if (ply.Role.GetTeam() == Team.ChaosInsurgency)
            {
                if (!ply.IsDisarmed) return;

                ply.SetRole(RoleTypeId.NtfPrivate, RoleChangeReason.Escaped);
            }
            else if (ply.Role.GetTeam() == Team.FoundationForces)
            {
                if (!ply.IsDisarmed && ply.Role == RoleTypeId.FacilityGuard && Plugin.Config.IsFacilityGuardCanEscape)
                {
                    ply.SetRole(Plugin.Config.FacilityGuardEscapeRole, RoleChangeReason.Escaped);
                    return;
                }
                if (!ply.IsDisarmed) return;

                ply.SetRole(RoleTypeId.ChaosConscript, RoleChangeReason.Escaped);
            }
            else return;
        }
    }
}