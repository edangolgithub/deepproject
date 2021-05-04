using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using TescoWineShopSql;
// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace dotnetserverless
{
    public class Functions
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
        }


        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The API Gateway response.</returns>
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine("Get Request\n");
            dynamic param=JsonConvert.DeserializeObject(request.Body);
            Console.WriteLine(param.fun);
            Console.WriteLine(param["fun"]);
            var fun=Convert.ToString(param.fun);
            switch (fun)
            {
                case "listadmin":
                SqlServer server= new SqlServer();
                var data= server.Administrations.ToList();
                 return GetResponse(data);
               
                
                case "insertadmin":
                using (SqlServer c = new SqlServer()) {

                var std = new Administration()
                {
                     Key = "Billy",
                     value="gatesy"
                };

                c.Administrations.Add(std);
                c.SaveChanges();
                }
                break;
                default:
                 return DefaultResponse();
            }

            return DefaultResponse();
            
        }
        public APIGatewayProxyResponse GetResponse(object data)
        {
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body =JsonConvert.SerializeObject(data),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }

        public APIGatewayProxyResponse DefaultResponse()
        {
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Hello AWS Serverless dotnet l. deploy-func",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }
}
