using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string PermissionApiPath = "/v1/me/getpermissions";

        public async Task<string[]> GetPermissions(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Get<string[]>(PermissionApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
