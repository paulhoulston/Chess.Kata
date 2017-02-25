using System;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Test1() 
        {
            var x = 1;
            Assert.True(x==2);
        }
    }
}
