using LabApi.Features.Wrappers;
using PlayerRoles;
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

            if (ply.IsDisarmed)
            {
                Team team = ply.Role.GetTeam();
                if (team == Team.ChaosInsurgency)
                    ply.SetRole(RoleTypeId.NtfPrivate, RoleChangeReason.Escaped);
                else if (team == Team.FoundationForces)
                    ply.SetRole(RoleTypeId.ChaosConscript, RoleChangeReason.Escaped);
            }
            else if (ply.Role == RoleTypeId.FacilityGuard && Plugin.Instance.Config.IsFacilityGuardCanEscape)
                ply.SetRole(Plugin.Instance.Config.FacilityGuardEscapeRole, RoleChangeReason.Escaped);
        }
    }
}