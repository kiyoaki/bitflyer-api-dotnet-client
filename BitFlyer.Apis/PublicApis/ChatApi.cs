using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string ChatApiPath = "/v1/getchats";

        public static async Task<Chat[]> GetChat(DateTime? fromDate = null)
        {
            if (fromDate != null)
            {
                var query = new Dictionary<string, object>
                {
                    { "from_date", fromDate.Value }
                };

                return await Get<Chat[]>(ChatApiPath, query);
            }

            return await Get<Chat[]>(ChatApiPath);
        }
    }
}
