using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DotNetLambda
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse  FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var body=request.Body;
            NewUser user= JsonConvert.DeserializeObject<NewUser>(body);
            LambdaLogger.Log($"Calling function name: {context.FunctionName}\n");
            string x= $" {user.firstName} {user.surname}";
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Hello "+x+ " the time is: " + DateTime.Now.ToString("hh:mm:ss"),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
         
            return response;

        }
    }
}
