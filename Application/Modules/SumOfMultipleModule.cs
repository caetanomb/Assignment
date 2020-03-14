using SumOfMultiple;

namespace Application.Modules
{
    public class SumOfMultipleModule : IModule
    {
        private readonly IFindMultipleNumbersOf3Or5 _findMultipleNumbersOf3Or5;
        private readonly IPresenter _presentation;
        public SumOfMultipleModule(IFindMultipleNumbersOf3Or5 findMultipleNumbersOf3Or5,
            IPresenter presentation)
        {
            _findMultipleNumbersOf3Or5 = findMultipleNumbersOf3Or5;
            _presentation = presentation;
        }

        public void Execute()
        {
            _presentation.ShowText("Informe a limit");

            if (!long.TryParse(_presentation.FetchInput(), out var limit))
            {
                _presentation.ShowText("WARNING - Invalid value");
                return;
            }

            var result =
                _findMultipleNumbersOf3Or5
                .Handle(limit)
                .Sum();

            _presentation.ShowText($"Output: {result}");
        }
    }
}
