using Prism.Commands;
using Prism.Mvvm;

namespace PrismCourseApp.ViewModels
{
    public class DsPageViewModel : BindableBase
    {
        private readonly IPrismService _prismService;
        public DelegateCommand CallDsCmd { get; private set; }
        public DsPageViewModel(IPrismService prismService)
        {
            CallDsCmd = new DelegateCommand(CallDsAndroid);
            _prismService = prismService;
        }
        public void CallDsAndroid()
        {
            _prismService.CallDs("Hello from forms!");
        }
    }
}
