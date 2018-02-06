using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class Error
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
