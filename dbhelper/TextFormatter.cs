namespace dbhelper
{
    class TextFormatter
    {
        TextFormatter() { }
        public static void formater(ref string a)
        {
            //we will write a string formatter here to avoid ' character error for sql solver.
            //example: john's villa. if we send it to sql engine the engine will fall in a conflict.

            //fields
            int count =0;

            if (a.Contains("'"))
            {
                foreach (char character in a)
                {
                    count++;
                    if (character == '\'')
                        a=a.Insert(count,"'");
                }
            }
            
        }

    }
}
