namespace Solution1App.Test
{
    public class CalculatorTest
    {
        private Calculator _calculator;

        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        public static IEnumerable<object[]> SimpleDataTest =>
        new List<object[]>
        {
            new object[] { false, 1,  new long[] { 2, 1, 9, 12, 4, 8, 24 } },
            new object[] { false, 2,  new long[] { 2, 1, 9, 12, 4, 8, 24 } },
            new object[] { false, 6,  new long[] { 3, 8, 5, 4, 10, 11 } },
            new object[] { true,  10, new long[] { 3, 1, 8, 5, 4, 10, 11 } },
            new object[] { true,  11, new long[] { 1, 8, 5, 4, 15, 25, 43, 3 } },
            new object[] { true,  11, new long[] { 6, 2, 9, 5, 4, 7 } },
            new object[] { false, 11, new long[] { 1, 8, 5, 4, 11 } },
            new object[] { true,  27, new long[] { 3, 1, 8, 5, 4, 10, 11 } },
            new object[] { false, 55, new long[] { 3, 1, 8, 5, 4, 10, 11 } },
            new object[] { false, 66, new long[] { 10, 11, 22, 35, 48, 57 } },
        };

        public static IEnumerable<object[]> DoubleDataTest =>
        new List<object[]>
        {
            new object[] { true,  2,   new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { false, 3,   new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { false, 4,   new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { true,  7,   new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { true,  11,  new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { false, 14,  new long[] { 5, 5, 5, 8, 8, 8, 10, 10, 10 } },
            new object[] { true,  16,  new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { true,  19,  new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { true,  57,  new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
            new object[] { false, 300, new long[] { 1, 1, 5, 5, 8, 8, 9, 47 } },
        };

        public static IEnumerable<object[]> RandomMiddleDataTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var arrayCount = random.Next(10000, 100000);
            var array = new long[arrayCount];
            var indexesCount = random.Next(50, 300);
            var indexes = new HashSet<int>();
            var sum = 0L;
            for (int i = 0; i < indexesCount; i++)
            {
                indexes.Add(random.Next(0, arrayCount - 1));
            }
            for (var i = 0; i < arrayCount; i++)
            {
                array[i] = random.Next(1, 10000);
                if (indexes.Contains(i))
                {
                    sum += array[i];
                }
            }
            yield return new object[] { true, sum, array };
        }

        [Theory]
        [MemberData(nameof(SimpleDataTest))]
        [MemberData(nameof(DoubleDataTest))]
        [MemberData(nameof(RandomMiddleDataTest))]
        public void IsRepresented_Test(bool expectedResult, long source, long[] array)
        {
            var actualResult = _calculator.IsRepresented(source, array);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}