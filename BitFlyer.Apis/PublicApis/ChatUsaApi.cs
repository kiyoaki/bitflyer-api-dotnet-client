using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string ChatUsaApiPath = "/v1/getchats/usa";

        public static async Task<Chat[]> GetChatUsa(DateTime? fromDate = null)
        {
            if (fromDate != null)
            {
                var query = new Dictionary<string, object>
                {
                    { "from_date", fromDate.Value }
                };

                return await Get<Chat[]>(ChatUsaApiPath, query);
            }

            return await Get<Chat[]>(ChatUsaApiPath);
        }
    }
}
