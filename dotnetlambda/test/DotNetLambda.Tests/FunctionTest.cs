using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using DotNetLambda;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

namespace DotNetLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            NewUser user= new NewUser();
            user.firstName="evan";
            user.surname="dangol";
            APIGatewayProxyRequest request= new APIGatewayProxyRequest();
            request.Body=JsonConvert.SerializeObject(user);
            var userresponse = function.FunctionHandler(request, context);

            Console.WriteLine(userresponse.Body);
             System.Diagnostics.Debug.WriteLine(userresponse);
        }
    }
}
