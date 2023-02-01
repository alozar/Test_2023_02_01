namespace Solution1App
{
    public class Calculator
    {
        public Calculator() { }

        public bool IsRepresented(long source, IEnumerable<long> array)
        {
            if (array.Sum() < source)
            {
                return false;
            }
            var sortNums = array.Where(x => x < source).ToArray();
            var sumNumbers = new List<long>();
            var result = IsRepresentedRecursion(source, sortNums, sumNumbers);
            return result;
        }

        private bool IsRepresentedRecursion(long number, IEnumerable<long> array, List<long> sumNumbers)
        {
            if (number == 0)
            {
                return true;
            }
            if (number < 0)
            {
                return false;
            }

            var isRepresented = false;
            var index = 0L;
            foreach (var n in array)
            {
                var filteredNewArray = array.Where((_, i) => i != index).ToArray();
                isRepresented = IsRepresentedRecursion(number - n, filteredNewArray, sumNumbers);
                if (isRepresented)
                {
                    sumNumbers.Add(n);
                    return isRepresented;
                }
                index++;
            }

            return isRepresented;
        }
    }
}
