using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string ChatEuApiPath = "/v1/getchats/eu";

        public static async Task<Chat[]> GetChatEu(DateTime? fromDate = null)
        {
            if (fromDate != null)
            {
                var query = new Dictionary<string, object>
                {
                    { "from_date", fromDate.Value }
                };

                return await Get<Chat[]>(ChatEuApiPath, query);
            }

            return await Get<Chat[]>(ChatEuApiPath);
        }
    }
}
