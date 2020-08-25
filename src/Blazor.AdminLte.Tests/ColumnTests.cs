using Xunit;

namespace Blazor.AdminLte.Tests
{

    public class ColumnTests
    {
        [Fact]
        public void ClassTest()
        {
            var u = col.md._12;
            var v = col._12;
            var x = col.xs._6.col.sm._4.col.md._3.col.lg._2;
            Assert.Equal("col-md-12", u.ToString());
            Assert.Equal("col-12", v.ToString());
            Assert.Equal("col-xs-6 col-sm-4 col-md-3 col-lg-2", x.ToString());
        }
    }
}
