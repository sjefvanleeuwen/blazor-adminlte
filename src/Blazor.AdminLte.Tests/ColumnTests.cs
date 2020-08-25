using Xunit;

namespace Blazor.AdminLte.Tests
{

    public class ColumnTests
    {
        [Fact]
        public void ClassTest()
        {
            var s = Column.Class.Size.Medium.Width.Twelve;
            Assert.Equal("col-md-12", s.ToString());
        }
    }
}
