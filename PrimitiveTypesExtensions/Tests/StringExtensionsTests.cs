using FluentAssertions;
using KitProjects.PrimitiveTypes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Null_or_empty_string_is_considered_null_or_empty(string str)
        {
            var result = str.IsNullOrEmpty();

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("string")]
        public void String_with_any_value_is_not_null_or_empty(string str)
        {
            var result = str.IsNullOrEmpty();

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(" s")]
        [InlineData("s")]
        [InlineData("symbols")]
        public void String_has_value_with_any_symbol(string str)
        {
            var result = str.HasValue();

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(" ")]
        public void String_has_to_have_any_symbols_to_have_any_value(string str)
        {
            var result = str.HasValue();

            result.Should().BeFalse();
        }

        [Fact]
        public void Can_pass_default_string_values_to_be_joined_spaced()
        {
            var stringCaller = "IAmTheFirst";
            var strings = new[]
            {
                string.Empty,
                "string",
                null,
                "valuableString"
            };

            var result = stringCaller.JoinSpaced(strings);

            result.Should().Be("IAmTheFirst string valuableString");
        }

        [Fact]
        public void Joined_strings_have_no_leading_or_trailing_spaces()
        {
            var caller = "";
            var strings = new[]
            {
                null,
                "            leading",
                "       space          ",
                "trailing            ",
                null
            };

            var result = caller.JoinSpaced(strings);

            result.Should().Be("leading space trailing");
        }

        [Fact]
        public void Parsable_string_returns_a_number()
        {
            string parsableNumber = "123";

            var result = parsableNumber.ToIntOrDefault();

            result.Should().Be(123);
        }

        [Theory]
        [InlineData("123avc")]
        [InlineData("")]
        [InlineData(null)]
        public void Non_parsable_number_strings_return_null(string str)
        {
            var result = str.ToIntOrDefault();

            result.Should().BeNull();
        }

        [Fact]
        public void Parsable_string_returns_a_date()
        {
            var date = "01.01.2021";

            var result = date.ToDateTimeOrDefault();

            result.Should().Be(new DateTime(2021, 1, 1));
        }

        [Theory]
        [InlineData("01.013.2021")]
        [InlineData("0.1.2")]
        [InlineData("12032012")]
        [InlineData("absdsa")]
        public void Non_parsable_date_string_returns_null(string str)
        {
            var result = str.ToDateTimeOrDefault();

            result.Should().BeNull();
        }
    }
}
