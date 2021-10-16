using FluentAssertions;
using KP.Extensions.Generics;
using System;
using Xunit;

namespace Tests
{
    public class GenericExtensionsTests
    {
        [Fact]
        public void Default_guid_converts_to_null()
        {
            var emptyGuid = Guid.Empty;

            var result = emptyGuid.ToNullIfDefault();

            result.Should().BeNull();
        }

        [Fact]
        public void Default_date_time_converts_to_null()
        {
            var defaultDate = DateTime.MinValue;

            var result = defaultDate.ToNullIfDefault();

            result.Should().BeNull();
        }

        [Fact]
        public void Default_int_converts_to_null()
        {
            var defaultInt = 0;

            var result = defaultInt.ToNullIfDefault();

            result.Should().BeNull();
        }
    }
}
