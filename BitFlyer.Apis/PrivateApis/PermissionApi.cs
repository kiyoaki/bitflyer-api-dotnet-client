using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string PermissionApiPath = "/v1/me/getpermissions";

        public async Task<string[]> GetPermissions()
        {
            return await Get<string[]>(PermissionApiPath);
        }
    }
}
