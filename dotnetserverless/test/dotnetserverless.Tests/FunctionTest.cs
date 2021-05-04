using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using dotnetserverless;
using Newtonsoft.Json;

namespace dotnetserverless.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TestGetMethod()
        {
            TestLambdaContext context;
            APIGatewayProxyRequest request;
            APIGatewayProxyResponse response;

            Functions functions = new Functions();


            request = new APIGatewayProxyRequest();
            context = new TestLambdaContext();
            var param = new { fun = "listadmin", Message = "Hello",data="this is data" };  
            request.Body=JsonConvert.SerializeObject(param);
            response = functions.Get(request, context);
            Assert.Equal(200, response.StatusCode);
            Console.WriteLine(response.Body);
           // Assert.Equal("Hello AWS Serverless", response.Body);
        }
    }
}
