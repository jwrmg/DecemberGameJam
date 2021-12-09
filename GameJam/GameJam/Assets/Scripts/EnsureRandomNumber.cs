namespace Tools
{
    public static class EnsureRandomNumber
    {
        /// <summary>
        /// Will never generate the two same numbers in a row.
        /// </summary>
        /// <param name="previousValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Get(ref int previousValue, int min, int max)
        {
            int value = UnityEngine.Random.Range(min, max);

            if (value == previousValue)
                if (value + 1 < max)
                    value++;
                else if (value - 1 > min)
                    value--;

            previousValue = value;

            return value;
        }
    }
}

// File Logs.
/*
 *  -- JAMES GREENSILL @ ~ 10PM 23rd August
 *      - + Get();
 */