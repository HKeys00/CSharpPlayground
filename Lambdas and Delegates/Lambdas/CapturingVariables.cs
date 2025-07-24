namespace Lambdas
{
    /// <summary>
    /// Demonstrating how variables are captured in lambda expressions.
    /// </summary>
    internal class CapturingVariables
    {
        private string instanceField = "instance Field";

        /// Simple property to view instance field.
        public string InstanceField => instanceField;

        public Action<string> CreateLogAction(string methodParameter)
        {
            string methodLocalVariable = "method local";
            string uncapturedLocalVariable = "uncaptured local";

            Action<string> action = (lambdaParameter) =>
            {
                string lambdaLocal = "lambda local";
                Console.WriteLine("Instance Field: {0}", instanceField);
                Console.WriteLine("Method Parameter: {0}", methodParameter);
                Console.WriteLine("Method Local: {0}", methodLocalVariable);
                Console.WriteLine("Lambda Parameter {0}", lambdaParameter);
                Console.WriteLine("Lambda Local {0}", lambdaLocal);
            };

            return action;
        }

        public Action<string> CreateAlterAction(string methodParameter)
        {
            var methodLocalVariable = "method local";

            Action<string> action = (lambdaParameter) =>
            {
                methodLocalVariable = "This is an altered method local variable";
                instanceField = "This is an altered instance field";
                methodParameter = "This is an altered method parameter";
                lambdaParameter = "This is an altered lambda parameter";

                Console.WriteLine("Method Local: {0}", methodLocalVariable);
            };

            return action;
        }

        public List<Action> CreateActions()
        {
            var actions = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                string text = string.Format("message {0}", i);
                actions.Add(() => Console.WriteLine(text));
            }

            return actions;
        }

        public List<Action> CreateCountingActions()
        {
            var actions = new List<Action>();
            int outerCounter = 0;
            for (int i = 0; i < 2; i++)
            {
                int innerCounter = 0;
                Action action = () =>
                {
                    Console.WriteLine("Outer: {0}; Inner: {1}", outerCounter, innerCounter);
                    outerCounter++;
                    innerCounter++;
                };

                actions.Add(action);
            }

            return actions;
        }
    }
}
