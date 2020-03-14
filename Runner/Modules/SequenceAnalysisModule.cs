using Application;
using SequenceAnalysis;

namespace Runner.Modules
{
    public class SequenceAnalysisModule : IModule
    {
        private readonly IFindUpperCaseWords _findUpperCaseWords;
        private readonly IPresenter _presentation;
        public SequenceAnalysisModule(IFindUpperCaseWords findUpperCaseWords,
            IPresenter presentation)
        {
            _findUpperCaseWords = findUpperCaseWords;
            _presentation = presentation;
        }

        public void Execute()
        {
            _presentation.ShowText("Informe a text");

            var stringContent = _presentation.FetchInput();
    
            var result = 
                _findUpperCaseWords
                .Handle(stringContent)
                .OrderBy();

            _presentation.ShowText($"Output: {result}");
        }
    }
}
