using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using MySimpleFunction;

namespace MySimpleFunction.Tests
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
            var userresponse = function.FunctionHandler(user, context);

            Console.WriteLine(userresponse);
        }
    }
}
