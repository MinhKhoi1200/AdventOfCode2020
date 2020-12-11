using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day06
{
    public class PersonResponse
    {
        public PersonResponse(string rawResponse)
        {
            RawResponse = rawResponse;
        }

        public string RawResponse { get; }

        public List<char> YesQuestionsList => RawResponse.ToCharArray().ToList();
    }
}