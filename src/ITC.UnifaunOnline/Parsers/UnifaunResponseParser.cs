using System;
using ITC.UnifaunOnline.Responses;

namespace ITC.UnifaunOnline.Parsers
{
    public class UnifaunResponseParser
    {
        public static UnifaunTxtResponse Parse(string content)
        {
            content = content.TrimEnd('\r', '\n');

            var lineContent = content.Split(';');

            var response = new UnifaunTxtResponse
            {
                OrderNo = lineContent[0],
                Unknown = lineContent[1],
                ShippmentNumber = long.Parse(lineContent[2]),
                Date = DateTime.Parse(lineContent[3])
            };

            if (lineContent.Length == 5)
                response.Reference = lineContent[4];

            return response;
        }
    }
}
