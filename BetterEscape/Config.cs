using PlayerRoles;
using System.ComponentModel;

namespace BetterEscape
{
    public class Config
    {
        [Description("Can a facility guard escape?")]
        public bool IsFacilityGuardCanEscape { get; set; } = true;

        [Description("What role will the facility guard get after the escape?")]
        public RoleTypeId FacilityGuardEscapeRole { get; set; } = RoleTypeId.NtfPrivate;
    }
}